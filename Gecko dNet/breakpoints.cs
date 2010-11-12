using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using FTDIUSBGecko;

namespace GeckoApp
{
    public enum BreakpointComparison
    {
        Equal,
        NotEqual,
        Lower,
        LowerEqual,
        Greater,
        GreaterEqual,
    }

    public class BreakpointCondition
    {
        private int PRegister;
        private UInt32 PValue;
        private BreakpointComparison PCondition;
        public UInt32 GroupNumber;

        public int register
        {
            get
            {
                return PRegister;
            }
            set
            {
                if (value >= 0 && value < 73)
                    PRegister = value;
                else
                    PRegister = 0;
            }
        }
        public UInt32 value
        {
            get
            {
                return PValue;
            }
            set
            {
                PValue = value;
            }
        }
        public BreakpointComparison condition
        {
            get
            {
                return PCondition;
            }
            set
            {
                PCondition = condition;
            }
        }

        public BreakpointCondition(int register, UInt32 value,
            BreakpointComparison condition)
        {
            this.register = register;
            PValue = value;
            PCondition = condition;
            GroupNumber = 1;
        }

        public BreakpointCondition(int register, UInt32 value,
            BreakpointComparison condition, UInt32 groupNumber)
        {
            this.register = register;
            PValue = value;
            PCondition = condition;
            GroupNumber = groupNumber;
        }

        public bool Compare(Stream regStream, BreakpointType bpType, UInt32 bpAddress, USBGecko gecko)
        {
            if (regStream.Length != 0x120)
                return false;
            
            int spos = PRegister * 4;

            UInt32 val = 0;
            if (spos == 0x120) //Value of address is supposed to be checked
            {
                switch (bpType)
                {                    
                    case BreakpointType.Read:
                        val = gecko.peek(bpAddress);
                        break;
                    case BreakpointType.ReadWrite:
                    case BreakpointType.Write:
                        gecko.Step();
                        val = gecko.peek(bpAddress);
                        break;
                    default:
                        return true;
                }
            }
            else
            {
                regStream.Seek(spos, SeekOrigin.Begin);
                val = GlobalFunctions.ReadStream(regStream);
            }

            switch (PCondition)
            {
                case BreakpointComparison.Equal:
                    return (val == PValue);
                case BreakpointComparison.NotEqual:
                    return (val != PValue);
                case BreakpointComparison.Greater:
                    return (val > PValue);
                case BreakpointComparison.GreaterEqual:
                    return (val >= PValue);
                case BreakpointComparison.Lower:
                    return (val < PValue);
                case BreakpointComparison.LowerEqual:
                    return (val <= PValue);
            }

            return true;
        }

        public override String ToString()
        {
            String result = GroupNumber + ": ";
            if(PRegister >= BPList.longRegNames.Length)
                result += "VoA ";
            else
                result += BPList.longRegNames[PRegister].Trim() + " ";
            switch (PCondition)
            {
                case BreakpointComparison.Equal:
                    result += "=="; break;
                case BreakpointComparison.NotEqual:
                    result += "!="; break;
                case BreakpointComparison.Greater:
                    result += ">"; break;
                case BreakpointComparison.GreaterEqual:
                    result += ">="; break;
                case BreakpointComparison.Lower:
                    result += "<"; break;
                case BreakpointComparison.LowerEqual:
                    result += "<="; break;
            }
            result += " " + GlobalFunctions.toHex(PValue);
            return result;
        }

        public static BreakpointCondition FromString(String cond)
        {
            if (cond == String.Empty) return null;
            String[] sep = cond.Split(new char[] { ' ', ':' });
            int register = Convert.ToInt32(BPList.regTextToID(sep[2]));
            
            if (sep[2] == "VoA") register = BPList.longRegNames.Length;
            
            uint value;
            if (!(GlobalFunctions.tryToHex(sep[4], out value)))
            {
                return null;
            }
            uint group = Convert.ToUInt32(sep[0]);
            BreakpointComparison comp;
            switch (sep[3])
            {
                case "==":
                    comp = BreakpointComparison.Equal; break;
                case "!=":
                    comp = BreakpointComparison.NotEqual; break;
                case ">":
                    comp = BreakpointComparison.Greater; break;
                case ">=":
                    comp = BreakpointComparison.GreaterEqual; break;
                case "<":
                    comp = BreakpointComparison.Lower; break;
                case "<=":
                    comp = BreakpointComparison.LowerEqual; break;
                default:
                    comp = BreakpointComparison.Equal; break;
            }
            return new BreakpointCondition(register, value, comp, group);
        }
    }

    public class BreakpointConditions
    {
        private List<BreakpointCondition> PConditions;
        private ListBox PConditionList;
        public bool Enabled;

        public BreakpointConditions(ListBox conditionList)
        {
            PConditions = new List<BreakpointCondition>();
            PConditionList = conditionList;
            UpdateOutput();
            Enabled = true;
        }

        public void Add(BreakpointCondition condition)
        {
            PConditions.Add(condition);
            UpdateOutput();
        }

        public void Insert(int index, BreakpointCondition condition)
        {
            PConditions.Insert(index, condition);
            UpdateOutput();
        }

        public void Delete(int index)
        {
            PConditions.RemoveAt(index);
            UpdateOutput();
        }

        public UInt32 GetIndexedConditionGroup(int index)
        {
            return PConditions[index].GroupNumber;
        }

        public void SetIndexedConditionGroup(int index, UInt32 value)
        {
            PConditions[index].GroupNumber = value;
            UpdateOutput();
        }

        public bool Check(Stream regStream, BreakpointType bpType, UInt32 bpAddress, USBGecko gecko)
        {
            if (!Enabled)
                return true;
            if (PConditions.Count == 0)
                return true;
            if (regStream.Length != 0x120)
                return false;
            List<UInt32> groups = new List<uint>();

            // Fill it up with each groupNumber in the condition list
            foreach (BreakpointCondition cond in PConditions)
            {
                if (!groups.Contains(cond.GroupNumber))
                    groups.Add(cond.GroupNumber);
            }

            // If any condition fails, remove it's group number from the group
            foreach (BreakpointCondition cond in PConditions)
            {
                if (groups.Contains(cond.GroupNumber) && !cond.Compare(regStream, bpType, bpAddress, gecko))
                    groups.Remove(cond.GroupNumber);
            }

            // If there are any left, we succeeded!
            return (groups.Count != 0);
        }

        public void Clear()
        {
            PConditions.Clear();
            UpdateOutput();
        }

        public void UpdateOutput()
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < PConditionList.SelectedIndices.Count; i++)
            {
                indices.Add(PConditionList.SelectedIndices[i]);
            }
            PConditionList.Items.Clear();
            foreach (BreakpointCondition cond in PConditions)
            {
                PConditionList.Items.Add(cond.ToString());
            }
            foreach (int index in indices)
            {
                PConditionList.SelectedIndices.Add(index);
            }
        }
    }

    public enum BreakpointType
    {
        Read,
        Write,
        ReadWrite,
        Execute,
        Step
    }

    public enum ConditionalBranchState
    {
        NotConditional,
        Taken,
        NotTaken
    }

    public delegate void BreakpointStop(bool success);

    public delegate void BreakpointSkip(int skipCount);

    class Breakpoints
    {
        private USBGecko gecko;
        private BPList bpOutput;
        private MainForm mainForm;
        private RegisterDialog regDialog;
        private Disassembly disassembler;
        //private RichTextBox dissBox;
        private TextBox dissBox;
        private TextBox classicBox;

        private ExceptionHandler exceptionHandling;

        private bool cancelled;
        private bool BPSet;
        private bool BPHit;
        private bool bpExact;

        private UInt32 bpAddress;
        private BreakpointType bpType;
        private bool bpWait;

        private int PSkipCount;

        private bool listSet;
        private bool stepOverPossible;
        private UInt32 MemoryAccessAddress;
        private ConditionalBranchState branchState;
        private String[] currentInstruction;
        private String currentInstructionAndAddress;

        private int logIndent;

        public bool ShowFloatsInHex;

        public void ClearLogIndent()
        {
            logIndent = 0;
        }

        public void IncIndent()
        {
            logIndent++;
        }

        public void DecIndent()
        {
            if (logIndent > 0) logIndent--;
        }

        public ConditionalBranchState BranchState
        {
            get { return branchState; }
        }

        public UInt32 MemoryAddress
        {
            get { return MemoryAccessAddress; }
        }

        public bool stepOver
        {
            get { return stepOverPossible; }
        }

        private bool breakpointNext;

        public bool BreakpointNext
        {
            get { return breakpointNext; }
            set { breakpointNext = value; }
        }

        private UInt32 PHitAddress;
        public UInt32 hitAddress
        {
            get { return PHitAddress; }
        }

        private UInt32[] changableRegs;

        private BreakpointConditions PConditions;

        public BreakpointConditions conditions
        {
            get { return PConditions; }
        }

        private event BreakpointStop PBPStop;

        public event BreakpointStop BPStop
        {
            add
            {
                PBPStop += value;
            }
            remove
            {
                PBPStop -= value;
            }
        }

        private event BreakpointSkip PBPSkip;

        public event BreakpointSkip BPSkip
        {
            add
            {
                PBPSkip += value;
            }
            remove
            {
                PBPSkip -= value;
            }
        }

        public Breakpoints(USBGecko UGecko, BPList UBPOut, MainForm UMainForm, Disassembly UDissAss,
            //RichTextBox UDissBox, TextBox UClassicBox, ListBox conditionList, ExceptionHandler UExcHandler)
            TextBox UDissBox, TextBox UClassicBox, ListBox conditionList, ExceptionHandler UExcHandler)
        {
            exceptionHandling = UExcHandler;
            gecko = UGecko;
            bpOutput = UBPOut;
            mainForm = UMainForm;
            listSet = false;
            disassembler = UDissAss;
            dissBox = UDissBox;
            classicBox = UClassicBox;
            stepOverPossible = false;

            changableRegs = new UInt32[40];

            regDialog = new RegisterDialog();

            PConditions = new BreakpointConditions(conditionList);

            for (int i = 0; i < 40; i++)
            {
                bpOutput.shortRegTextBox[i].Click += clickReg;
            }

            ShowFloatsInHex = false;
        }

        private void SendRegisters()
        {
            MemoryStream ms = new MemoryStream();
            for (int i = 0; i < 40; i++)
            {
                GlobalFunctions.WriteStream(ms, changableRegs[i]);
            }
            try
            {
                gecko.SendRegisters(ms);
                ms.Close();

                GetRegisters();
            }
            catch (EUSBGeckoException e)
            {
                exceptionHandling.HandleException(e);
            }
        }

        private void clickReg(object sender, EventArgs e)
        {
            try
            {
                if (gecko.status() != WiiStatus.Breakpoint)
                    return;
            }
            catch (EUSBGeckoException ex)
            {
                exceptionHandling.HandleException(ex);
                return;
            }

            if (!listSet)
                return;

            int tag = int.Parse(((Control)sender).Tag.ToString());

            UInt32 value = changableRegs[tag];

            regDialog.TopMost = mainForm.TopMost;

            if (regDialog.SetRegister(bpOutput.shortRegNames[tag], ref value))
            {
                changableRegs[tag] = value;
                SendRegisters();
            }
        }

        public void GetRegisters()
        {
            MemoryStream regStream = new MemoryStream();
            try
            {
                gecko.GetRegisters(regStream);
                GetRegisters(regStream);
            }
            catch (EUSBGeckoException e)
            {
                regStream.Close();
                exceptionHandling.HandleException(e);
            }
        }

        private void GetRegisters(Stream regStream)
        {
            regStream.Seek(0, SeekOrigin.Begin);
            String regValue;
            UInt32 rStream;
            UInt32[] allReg = new UInt32[72];
            for (int i = 0; i < 72; i++)
            {
                rStream = GlobalFunctions.ReadStream(regStream);

                if (i < 40)
                {
                    changableRegs[i] = rStream;
                }
                allReg[i] = rStream;

                if (i < 40 || ShowFloatsInHex)
                {
                    regValue = GlobalFunctions.toHex(rStream);
                }
                else
                {
                    regValue = GlobalFunctions.UIntToSingle(rStream).ToString("G8");
                }
                bpOutput.longRegTextBox[i].Text = regValue; // TODO: invoke required?
            }
            listSet = true;
            regStream.Close();

            String output = "";
            for (int i = 0; i < 72; i++)
            {
                output += BPList.longRegNames[bpOutput.longRegIDs[i]] + ":" +
                        GlobalFunctions.toHex(allReg[bpOutput.longRegIDs[i]]);
                if (i % 4 == 3 && i != 71)
                    output += "\r\n";
                else if (i % 4 != 3)
                    output += " ";

                if (i == 39)
                    output += "\r\n";
            }

            InvokeClassicTextBoxUpdate(output);

            // Make sure that (SRR0?) contains a valid address
            // Otherwise we might not be pointing at any valid memory to pass to disassemble
            if (ValidMemory.validAddress(changableRegs[5]))
            {
                UInt32 assAdd = changableRegs[5];
                PHitAddress = assAdd;   // cache this for later

                // Fill an array of strings with instructions
                // TODO: subtract back some so we can see what comes BEFORE the assembly address...
                String[] assembly = disassembler.DissToBox(assAdd);

                // Grab the first (i.e. current) instruction
                if (assembly.Length > 0)
                {
                    String fCommand = assembly[0];
                    currentInstructionAndAddress = fCommand;
                    fCommand = fCommand.Substring(20, fCommand.Length - 20);

                    // Split it along tabs so we can extract the operation
                    String[] sep = fCommand.Split(new char[1] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    currentInstruction = sep;
                    fCommand = sep[0].ToLower();

                    // If we're doing a branch-and-link, make a note that we can step over it
                    stepOverPossible = (fCommand == "bl" || fCommand == "bctrl");

                    GetMemoryAddress(sep);

                    UpdateBranchState(sep);
                }

                InvokeDissBoxUpdate(assembly);
            }
        }

        private void InvokeDissBoxUpdate(String[] assembly)
        {
            // Make sure this assignment is carried out on the main thread,
            // where it has permission to modify the form's controls
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke((MethodInvoker)delegate
                {
                    dissBox.Lines = assembly;
                    mainForm.ScrollBPDissToLine(3);
                });
            }
            else
            {
                dissBox.Lines = assembly;
                mainForm.ScrollBPDissToLine(3);
            }
        }

        private void InvokeClassicTextBoxUpdate(String output)
        {
            if (classicBox.InvokeRequired)
            {
                classicBox.Invoke((MethodInvoker)delegate
                {
                    classicBox.Text = output;
                });
            }
            else
            {
                classicBox.Text = output;
            }
        }

        private void UpdateBranchState(String[] sep)
        {
            if (isConditionalBranch(sep))
            {
                if (BranchTaken(sep))
                {
                    branchState = ConditionalBranchState.Taken;
                }
                else
                {
                    branchState = ConditionalBranchState.NotTaken;
                }
            }
            else
            {
                branchState = ConditionalBranchState.NotConditional;
            }
        }

        public void BranchToggle()
        {
            if (currentInstruction.Length == 1) return;

            bool taken = BranchTaken(currentInstruction);

            // Remove the branch hint
            string branchCommand = currentInstruction[0].ToLower().Trim(new char[2] { '+', '-' });

            uint CR = changableRegs[0];
            switch (branchCommand)
            {
                case "ble": CR = taken ? (CR & (~0xA0000000)) : (CR | 0xA0000000); break;
                case "blt": CR = taken ? (CR & (~(uint)0x80000000)) : (CR | 0x80000000); break;
                case "bge": CR = taken ? (CR & (~(uint)0x60000000)) : (CR | 0x60000000); break;
                case "bgt": CR = taken ? (CR & (~(uint)0x40000000)) : (CR | 0x40000000); break;
                case "beq": CR = taken ? (CR & (~(uint)0x20000000)) : (CR | 0x20000000); break;
                case "bne": CR = taken ? (CR | 0x20000000) : (CR & (~(uint)0x20000000)); break;
                default: break;
            }
            changableRegs[0] = CR;
            SendRegisters();
            UpdateBranchState(currentInstruction);
        }


        private bool BranchTaken(String[] splitted)
        {
            // TODO: add bdnz etc
            if (splitted.Length == 1)
            {
                // if it's not a conditional blr, return false
                if (!Regex.Match(splitted[0], "^b..lr").Success)
                {
                    return false;
                }
            }

            // Remove the branch hint
            string command = splitted[0].ToLower().Trim(new char[2] { '+', '-' });

            command = Regex.Replace(command, "lr$", String.Empty);

            if (command == "ble")
            {
                return (changableRegs[0] & 0xA0000000) != 0;
            }
            else if (command == "blt")
            {
                return (changableRegs[0] & 0x80000000) != 0;
            }
            else if (command == "bge")
            {
                return (changableRegs[0] & 0x60000000) != 0;
            }
            else if (command == "bgt")
            {
                return (changableRegs[0] & 0x40000000) != 0;
            }
            else if (command == "beq")
            {
                return (changableRegs[0] & 0x20000000) != 0;
            }
            else if (command == "bne")
            {
                return (changableRegs[0] & 0x20000000) == 0;
            }

            return false;
        }

        private bool isConditionalBranch(String[] splitted)
        {
            string command = splitted[0].ToLower().Trim(new char[2] { '+', '-' });
            switch (command)
            {
                    // TODO: bdnz, b..lr, etc
                case "ble":
                case "blt":
                case "bge":
                case "bgt":
                case "beq":
                case "bne":
                    return true;
                default: return false;
            }
        }

        private void GetMemoryAddress(String[] splitted)
        {
            if (splitted.Length == 1) return;
            string command = splitted[0].ToLower();

            // If we're doing a load or store, calculate the address
            bool indexed = Regex.Match(command, "x$").Success;
            command = Regex.Replace(command, "x$", String.Empty);
            command = Regex.Replace(command, "u$", String.Empty);
            switch (command)
            {
                case "stw":
                case "lwz":
                case "sth":
                case "lhz":
                case "stb":
                case "lbz":
                case "stmw":
                case "lmw":
                case "stfs":
                case "lfs":
                case "stfd":
                case "lfd":
                case "psq_st":
                case "psq_l":
                case "lha":
                case "sthbr":
                case "lhbr":
                case "stwbr":
                case "lwbr":
                case "stsw":
                case "lsw":
                case "stswi":
                case "lswi":
                    String[] sep2 = splitted[1].Split(new char[3] { ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    int offset;
                    uint pointer;
                    if (indexed)
                    {
                        offset = (int)(changableRegs[Convert.ToUInt32(sep2[2].Substring(1)) + 7]);
                        pointer = changableRegs[Convert.ToUInt32(sep2[1].Substring(1)) + 7];
                    }
                    else
                    {
                        offset = Convert.ToInt32(sep2[1]);
                        pointer = changableRegs[Convert.ToUInt32(sep2[2].Substring(1)) + 7];
                    }
                    //int offset = indexed ? Convert.ToInt32(sep2[1]) : Convert.ToInt32(sep2[1]);
                    MemoryAccessAddress = (uint)(pointer + offset);
                    break;
                default: MemoryAccessAddress = 0; break;
            }

        }

        private void WaitForBreakpoint()
        {
            //WiiStatus status;
            BPHit = false;
            try
            {
                while (!cancelled && !BPHit)
                {
                    Thread.Sleep(100);          // Why 100 ms?
                    //status = gecko.status();
                    if (gecko.BreakpointHit())
                    {
                        BPSet = false;
                        BPHit = true;
                        //status = gecko.status();
                    }
                }
                gecko.CancelBreakpoint();
                //gecko.status();

                if (BPHit)
                {
                    MemoryStream regStream = new MemoryStream();
                    gecko.GetRegisters(regStream);

                    if (!conditions.Check(regStream, bpType, bpAddress, gecko))
                    {
                        PSkipCount++;
                        InvokeSkip();
                        regStream.Close();
                        regStream.Dispose();
                        SetActualBP();
                        WaitForBreakpoint();    // WARNING: RECURSION
                        return;
                    }

                    cancelled = true;

                    InvokeGetRegisters(regStream);
                }

                if (PBPStop != null)
                {
                    InvokePBPStop();
                }
            }
            catch (EUSBGeckoException e)
            {
                if (PBPStop != null)
                {
                    InvokePBPStop();
                }
                exceptionHandling.HandleException(e);
            }
        }

        private void InvokePBPStop()
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke((MethodInvoker)delegate
                {
                    PBPStop(BPHit);
                });
            }
            else
                PBPStop(BPHit);
        }

        private void InvokeGetRegisters(MemoryStream regStream)
        {
            if (bpOutput.InvokeRequired)
            {
                bpOutput.Invoke((MethodInvoker)delegate
                {
                    GetRegisters(regStream);
                });
            }
            else
                GetRegisters(regStream);
        }

        // Wrap Invoke in a function so that way we can Edit and Continue
        private void InvokeSkip()
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke((MethodInvoker)delegate
                {
                    PBPSkip(PSkipCount);
                });
            }
            else
                PBPSkip(PSkipCount);
        }

        private void SetActualBP()
        {
            switch (bpType)
            {
                case BreakpointType.Read:
                    gecko.BreakpointR(bpAddress, bpExact);
                    break;
                case BreakpointType.Write:
                    gecko.BreakpointW(bpAddress, bpExact);
                    break;
                case BreakpointType.ReadWrite:
                    gecko.BreakpointRW(bpAddress, bpExact);
                    break;
                case BreakpointType.Execute:
                    gecko.BreakpointX(bpAddress);
                    break;
                default:
                    gecko.Step();
                    break;
            }
            BPSet = true;
            gecko.Resume();
            //if (!wait)
            //    return true;
            listSet = false;
        }

        public bool SetBreakpoint(UInt32 address, BreakpointType type, bool exact, bool wait)
        {
            try
            {
                bpType = type;
                bpAddress = address;
                bpWait = wait;
                bpExact = exact;
                PSkipCount = 0;
                cancelled = false;
                SetActualBP();
                if (!bpWait)
                    return true;
                Thread waitThread = new Thread(WaitForBreakpoint);
                waitThread.Start();
                return true;
            }
            catch (EUSBGeckoException e)
            {
                exceptionHandling.HandleException(e);
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool SetBreakpoint(UInt32 address, BreakpointType type, bool exact)
        {
            return SetBreakpoint(address, type, exact, true);
        }

        public void CancelBreakpoint()
        {
            try
            {
                if (BPSet)
                {
                    cancelled = true;
                    gecko.CancelBreakpoint();
                    BPSet = false;

                    // The breakpoint will still be hit after being canceled
                    // So we set a breakpoint that could never ever be hit
                    //Thread.Sleep(100);
                    //Application.DoEvents();
                    ////SetBreakpoint(0x817FFFF0, BreakpointType.Execute, true);
                    //Thread.Sleep(100);
                    //Application.DoEvents();
                    //cancelled = true;
                    ////gecko.CancelBreakpoint();
                    //BPSet = false;
                }
            }
            catch (EUSBGeckoException e)
            {
                BPSet = false;
                exceptionHandling.HandleException(e);
            }
        }

        public bool IsBLR()
        {
            if (Regex.Match(currentInstruction[0], "^blr$").Success)
            {
                return true;
            }
            if (Regex.Match(currentInstruction[0], "^b..lr").Success && BranchTaken(currentInstruction))
            {
                return true;
            }
            return false;
        }

        public bool IsBL()
        {
            if (Regex.Match(currentInstruction[0], "^bl$|^bctrl$").Success)
            {
                return true;
            }
            return false;
        }

        public UInt32 GetRegisterValue(int regIndex)
        {
            if (regIndex >= BPList.longRegNames.Length)
                return 0;
            uint foo = 0;
            GlobalFunctions.tryToHex(bpOutput.longRegTextBox[regIndex].Text, out foo);
            return foo;
        }

        public Single GetFloatRegisterValue(int regIndex)
        {
            Single foo = 0;
            foo = Single.Parse(bpOutput.longRegTextBox[regIndex].Text);
            return foo;
        }

        public String GetStepLog()
        {
            String DetailedInstruction = currentInstructionAndAddress;
            String regDetails;
            MatchCollection getRegDetails;

            if (currentInstructionAndAddress == null) return String.Empty;

            String[] Padding = DetailedInstruction.Split('\t');

            // this will help align things
            if (Padding.Length < 3)
            {
                DetailedInstruction += "        ";
            }
            else if (Padding[2].Length < 8)
            {
                for (int i = 8 - Padding[2].Length; i > 0; i--)
                {
                    DetailedInstruction += " ";
                }
            }

            // Get all the places where there's an LR
            getRegDetails = Regex.Matches(DetailedInstruction, "lr");

            for (int i = 0; i < getRegDetails.Count; i++)
            {
                regDetails = "LR = " + GlobalFunctions.toHex(GetRegisterValue(39));
                //DetailedInstruction = DetailedInstruction.Insert(getRegDetails[i].Index + getRegDetails[i].Length, regDetails);
                DetailedInstruction += "\t" + regDetails;
            }

            // Get all the places where there's an f0-f31
            // TODO: not 0-9 or a-f!
            // TODO: over matching?  switch to trying to find the 0x to determine when not a float reg?
            //getRegDetails = Regex.Matches(DetailedInstruction, "([^0-9]f[0-9][^0-9])|" +
            //                                                  "([^0-9]f1[0-9][^0-9])|" +
            //                                                  "([^0-9]f2[0-9][^0-9])|" +
            //                                                  "([^0-9]f3[01][^0-9])");

            if (!Regex.Match(DetailedInstruction, "0x").Success)
            {
                getRegDetails = Regex.Matches(DetailedInstruction, "f[0-9]+");

                for (int i = 0; i < getRegDetails.Count; i++)
                {
                    string floatReg = getRegDetails[i].Value;
                    int index = Int32.Parse(floatReg.Substring(1)) + 40;
                    Single floatVal = GetFloatRegisterValue(index);
                    regDetails = floatReg + " = " + floatVal.ToString("G6");
                    //DetailedInstruction = DetailedInstruction.Insert(getRegDetails[i].Index + getRegDetails[i].Length, regDetails);
                    DetailedInstruction += "\t" + regDetails;
                }
            }

            // Get all the places where there's an r0-r31
            getRegDetails = Regex.Matches(DetailedInstruction, "r[0-9]+");

            for (int i = 0; i < getRegDetails.Count; i++)
            {
                regDetails = getRegDetails[i].Value + " = " + GlobalFunctions.toHex(GetRegisterValue(Int32.Parse(getRegDetails[i].Value.Substring(1)) + 7));
                //DetailedInstruction = DetailedInstruction.Insert(getRegDetails[i].Index + getRegDetails[i].Length, regDetails);
                DetailedInstruction += "\t" + regDetails;
            }

            getRegDetails = Regex.Matches(DetailedInstruction, "\\(r[0-9]+\\)");

            for (int i = 0; i < getRegDetails.Count; i++)
            {
                if (ValidMemory.validAddress(MemoryAddress))
                {
                    regDetails = "[" + GlobalFunctions.toHex(MemoryAddress) + "] = " + GlobalFunctions.toHex(gecko.peek(MemoryAddress));
                    //DetailedInstruction = DetailedInstruction.Insert(getRegDetails[i].Index + getRegDetails[i].Length, regDetails);
                    if (Regex.Match(DetailedInstruction, "lfd|stfd").Success)
                    {
                        regDetails += GlobalFunctions.toHex(gecko.peek(MemoryAddress+4));
                    }
                    DetailedInstruction += "\t" + regDetails;
                }
            }

            //if (IsTakenBranch())
            if ((isConditionalBranch(currentInstruction) && BranchTaken(currentInstruction)) || currentInstruction[0]=="b")
            {
                DetailedInstruction += "\r\n";
                for (int i = 0; i < logIndent; i++)
                {
                    DetailedInstruction += "|  ";
                }
                DetailedInstruction += "\t...\t...\t...\t...";
            }

            if (logIndent > 0)
            {
                for (int i = 0; i < logIndent; i++)
                {
                    DetailedInstruction = DetailedInstruction.Insert(0, "|  ");
                }
            }

            if (IsBL())
            {
                logIndent++;
            }

            if (logIndent > 0 && IsBLR())
            {
                logIndent--;
            }

            return DetailedInstruction;
        }

        public void SetSRR0(UInt32 address)
        {
            if (gecko.status() != WiiStatus.Breakpoint)
                return;
            if (ValidMemory.rangeCheck(address) != AddressType.UncachedMem1)
                return;


            changableRegs[BPList.regTextToID("SRR0")] = address;
            SendRegisters();
        }

        //public bool IsTakenBranch()
        //{
        //    return (isConditionalBranch(currentInstruction) && BranchTaken(currentInstruction)) || currentInstruction[0]=="b");
        //}
    }
}
