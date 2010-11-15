#define BUILD_STRUCT

using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace libftdi
{
	[StructLayout(LayoutKind.Sequential)]
    public struct ftdi_context
    {
        public IntPtr usb_dev_handle;   // actually usb_dev_handle*
        public int usb_read_timeout;
        public int usb_write_timeout;
        public int ftdi_chip_type;      // actually enum
        public int baudrate;
        public byte bitbang_enabled;
        public IntPtr readbuffer;       // actually byte*
        public uint readbuffer_offset;
        public uint readbuffer_remaining;
        public uint readbuffer_chunksize;
        public uint writebuffer_chunksize;
        public int interfce;
        public int index;
        public int in_ep;
        public int out_ep;
        public byte bitbang_mode;
        public int eeprom_size;
        public IntPtr error_str;        // actually char*
        public IntPtr async_usb_buffer; // actually char*
        public uint async_usb_buffer_size;
	}

    public enum FT_STATUS
    {
        FT_OK,
        FT_FAIL
    }

    public class LFTDI
    {
        [DllImport("ftdi")]
        private static extern int ftdi_init(ref ftdi_context ftdi);

        [DllImport("ftdi")]
        private static extern IntPtr ftdi_new();

        [DllImport("ftdi")]
        private static extern int ftdi_deinit(ref ftdi_context ftdi);

        [DllImport("ftdi")]
        private static extern int ftdi_usb_open(ref ftdi_context ftdi, int vendor, int product);

        [DllImport("ftdi")]
        private static extern int ftdi_usb_close(ref ftdi_context ftdi);

        [DllImport("ftdi")]
        private static extern int ftdi_usb_reset(ref ftdi_context ftdi);
        
        [DllImport("ftdi")]
        private static extern int ftdi_read_data_set_chunksize(
            ref ftdi_context ftdi, UInt32 chunksize);
        
        [DllImport("ftdi")]
        private static extern int ftdi_write_data_set_chunksize(
            ref ftdi_context ftdi, UInt32 chunksize);

        [DllImport("ftdi")]
        private static extern int ftdi_usb_purge_rx_buffer(ref ftdi_context ftdi);

        [DllImport("ftdi")]
        private static extern int ftdi_usb_purge_tx_buffer(ref ftdi_context ftdi);

        [DllImport("ftdi")]
        private static extern int ftdi_read_chipid(ref ftdi_context ftdi, ref int chipid);

        [DllImport("ftdi")]
        private static extern int ftdi_read_data(ref ftdi_context ftdi, Byte[] buf, int size);

        [DllImport("ftdi")]
        private static extern int ftdi_write_data(ref ftdi_context ftdi, Byte[] buf, int size);

#if BUILD_STRUCT
		private ftdi_context FFTHandle;
#else
		private unsafe IntPtr PFFTHandle;
#endif
	
		public LFTDI ()
		{
        }

        public FT_STATUS GetNumberOfDevices(ref UInt32 deviceCount)
        {
            deviceCount=1;
            return FT_STATUS.FT_OK;
        }

        public FT_STATUS OpenBySerialNumber(String serial)
        {

//			fixed (ftdi_context *foo = &FFTHandle)
//			{
//				ftdi_context *foo = (ftdi_context*)ftdi_new();
//			}
//			FFTHandle = *foo;
			

//			FFTHandle = *((ftdi_context*)ftdi_new());


			int status;
			int retVal;
			int chipid = 0, origChipID = 0;
			
#if BUILD_STRUCT
			status = ftdi_init(ref FFTHandle);
			status = ftdi_usb_open(ref FFTHandle, 0x0403, 0x6001);
			retVal = status;
            if (status == 0)
            {
                status = ftdi_read_chipid(ref FFTHandle, ref origChipID);
	#if DEBUG
				System.Console.WriteLine(origChipID.ToString("X"));
	#endif
            }
#else
			unsafe {
				PFFTHandle = ftdi_new();
				status = ftdi_usb_open(ref (*(((ftdi_context*)PFFTHandle))), 0x0403, 0x6001);
				retVal = status;
                if (status == 0)
                {
	        	    status = ftdi_read_chipid(ref (*(((ftdi_context*)PFFTHandle))), ref origChipID);
                    System.Console.WriteLine(origChipID.ToString("X"));
                }
        	}
#endif



            if (retVal == 0)
                return FT_STATUS.FT_OK;
            else
                return FT_STATUS.FT_FAIL;
        }

        public FT_STATUS SetTimeouts(UInt32 rT, UInt32 wt)
        {
            return FT_STATUS.FT_OK;
        }

        public FT_STATUS InTransferSize(UInt32 transfer) {
			int status;
#if BUILD_STRUCT
            status = ftdi_read_data_set_chunksize(ref FFTHandle, transfer);
#else
	        unsafe { status = ftdi_read_data_set_chunksize(ref (*(((ftdi_context*)PFFTHandle))), transfer); }
#endif

            if (status != 0)
                return FT_STATUS.FT_FAIL;

#if BUILD_STRUCT
            status = ftdi_write_data_set_chunksize(ref FFTHandle, transfer);
#else
			unsafe { status = ftdi_write_data_set_chunksize(ref (*(((ftdi_context*)PFFTHandle))), transfer); }
#endif
                                
			
            if (status != 0)
                return FT_STATUS.FT_FAIL;

            return FT_STATUS.FT_OK;
        }

        public FT_STATUS ResetDevice()
        {
			int status;
			
#if BUILD_STRUCT
            status = ftdi_usb_reset(ref FFTHandle);
#else
			unsafe { status = ftdi_usb_reset(ref (*(((ftdi_context*)PFFTHandle)))); }
#endif
			
            if(status == 0)
                return FT_STATUS.FT_OK;
            else
                return FT_STATUS.FT_FAIL;
        }

        public FT_STATUS Purge(UInt32 buffer)
        {
			int status;
			
#if BUILD_STRUCT
            status = ftdi_usb_reset(ref FFTHandle);
			if (buffer == 1)
        		status = ftdi_usb_purge_rx_buffer(ref FFTHandle);
        	else
        		status = ftdi_usb_purge_tx_buffer(ref FFTHandle);
#else
			unsafe { 
				status = ftdi_usb_reset(ref (*(((ftdi_context*)PFFTHandle))));
				if (buffer == 1)
	        		status = ftdi_usb_purge_rx_buffer(ref (*(((ftdi_context*)PFFTHandle))));
            	else
 	        		status = ftdi_usb_purge_tx_buffer(ref (*(((ftdi_context*)PFFTHandle))));
 	        }
#endif
			
            if (status == 0)
                return FT_STATUS.FT_OK;
            else
                return FT_STATUS.FT_FAIL;            
        }

        public FT_STATUS Read(Byte[] buffer, UInt32 nobytes, ref UInt32 bytes_read)
        {
            int read = 0, loopCounter = 0;
			const int loopLimit = 100;
			
			// A return value of 0 means nothing came in yet...
			// So we have to loop for a while
			while (read == 0 && loopCounter < loopLimit)
			{
				if (loopCounter > 1)
				{
					System.Threading.Thread.Sleep(1);	
				}
				loopCounter++;
#if BUILD_STRUCT
				read = ftdi_read_data(ref FFTHandle, buffer, (int)nobytes);
#else
				unsafe { read = ftdi_read_data(ref (*(((ftdi_context*)PFFTHandle))), buffer, (int)nobytes); }
#endif
			}
			bytes_read = (UInt32)read;
#if DEBUG
			System.Console.WriteLine("LFTDI::Read() " + read + " bytes");
#endif
            if (bytes_read <= 0)
			{				
            	return FT_STATUS.FT_FAIL;
			}
            else
                return FT_STATUS.FT_OK;
        }

        public FT_STATUS Write(Byte[] buffer, Int32 nobytes, ref UInt32 bytes_written)
        {
            int write;
#if BUILD_STRUCT
			write = ftdi_write_data(ref FFTHandle, buffer, (int)nobytes);
#else
			unsafe { write = ftdi_write_data(ref (*(((ftdi_context*)PFFTHandle))), buffer, (int)nobytes); }
#endif
            bytes_written = (UInt32)write;
#if DEBUG
			System.Console.WriteLine("LFTDI::Write() " + write + " bytes");
#endif
           if (bytes_written <= 0)
                return FT_STATUS.FT_FAIL;
            else
                return FT_STATUS.FT_OK;
        }

        public FT_STATUS Close()
        {
            int status;
#if BUILD_STRUCT
            status = ftdi_usb_close(ref FFTHandle);
#else
			unsafe { status = ftdi_usb_close(ref (*(((ftdi_context*)PFFTHandle)))); }
#endif
            if (status != 0)
                return FT_STATUS.FT_FAIL;

#if BUILD_STRUCT
            status = ftdi_deinit(ref FFTHandle);
#else
			unsafe { status = ftdi_deinit(ref (*(((ftdi_context*)PFFTHandle)))); }
#endif
            if (status != 0)
                return FT_STATUS.FT_FAIL;

            return FT_STATUS.FT_OK;
        }
    }
}
