using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

using FTDIUSBGecko;

namespace GeckoApp
{
    static class Logger
    {
        private static TextWriter debugLogWriter = null;
        //private static string path = System.Windows.Forms.Application.StartupPath + "\\Logs\\GDNdebug" + DateTime.Now + ".log";
        private static string folder = System.Windows.Forms.Application.StartupPath + "\\Logs\\";
        private static string filename = "GDNdebug " + DateTime.Now.ToString("yy-mm-dd H.mm.ss") + ".log";

        static void CreateOrAppendLoggingFile(string Folder, string Filename)
        {
            if (debugLogWriter != null)
            {
                debugLogWriter.Close();
                debugLogWriter.Dispose();
            }

            try
            {
                if (!Directory.Exists(Folder))
                    Directory.CreateDirectory(Folder);

                debugLogWriter = new StreamWriter(Folder + Filename, true);
            }
            catch (System.IO.IOException)
            {
                filename = "GDNdebug " + DateTime.Now.ToString("yy-mm-dd H.mm.ss") + ".log";
                CreateOrAppendLoggingFile(folder, filename);
            }
        }

        public static void WriteLine(string write)
        {
            if (debugLogWriter == null)
            {
                CreateOrAppendLoggingFile(folder, filename);
                debugLogWriter.WriteLine();
                debugLogWriter.WriteLine();
                debugLogWriter.WriteLine(DateTime.Now.ToString("G") + ": Opened log");
            }

            debugLogWriter.WriteLine(write);
            debugLogWriter.Flush();
        }

        public static void WriteLineTimed(string write)
        {
            string newWrite = DateTime.Now.ToString("T") + ": " + write;
            WriteLine(newWrite);
        }

        public static DateTime WriteLineTimedStarted(string write)
        {
#if _LOG_TIMING
            string newWrite = "Started " + write;
            WriteLineTimed(newWrite);
#endif
            return DateTime.Now;
        }

        public static void WriteLineTimedFinished(string write, DateTime start)
        {
#if _LOG_TIMING
            string newWrite = "Finished " + write + " in " + new TimeSpan(DateTime.Now.Ticks - start.Ticks).TotalSeconds + " seconds";
            WriteLineTimed(newWrite);
#endif
        }

        public static void WriteException(Exception ex)
        {
            Logger.WriteLineTimed("Exception occured!");
            Logger.WriteLine("Message: " + ex.Message);
            Logger.WriteLine("Stack Trace: \r\n" + ex.StackTrace);
            Logger.WriteLine("Inner Exception: " + ex.InnerException);
        }

    }


    public static class GlobalFunctions
    {
        public static String fixString(String input,int length)
        {
            String parse = input;
            if (parse.Length > length)
                parse =
                    parse.Substring(parse.Length - length, length);

            while (parse.Length < length)
                parse = "0" + parse;

            return parse;
        }

        public static String shortHex(UInt32 value)
        {
            return Convert.ToString(value, 16).ToUpper();
        }
        
        public static String toHex(UInt32 value,int length)
        {
            return fixString(Convert.ToString(value, 16).ToUpper(), length);
        }

        public static String toHex(long value, int length)
        {
            return toHex((UInt32)value);
        }

        public static String toHex(UInt32 value)
        {
            return toHex(value, 8);
        }

        public static String toHex(long value)
        {
            return toHex((UInt32)value, 8);
        }

        // Shouldn't this be "tryToUInt32" or "tryFromHex"?
        public static bool tryToHex(String input, out UInt32 value)
        {
            value = 0;
            try
            {
                UInt32 temp = Convert.ToUInt32(input, 16);
                value = temp;
                return true;
            }
            catch { }
            return false;
        }

        public static bool tryToHex(String input, out byte[] value)
        {
            value = new byte[(input.Length + 1) / 2];
            //foreach (byte foo in value)
            //    foo = 0;
            try
            {
                for (int i = 0; i < input.Length; i+=2)
                {
                    value[i/2] = Convert.ToByte(input.Substring(i, 2), 16);
                }
                return true;
            }
            catch { }
            return false;
        }

        public static Single UIntToSingle(UInt32 input)
        {
            Byte[] data = BitConverter.GetBytes(input);
            Single result;
            result = BitConverter.ToSingle(data, 0);
            return result;
        }

        public static UInt32 SingleToUInt(Single input)
        {
            Byte[] data = BitConverter.GetBytes(input);
            UInt32 result;
            result = BitConverter.ToUInt32(data, 0);
            return result;
        }

        public static UInt32 ReadStream(Stream input, int blength)
        {
            Byte[] buffer = new Byte[blength];
            UInt32 result;

            input.Read(buffer, 0, blength);

            switch (blength)
            {
                case 1: result = (UInt32)buffer[0]; break;
                case 2: result = (UInt32)ByteSwap.Swap((UInt16)BitConverter.ToUInt16(buffer, 0)); break;
                default: result = (UInt32)ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0)); break;
            }

            return result;
        }

        public static UInt32 ReadStream(Stream input)
        {
            return ReadStream(input, 4);
        }

        public static void WriteStream(Stream output, UInt32 value, int blength)
        {
            Byte[] buffer = new Byte[blength];
            
            Byte[] vBuffer = vBuffer = BitConverter.GetBytes(value);
           
            switch (blength)
            {
                case 1:
                    buffer[0] = vBuffer[0];
                    break;
                case 2:
                    buffer[0] = vBuffer[1];
                    buffer[1] = vBuffer[0];
                    break;
                default:
                    buffer[0] = vBuffer[3];
                    buffer[1] = vBuffer[2];
                    buffer[2] = vBuffer[1];
                    buffer[3] = vBuffer[0];
                    break;
            }

            output.Write(buffer, 0, blength);

        }

        public static void WriteStream(Stream output, UInt32 value)
        {
            WriteStream(output, value, 4);
        }

        public static int IndexOfByteArray(byte[] buffer, byte[] pattern, int startIndex)
        {
            return IndexOfByteArray(buffer, pattern, startIndex, true);
        }

        public static byte SafeToUpper(byte input)
        {
            char foo = ((char)input);
            byte retVal = Char.IsLetter(foo) ? (byte)(Char.ToUpper(foo)) : input;
            return retVal;
        }

        public static byte SafeToLower(byte input)
        {
            char foo = ((char)input);
            byte retVal = Char.IsLetter(foo) ? (byte)(Char.ToLower(foo)) : input;
            return retVal;
        }

        public static int SafeMinIndex(byte[] buffer, byte input1, byte input2, int startIndex)
        {
            int index1 = Array.IndexOf(buffer, input1, startIndex);
            int index2 = Array.IndexOf(buffer, input2, startIndex);
            if (index1 < 0) return index2;
            if (index2 < 0) return index1;
            return Math.Min(index1, index2);
        }

        public static int IndexOfByteArray(byte[] buffer, byte[] pattern, int startIndex, bool caseSensitive)
        {
            int returnIndex = -1;
            byte firstByte = caseSensitive ? pattern[0] : SafeToLower(pattern[0]);
            byte secondByte = caseSensitive ? firstByte : SafeToUpper(firstByte);
            int i = SafeMinIndex(buffer, firstByte, secondByte, startIndex);

            while (i >= 0 && i <= buffer.Length - pattern.Length)
            {
                bool found = true;
                for (int j = 1; j < pattern.Length; j++)
                {
                    byte firstCmpLHS = buffer[i + j];
                    byte firstCmpRHS = pattern[j];
                    byte secondCmpLHS = caseSensitive ? firstCmpLHS : SafeToUpper(firstCmpLHS);
                    byte secondCmpRHS = caseSensitive ? firstCmpRHS : SafeToUpper(firstCmpRHS);

                    if ((i + j >= buffer.Length) || (firstCmpLHS != firstCmpRHS && secondCmpLHS != secondCmpRHS))
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    returnIndex = i;
                    break;
                }
                startIndex = i + 1;
                i = SafeMinIndex(buffer, firstByte, secondByte, startIndex);
            }
            return returnIndex;
        }
    }
}
