using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using TCPTCPGecko;

namespace GeckoApp
{
    public class ExceptionHandler
    {
        private MainForm mainForm;

        public ExceptionHandler(MainForm uMForm)
        {
            mainForm = uMForm;
        }

        public void HandleException(ETCPGeckoException exc)
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

        private void HandleExceptionInternally(ETCPGeckoException exc)
        {
            Logger.WriteLineTimed("Exception occured!");
            Logger.WriteLine("Message: " + exc.Message);
            Logger.WriteLine("Stack Trace: \r\n" + exc.StackTrace);
            Logger.WriteLine("Inner Exception: " + exc.InnerException);

            // Try to quietly reconnect first
            mainForm.CTCPGecko_Click(mainForm, new EventArgs());
            if (mainForm.Text.Contains("(")) return;

            // If the result has no (, then it we failed, so be loud
            mainForm.DisconnectButton_Click(mainForm, new EventArgs());
            ETCPErrorCode error = exc.ErrorCode;
            String msg = "";
            switch (error)
            {
                case ETCPErrorCode.CheatStreamSizeInvalid: msg = "Cheat stream size is invalid!"; break;
                case ETCPErrorCode.FTDICommandSendError: msg = "Error sending a command to the TCP Gecko!"; break;
                case ETCPErrorCode.FTDIInvalidReply: msg = "Received an invalid reply from the TCP Gecko!"; break;
                case ETCPErrorCode.FTDIPurgeRxError: msg = "Error occured while purging receive data buffer!"; break;
                case ETCPErrorCode.FTDIPurgeTxError: msg = "Error occured while purging transfer data buffer!"; break;
                case ETCPErrorCode.FTDIQueryError: msg = "Error querying TCP Gecko data!"; break;
                case ETCPErrorCode.FTDIReadDataError: msg = "Error reading TCP Gecko data!"; break;
                case ETCPErrorCode.FTDIResetError: msg = "Error resetting the TCP Gecko connection!"; break;
                case ETCPErrorCode.FTDITimeoutSetError: msg = "Error setting send/receive timeouts!"; break;
                case ETCPErrorCode.FTDITransferSetError: msg = "Error setting transfer buffer sizes!"; break;
                case ETCPErrorCode.noFTDIDevicesFound: msg = "No FTDI devices found! Please make sure your TCP Gecko is connected!"; break;
                case ETCPErrorCode.noTCPGeckoFound: msg = "No TCP Gecko device found! Please make sure your TCP Gecko is connected!"; break;
                case ETCPErrorCode.REGStreamSizeInvalid: msg = "Register stream data invalid!"; break;
                case ETCPErrorCode.TooManyRetries: msg = "Too many retries while attempting to transfer data!"; break;
                default: msg = "An unknown error occured"; break;
            }
            if (MessageBox.Show("During the connection with the TCP Gecko an error occured. The error description was: \n\n" +
                                msg + "\n\nDo you want to retry connecting to the TCP Gecko?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                mainForm.CTCPGecko_Click(mainForm, new EventArgs());
            }
        }
    }
}
