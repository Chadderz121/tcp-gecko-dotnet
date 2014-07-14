using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace TCPTCPGecko
{
    class tcpconn
    {
        TcpClient client;
        NetworkStream stream;

        public string Host { get; private set; }
        public int Port { get; private set; }

        public tcpconn(string host, int port)
        {
            Host = host;
            Port = port;
            client = null;
            stream = null;
        }

        public void Connect()
        {
            try
            {
                Close();
            }
            catch (Exception) { }
            client = new TcpClient();
            client.NoDelay = true;
            IAsyncResult ar = client.BeginConnect(Host, Port, null, null);
            System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
            try
            {
                if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    client.Close();
                    throw new IOException("Connection timoeut.", new TimeoutException());
                }

                client.EndConnect(ar);
            }
            finally
            {
                wh.Close();
            } 
            stream = client.GetStream();
            stream.ReadTimeout = 10000;
            stream.WriteTimeout = 10000;
        }

        public void Close()
        {
            try
            {
                if (client == null)
                {
                    throw new IOException("Not connected.", new NullReferenceException());
                }
                client.Close();

            }
            catch (Exception) { }
            finally
            {
                client = null;
            }
        }

        public void Purge()
        {
            if (stream == null)
            {
                throw new IOException("Not connected.", new NullReferenceException());
            }
            stream.Flush();
        }

        public void Read(Byte[] buffer, UInt32 nobytes, ref UInt32 bytes_read)
        {
            try
            {
                int offset = 0;
                if (stream == null)
                {
                    throw new IOException("Not connected.", new NullReferenceException());
                }
                bytes_read = 0;
                while (nobytes > 0)
                {
                    int read = stream.Read(buffer, offset, (int)nobytes);
                    if (read >= 0)
                    {
                        bytes_read += (uint)read;
                        offset += read;
                        nobytes -= (uint)read;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (ObjectDisposedException e)
            {
                throw new IOException("Connection closed.", e);
            }
        }

        public void Write(Byte[] buffer, Int32 nobytes, ref UInt32 bytes_written)
        {
            try
            {
                if (stream == null)
                {
                    throw new IOException("Not connected.", new NullReferenceException());
                }
                stream.Write(buffer, 0, nobytes);
                if (nobytes >= 0)
                    bytes_written = (uint)nobytes;
                else
                    bytes_written = 0;
                stream.Flush();
            }
            catch (ObjectDisposedException e)
            {
                throw new IOException("Connection closed.", e);
            }
        }
    }
}
