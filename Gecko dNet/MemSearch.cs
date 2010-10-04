using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;

using FTDIUSBGecko;

namespace GeckoApp
{
    public enum SearchSize
    {
        Bit8,
        Bit16,
        Bit32,
        Single
    }

    public enum SearchType
    {
        Exact,
        Unknown,
        Old,
        Diff
    }

    public enum ComparisonType
    {
        Equal,
        NotEqual,
        Lower,
        LowerEqual,
        Greater,
        GreaterEqual,
        DifferentBy,
        DifferentByLess,
        DifferentByMore
    }

    public class SearchComparisonInfo
    {
        public ComparisonType comparisonType;
        public UInt32 value;
        public SearchType searchType;

        public SearchComparisonInfo()
        {
            comparisonType = ComparisonType.Equal;
            value = 0;
            searchType = SearchType.Exact;
        }

        public SearchComparisonInfo(ComparisonType ctype, UInt32 searchValue, SearchType stype)
        {
            comparisonType = ctype;
            value = searchValue;
            searchType = stype;
        }
    }

    [Serializable()]
    public class SearchResult 
    {
        private UInt32 PAddress;
        private UInt32 PValue;
        private UInt32 POldValue;

        public UInt32 address { get { return PAddress; } }
        public UInt32 value { get { return PValue; } }
        public UInt32 oldValue { get { return POldValue; } }

        public SearchResult(UInt32 address,UInt32 value,UInt32 old) 
        {
            PAddress = address;
            PValue = value;
            POldValue = old;
        }
    }

    public class DumpRange
    {
        public UInt32 rangeLength;
        public UInt32 streamOffset;

        private UInt32 PStartAddress;
        private UInt32 PEndAddress;

        public UInt32 startAddress 
        { 
            get 
            { 
                return PStartAddress; 
            }
            set
            {
                PStartAddress = value;
            }
        }
        public UInt32 endAddress { 
            get 
            { 
                return PEndAddress; 
            }
            set
            {
                PEndAddress = value;
            }
        }

        public DumpRange()
        {
        }

        public DumpRange(UInt32 startAddress)
        {
            PStartAddress = startAddress;
        }

        public DumpRange(UInt32 startAddress, UInt32 endAddress)
        {
            PStartAddress = startAddress;
            PEndAddress = endAddress;
        }
    }

    public struct StringResult
    {
        public String SAddress;
        public String SValue;
        public String SOldValue;
    }
    
    public class MemSearch
    {
        const int pageSize = 256;

        //private List<SearchResult> resList;
        private List<UInt32> resultAddressList;
        private SearchSize sSize;
        private int cPage;
        private int cPages;
        private int oldSelectedRow;
        private bool InitialSearch;

        public SearchSize searchSize
            { get { return sSize; } }
        
        private bool UnknownStart;
        private UInt32 UnknownLAddress;
        private UInt32 UnknownHAddress;

        private USBGecko gecko;
        private DataGridView gView;
        private Button prvButton;
        private Button nxButton;
        private Label resLab;
        private NumericUpDown pageUpDown;

        private MemoryStream orgStream;
        private MemoryStream cmpStream;
        public Dump oldDump;
        public Dump newDump;
        private Dump undoDump;
        private List<UInt32> undoList;
        private int dumpNum;
        public int DumpNum
        {
            get { return dumpNum; }
        }
        private SearchHistoryManager searchHistory;

        private bool NewSearch = true;

        private ExceptionHandler exceptionHandling;

        private bool PBlockDump;
        private UInt32 PTotalBlockSize;
        private UInt32 PBlocksDumpedSize;
        private int PBlockID;
        private int PBlockCount;
        private UInt32 PBlockStart;
        private UInt32 PBlockEnd;
        private String displayType;
        public String DisplayType
        {
            get { return displayType; }
            set { displayType = value; }
        }
        public bool blockDump
        { get { return PBlockDump; } }
        public UInt32 totalBlockSize
        { get { return PTotalBlockSize; } }
        public UInt32 blocksDumpedSize
        { get { return PBlocksDumpedSize; } }
        public int blockID
        { get { return PBlockID; } }
        public int blockCount
        { get { return PBlockCount; } }
        public UInt32 blockStart
        { get { return PBlockStart; } }
        public UInt32 blockEnd
        { get { return PBlockEnd; } }
        

        public MemSearch(USBGecko uGecko,DataGridView uGView,Button uPrvButton,Button uNxButton,
            Label UResLab, NumericUpDown UPageUpDown, ExceptionHandler UEHandler)
        {
            exceptionHandling = UEHandler;

            gecko = uGecko;
            gView = uGView;

            prvButton = uPrvButton;
            nxButton = uNxButton;
            resLab = UResLab;
            pageUpDown = UPageUpDown;

            pageUpDown.ValueChanged += UpDownValueChanged;
            nxButton.Click += nextPage;
            prvButton.Click += previousPage;

            //resList = new List<SearchResult>();
            resultAddressList = new List<uint>();
            undoList = new List<uint>();

            PBlockDump = false;

            dumpNum = 0;

            searchHistory = new SearchHistoryManager();

        }

        void UpDownValueChanged(object sender, EventArgs e)
        {
            cPage = Convert.ToInt32(pageUpDown.Value) - 1;
            PrintPageAlt();
        }

        //private void PrintPage()
        //{
        //    // Make sure we don't go before the first page...
        //    if (cPage <= 0)
        //    {
        //        cPage = 0;
        //        prvButton.Enabled = false;
        //    }
        //    else
        //    {
        //        // Only enable previous button if current page is > 0
        //        prvButton.Enabled = true;
        //    }

        //    // ...or after the last page
        //    if (cPage >= cPages - 1)
        //    {
        //        cPage = cPages - 1;
        //        if (cPage < 0) cPage = 0;
        //        nxButton.Enabled = false;
        //    }
        //    else
        //    {
        //        // Only enable next button if there are multiple pages and we aren't on the last page
        //        nxButton.Enabled = (cPages > 1);
        //    }

        //    resLab.Text = resList.Count.ToString() + " results (page "
        //     + (cPage + 1).ToString() + "/"
        //     + cPages.ToString() + ")";

        //    int i = 0;
        //    String addr, value, oldv, diff;

        //    int strLength;
        //    switch (sSize)
        //    {
        //        case SearchSize.Bit8: strLength = 2; break;
        //        case SearchSize.Bit16: strLength = 4; break;
        //        default: strLength = 8; break;
        //    }

        //    //gView.Rows.Clear();
        //    int start = cPage * pageSize;
        //    int end = Math.Min(cPage * pageSize + pageSize, resList.Count);
        //    int count = end - start;
        //    if (count < gView.Rows.Count)
        //    {
        //        gView.Rows.Clear();
        //    }
        //    int addCount = count - gView.Rows.Count;
        //    if (addCount > 0)
        //    {
        //        gView.Rows.Add(addCount);
        //    }

        //    for (int j = start; j < end; j++)
        //    {
        //        SearchResult result = resList[j];

        //        addr = fixString(Convert.ToString(result.address, 16).ToUpper(), 8);
        //        if (displayType == "Hex")
        //        {
        //            value = fixString(Convert.ToString(result.value, 16).ToUpper(), strLength);
        //            oldv = fixString(Convert.ToString(result.oldValue, 16).ToUpper(), strLength);
        //            diff = fixString(Convert.ToString(result.value - result.oldValue, 16).ToUpper(), strLength);
        //        }
        //        else if (displayType == "Dec")
        //        {
        //            value = ((int)result.value).ToString();
        //            oldv = ((int)result.oldValue).ToString();
        //            diff = ((int)(result.value - result.oldValue)).ToString();
        //        }
        //        else
        //        {
        //            value = GlobalFunctions.UIntToSingle(result.value).ToString("g5");
        //            oldv = GlobalFunctions.UIntToSingle(result.oldValue).ToString("g5");
        //            diff = GlobalFunctions.UIntToSingle(result.value - result.oldValue).ToString("g5");
        //        }
        //        gView.Rows[i].Cells[0].Value = addr;
        //        if (!InitialSearch)
        //        {
        //            gView.Rows[i].Cells[1].Value = oldv;
        //            gView.Rows[i].Cells[3].Value = diff;
        //        }
        //        else
        //        {
        //            gView.Rows[i].Cells[1].Value = "";
        //            gView.Rows[i].Cells[3].Value = "";
        //        }
        //        gView.Rows[i].Cells[2].Value = value;
        //        i++;
        //    }
        //}

        private void PrintPageAlt()
        {
            // Make sure we don't go before the first page...
            if (cPage <= 0)
            {
                cPage = 0;
                prvButton.Enabled = false;
            }
            else
            {
                // Only enable previous button if current page is > 0
                prvButton.Enabled = true;
            }

            // ...or after the last page
            if (cPage >= cPages - 1)
            {
                cPage = cPages - 1;
                if (cPage < 0) cPage = 0;
                nxButton.Enabled = false;
            }
            else
            {
                // Only enable next button if there are multiple pages and we aren't on the last page
                nxButton.Enabled = (cPages > 1);
            }

            resLab.Text = resultAddressList.Count.ToString() + " results ("
             + cPages.ToString() + " pages)";

            int i = 0;
            String addr, value, oldv, diff;

            int strLength;
            switch (sSize)
            {
                case SearchSize.Bit8: strLength = 2; break;
                case SearchSize.Bit16: strLength = 4; break;
                default: strLength = 8; break;
            }

            int searchBytes = strLength / 2;

            //gView.Rows.Clear();
            int start = cPage * pageSize;
            int end = Math.Min(cPage * pageSize + pageSize, resultAddressList.Count);
            int count = end - start;
            if (count < gView.Rows.Count)
            {
                gView.Rows.Clear();
            }
            int addCount = count - gView.Rows.Count;
            if (addCount > 0)
            {
                gView.Rows.Add(addCount);
            }

            for (int j = start; j < end; j++)
            {
                SearchResult result;
                if (oldDump == null)
                {
                    result = new SearchResult(resultAddressList[j],
                        newDump.ReadAddress(resultAddressList[j], searchBytes),
                        0);
                }
                else
                {
                    result = new SearchResult(resultAddressList[j],
                        newDump.ReadAddress(resultAddressList[j], searchBytes),
                        oldDump.ReadAddress(resultAddressList[j], searchBytes));
                }

                addr = fixString(Convert.ToString(result.address, 16).ToUpper(), 8);
                if (displayType == "Hex")
                {
                    value = fixString(Convert.ToString(result.value, 16).ToUpper(), strLength);
                    oldv = fixString(Convert.ToString(result.oldValue, 16).ToUpper(), strLength);
                    diff = fixString(Convert.ToString(result.value - result.oldValue, 16).ToUpper(), strLength);
                }
                else if (displayType == "Dec")
                {
                    value = ((int)result.value).ToString();
                    oldv = ((int)result.oldValue).ToString();
                    diff = ((int)(result.value - result.oldValue)).ToString();
                }
                else
                {
                    float floatVal = GlobalFunctions.UIntToSingle(result.value);
                    float floatOldVal = GlobalFunctions.UIntToSingle(result.oldValue);

                    value = floatVal.ToString("g5");
                    oldv = floatOldVal.ToString("g5");
                    diff = (floatVal - floatOldVal).ToString("g5");
                }
                gView.Rows[i].Cells[0].Value = addr;

                if (InitialSearch)
                {
                    gView.Rows[i].Cells[1].Value = "";
                    gView.Rows[i].Cells[3].Value = "";

                }
                else if (resultAddressList[i] < oldDump.StartAddress || resultAddressList[i] > oldDump.EndAddress - searchBytes)
                {
                    gView.Rows[i].Cells[1].Value = "N/A";
                    gView.Rows[i].Cells[3].Value = "N/A";
                }
                else
                {
                    gView.Rows[i].Cells[1].Value = oldv;
                    gView.Rows[i].Cells[3].Value = diff;
                }
                gView.Rows[i].Cells[2].Value = value;
                i++;
            }
        }

        private void nextPage(object sender, EventArgs e)
        {
            //cPage++;
            //PrintPage();
            // Add 2, 1 because we're going to the next page,
            // and another because the upDown is 1-based instead of 0-based like cPage
            pageUpDown.Value = Convert.ToDecimal(cPage + 2);
        }

        private void previousPage(object sender, EventArgs e)
        {
            //cPage--;
            //PrintPage();
            // Since cPage is 0-based, we don't need to subtract 1
            pageUpDown.Value = Convert.ToDecimal(cPage);
        }

        private String fixString(String input, int length)
        {
            String parse = input;
            if (parse.Length > length)
                parse =
                    parse.Substring(parse.Length - length, length);

            while (parse.Length < length)
                parse = "0" + parse;

            return parse;
        }

        public UInt32 GetAddress(int index)
        {
            return resultAddressList[cPage * pageSize + index];
        }

        public StringResult GetResult(int index)
        {
            UInt32 resultAddress = GetAddress(index);

            int strLength;
            switch (sSize)
            {
                case (SearchSize.Bit8): strLength = 2; break;
                case (SearchSize.Bit16): strLength = 4; break;
                default: strLength = 8; break;
            }
            StringResult result;
            result.SAddress = fixString(Convert.ToString(resultAddress, 16).ToUpper(), 8);
            result.SValue = fixString(Convert.ToString(newDump.ReadAddress32(resultAddress), 16).ToUpper(), strLength);
            if (oldDump != null)
            {
                result.SOldValue = fixString(Convert.ToString(oldDump.ReadAddress32(resultAddress), 16).ToUpper(), strLength);
            }
            else
            {
                result.SOldValue = "";
            }
            return result;
        }

        public UInt32 GetNewValueFromAddress(UInt32 resultAddress)
        {
            return newDump.ReadAddress(resultAddress, 4);
        }

        public static UInt32 ReadStream(Stream input, int blength)
        {
            Byte[] buffer = new Byte[blength];
            UInt32 result;

            input.Read(buffer, 0, blength);
            
            switch(blength)
            {
                 case 1: result = (UInt32)buffer[0]; break;
                 case 2: result = (UInt32)ByteSwap.Swap((UInt16)BitConverter.ToUInt16(buffer, 0)); break;
                default: result = (UInt32)ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0)); break;
            }

            return result;
        }

        private void PerformBlockSearch(Dump blockDump, List<DumpRange> dumpranges)
        {
            PBlockDump = true;

            PTotalBlockSize = 0;
            PBlocksDumpedSize = 0;
            for (int i = 0; i < dumpranges.Count; i++)
                PTotalBlockSize += dumpranges[i].rangeLength;

            PBlockCount = dumpranges.Count;

            // This is only here to satisfy the for loop condition, dump sets this to false too
            gecko.CancelDump = false;

            //Stream backupStream = blockDump.getOutputStream();
            //Stream[] streams = { stream, backupStream };
            //Stream[] streams = { stream };

            //stream.Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < dumpranges.Count && !gecko.CancelDump; i++)
            {
                PBlockID = i + 1;
                PBlockStart = dumpranges[i].startAddress;
                PBlockEnd = dumpranges[i].endAddress;

                // Seek in the seek-able stream...
                //stream.Seek(dumpranges[i].streamOffset, SeekOrigin.Begin);
                //int fillCount = (int)(dumpranges[i].streamOffset - backupStream.Position);
                //byte[] zeroes = new byte[fillCount];
                
                // ZipOutputStream can't seek, so fill with zeroes
                //backupStream.Write(zeroes, 0, fillCount);

                //gecko.Dump(dumpranges[i].startAddress, dumpranges[i].endAddress, streams);
                SafeDump(dumpranges[i].startAddress, dumpranges[i].endAddress, blockDump);

                

                PBlocksDumpedSize += dumpranges[i].rangeLength;
            }

            //backupStream.Dispose();

            PBlockDump = false;
        }

        private List<DumpRange> FindDumpRanges(UInt32 startAddress, Byte valueLength, int lowIndex, int highIndex)
        {
            const UInt32 blockSize = 0x3E000;

            List<DumpRange> dumpranges = new List<DumpRange>();

            UInt32 lastAddress;

            if (resultAddressList.Count > 0)
            {
                lastAddress = resultAddressList[lowIndex];
            }
            else
            {
                lastAddress = startAddress;   
            }
            
            DumpRange addRange = new DumpRange(lastAddress);
            addRange.streamOffset = lastAddress - startAddress;

            // Check from lowIndex to highIndex in resultAddressList for dump ranges
            for (int i = lowIndex + 1; i <= highIndex; i++)
            {
                if (resultAddressList[i] >= lastAddress + blockSize)
                {
                    addRange.endAddress = lastAddress + valueLength;
                    addRange.rangeLength =
                        addRange.endAddress - addRange.startAddress;
                    dumpranges.Add(addRange);
                    lastAddress = resultAddressList[i];
                    addRange = new DumpRange(lastAddress);
                    addRange.streamOffset = lastAddress - startAddress;
                }
                lastAddress = resultAddressList[i];
            }
            addRange.endAddress = lastAddress + valueLength;
            addRange.rangeLength =
                addRange.endAddress - addRange.startAddress;
            dumpranges.Add(addRange);
            return dumpranges;
        }

        private bool Compare(UInt32 given, UInt32 loExpected, UInt32 hiExpected, bool useHigh,
            ComparisonType cType, UInt32 diffBy, bool floatCompare)
        {
            if (floatCompare)
            {
                Single givenSingle = GlobalFunctions.UIntToSingle(given),
                    loExpectedSingle = GlobalFunctions.UIntToSingle(loExpected),
                    diffBySingle = GlobalFunctions.UIntToSingle(diffBy);
                // Bail if any of the inputs are Not a Number
                if (Single.IsNaN(givenSingle) || Single.IsNaN(loExpectedSingle) || Single.IsNaN(diffBySingle))
                {
                    return false;
                }

                switch (cType)
                {
                    case ComparisonType.Equal: return (givenSingle == loExpectedSingle);
                    case ComparisonType.NotEqual: return (givenSingle != loExpectedSingle);
                    case ComparisonType.Greater: return (givenSingle > loExpectedSingle);
                    case ComparisonType.GreaterEqual: return (givenSingle >= loExpectedSingle);
                    case ComparisonType.Lower: return (givenSingle < loExpectedSingle);
                    case ComparisonType.LowerEqual: return (givenSingle <= loExpectedSingle);
                    case ComparisonType.DifferentBy: return (loExpectedSingle - diffBySingle == givenSingle || loExpectedSingle + diffBySingle == givenSingle);
                    case ComparisonType.DifferentByLess: return (loExpectedSingle - diffBySingle < givenSingle && givenSingle < loExpectedSingle + diffBySingle);
                    case ComparisonType.DifferentByMore: return (givenSingle < loExpectedSingle - diffBySingle || givenSingle > loExpectedSingle + diffBySingle);
                    default: return (givenSingle == loExpectedSingle);
                }
            }
            else if (useHigh)
            {
                switch (cType)
                {
                    case ComparisonType.Equal: return (given >= loExpected && given <= hiExpected);
                    case ComparisonType.NotEqual: return (given < loExpected || given > hiExpected);
                    case ComparisonType.Greater: return (given > hiExpected);
                    case ComparisonType.GreaterEqual: return (given >= hiExpected);
                    case ComparisonType.Lower: return (given < loExpected);
                    case ComparisonType.LowerEqual: return (given <= loExpected);
                    default: return (given >= loExpected && given <= hiExpected);
                }
            }
            else
            {
                switch (cType)
                {
                    case ComparisonType.Equal: return (given == loExpected);
                    case ComparisonType.NotEqual: return (given != loExpected);
                    case ComparisonType.Greater: return (given > loExpected);
                    case ComparisonType.GreaterEqual: return (given >= loExpected);
                    case ComparisonType.Lower: return (given < loExpected);
                    case ComparisonType.LowerEqual: return (given <= loExpected);
                    case ComparisonType.DifferentBy: return (loExpected - diffBy == given || loExpected + diffBy == given);
                    // Are these right?  How are they supposed to work?
                    // Would ByLess with given 6 and expected 8 with diffBy 3 be true...
                    // 8 - 3 = 5 < 6 OR 8 + 3 = 11 > 6 (shouldn't this be and?)
                    // ByMore, using DiffBy 1 should be true...
                    // 8 - 1 = 7 > 6 AND 8 + 1 = 9 < 6 (shouldn't this be or?)

                    // I'm changing these because I'm pretty sure I'm right...
                    case ComparisonType.DifferentByLess: return (loExpected - diffBy < given && given < loExpected + diffBy);
                    case ComparisonType.DifferentByMore: return (given < loExpected - diffBy || given > loExpected + diffBy);
                    default: return (given == loExpected);
                }
            }
        }

        //private bool CompareRefactored(UInt32 given, UInt32 loExpected, List<SearchComparisonInfo> comparisons, bool floatCompare, SearchType sType)
        private bool CompareRefactored(UInt32 newDumpVal, UInt32 oldDumpVal, UInt32 UndoDumpVal, List<SearchComparisonInfo> comparisons, bool floatCompare)
        {
            bool success = true;
            int others = 0;    // 0 = did not run, -1 = ran and failed, 1 = ran and succeeded
            int GT = 0;
            int LT = 0;
            bool reverseGTLT = false;
            UInt32 GTValue = 0, LTValue = 0;
            foreach (SearchComparisonInfo comp in comparisons)
            {
                UInt32 LHS = newDumpVal;
                UInt32 RHS = comp.value;

                SearchType sType = comp.searchType;

                if (sType == SearchType.Unknown)
                {
                    RHS = oldDumpVal;
                }
                else if (sType == SearchType.Old)
                {
                    RHS = UndoDumpVal;
                }
                else if (sType == SearchType.Diff)
                {
                    LHS = newDumpVal - oldDumpVal;
                }
                
                success = CompareRefactored(LHS, RHS, comp.comparisonType, comp.value, floatCompare);

                if (comp.comparisonType == ComparisonType.Equal)
                {
                    // If any individual equals comparisons succeed, win immediately
                    if (success) return true;
                }
                else if (comp.comparisonType == ComparisonType.GreaterEqual || comp.comparisonType == ComparisonType.Greater)
                {
                    // Store this in case we need to do a reverseGTLT
                    GTValue = comp.value;

                    // Indicate both that we tested (by being non-zero) and success (positive/negative)
                    if (success) GT = 1;
                    else GT = -1;

                    // If some LT test before us ran, and we're reversed, take note
                    if (LT != 0 && GTValue > LTValue)
                    {
                        reverseGTLT = true;
                    }
                }
                else if (comp.comparisonType == ComparisonType.Lower || comp.comparisonType == ComparisonType.LowerEqual)
                {
                    LTValue = comp.value;

                    if (success) LT = 1;
                    else LT = -1;

                    if (GT != 0 && GTValue > LTValue)
                    {
                        reverseGTLT = true;
                    }
                }
                else
                {
                    // all other comparisons must all be true
                    // therefore, any failed fails them all

                    // as long as we didn't fail yet, and we are succeeding, note that we ran and were successful
                    // however, if we ever fail once, then it will fail forever
                    if (others != -1 && success) others = 1;
                    else others = -1;
                }
            }

            // if we got here, none of the equals have succeeded

            // if any of the others are ever false, fail
            if (others < 0) return false;

            // if at least one LT or GT are true, we have some more checks to do...
            if (LT > 0 || GT > 0)
            {
                // if it was a reversed GTLT, then only one must be true
                // if it wasn't reversed, then both must not fail
                if (reverseGTLT)
                {
                    return true;
                }
                else
                {
                    return LT > -1 && GT > -1;
                }
            }

            // if we got this far, then there were no GT/LT checks, or neither passed
            // any failed GT/LT checks fail the compare, but untested checks can continue
            if (LT < 0 || GT < 0) return false;

            // Now there are no GT/LT checks, pass or fail
            // if there was any successful others tests, succeed, otherwise no tests ever succeeded
            return (others > 0);
        }

        private bool CompareRefactored(UInt32 given, UInt32 loExpected, ComparisonType cType, UInt32 diffBy, bool floatCompare)
        {
            if (floatCompare)
            {
                Single givenSingle = GlobalFunctions.UIntToSingle(given),
                    loExpectedSingle = GlobalFunctions.UIntToSingle(loExpected),
                    diffBySingle = GlobalFunctions.UIntToSingle(diffBy);
                // Fail if any of the inputs are Not a Number
                if (Single.IsNaN(givenSingle) || Single.IsNaN(loExpectedSingle) || Single.IsNaN(diffBySingle))
                {
                    return false;
                }

                switch (cType)
                {
                    case ComparisonType.Equal: return (givenSingle == loExpectedSingle);
                    case ComparisonType.NotEqual: return (givenSingle != loExpectedSingle);
                    case ComparisonType.Greater: return (givenSingle > loExpectedSingle);
                    case ComparisonType.GreaterEqual: return (givenSingle >= loExpectedSingle);
                    case ComparisonType.Lower: return (givenSingle < loExpectedSingle);
                    case ComparisonType.LowerEqual: return (givenSingle <= loExpectedSingle);
                    case ComparisonType.DifferentBy: return (loExpectedSingle - diffBySingle == givenSingle || loExpectedSingle + diffBySingle == givenSingle);
                    case ComparisonType.DifferentByLess: return (loExpectedSingle - diffBySingle < givenSingle && givenSingle < loExpectedSingle + diffBySingle);
                    case ComparisonType.DifferentByMore: return (givenSingle < loExpectedSingle - diffBySingle || givenSingle > loExpectedSingle + diffBySingle);
                    default: return (givenSingle == loExpectedSingle);
                }
            }
            else
            {
                switch (cType)
                {
                    case ComparisonType.Equal: return (given == loExpected);
                    case ComparisonType.NotEqual: return (given != loExpected);
                    case ComparisonType.Greater: return (given > loExpected);
                    case ComparisonType.GreaterEqual: return (given >= loExpected);
                    case ComparisonType.Lower: return (given < loExpected);
                    case ComparisonType.LowerEqual: return (given <= loExpected);
                    case ComparisonType.DifferentBy: return (loExpected - diffBy == given || loExpected + diffBy == given);
                    // Are these right?  How are they supposed to work?
                    // Would ByLess with given 6 and expected 8 with diffBy 3 be true...
                    // 8 - 3 = 5 < 6 OR 8 + 3 = 11 > 6 (shouldn't this be and?)
                    // ByMore, using DiffBy 1 should be true...
                    // 8 - 1 = 7 > 6 AND 8 + 1 = 9 < 6 (shouldn't this be or?)

                    // I'm changing these because I'm pretty sure I'm right...
                    case ComparisonType.DifferentByLess: return (loExpected - diffBy < given && given < loExpected + diffBy);
                    case ComparisonType.DifferentByMore: return (given < loExpected - diffBy || given > loExpected + diffBy);
                    default: return (given == loExpected);
                }
            }
        }

        private void FindPairs(UInt32 sAddress, UInt32 eAddress, Byte valSize, out UInt32 firstAddress, out UInt32 lastAddress, out int firstAddressIndex, out int lastAddressIndex)
        {
            // TODO what is this function doing?
            firstAddress = sAddress;
            lastAddress = eAddress;
            firstAddressIndex = 0;
            lastAddressIndex = resultAddressList.Count - 1;
            for (int i = 0; i < resultAddressList.Count; i++)
            {
                if (sAddress <= resultAddressList[i])
                {
                    firstAddress = resultAddressList[i];
                    firstAddressIndex = i;
                    break;
                }
            }
            for (int i = resultAddressList.Count - 1; i >= 0; i--)
            {
                if (eAddress >= resultAddressList[i] + valSize)
                {
                    lastAddress = resultAddressList[i] + valSize;
                    lastAddressIndex = i;
                    break;
                }
            }
        }

        public void Reset()
        {
            NewSearch = true;
            InitialSearch = false;
            nxButton.Enabled = false;
            prvButton.Enabled = false;
            resLab.Text = "";
            //resList.Clear();
            resultAddressList.Clear();
            undoList.Clear();
            gView.Rows.Clear();
            if (newDump != null)
            {
                //newDump.dumpStream.Close();
                //newDump.dumpStream.Dispose();
                newDump = null;
            }
            if (oldDump != null)
            {
                //oldDump.dumpStream.Close();
                //oldDump.dumpStream.Dispose();
                oldDump = null;
            }
            if (undoDump != null)
            {
                //undoDump.dumpStream.Close();
                //undoDump.dumpStream.Dispose();
                undoDump = null;
            }

            dumpNum = 0;
        }

        public bool Search(UInt32 sAddress, UInt32 eAddress, UInt32 lValue, UInt32 hValue,
            bool useHValue, SearchType sType, SearchSize sSize, ComparisonType cType,
            UInt32 differentBy)
        {
            PBlockDump = false;

            resLab.Text = "Searching";
            Byte bufferlength = 0;

            switch (sSize)
            {
                case (SearchSize.Bit8): bufferlength = 1; break;
                case (SearchSize.Bit16): bufferlength = 2; break;
                default: bufferlength = 4; break;
            }

            bool floatCompare = sSize == SearchSize.Single;

            int oldSortedColumn = 0;
            SortOrder oldSortOrder = SortOrder.Ascending;
            SearchResultComparer comparer = new SearchResultComparer();
            // Search process requires list to be in order by address
            // We will restore the sort order afterward
            if (gView.SortedColumn != null)
            {
                oldSortedColumn = gView.SortedColumn.Index;
                oldSortOrder = gView.SortOrder;
            }
            if (oldSortedColumn != 0 || oldSortOrder != SortOrder.Ascending)
            {
                comparer.sortedColumn = 0;
                comparer.descending = false;
                resultAddressList.Sort(comparer);
            }

            // Do we need to do this?  Clearing the grid view makes it suck...
            //gView.Rows.Clear();
            this.sSize = sSize;

            // Pause Gecko - while changing blocks during block search
            // the game will sometimes move forward a few frames
            //bool WasRunning = (gecko.status() == WiiStatus.Running);
            //bool WTF = WasRunning;
            //while (WTF)
            //{
            //    gecko.Pause();
            //    System.Threading.Thread.Sleep(100);
            //    // Sometimes, the game doesn't actually pause...
            //    // So loop repeatedly until it does!
            //    WTF = (gecko.status() == WiiStatus.Running);
            //}
            //gecko.SafePause();

            bool doBlockSearch = false;
            bool doCompare = false;

            Dump searchDump;
            UInt32 dumpStart, dumpEnd, dumpOffset;

            dumpStart = sAddress;
            dumpEnd = eAddress;
            dumpOffset = 0;

            if (NewSearch || (UnknownStart && sType == SearchType.Exact))
            {
                // if an unknown search is followed by an exact search, it should be treated as an initial search
                InitialSearch = true;
                dumpNum = 0;

                // Dispose of any old dumps and lists
                if (newDump != null)
                {
                    //newDump.dumpStream.Dispose();
                    newDump = null;
                }
                resultAddressList.Clear();
                if (oldDump != null)
                {
                    //oldDump.dumpStream.Dispose();
                    oldDump = null;
                }

                // only do compares if it's an exact search
                if (sType == SearchType.Exact)
                {
                    doCompare = true;
                }
                else
                {
                    // Otherwise, it's an unknown search
                    UnknownLAddress = sAddress;
                    UnknownHAddress = eAddress;
                    UnknownStart = true;
                    NewSearch = false;      // I don't think we need this...
                }
            }
            else
            {
                // This is a second search...
                InitialSearch = false;
                doCompare = true;   // will always do a comparison
                if (UnknownStart)
                {
                    // if it's the search after an unknown search, check every address
                    // although double-check the start and end addresses, just in case they changed
                    dumpStart = Math.Max(UnknownLAddress, sAddress);
                    dumpEnd = Math.Min(UnknownHAddress, eAddress);
                    dumpOffset = dumpStart - UnknownLAddress;
                }
                else
                {
                    // otherwise, do a block search to avoid transferring useless data
                    doBlockSearch = true;
                }
            }

            // Clear out any old dumps before caching the current dumps
            if (undoDump != null)
            {
                //undoDump.dumpStream.Dispose();
            }
            undoDump = oldDump;
            oldDump = newDump;

            if (undoList != resultAddressList)
            {
                undoList.Clear();
            }
            undoList = resultAddressList;

            // Dump the contents of memory for the search, by either using a full dump or a block-search-dump
            try
            {
                if (doBlockSearch)
                {
                    UInt32 startAddress, endAddress;
                    int startAddressIndex, endAddressIndex;
                    FindPairs(sAddress, eAddress, bufferlength, out startAddress, out endAddress, out startAddressIndex, out endAddressIndex);
                    List<DumpRange> dumpRanges = FindDumpRanges(startAddress, bufferlength, startAddressIndex, endAddressIndex);
                    //orgStream = new MemoryStream((int)(fAddr - sAddr));
                    newDump = new Dump(startAddress, endAddress, dumpNum);
                    PerformBlockSearch(newDump, dumpRanges);
                    //newDump.WriteStreamToDisk();
                }
                else
                {
                    newDump = new Dump(dumpStart, dumpEnd, dumpNum);
                    gecko.Dump(newDump);
                }
            }
            catch (EUSBGeckoException e)
            {
                exceptionHandling.HandleException(e);
            }

            if (doCompare)
            {
                // The "original stream" is always the one we just read from the USB Gecko
                //Stream originalStream, compareStream;
                //originalStream = newDump.dumpStream;
                //compareStream = newDump.dumpStream;
                //// dumpOffset is 0 if sType = exact
                //originalStream.Seek(dumpOffset, SeekOrigin.Begin);

                // if sType != exact, compare against the previous dump
                if (sType != SearchType.Exact && sType != SearchType.Diff)
                {
                    //compareStream = oldDump.dumpStream;
                    //compareStream.Seek(0, SeekOrigin.Begin);
                    hValue = 0;
                    useHValue = false;
                }

                UInt32 val, cmpVal;
                // assume that it's exact and change it if not
                cmpVal = lValue;

                if (resultAddressList.Count > 0)
                {
                    // We have a working list so we will only check the values in that list
                    // Create a temporary list to write to while we read from the old one
                    List<UInt32> tempAddressList = new List<uint>();
                    foreach (UInt32 compareAddress in resultAddressList)
                    {
                        val = newDump.ReadAddress(compareAddress, bufferlength);
                        if (sType == SearchType.Unknown)
                        {
                            cmpVal = oldDump.ReadAddress(compareAddress, bufferlength);
                        }
                        else if (sType == SearchType.Old)
                        {
                            cmpVal = undoDump.ReadAddress(compareAddress, bufferlength);
                        }
                        else if (sType == SearchType.Diff)
                        {
                            val = val - oldDump.ReadAddress(compareAddress, bufferlength);
                        }

                        if (Compare(val, cmpVal, hValue, useHValue, cType, differentBy, floatCompare))
                        {
                            tempAddressList.Add(compareAddress);
                        }
                    }

                    // Copy the temporary list over
                    resultAddressList = tempAddressList;
                }
                else
                {
                    for (UInt32 i = newDump.StartAddress; i < newDump.EndAddress; i += bufferlength)
                    {
                        //// There are no pre-existing addresses to compare to!  compare all addresses
                        //while (originalStream.Position + bufferlength < originalStream.Length)
                        //{
                        //    val = ReadStream(originalStream, bufferlength);

                        // This will either happen on the very first search if it is specific,
                        // or the second search if the first search was unknown
                        // In either case, there cannot be an Old or Diff passed in
                        val = newDump.ReadAddress(i, bufferlength);
                        if (sType != SearchType.Exact)
                        {
                            //cmpVal = ReadStream(compareStream, bufferlength);
                            cmpVal = oldDump.ReadAddress(i, bufferlength);
                        }

                        if (Compare(val, cmpVal, hValue, useHValue, cType, differentBy, floatCompare))
                        {
                            resultAddressList.Add(i);
                        }
                    }
                }
            }


            //SearchHistoryItem item = new SearchHistoryItem();

            //item.searchDump = newDump;
            //item.resultsList = resultAddressList;


            //DateTime startTime = Logger.WriteLineTimedStarted("serializing search items");

            //searchHistory.SaveSearchBackground(dumpNum, resultAddressList, newDump);
            ////item.WriteCompressedZipBackground("foo.zip");

            //Logger.WriteLineTimedFinished("serializing search items", startTime);

            //startTime = Logger.WriteLineTimedStarted("deserializing search items");

            ////item.ReadCompressedZip("foo.zip");

            //Dump testDump = searchHistory.LoadSearchDump(dumpNum);

            //List<UInt32> testList = searchHistory.LoadSearchList(dumpNum);

            //Logger.WriteLineTimedFinished("deserializing search items", startTime);


            if (UnknownStart && !InitialSearch)
            {
                // clear UnknownStart if InitialSearch is false
                UnknownStart = false;
            }

            dumpNum++;


            //if (NewSearch || (UnknownStart && sType == SearchType.Exact))
            //{
            //    bool abort = false;
            //    InitialSearch = true;
            //    //orgStream = new MemoryStream((int)(eAddress - sAddress));
            //    Dump myDump = new Dump(sAddress, eAddress);
            //    resList.Clear();
            //    resultAddressList.Clear();
            //    try
            //    {
            //        gecko.CancelDump = false;
            //        //gecko.Dump(sAddress, eAddress, orgStream);
            //        gecko.Dump(myDump);
            //        orgStream = myDump.dumpStream;
            //        FileStream foo = new FileStream(Environment.CurrentDirectory + @"\searchdumps\dump0.ful", FileMode.Create);
            //        orgStream.WriteTo(foo);
            //        foo.Close();
            //        foo.Dispose();
            //        oldDump = null;
            //        newDump = myDump;
            //        orgStream.Seek(0, SeekOrigin.Begin);
            //        if (!gecko.CancelDump)
            //        {
            //            if (sType == SearchType.Exact)
            //            {
            //                //                         orgStream.Seek(0, SeekOrigin.Begin);
            //                UInt32 val;
            //                while (orgStream.Position + bufferlength < orgStream.Length)
            //                {
            //                    val = ReadStream(orgStream, bufferlength);
            //                    if (Compare(val, lValue, hValue, useHValue, cType, differentBy, floatCompare))
            //                    {
            //                        //resList.Add(new SearchResult(sAddress + (UInt32)orgStream.Position - bufferlength, val, 0));
            //                        resultAddressList.Add(sAddress + (UInt32)orgStream.Position - bufferlength);
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                UnknownLAddress = sAddress;
            //                UnknownHAddress = eAddress;
            //                UnknownStart = true;
            //                NewSearch = false;
            //                abort = true;
            //            }
            //        }
            //        orgStream = null;
            //    }
            //    catch (EUSBGeckoException e)
            //    {
            //        Reset();
            //        exceptionHandling.HandleException(e);
            //        abort = true;
            //    }
            //}
            //else 
            //{
            //    InitialSearch = false;
            //    try
            //    {
            //        // This branch is only executed once, the search after an unknown search
            //        if (UnknownStart)
            //        {
            //            UnknownStart = false;
            //            UInt32 sAddr = Math.Max(UnknownLAddress, sAddress);
            //            UInt32 fAddr = Math.Min(UnknownHAddress, eAddress);
            //            UInt32 offset = sAddr - UnknownLAddress;

            //            cmpStream = new MemoryStream((int)(fAddr - sAddr));
            //            try
            //            {
            //                gecko.CancelDump = false;
            //                gecko.Dump(sAddr, fAddr, cmpStream);
            //                if (!gecko.CancelDump)
            //                {
            //                    orgStream.Seek(offset, SeekOrigin.Begin);
            //                    cmpStream.Seek(0, SeekOrigin.Begin);

            //                    UInt32 oldValue, newValue;
            //                    while (cmpStream.Position + bufferlength < cmpStream.Length)
            //                    {
            //                        newValue = ReadStream(cmpStream, bufferlength);
            //                        oldValue = ReadStream(orgStream, bufferlength);
            //                        if (Compare(newValue, oldValue, 0, false, cType, differentBy, floatCompare))
            //                            resList.Add(new SearchResult(sAddr + (UInt32)cmpStream.Position - bufferlength, newValue, oldValue));
            //                    }
            //                }
            //                else
            //                {
            //                    UnknownStart = true;
            //                    NewSearch = false;
            //                    return true;
            //                }
            //            }
            //            finally
            //            {
            //                cmpStream.Close();
            //                cmpStream = null;
            //            }
            //        }
            //        else
            //        {
            //            UInt32 sAddr, fAddr;
            //            UInt32 cmpV = lValue;
            //            bool useUpper = useHValue;
            //            bool lastV = false;
            //            List<SearchResult> tempList = new List<SearchResult>();
            //            if (sType == SearchType.Unknown)
            //            {
            //                useUpper = false;
            //                lastV = true;
            //            }
            //            int lV, hV;
            //            FindPairs(sAddress, eAddress, bufferlength, out sAddr, out fAddr, out lV, out hV);
            //            orgStream = new MemoryStream((int)(fAddr - sAddr));
            //            //Insert block based search here
            //            PerformBlockSearch(sAddr, fAddr, bufferlength, lV, hV, orgStream);
            //            //gecko.Dump(sAddr, fAddr, orgStream);
            //            //end
            //            UInt32 val;

            //            // Compare the two dumps
            //            for (int i = lV; i <= hV && !gecko.CancelDump; i++)
            //            {
            //                if (lastV)
            //                    cmpV = resList[i].value;
            //                orgStream.Seek(resList[i].address - sAddr, SeekOrigin.Begin);
            //                val = ReadStream(orgStream, bufferlength);
            //                if (Compare(val, cmpV, hValue, useUpper, cType, differentBy, floatCompare))
            //                    tempList.Add(
            //                        new SearchResult(sAddr + (UInt32)orgStream.Position - bufferlength, val, resList[i].value));
            //            }

            //            // If this was canceled, don't update the results list
            //            if (!gecko.CancelDump)
            //            {
            //                resList.Clear();
            //                resList = null;
            //                resList = tempList;
            //            }
            //        }
            //    }
            //    catch (EUSBGeckoException e)
            //    {
            //        Reset();
            //        exceptionHandling.HandleException(e);
            //        return false;
            //    }
            //}

            //// If we were running, go back to running
            //// If we *weren't* running, *don't* go back to running
            //if (WasRunning)
            //{
            //    gecko.SafeResume();
            //}

            //if (orgStream != null)
            //{
            //    orgStream.Close();
            //}
            //orgStream = null;

            //if (resList.Count == 0 && resultAddressList.Count == 0)
            if (resultAddressList.Count == 0 && !UnknownStart)
            {
                NewSearch = true;
                nxButton.Enabled = false;
                prvButton.Enabled = false;
                resLab.Text = "No results found";
                Reset();
                return false;
            }

            NewSearch = false;

            //int PageCount = resList.Count / 256;
            //if (resList.Count % 256 != 0) PageCount++;

            //cPage = 0;
            //cPages = PageCount;

            //PrintPage();

            UpdateGridViewPage(true);

            return true;
        }

        public bool SearchRefactored(UInt32 sAddress, UInt32 eAddress, List<SearchComparisonInfo> comparisons, SearchSize searchSize)
        {
            PBlockDump = false;

            resLab.Text = "Searching";
            Byte bufferlength = 0;

            switch (searchSize)
            {
                case (SearchSize.Bit8): bufferlength = 1; break;
                case (SearchSize.Bit16): bufferlength = 2; break;
                default: bufferlength = 4; break;
            }

            this.sSize = searchSize;

            bool floatCompare = searchSize == SearchSize.Single;

            int oldSortedColumn = 0;
            SortOrder oldSortOrder = SortOrder.Ascending;
            SearchResultComparer comparer = new SearchResultComparer();
            // Search process requires list to be in order by address
            // We will restore the sort order afterward
            if (gView.SortedColumn != null)
            {
                oldSortedColumn = gView.SortedColumn.Index;
                oldSortOrder = gView.SortOrder;
            }
            if (oldSortedColumn != 0 || oldSortOrder != SortOrder.Ascending)
            {
                comparer.sortedColumn = 0;
                comparer.descending = false;
                resultAddressList.Sort(comparer);
            }

            SearchType sType = comparisons[0].searchType;

            bool doBlockSearch = false;
            bool doCompare = false;

            Dump searchDump;
            UInt32 dumpStart, dumpEnd, dumpOffset;

            dumpStart = sAddress;
            dumpEnd = eAddress;
            dumpOffset = 0;

            if (NewSearch || (UnknownStart && sType == SearchType.Exact))
            {
                // if an unknown search is followed by an exact search, it should be treated as an initial search
                InitialSearch = true;
                dumpNum = 0;

                // Dispose of any old dumps and lists
                if (newDump != null)
                {
                    //newDump.dumpStream.Dispose();
                    newDump = null;
                }
                resultAddressList.Clear();
                if (oldDump != null)
                {
                    //oldDump.dumpStream.Dispose();
                    oldDump = null;
                }

                // only do compares if it's an exact search
                if (sType == SearchType.Exact)
                {
                    doCompare = true;
                }
                else
                {
                    // Otherwise, it's an unknown search
                    UnknownLAddress = sAddress;
                    UnknownHAddress = eAddress;
                    UnknownStart = true;
                    NewSearch = false;      // I don't think we need this...
                }
            }
            else
            {
                // This is a second search...
                InitialSearch = false;
                doCompare = true;   // will always do a comparison
                if (UnknownStart)
                {
                    // if it's the search after an unknown search, check every address
                    // although double-check the start and end addresses, just in case they changed
                    dumpStart = Math.Max(UnknownLAddress, sAddress);
                    dumpEnd = Math.Min(UnknownHAddress, eAddress);
                    dumpOffset = dumpStart - UnknownLAddress;
                }
                else
                {
                    // otherwise, do a block search to avoid transferring useless data
                    doBlockSearch = true;
                }
            }

            // Clear out any old dumps before caching the current dumps
            undoDump = oldDump;
            oldDump = newDump;
            undoList = resultAddressList;

            // Dump the contents of memory for the search, by either using a full dump or a block-search-dump
            if (doBlockSearch)
            {
                UInt32 startAddress, endAddress;
                int startAddressIndex, endAddressIndex;
                FindPairs(dumpStart, dumpEnd, bufferlength, out startAddress, out endAddress, out startAddressIndex, out endAddressIndex);
                List<DumpRange> dumpRanges = FindDumpRanges(startAddress, bufferlength, startAddressIndex, endAddressIndex);
                newDump = new Dump(startAddress, endAddress, dumpNum);
                PerformBlockSearch(newDump, dumpRanges);
            }
            else
            {
                newDump = new Dump(dumpStart, dumpEnd, dumpNum);
                SafeDump(dumpStart, dumpEnd, newDump);
            }

            if (doCompare)
            {
                UInt32 val, cmpVal;
                // assume that it's exact and change it if not
                cmpVal = comparisons[0].value;

                if (resultAddressList.Count > 0)
                {
                    // We have a working list so we will only check the values in that list
                    // Create a temporary list to write to while we read from the old one
                    List<UInt32> tempAddressList = new List<uint>();
                    foreach (UInt32 compareAddress in resultAddressList)
                    {
                        UInt32 newDumpVal = newDump.ReadAddress(compareAddress, bufferlength);
                        UInt32 oldDumpVal = oldDump.ReadAddress(compareAddress, bufferlength);
                        UInt32 UndoDumpVal;
                        if (undoDump != null)
                        {
                            UndoDumpVal = undoDump.ReadAddress(compareAddress, bufferlength);
                        }
                        else
                        {
                            UndoDumpVal = oldDumpVal;
                        }
                        if (CompareRefactored(newDumpVal, oldDumpVal, UndoDumpVal, comparisons, floatCompare))
                        {
                            tempAddressList.Add(compareAddress);
                        }
                    }

                    // Copy the temporary list over
                    resultAddressList = tempAddressList;
                }
                else
                {
                    for (UInt32 i = newDump.StartAddress; i < newDump.EndAddress; i += bufferlength)
                    {
                        // There are no pre-existing addresses to compare to!  compare all addresses

                        // This will either happen on the very first search if it is specific,
                        // or the second search if the first search was unknown
                        // In either case, there cannot be an Old or Diff passed in
                        UInt32 newDumpVal = newDump.ReadAddress(i, bufferlength);
                        UInt32 oldDumpVal = newDumpVal;
                        UInt32 UndoDumpVal = newDumpVal;
                        if (sType != SearchType.Exact)
                        {
                            oldDumpVal = oldDump.ReadAddress(i, bufferlength);
                            UndoDumpVal = oldDumpVal;
                        }

                        //if (Compare(val, cmpVal, hValue, useHValue, cType, differentBy, floatCompare))
                        if (CompareRefactored(newDumpVal, oldDumpVal, UndoDumpVal, comparisons, floatCompare))
                        {
                            resultAddressList.Add(i);
                        }
                    }
                }
            }

            if (UnknownStart && !InitialSearch)
            {
                // clear UnknownStart if InitialSearch is false
                UnknownStart = false;
            }

            dumpNum++;

            if (resultAddressList.Count == 0 && !UnknownStart)
            {
                DialogResult result = MessageBox.Show(null, "No search results!\n\nTo undo, press Yes\nTo restart, press No", "No search results!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                bool UndoSuccess = false;
                if (result == DialogResult.Yes)
                {
                    UndoSuccess = UndoSearch();
                    if (!UndoSuccess)
                    {
                        MessageBox.Show("Could not undo!  Restarting search");
                    }
                }

                if (!UndoSuccess)
                {
                    NewSearch = true;
                    nxButton.Enabled = false;
                    prvButton.Enabled = false;
                    resLab.Text = "No results found";
                    Reset();
                    return false;
                }
            }

            NewSearch = false;

            UpdateGridViewPage(true);

            return true;
        }

        public void SafeDump(UInt32 startdump, UInt32 enddump, Dump memdump)
        {
            bool finished = false;
            while (!finished)
            {
                try
                {
                    gecko.Dump(startdump, enddump, memdump);
                    finished = true;
                }
                catch (EUSBGeckoException e)
                {
                    exceptionHandling.HandleException(e);
                    if (startdump == memdump.ReadCompletedAddress)
                    {
                        // failed to get any more data; something is probably really wrong so let's just quit
                        finished = true;
                    }
                    else
                    {
                        startdump = memdump.ReadCompletedAddress;
                    }
                }
            }
        }



        public bool UndoSearch()
        {
            if (newDump == null || oldDump == null || undoDump == null)
            {
                return false;
            }
            //newDump.dumpStream.Dispose();
            newDump = oldDump;
            oldDump = undoDump;
            undoDump = null;
            resultAddressList.Clear();
            resultAddressList = new List<uint>(undoList);

            UpdateGridViewPage(true);
            return true;
        }

        public bool SaveSearch(string path)
        {
            return SaveSearch(path, true);
        }

        public bool SaveSearch(string path, bool compressed)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializeResults = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            if (!compressed)
            {
                FileStream resultFile = new FileStream(path, FileMode.Create);
                serializeResults.Serialize(resultFile, sSize);
                //serializeResults.Serialize(resultFile, resList);
                // TODO SAVING SEARCHES TO FILE
                resultFile.Close();
                return true;
            }

            ZipOutputStream resultStream = new ZipOutputStream(path);
            resultStream.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed;
            resultStream.PutNextEntry("ResList");

            // good first guess
            //MemoryStream resultStream = new MemoryStream(12 * resList.Count);
            
            serializeResults.Serialize(resultStream, sSize);
            //serializeResults.Serialize(resultStream, resList);

            // TODO SAVING SEARCHES TO FILE

            //ZipFile outfile = new ZipFile(path);
            //outfile.AddEntry("ResList", resultStream);
            //outfile.Save();
            //outfile.Dispose();
            resultStream.Close();
            resultStream.Dispose();
            return true;
        }

        public void LoadIndexIntoOldSearchDump(int index)
        {
            oldDump = searchHistory.LoadSearchDump(index);
        }

        public void LoadIndexIntoNewSearchDump(int index)
        {
            newDump = searchHistory.LoadSearchDump(index);
        }

        public void LoadIndexIntoSearchList(int index)
        {
            resultAddressList = searchHistory.LoadSearchList(index);
        }

        public void SaveSearchToIndex(int index)
        {
            searchHistory.SaveSearchBackground(index, resultAddressList, newDump);
        }

        public bool LoadSearchHistory(string path)
        {
            searchHistory.LoadHistory(path, out dumpNum, out sSize);
            if (dumpNum > 0)
            {
                newDump = searchHistory.LoadSearchDump(dumpNum);
                resultAddressList = searchHistory.LoadSearchList(dumpNum);
            }
            if (dumpNum > 1)
                oldDump = searchHistory.LoadSearchDump(dumpNum - 1);
            if (dumpNum > 2)
                undoDump = searchHistory.LoadSearchDump(dumpNum - 2);
            return dumpNum == 0;
        }

        public bool SaveSearchHistory(string path)
        {
            searchHistory.SaveHistory(path, dumpNum, sSize);
            return true;
        }

        public bool LoadSearch(string path, bool compressed)
        {

            // TODO LOADING SEARCHES FROM FILE
            int oldSortedColumn = 0;
            SortOrder oldSortOrder = SortOrder.Ascending;
            if (gView.SortedColumn != null)
            {
                oldSortedColumn = gView.SortedColumn.Index;
                oldSortOrder = gView.SortOrder;
            }

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializeResults = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            if (!compressed)
            {
                FileStream resultFile = new FileStream(path, FileMode.Open);
                sSize = (SearchSize)serializeResults.Deserialize(resultFile);
                //resList = (List<SearchResult>)serializeResults.Deserialize(resultFile);
                resultFile.Close();
            }
            else
            {
                ZipFile infile = ZipFile.Read(path);
                MemoryStream resultStream = new MemoryStream();
                infile["ResList"].Extract(resultStream);
                sSize = (SearchSize)serializeResults.Deserialize(resultStream);
                //resList = (List<SearchResult>)serializeResults.Deserialize(resultStream);
                infile.Dispose();
                resultStream.Close();
                resultStream.Dispose();
            }

            //if (resList.Count == 0)
            {
                NewSearch = true;
                nxButton.Enabled = false;
                prvButton.Enabled = false;
                resLab.Text = "No results found";
                return false;
            }

            //int PageCount = resList.Count / 256;
            //if (resList.Count % 256 != 0) PageCount++;

            //NewSearch = false;

            //cPage = 0;
            //cPages = PageCount;

            // Restore sort
            // EDIT: User should restore sort on their own
            //       Sorting a large list can take a lot of time
            //if (oldSortOrder == SortOrder.Ascending)
            //{
            //    gView.Sort(gView.Columns[oldSortedColumn], System.ComponentModel.ListSortDirection.Ascending);
            //}
            //else
            //{
            //    gView.Sort(gView.Columns[oldSortedColumn], System.ComponentModel.ListSortDirection.Descending);
            //}
            //SortResults();

            //PrintPage();

            UpdateGridViewPage(true);

            return true;
        }

        public void DeleteResults(DataGridViewSelectedRowCollection deletingCollection)
        {
            int pageOffset = cPage * pageSize;
            List<int> deletedIndices = new List<int>();
            
            // Get all the indices
            foreach (DataGridViewRow row in gView.SelectedRows)
            {
                deletedIndices.Add(row.Index);
            }

            // Sort them, descending
            deletedIndices.Sort();
            deletedIndices.Reverse();

            // Delete, starting from the last one
            for (int i = 0; i < deletedIndices.Count; i++)
            {
                resultAddressList.RemoveAt(pageOffset + deletedIndices[i]);
            }

            //int start = pageOffset + deletingCollection[0].Index;
            //// Supposedly this GetRowCount is faster...
            //int endIndex = gView.Rows.GetRowCount(DataGridViewElementStates.Selected) - 1;
            //int end = pageOffset + deletingCollection[endIndex].Index;
            //if (end < start)
            //{
            //    int temp = end;
            //    end = start;
            //    start = temp;
            //}
            //int deletingCount = (end - start) + 1;  // if end = start (because we only have one row to delete), we want 1
            //resList.RemoveRange(start, deletingCount);

            UpdateGridViewPage();
        }

        public void DeleteResult(int index)
        {
            // Deleting results can potentially change the page count
            resultAddressList.RemoveAt(cPage * pageSize + index);

            UpdateGridViewPage();
        }

        public void UpdateGridViewPage()
        {
            UpdateGridViewPage(false);
        }

        public void UpdateGridViewPage(bool ResizeGridView)
        {
            //int PageCount = resList.Count / 256;
            //if (resList.Count % 256 != 0) PageCount++;

            //if (resList.Count == 0)
            //{
            int PageCount = resultAddressList.Count / 256;
            if (resultAddressList.Count % 256 != 0) PageCount++;
            //}
            cPages = PageCount;
            pageUpDown.Maximum = Convert.ToDecimal(cPages);

            bool HadSelectedCells = gView.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0;
            if (HadSelectedCells)
            {
                // Remember what row was selected in case we need to restore it
                // Depending on the order of selection, the earliest index may be first or last
                oldSelectedRow = Math.Min(gView.SelectedRows[0].Index, gView.SelectedRows[gView.SelectedRows.Count - 1].Index);
            }

            //if (resList.Count == 0)
            //{
                PrintPageAlt();
            //}
            //else
            //{
            //    PrintPage();
            //}

            if (HadSelectedCells && gView.Rows.Count > 0)
            {
                if (oldSelectedRow >= gView.Rows.Count)
                {
                    oldSelectedRow = gView.Rows.Count - 1;
                }

                // PrintPage selects the first row...
                // This creates a multi-selected row issue
                gView.Rows[0].Selected = false;
                foreach (DataGridViewRow row in gView.SelectedRows)
                {
                    // If multiple rows were selected (for instance, for deleting)
                    // Turn off all those rows
                    row.Selected = false;
                }

                // Must activate old row after deactivating other rows,
                // otherwise when the old row _is_ the other row, nothing happens
                gView.Rows[oldSelectedRow].Selected = true;

                // All of this selection changing doesn't move the "current cell" box
                // So if the user uses the arrow keys, the selected cell won't be where they expect it to be
                // So let's move that current cell to the selected row
                gView.CurrentCell = gView.SelectedRows[0].Cells[0];
            }

            if (ResizeGridView)
            {
                int col1Width = gView.Columns[1].Width, col2Width = gView.Columns[2].Width, col3Width = gView.Columns[3].Width;
                gView.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells);
                gView.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.AllCells);
                gView.AutoResizeColumn(3, DataGridViewAutoSizeColumnMode.AllCells);

                // Choose the larger of the previous column width or the resized column width
                gView.Columns[1].Width = Math.Max(col1Width, gView.Columns[1].Width);
                gView.Columns[2].Width = Math.Max(col2Width, gView.Columns[2].Width);
                gView.Columns[3].Width = Math.Max(col3Width, gView.Columns[3].Width);
            }

            // If the user holds delete down, it's possible the control never gets a chance to update
            // So we force the control to update
            gView.Update();
        }

        //public void RestoreSelectedRow()
        //{
        //    // We don't want multiple rows selected...
        //    while (gView.SelectedRows.Count > 0)
        //    {
        //        gView.SelectedRows[0].Selected = false;
        //    }

        //    if (oldSelectedRow >= gView.Rows.Count)
        //    {
        //        oldSelectedRow = gView.Rows.Count - 1;
        //    }
        //    gView.Rows[oldSelectedRow].Selected = true;
        //}

        public bool CanUndo()
        {
            return undoDump != null;
        }

        public void SortResults()
        {
            // We want the list to match the sorting of the grid view
            // This way if they, say, delete an element on the grid view, it finds the right index in the list
            SearchResultComparer comparer = new SearchResultComparer();
            comparer.sortedColumn = gView.SortedColumn.Index;
            if (gView.SortOrder == SortOrder.Descending)
            {
                comparer.descending = true;
            }

            comparer.oldDump = oldDump;
            comparer.newDump = newDump;

            DateTime SortStart = Logger.WriteLineTimedStarted("sorting column " + comparer.sortedColumn.ToString());

            // TODO: reverse if possible?

            resultAddressList.Sort(comparer);

            Logger.WriteLineTimedFinished("sorting", SortStart);

            PrintPageAlt();
        }

        // This class is used when sorting the search results list
        public class SearchResultComparer : IComparer<UInt32>
        {
            public int sortedColumn = 0;
            public bool descending = false;
            public Dump oldDump, newDump;
            //public bool viewModeFloat;
            // TODO: if float, do the cast before comparing

            public int Compare(UInt32 x, UInt32 y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }
                else
                {
                    int retval = 0;
                    // Compare by column
                    switch (sortedColumn)
                    {
                        case 0: retval = x.CompareTo(y);    break;
                        case 1: if (oldDump != null) retval = oldDump.ReadAddress32(x).CompareTo(oldDump.ReadAddress32(y));  break;
                        case 2: if (newDump != null) retval = newDump.ReadAddress32(x).CompareTo(newDump.ReadAddress32(y)); break;
                        case 3: if (oldDump != null && newDump != null) retval = (newDump.ReadAddress32(x) - oldDump.ReadAddress32(x)).CompareTo(newDump.ReadAddress32(y) - oldDump.ReadAddress32(y)); break;
                        default: retval = 0;                                break;
                    }
                    // If the values are equal, compare them by address
                    if (retval == 0)
                    {
                        retval = x.CompareTo(y);
                    }

                    // Reverse if descending
                    if (descending)
                    {
                        retval *= -1;
                    }
                    return retval;
                }
            }
        }
    }

}

