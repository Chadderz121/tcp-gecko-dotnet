using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FTDIUSBGecko;

namespace GeckoApp
{
    public class ExceptionHandler
    {
        private MainForm mainForm;

        public ExceptionHandler(MainForm uMForm)
        {
            mainForm = uMForm;
        }

        public void HandleException(EUSBGeckoException exc)
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke((MethodInvoker)delegate
                {
                    HandleExceptionInternally(exc);
                });
            }
            else
            {
                HandleExceptionInternally(exc);
            }
        }

        private void HandleExceptionInternally(EUSBGeckoException exc)
        {
            Logger.WriteLineTimed("Exception occured!");
            Logger.WriteLine("Message: " + exc.Message);
            Logger.WriteLine("Stack Trace: \r\n" + exc.StackTrace);
            Logger.WriteLine("Inner Exception: " + exc.InnerException);

            // Try to quietly reconnect first
            mainForm.CUSBGecko_Click(mainForm, new EventArgs());
            if (mainForm.Text.Contains("(")) return;

            // If the result has no (, then it we failed, so be loud
            mainForm.DisconnectButton_Click(mainForm, new EventArgs());
            EUSBErrorCode error = exc.ErrorCode;
            String msg = "";
            switch (error)
            {
                case EUSBErrorCode.CheatStreamSizeInvalid: msg = "Cheat stream size is invalid!"; break;
                case EUSBErrorCode.FTDICommandSendError: msg = "Error sending a command to the USB Gecko!"; break;
                case EUSBErrorCode.FTDIInvalidReply: msg = "Received an invalid reply from the USB Gecko!"; break;
                case EUSBErrorCode.FTDIPurgeRxError: msg = "Error occured while purging receive data buffer!"; break;
                case EUSBErrorCode.FTDIPurgeTxError: msg = "Error occured while purging transfer data buffer!"; break;
                case EUSBErrorCode.FTDIQueryError: msg = "Error querying USB Gecko data!"; break;
                case EUSBErrorCode.FTDIReadDataError: msg = "Error reading USB Gecko data!"; break;
                case EUSBErrorCode.FTDIResetError: msg = "Error resetting the USB Gecko connection!"; break;
                case EUSBErrorCode.FTDITimeoutSetError: msg = "Error setting send/receive timeouts!"; break;
                case EUSBErrorCode.FTDITransferSetError: msg = "Error setting transfer buffer sizes!"; break;
                case EUSBErrorCode.noFTDIDevicesFound: msg = "No FTDI devices found! Please make sure your USB Gecko is connected!"; break;
                case EUSBErrorCode.noUSBGeckoFound: msg = "No USB Gecko device found! Please make sure your USB Gecko is connected!"; break;
                case EUSBErrorCode.REGStreamSizeInvalid: msg = "Register stream data invalid!"; break;
                case EUSBErrorCode.TooManyRetries: msg = "Too many retries while attempting to transfer data!"; break;
                default: msg = "An unknown error occured"; break;
            }
            if (MessageBox.Show("During the connection with the USB Gecko an error occured. The error description was: \n\n" +
                                msg + "\n\nDo you want to retry connecting to the USB Gecko?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                mainForm.CUSBGecko_Click(mainForm, new EventArgs());
            }
        }
    }
}
