using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

using FTDIUSBGecko;

namespace GeckoApp
{
    public enum MemoryViewMode
    {
        Hex,
        ASCII,
        ANSI,
        Unicode,
        Single,
        AutoZero,
        AutoDot
    }

    class MemoryViewer
    {
        private USBGecko gecko;
        private DataGridView gView;
        private TextBox pokeAddress;
        private TextBox pokeValue;
        private Label fpValue;
        private UInt32 cAddress;
        private UInt32 selAddress;
        private MemoryViewMode PViewMode;
        private bool searching;

        private ExceptionHandler exceptionHandling;

        private int oldCol = 1;
        private int oldRow = 0;

        public UInt32 address
        {
            get
            {
                return cAddress;
            }
            set
            {
                cAddress = value & 0xFFFFFFFC;
                // TODO: handle changing memViewAValue and updating the memory view
                // so clients can just change the address
            }
        }

        public UInt32 selectedAddress
        {
            // TODO: handle changing poke box 
            get
            {
                return selAddress;
            }
        }


        public MemoryViewMode viewMode
        {
            get
            {
                return PViewMode;
            }
            set
            {
                PViewMode = value;
            }
        }

        public bool Searching
        {
            get { return searching; }
            set { searching = value; }
        }

        public MemoryViewer(USBGecko UGecko, UInt32 initAddress,DataGridView UGView,
            TextBox UPokeAddress,TextBox UPokeValue,Label UFPValue, ExceptionHandler UExpHandler)
        {
            gecko = UGecko;
            exceptionHandling = UExpHandler;

            cAddress = initAddress;
            gView = UGView;
            pokeAddress = UPokeAddress;
            pokeValue = UPokeValue;
            fpValue = UFPValue;
            gView.CellClick += CellClick;
            gView.SelectionChanged += CellSelectionChange;
        }

        private UInt32 ReadStream(Stream input)
        {
            Byte[] buffer = new Byte[4];
            input.Read(buffer, 0, 4);
            return (UInt32)ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0));
        }

        public void Update()
        {
            // We can do a slow update by default
            // But during auto-update we want to be faster
            Update(false);
        }

        public void Update(bool fast)
        {
            MemoryStream miniDump = new MemoryStream();
            int oldColumnIndex, oldRowIndex;
            if (gView.SelectedCells.Count > 0)
            {
                oldColumnIndex = gView.SelectedCells[0].ColumnIndex;
                oldRowIndex = gView.SelectedCells[0].RowIndex;
            }
            else
            {
                oldColumnIndex = 1;
                oldRowIndex = 1;
            }
            
            UInt32 sAddress = cAddress & 0xFFFFFFF0;
            UInt32 offset = cAddress - sAddress;
            try
            {
                gecko.Dump(sAddress, sAddress + 0x100, miniDump);

                //gView.Rows.Add(16);
                // Only clear and re-load gView.Rows when it's != 16
                // This was one thing slowing us down...
                if (gView.Rows.Count != 16)
                {
                    gView.Rows.Clear();
                    gView.Rows.Add(16);
                }
                
                miniDump.Seek(0, SeekOrigin.Begin);
                UInt32 value, bValue;
                Byte[] buffer = new Byte[4];
                UInt16 hwInput;
                UInt32 pValue = 0;
                for (int i = 0; i < 16; i++)
                {
                    gView.Rows[i].Cells[0].Value = GlobalFunctions.toHex(sAddress + i * 16);
                    for (int j = 1; j < 5; j++)
                    {
                        miniDump.Read(buffer, 0, 4);
                        bValue = BitConverter.ToUInt32(buffer, 0);
                        value = ByteSwap.Swap(bValue);
                        if (sAddress + i * 0x10 + (j - 1) * 4 == selAddress)
                            pValue = value;
                        DataGridViewCell cell = gView.Rows[i].Cells[j];
                        if (PViewMode == MemoryViewMode.Hex)
                        {
                            cell.Value = GlobalFunctions.toHex(value);
                        }
                        else if (PViewMode == MemoryViewMode.ASCII)
                        {
                            cell.Value = DecodeASCII(buffer);
                        }
                        else if (PViewMode == MemoryViewMode.ANSI)
                        {
                            cell.Value = DecodeANSI(buffer);
                        }
                        else if (PViewMode == MemoryViewMode.Unicode)
                        {
                            cell.Value = DecodeUnicode(buffer);
                        }
                        else if (PViewMode == MemoryViewMode.Single)
                        {
                            cell.Value = PrettyFloat(GlobalFunctions.UIntToSingle(value));
                        }
                        else if (PViewMode == MemoryViewMode.AutoZero || PViewMode == MemoryViewMode.AutoDot)
                        {
                            // if it might be a pointer, cast it as hex
                            if (ValidMemory.validAddress(value))
                            {
                                cell.Value = GlobalFunctions.toHex(value);
                            }
                            else
                            {
                                // If it's a float, and it's not too big or small, cast it as a Single
                                Single singleCast = GlobalFunctions.UIntToSingle(value);
                                if (!Single.IsNaN(singleCast) && Math.Abs(singleCast) > 1e-7 && Math.Abs(singleCast) < 1e10)
                                {
                                    cell.Value = PrettyFloat(GlobalFunctions.UIntToSingle(value));
                                }
                                else
                                {
                                    if (IsASCII(buffer))
                                    {
                                        if (PViewMode == MemoryViewMode.AutoZero && value == 0)
                                        {
                                            // Cast 0 as hex in auto zero mode
                                            cell.Value = GlobalFunctions.toHex(value);
                                        }
                                        else
                                        {
                                            // If all characters are valid printable ASCII, cast it as char
                                            cell.Value = DecodeASCII(buffer);
                                        }
                                    }
                                    else
                                    {
                                        // When all else fails, cast as hex
                                        cell.Value = GlobalFunctions.toHex(value);
                                    }
                                }
                            }
                        }
                    }
                }
                oldRow = (int)offset / 0x10;
                oldCol = (int)(offset & 0xC) / 4 + 1;
                if (!fast)
                {
                    gView.Rows[oldRowIndex].Cells[oldColumnIndex].Selected = true;
                    // Don't update the poke value during auto-updates
                    // This way the user can still poke things

                    // TODO: Ignore this if the poke operation isn't write?
                    //pokeValue.Text = GlobalFunctions.toHex(pValue);
                }

                pokeAddress.Text = GlobalFunctions.toHex(selAddress);
                fpValue.Text = GlobalFunctions.UIntToSingle(pValue).ToString("G6");
            }
            catch (EUSBGeckoException e)
            {
                exceptionHandling.HandleException(e);
            }
        }

        private String PrettyFloat(Single val)
        {
            String floatString = val.ToString("G6");
            if (floatString.Length > 8)
            {
                return val.ToString("G2");
            }
            else
            {
                return floatString;
            }
        }

        private static String DecodeUnicode(Byte[] buffer)
        {
            String cellV = "";
            for (int k = 0; k < 2; k++)
            {
                UInt16 hwInput = (UInt16)(buffer[k * 2] << 8 + buffer[k * 2 + 1]);
                if (hwInput > 0x20 && hwInput != 0x7F)
                    cellV += "   " + (char)hwInput;
                else
                    cellV += "   .";
            }
            return cellV;
        }

        private static bool IsASCII(Byte[] buffer)
        {
            for (int k = 0; k < 4; k++)
            {
                if ((buffer[k] != 0) && (buffer[k] < 0x20 || buffer[k] > 0x7E)) return false;
            }
            return true;
        }

        private static String DecodeASCII(Byte[] buffer)
        {
            String cellV = "";
            for (int k = 0; k < 4; k++)
            {
                Byte bInput = buffer[k];
                if (bInput > 0x20 && bInput < 0x7F)
                    cellV += " " + (char)bInput;
                else
                    cellV += " .";
            }
            return cellV;
        }

        private static String DecodeANSI(Byte[] buffer)
        {
            String cellV = "";
            for (int k = 0; k < 4; k++)
            {
                Byte bInput = buffer[k];
                if (bInput > 0x20 && bInput != 0x7F)
                    cellV += " " + (char)bInput;
                else
                    cellV += " .";
            }
            return cellV;
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }


        private void CellSelectionChange(object sender, EventArgs e)
        {
            UInt32 sAddress = cAddress & 0xFFFFFFF0;
            if (gView.SelectedCells.Count > 0)
            {
                int col = gView.SelectedCells[0].ColumnIndex;
                int row = gView.SelectedCells[0].RowIndex;
                if (col == 0)
                {
                    gView.Rows[oldRow].Cells[oldCol].Selected = true;
                }
                else
                {
                    oldCol = col;
                    oldRow = row;
                    UInt32 addr = (UInt32)(sAddress + row * 16 + (col - 1) * 4);

                    // Nothing to update if the address didn't change
                    if (selAddress == addr) return;

                    selAddress = addr;
                    pokeAddress.Text = GlobalFunctions.toHex(addr);
                    try
                    {
                        UInt32 locValue = gecko.peek(addr);
                        pokeValue.Text = GlobalFunctions.toHex(locValue);
                        fpValue.Text = GlobalFunctions.UIntToSingle(locValue).ToString("G6");
                    }
                    catch (EUSBGeckoException exc)
                    {
                        exceptionHandling.HandleException(exc);
                    }
                }
            }
        }

        public void SearchString(byte[] searchBytes, bool caseSensitive, bool unicode, bool hex)
        //public void SearchString(String sString, bool caseSensitive, bool unicode)
        {
            byte[] stringBytes = searchBytes;
            
            UInt32 startAddr = selAddress + 4;

            UInt32 endAddress = 0;

            int dumpLength = (unicode ? 2:1);
            
            bool found = false;
            for (int i = 0; i < ValidMemory.ValidAreas.Length; i++)
            {
                if (startAddr >= ValidMemory.ValidAreas[i].low &&
                    startAddr < ValidMemory.ValidAreas[i].high)
                {
                    found = true;
                    endAddress = ValidMemory.ValidAreas[i].high;
                    break;
                }
            }

            if (!found)
            {
                throw new Exception("Memory area could not be acquired!");
            }

            bool valueFound = false;
            int inpos = 0;

            UInt32 beginAddress = startAddr;

            MemoryStream ms = new MemoryStream();
            long streamPos = 0;
            UInt32 cVal;
            char cChar;

            UInt32 SearchBufferSize = 0xF800 * 8;   // F800 is the packet size in USBGecko.cs

            UInt32 dumpHigh = Math.Min(startAddr + SearchBufferSize, endAddress);     

            try
            {
                int index;

                do
                {
                    ms.Seek(0, SeekOrigin.End);
                    int startIndex = (int)ms.Position;
                    gecko.Dump(startAddr, dumpHigh, ms);

                    byte[] streamArray = ms.GetBuffer();

                    index = GlobalFunctions.IndexOfByteArray(streamArray, stringBytes, startIndex, caseSensitive);

                    if (index != -1)
                    {
                        valueFound = true;
                        break;
                    }

                    startAddr = dumpHigh;
                    dumpHigh = Math.Min(startAddr + SearchBufferSize, endAddress);
                    Application.DoEvents();     // check for cancel search
                } while (dumpHigh != endAddress && !valueFound && searching);

                if (valueFound)
                {
                    UInt32 address = (UInt32)(beginAddress + index);
                    cAddress = address;
                }
                else
                {
                    // hack to fix the jumping disassembly window
                    cAddress = beginAddress - 4;
                    if (dumpHigh == endAddress)
                        MessageBox.Show("Could not find search query");
                }
            }
            catch (EUSBGeckoException exc)
            {
                exceptionHandling.HandleException(exc);
            }
        }
    }
}
