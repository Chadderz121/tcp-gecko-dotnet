using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

using DWORD = System.UInt32;
using FT_Result = System.UInt32;
using FT_Handle = System.UInt32;

namespace D2XXDirect
{
    public enum FT_STATUS
    {
        FT_OK,
        FT_INVALID_HANDLE,
        FT_DEVICE_NOT_FOUND,
        FT_DEVICE_NOT_OPENED,
        FT_IO_ERROR,
        FT_INSUFFICIENT_RESOURCES,
        FT_INVALID_PARAMETER,
        FT_INVALID_BAUD_RATE,
        FT_DEVICE_NOT_OPENED_FOR_ERASE,
        FT_DEVICE_NOT_OPENED_FOR_WRITE,
        FT_FAILED_TO_WRITE_DEVICE,
        FT_EEPROM_READ_FAILED,
        FT_EEPROM_WRITE_FAILED,
        FT_EEPROM_ERASE_FAILED,
        FT_EEPROM_NOT_PRESENT,
        FT_EEPROM_NOT_PROGRAMMED,
        FT_INVALID_ARGS,
        FT_OTHER_ERROR
    }

    public class D2XXWrapper
    {
        private FT_STATUS ConvertResult(DWORD result)
        {
            // FT_Result Values
            switch (result)
            {
                case 00: return FT_STATUS.FT_OK;
                case 01: return FT_STATUS.FT_INVALID_HANDLE;
                case 02: return FT_STATUS.FT_DEVICE_NOT_FOUND;
                case 03: return FT_STATUS.FT_DEVICE_NOT_OPENED;
                case 04: return FT_STATUS.FT_IO_ERROR;
                case 05: return FT_STATUS.FT_INSUFFICIENT_RESOURCES;
                case 06: return FT_STATUS.FT_INVALID_PARAMETER;
                case 07: return FT_STATUS.FT_INVALID_BAUD_RATE;
                case 08: return FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_ERASE;
                case 09: return FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_WRITE;
                case 10: return FT_STATUS.FT_FAILED_TO_WRITE_DEVICE;
                case 11: return FT_STATUS.FT_EEPROM_READ_FAILED;
                case 12: return FT_STATUS.FT_EEPROM_WRITE_FAILED;
                case 13: return FT_STATUS.FT_EEPROM_ERASE_FAILED;
                case 14: return FT_STATUS.FT_EEPROM_NOT_PRESENT;
                case 15: return FT_STATUS.FT_EEPROM_NOT_PROGRAMMED;
                case 16: return FT_STATUS.FT_INVALID_ARGS;
                default: return FT_STATUS.FT_OTHER_ERROR;
            }
        }
        
        // FT_Open_Ex Flags
        private const UInt32 FT_OPEN_BY_SERIAL_NUMBER = 1;
        private const UInt32 FT_OPEN_BY_DESCRIPTION = 2;
        private const UInt32 FT_OPEN_BY_LOCATION = 4;

        // FT_List_Devices Flags
        private const UInt32 FT_LIST_NUMBER_ONLY = 0x80000000;
        private const UInt32 FT_LIST_BY_INDEX = 0x40000000;
        private const UInt32 FT_LIST_ALL = 0x20000000;
        // Baud Rate Selection
        private const UInt32 FT_BAUD_300 = 300;
        private const UInt32 FT_BAUD_600 = 600;
        private const UInt32 FT_BAUD_1200 = 1200;
        private const UInt32 FT_BAUD_2400 = 2400;
        private const UInt32 FT_BAUD_4800 = 4800;
        private const UInt32 FT_BAUD_9600 = 9600;
        private const UInt32 FT_BAUD_14400 = 14400;
        private const UInt32 FT_BAUD_19200 = 19200;
        private const UInt32 FT_BAUD_38400 = 38400;
        private const UInt32 FT_BAUD_57600 = 57600;
        private const UInt32 FT_BAUD_115200 = 115200;
        private const UInt32 FT_BAUD_230400 = 230400;
        private const UInt32 FT_BAUD_460800 = 460800;
        private const UInt32 FT_BAUD_921600 = 921600;
        // Data Bits Selection
        private const UInt32 FT_DATA_BITS_7 = 7;
        private const UInt32 FT_DATA_BITS_8 = 8;
        // Stop Bits Selection
        private const UInt32 FT_STOP_BITS_1 = 0;
        private const UInt32 FT_STOP_BITS_2 = 2;
        // Parity Selection
        private const UInt32 FT_PARITY_NONE = 0;
        private const UInt32 FT_PARITY_ODD = 1;
        private const UInt32 FT_PARITY_EVEN = 2;
        private const UInt32 FT_PARITY_MARK = 3;
        private const UInt32 FT_PARITY_SPACE = 4;
        // Flow Control Selection
        private const UInt32 FT_FLOW_NONE = 0x0000;
        private const UInt32 FT_FLOW_RTS_CTS = 0x0100;
        private const UInt32 FT_FLOW_DTR_DSR = 0x0200;
        private const UInt32 FT_FLOW_XON_XOFF = 0x0400;
        // Purge Commands
        private const UInt32 FT_PURGE_RX = 1;
        private const UInt32 FT_PURGE_TX = 2;
        // Notification Events
        private const UInt32 FT_EVENT_RXCHAR = 1;
        private const UInt32 FT_EVENT_MODEM_STATUS = 2;
        // Modem Status
        private const UInt32 CTS = 0x10;
        private const UInt32 DSR = 0x20;
        private const UInt32 RI = 0x40;
        private const UInt32 DCD = 0x80;


        // IO Buffer Sizes
        public const UInt32 FT_In_Buffer_Size = 0x10000;    // 64k
        public const UInt32 FT_In_Buffer_Index = FT_In_Buffer_Size - 1;
        public const UInt32 FT_Out_Buffer_Size = 0x10000;    // 64k
        public const UInt32 FT_Out_Buffer_Index = FT_Out_Buffer_Size - 1;
        // DLL Name
        public const String FT_DLL_Name = "FTD2XX.DLL";

        private FT_Handle handle;

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_OpenEx(IntPtr pvArg1, DWORD dwFlags, ref FT_Handle ftHandle);

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_Close(FT_Handle ftHandle);

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_ResetDevice(FT_Handle ftHandle);

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_ListDevices(IntPtr pvArg1, IntPtr pvArg2, UInt32 dwFlags);

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_SetTimeouts(FT_Handle ftHandle, DWORD dwReadTimeout, DWORD dwWriteTimeout);

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_SetLatencyTimer(FT_Handle ftHandle, Byte ucTimer);

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_SetUSBParameters(FT_Handle ftHandle, DWORD dwInTransferSize, DWORD dwOutTransferSize);

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_Purge(FT_Handle ftHandle, DWORD uEventCh);

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_Read(FT_Handle ftHandle, IntPtr lpBuffer, DWORD dwBytesToRead, ref UInt32 lpdwBytesReturned);

        [DllImport(FT_DLL_Name)]
        private static extern FT_Result FT_Write(FT_Handle ftHandle, IntPtr lpBuffer, DWORD dwBytesToWrite, ref UInt32 lpdwBytesWritten);

        public D2XXWrapper()
        {
            handle = 0;
        }

        public FT_STATUS OpenBySerialNumber(String serial)
        {
            Byte[] serBytes = Encoding.ASCII.GetBytes(serial);

            GCHandle pin = GCHandle.Alloc(serBytes, GCHandleType.Pinned);
            
            FT_STATUS result = ConvertResult(FT_OpenEx(pin.AddrOfPinnedObject(), FT_OPEN_BY_SERIAL_NUMBER, ref handle));

            pin.Free();

            return result;
        }

        public FT_STATUS GetNumberOfDevices(ref UInt32 numberOfDevices)
        {
            Byte[] arg1 = new Byte[4];

            GCHandle pin = GCHandle.Alloc(arg1, GCHandleType.Pinned);
            GCHandle pin2 = GCHandle.Alloc(null, GCHandleType.Pinned);

            DWORD result = FT_ListDevices(pin.AddrOfPinnedObject(), pin2.AddrOfPinnedObject(), FT_LIST_NUMBER_ONLY);

            pin2.Free();
            pin.Free();

            numberOfDevices = BitConverter.ToUInt32(arg1,0);
            return ConvertResult(result);
        }

        public FT_STATUS SetTimeouts(UInt32 readTimeout, UInt32 writeTimeout)
        {
            DWORD result = FT_SetTimeouts(handle, readTimeout, writeTimeout);
            return ConvertResult(result);
        }

        public FT_STATUS SetLatencyTimer(Byte ucTimer)
        {
            DWORD result = FT_SetLatencyTimer(handle, ucTimer);
            return ConvertResult(result);
        }

        public FT_STATUS InTransferSize(UInt32 transfer)
        {
            DWORD result = FT_SetUSBParameters(handle, transfer, 0);
            return ConvertResult(result);
        }

        public FT_STATUS Close()
        {
            DWORD result = FT_Close(handle);
            FT_STATUS sRes = ConvertResult(result);
            if (sRes == FT_STATUS.FT_OK)
                handle = 0;
            return sRes;
        }

        public FT_STATUS ResetDevice()
        {
            DWORD result = FT_ResetDevice(handle);
            return ConvertResult(result);
        }

        public FT_STATUS Purge(UInt32 eventCh)
        {
            DWORD result = FT_Purge(handle, eventCh);
            return ConvertResult(result);
        }

        public FT_STATUS Read(Byte[] buffer, UInt32 nobytes, ref UInt32 bytes_read)
        {
            GCHandle pin = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            DWORD result = FT_Read(handle, pin.AddrOfPinnedObject(), nobytes, ref bytes_read);
            pin.Free();
            return ConvertResult(result);
        }

        public FT_STATUS Write(Byte[] buffer, Int32 nobytes, ref UInt32 bytes_written)
        {
            UInt32 sendBytes = (UInt32)nobytes;
            GCHandle pin = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            DWORD result = FT_Write(handle, pin.AddrOfPinnedObject(), sendBytes, ref bytes_written);
            pin.Free();
            return ConvertResult(result);
        }
    }
}
