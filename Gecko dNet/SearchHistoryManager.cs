using System;
using System.Collections.Generic;
using System.Text;
using Ionic.Zip;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using FTDIUSBGecko;

namespace GeckoApp
{
    public struct SearchItem
    {
        public List<UInt32> resultsList;
        public Dump searchDump;
        public int index;
    }

    public class SearchHistoryManager
    {
        private bool backgroundWriting;
        public bool BackgroundWriting
        {
            get { return backgroundWriting; }
        }

        public SearchHistoryManager()
        {
            backgroundWriting = false;
        }

        public void SaveSearchBackground(int index, List<UInt32> resultsList, Dump searchDump)
        {
            SearchItem foo = new SearchItem();
            // make a copy in case the user starts deleting, sorting, etc the original list
            foo.resultsList = new List<uint>(resultsList);
            foo.searchDump = searchDump;
            foo.index = index;

            // block in the event of a rapid-fire double call
            while (backgroundWriting) ;

            Thread zipThread = new Thread(new ParameterizedThreadStart(SaveSearchBackground));

            // Set the state before calling the thread
            backgroundWriting = true;

            zipThread.Start(foo);
        }

        public void SaveSearchBackground(object searchItem)
        {
            SearchItem foo = (SearchItem)searchItem;

            SaveSearch(foo.index, foo.resultsList, foo.searchDump);

            // clear the state when the thread is done
            backgroundWriting = false;
        }

        public void SaveHistory(string path, int DumpNum, SearchSize size)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
                zip.AddDirectory("DumpHistory");
                zip.Comment = DumpNum.ToString() + ":" + size.ToString();
                
                zip.Save(path);
            }
        }

        public void LoadHistory(string path, out int DumpNum, out SearchSize size)
        {
            int retVal;
            using (ZipFile zip = ZipFile.Read(path))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract("DumpHistory", ExtractExistingFileAction.OverwriteSilently);  // overwrite == true
                }
                string comment = zip.Comment;
                string[] split = comment.Split(':');
                DumpNum = Convert.ToInt32(split[0]);
                switch (split[1])
                {
                    case "Bit16": size = SearchSize.Bit16; break;
                    case "Bit8": size = SearchSize.Bit8; break;
                    case "Single": size = SearchSize.Single; break;
                    case "Bit32": size = SearchSize.Bit32; break;
                    default: size = SearchSize.Bit32; break;
                }
                //switch (
                //retVal = zip.Comment;
            }
            //return retVal;
        }
        
        public void SaveSearch(int index, List<UInt32> resultsList, Dump searchDump)
        {
            // TODO subdir?  check file exists?
            SaveSearch("DumpHistory\\DumpHistory" + index + ".zip", resultsList, searchDump);
        }

        public void SaveSearch(string filepath, List<UInt32> resultsList, Dump searchDump)
        {
            ZipOutputStream outstream = new ZipOutputStream(filepath);
            outstream.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed;
            BinaryFormatter formatter = new BinaryFormatter();

            // First entry is the dump
            outstream.PutNextEntry("dump");

            //DateTime start = Logger.WriteLineTimedStarted("compressing search dump");

            // Must put the addresses first, so that it can derive the right number of bytes to read for the dump
            formatter.Serialize(outstream, searchDump.StartAddress);
            formatter.Serialize(outstream, searchDump.EndAddress);
            outstream.Write(searchDump.mem, 0, (int)(searchDump.EndAddress - searchDump.StartAddress));

            //Logger.WriteLineTimedFinished("compressing search dump", start);

            // Second entry is the list
            outstream.PutNextEntry("list");

            //start = Logger.WriteLineTimedStarted("compressing search list");

            formatter.Serialize(outstream, resultsList);

            //Logger.WriteLineTimedFinished("compressing search list", start);

            outstream.Close();
            outstream.Dispose();
        }

        public Dump LoadSearchDump(int index)
        {
            return LoadSearchDump("DumpHistory\\DumpHistory" + index + ".zip");
        }

        public Dump LoadSearchDump(string filepath)
        {
            // spin while background writing to prevent us from reading a file that has yet to be written
            while (BackgroundWriting) ;

            ZipInputStream instream = new ZipInputStream(filepath);
            BinaryFormatter formatter = new BinaryFormatter();

            // First entry is the dump
            instream.GetNextEntry();
            Dump searchDump = new Dump((uint)formatter.Deserialize(instream), (uint)formatter.Deserialize(instream));
            instream.Read(searchDump.mem, 0, (int)(searchDump.EndAddress - searchDump.StartAddress));

            instream.Close();
            instream.Dispose();

            return searchDump;
        }

        public List<UInt32> LoadSearchList(int index)
        {
            return LoadSearchList("DumpHistory\\DumpHistory" + index + ".zip");
        }

        public List<UInt32> LoadSearchList(string filepath)
        {
            // spin while background writing to prevent us from reading a file that has yet to be written
            while (BackgroundWriting) ;

            ZipInputStream instream = new ZipInputStream(filepath);
            BinaryFormatter formatter = new BinaryFormatter();

            // First entry is the dump
            instream.GetNextEntry();

            // Second entry is the list
            instream.GetNextEntry();

            List<UInt32> searchList = (List<UInt32>)formatter.Deserialize(instream);

            instream.Close();
            instream.Dispose();
        
            return searchList;
        }
    }

    public class SearchHistoryItem
    {
        private List<UInt32> resultsList;
        private Dump searchDump;
        private bool backgroundWriting;


        public SearchHistoryItem()
        {
            resultsList = null;
            searchDump = null;
            backgroundWriting = false;
        }

        public bool BackgroundWriting
        {
            get { return backgroundWriting; }
        }

        public void WriteCompressedZipBackground(string filepath)
        {
            Thread zipThread = new Thread(new ParameterizedThreadStart(WriteCompressedZipBackgroundObj));

            backgroundWriting = true;

            zipThread.Start(filepath);
        }

        public void WriteCompressedZipBackgroundObj(object filepath)
        {
            string path = filepath as string;

            WriteCompressedZip(path);
            backgroundWriting = false;
        }

        public void WriteCompressedZip(string filepath)
        {
            ZipOutputStream outstream = new ZipOutputStream(filepath);
            outstream.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed;
            BinaryFormatter formatter = new BinaryFormatter();
            outstream.PutNextEntry("dump");


            //Logger.WriteLineTimed("Started compressing search dump");
            DateTime startTime = DateTime.Now;

            formatter.Serialize(outstream, searchDump.StartAddress);
            formatter.Serialize(outstream, searchDump.EndAddress);
            outstream.Write(searchDump.mem, 0, (int)(searchDump.EndAddress - searchDump.StartAddress));

            DateTime endTime = DateTime.Now;
            //Logger.WriteLineTimed("Finished compressing search dump in " + (new TimeSpan(endTime.Ticks - startTime.Ticks).TotalSeconds));


            outstream.PutNextEntry("list");

            //Logger.WriteLineTimed("Started copying search list");
            startTime = DateTime.Now;

            List<UInt32> copy = new List<uint>(resultsList);

            endTime = DateTime.Now;
            //Logger.WriteLineTimed("Finished copying search list in " + (new TimeSpan(endTime.Ticks - startTime.Ticks).TotalSeconds));


            //Logger.WriteLineTimed("Started compressing search list");
            startTime = DateTime.Now;

            formatter.Serialize(outstream, resultsList);

            endTime = DateTime.Now;
            //Logger.WriteLineTimed("Finished compressing search list in " + (new TimeSpan(endTime.Ticks - startTime.Ticks).TotalSeconds));


            outstream.Close();
            outstream.Dispose();
        }

        public void ReadCompressedZip(string filepath)
        {
            while (BackgroundWriting) ;

            ZipInputStream instream = new ZipInputStream(filepath);
            BinaryFormatter formatter = new BinaryFormatter();
            instream.GetNextEntry();
            searchDump = new FTDIUSBGecko.Dump((uint)formatter.Deserialize(instream), (uint)formatter.Deserialize(instream));
            instream.Read(searchDump.mem, 0, (int)(searchDump.EndAddress - searchDump.StartAddress));

            instream.GetNextEntry();
            resultsList = (System.Collections.Generic.List<UInt32>)formatter.Deserialize(instream);

            instream.Close();
            instream.Dispose();
        }
    }
}
