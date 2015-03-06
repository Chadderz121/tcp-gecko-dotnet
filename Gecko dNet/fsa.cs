using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Windows.Forms;
using TCPTCPGecko;

using IconHelper;
using System.ComponentModel;

namespace GeckoApp
{
    public class subFile:IComparable<subFile>
    {
        private String PName;
        private int PTag;
        private fileStructure PParent;
        public String name { 
            get { return PName; }
            set { PName = value; }
        }
        public int tag { get { return PTag; } }
        public fileStructure parent { get { return PParent; } }
        public String Path { get { return parent.Path + "/" + name; } }
        public uint Length { get; private set; }

        public subFile(String name, int tag, uint length, fileStructure parent)
        {
            PName = name;
            PTag = tag;
            PParent = parent;
            Length = length;
        }

        public int CompareTo(subFile other)
        {
            return String.Compare(this.name, other.name);
        }
    }

    public class fileStructure:IComparable<fileStructure>
    {        
        private String PName;
        private int PTag;
        private fileStructure PParent;
        List<fileStructure> subFolders;
        List<subFile> subFiles;
        public String name { 
            get { return PName; }
            set { PName = value; }
        }
        public String Path { get { return (parent == null ? "" : parent.Path) + "/" + name; } }
        public int tag { get { return PTag; } }
        public fileStructure parent { get { return PParent; } }

        public IEnumerable<fileStructure> GetFolders()
        {
            return subFolders;
        }
        public IEnumerable<subFile> GetFiles()
        {
            return subFiles;
        }

        private fileStructure(String name,int tag,fileStructure parent)
        {
            PName = name;
            PTag = tag;
            PParent = parent;
            subFiles = new List<subFile>();
            subFolders = new List<fileStructure>();
        }

        public fileStructure(String name, int tag) : this(name,tag,null)
        { }

        public fileStructure addSubFolder(String name, int tag)
        {
            fileStructure nFS = new fileStructure(name, tag, this);
            subFolders.Add(nFS);
            return nFS;
        }

        public void addFile(String name, int tag, uint length)
        {
            subFile nSF = new subFile(name, tag, length, this);
            subFiles.Add(nSF);
        }

        public int CompareTo(fileStructure other)
        {
            return String.Compare(this.name, other.name);
        }

        public void Sort()
        {
            subFolders.Sort();
            subFiles.Sort();
            foreach (fileStructure nFS in subFolders)
                nFS.Sort();
        }

        public void ToTreeView(TreeView tv)
        {
            tv.Nodes.Clear();
            TreeNode root = tv.Nodes.Add(this.name);
            TreeNode subnode;
            foreach (fileStructure nFS in subFolders)
            {
                subnode = root.Nodes.Add(nFS.name);
                subnode.ImageIndex = 0;
                subnode.SelectedImageIndex = 1;
                subnode.Tag = nFS;
                nFS.ToTreeNode(subnode);
            }
            foreach (subFile nSF in subFiles)
            {
                subnode = root.Nodes.Add(nSF.name);
                subnode.ImageIndex = 2;
                subnode.SelectedImageIndex = 2;
                subnode.Tag = nSF;
            }
            if (subFiles.Count == 0 && subFolders.Count == 0)
            {
                subnode = root.Nodes.Add("(empty)");
                subnode.ImageIndex = 2;
                subnode.SelectedImageIndex = 2;
                subnode.Tag = null;
            }
        }

        private void ToTreeNode(TreeNode tn)
        {
            TreeNode subnode;
            foreach (fileStructure nFS in subFolders)
            {
                subnode = tn.Nodes.Add(nFS.name);
                subnode.Tag = nFS;
                subnode.ImageIndex = 0;
                subnode.SelectedImageIndex = 1;
                nFS.ToTreeNode(subnode);
            }
            foreach (subFile nSF in subFiles)
            {
                subnode = tn.Nodes.Add(nSF.name);
                subnode.ImageIndex = 2;
                subnode.SelectedImageIndex = 2;
                subnode.Tag = nSF;
            }
            if (subFiles.Count == 0 && subFolders.Count == 0)
            {
                subnode = tn.Nodes.Add("(empty)");
                subnode.ImageIndex = 2;
                subnode.SelectedImageIndex = 2;
                subnode.Tag = null;
            }
        }
    }

    public class fsaEntry
    {
        public UInt32 dataAddress;
        public UInt32 nameOffset;
        public UInt32 offset;
        public UInt32 entries;

        public UInt32 nameAddress;

        public fsaEntry(UInt32 UDataAddress, UInt32 UNameOffset, UInt32 UOffset,
            UInt32 UEntries, UInt32 UNameAddress)
        {
            dataAddress = UDataAddress;
            nameOffset = UNameOffset;
            offset = UOffset;
            entries = UEntries;
            nameAddress = UNameAddress;
        }
    }

    public class FSA
    {
        private TCPGecko gecko;
        private TreeView treeView;
        private fileStructure root;
        private TextBox fileSwapCode;
        private ToolStripMenuItem extractToolStripMenuItem;
        
        private ImageList imgList;

        private ExceptionHandler exceptionHandling;

        private int selectedFile;
        private String selFile;

        public FSA(TCPGecko UGecko, TreeView UTreeView, ToolStripMenuItem UExtractToolStripMenuItem, TextBox UFileSwapCode, ExceptionHandler UExceptionHandling)
        {
            exceptionHandling = UExceptionHandling;
            imgList = new ImageList();
#if !MONO
            System.Drawing.Icon ni = IconReader.GetFolderIcon(IconReader.IconSize.Small,
                IconReader.FolderType.Closed);
            imgList.Images.Add(ni);
            ni = IconReader.GetFolderIcon(IconReader.IconSize.Small,
                IconReader.FolderType.Open);
            imgList.Images.Add(ni);
            ni = IconReader.GetFileIcon("?.?", IconReader.IconSize.Small, false);
            imgList.Images.Add(ni);
#endif
            treeView = UTreeView;
            treeView.ImageList = imgList;
            treeView.NodeMouseClick += TreeView_NodeMouseClick;
            treeView.AfterSelect += treeView_AfterSelect;
            treeView.ContextMenuStrip.Opening += ContextMenuStrip_Opening;

            extractToolStripMenuItem = UExtractToolStripMenuItem;
            extractToolStripMenuItem.Click += extractToolStripMenuItem_Click;

            gecko = UGecko;

            fileSwapCode = UFileSwapCode;

            selectedFile = -1;
        }

        private String ReadString(Stream inputStream)
        {
            Byte[] buffer = new Byte[1];
            String result="";
            do
            {
                inputStream.Read(buffer, 0, 1);
                if (buffer[0] != 0)
                    result += (Char)buffer[0];
            } while (buffer[0] != 0);
            //result += " ";

            do
            {
                inputStream.Read(buffer, 0, 1);
                if (buffer[0] == 0)
                    result += " ";
            } while (buffer[0] == 0);
            
            return result;
        }

        public void DumpTree()
        {
            DumpTree("content");
        }
        public void DumpTree(params String[] folders)
        {
            UInt32 FSInit;
            UInt32 FSAddClient;
            UInt32 FSDelClient;
            UInt32 FSInitCmdBlock;
            UInt32 FSOpenDir;
            UInt32 FSCloseDir;
            UInt32 FSReadDir;
            UInt32 memalign;
            UInt32 free;
            switch (gecko.OsVersionRequest())
            {
                case 400:
                case 410:
                    FSInit = 0x01060d70;
                    FSAddClient = 0x01061290;
                    FSDelClient = 0x0106129c;
                    FSInitCmdBlock = 0x01061498;
                    FSOpenDir = 0x01066f3c;
                    FSCloseDir = 0x01066fac;
                    FSReadDir = 0x0106702c;
                    memalign = gecko.peek(0x10049edc);
                    free = gecko.peek(0x100adc2c);
                    break;
                case 500:
                case 510:
                    FSInit = 0x010666fc;
                    FSAddClient = 0x01066d80;
                    FSDelClient = 0x01066d8c;
                    FSInitCmdBlock = 0x01066fec;
                    FSOpenDir = 0x0106db58;
                    FSCloseDir = 0x0106dbc8;
                    FSReadDir = 0x0106dc48;
                    memalign = gecko.peek(0x1004e2d0);
                    free = gecko.peek(0x100b41fc);
                    break;
                default:
                    MessageBox.Show("Unsupported Wii U OS version.", "Version mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            try
            {
                UInt32 ret;
                ret = gecko.rpc(FSInit);

                UInt32 pClient = gecko.rpc(memalign, 0x1700, 0x20);
                if (pClient == 0) goto noClient;
                UInt32 pCmd = gecko.rpc(memalign, 0xA80, 0x20);
                if (pCmd == 0) goto noCmd;

                ret = gecko.rpc(FSAddClient, pClient, 0);
                ret = gecko.rpc(FSInitCmdBlock, pCmd);

                UInt32 pDh = gecko.rpc(memalign, 4, 4);
                if (pDh == 0) goto noDh;
                UInt32 pPath = gecko.rpc(memalign, 0x200, 0x20);
                if (pPath == 0) goto noPath;
                UInt32 pBuf = gecko.rpc(memalign, 0x200, 0x20);
                if (pBuf == 0) goto noBuf;

                root = new fileStructure("vol", -1);
                Queue<fileStructure> scanQueue = new Queue<fileStructure>();
                foreach (String item in folders)
                {
                    scanQueue.Enqueue(root.addSubFolder(item, -1));
                }
                while (scanQueue.Count > 0)
                {
                    fileStructure current = scanQueue.Dequeue();
                    using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(current.Path + "\0")))
                    {
                        gecko.Upload(pPath, pPath + (uint)ms.Length, ms);
                    }


                    ret = gecko.rpc(FSOpenDir, pClient, pCmd, pPath, pDh, 0xffffffff);
                    if (ret != 0) goto noDir;

                    UInt32 dh = gecko.peek(pDh);

                    do
                    {
                        ret = gecko.rpc(FSReadDir, pClient, pCmd, dh, pBuf, 0xffffffff);
                        if (ret != 0) break;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            gecko.Dump(pBuf, pBuf + 0x200, ms);

                            Byte[] data = ms.ToArray();
                            UInt32 attr = ByteSwap.Swap(BitConverter.ToUInt32(data, 0));
                            UInt32 size = ByteSwap.Swap(BitConverter.ToUInt32(data, 8));

                            String name = new String(Encoding.ASCII.GetChars(data, 0x64, 0x100));
                            name = name.Remove(name.IndexOf('\0'));

                            if ((attr & 0x80000000) != 0)
                            {
                                scanQueue.Enqueue(current.addSubFolder(name, -1));
                            }
                            else
                            {
                                current.addFile(name, -1, size);
                            }
                        }
                    } while (true);

                    gecko.rpc(FSCloseDir, pClient, pCmd, dh, 0);
                noDir:
                    continue;
                }

                gecko.rpc(free, pBuf);
            noBuf:
                gecko.rpc(free, pPath);
            noPath:
                gecko.rpc(free, pDh);
            noDh:

                ret = gecko.rpc(FSDelClient, pClient);

                gecko.rpc(free, pCmd);
            noCmd:
                gecko.rpc(free, pClient);
            noClient:

                if (root != null)
                {
                    root.Sort();
                    root.ToTreeView(treeView);
                }
            }
            catch (ETCPGeckoException e)
            {
                exceptionHandling.HandleException(e);
            }
            catch
            {
            }
        }

        public void ExtractFile(ICollection<KeyValuePair<String, String>> paths)
        {
            UInt32 FSInit;
            UInt32 FSAddClient;
            UInt32 FSDelClient;
            UInt32 FSInitCmdBlock;
            UInt32 FSOpenFile;
            UInt32 FSCloseFile;
            UInt32 FSReadFile;
            UInt32 memalign;
            UInt32 free;
            switch (gecko.OsVersionRequest())
            {
                case 400:
                case 410:
                    FSInit = 0x01060d70;
                    FSAddClient = 0x01061290;
                    FSDelClient = 0x0106129c;
                    FSInitCmdBlock = 0x01061498;
                    FSOpenFile = 0x010668bc;
                    FSCloseFile = 0x01066934;
                    FSReadFile = 0x010669b4;
                    memalign = gecko.peek(0x10049edc);
                    free = gecko.peek(0x100adc2c);
                    break;
                case 500:
                case 510:
                    FSInit = 0x010666fc;
                    FSAddClient = 0x01066d80;
                    FSDelClient = 0x01066d8c;
                    FSInitCmdBlock = 0x01066fec;
                    FSOpenFile = 0x0106d4d8;
                    FSCloseFile = 0x0106d550;
                    FSReadFile = 0x0106d5d0;
                    memalign = gecko.peek(0x1004e2d0);
                    free = gecko.peek(0x100b41fc);
                    break;
                default:
                    MessageBox.Show("Unsupported Wii U OS version.", "Version mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            try
            {
                UInt32 ret;
                ret = gecko.rpc(FSInit);

                UInt32 pClient = gecko.rpc(memalign, 0x1700, 0x20);
                if (pClient == 0) goto noClient;
                UInt32 pCmd = gecko.rpc(memalign, 0xA80, 0x20);
                if (pCmd == 0) goto noCmd;

                ret = gecko.rpc(FSAddClient, pClient, 0);
                ret = gecko.rpc(FSInitCmdBlock, pCmd);

                UInt32 pFh = gecko.rpc(memalign, 4, 4);
                if (pFh == 0) goto noFh;
                UInt32 pPath = gecko.rpc(memalign, 0x200, 0x20);
                if (pPath == 0) goto noPath;
                UInt32 pBuf = gecko.rpc(memalign, 0x400 * 256, 0x40);
                if (pBuf == 0) goto noBuf;

                foreach (var item in paths)
                {
                    using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes("r\0" + item.Key + "\0")))
                    {
                        gecko.Upload(pPath, pPath + (uint)ms.Length, ms);
                    }


                    ret = gecko.rpc(FSOpenFile, pClient, pCmd, pPath + 2, pPath, pFh, 0xffffffff);
                    if (ret != 0) goto noFile;

                    UInt32 fh = gecko.peek(pFh);

                    try
                    {
                        using (FileStream fs = new FileStream(item.Value, FileMode.Create))
                        {
                            do
                            {
                                ret = gecko.rpc(FSReadFile, pClient, pCmd, pBuf, 1, 0x400 * 256, fh, 0, 0xffffffff);
                                if (ret <= 0) break;

                                gecko.Dump(pBuf, pBuf + ret, fs);
                            } while (true);
                        }
                    }
                    catch (IOException)
                    {

                    }

                    gecko.rpc(FSCloseFile, pClient, pCmd, fh, 0);
                noFile:
                    continue;
                }
                gecko.rpc(free, pBuf);
            noBuf:
                gecko.rpc(free, pPath);
            noPath:
                gecko.rpc(free, pFh);
            noFh:

                ret = gecko.rpc(FSDelClient, pClient);

                gecko.rpc(free, pCmd);
            noCmd:
                gecko.rpc(free, pClient);
            noClient:
                ;
            }
            catch (ETCPGeckoException e)
            {
                exceptionHandling.HandleException(e);
            }
            catch
            {
            }
        }
        
        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                treeView.SelectedNode = e.Node;
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                if (e.Node.Tag.GetType() == typeof(fileStructure))
                {
                    fileStructure folder = e.Node.Tag as fileStructure;

                    fileSwapCode.Text = folder.Path;
                }
                else
                {
                    subFile file = e.Node.Tag as subFile;

                    fileSwapCode.Text = file.name + "\nLength: " + file.Length.ToString() + " bytes";
                }
            }
            else
            {
                fileSwapCode.Text = "";
            }
        }

        void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = treeView.SelectedNode == null;
        }

        private string last_folder = "";

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null || treeView.SelectedNode.Tag == null) return;

            if (treeView.SelectedNode.Tag.GetType() == typeof(fileStructure))
            {
                fileStructure folder = treeView.SelectedNode.Tag as fileStructure;

                using (FolderBrowserDialog sfd = new FolderBrowserDialog())
                {
                    sfd.Description = "Select folder to be root of extracting " + folder.name;
                    sfd.SelectedPath = last_folder;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        last_folder = sfd.SelectedPath;
                        Queue<fileStructure> fs = new Queue<fileStructure>();
                        List<KeyValuePair<String, String>> files = new List<KeyValuePair<String, String>>();
                        fs.Enqueue(folder);

                        while (fs.Count > 0)
                        {
                            fileStructure current = fs.Dequeue();

                            foreach (var item in current.GetFiles())
                            {
                                String path = sfd.SelectedPath + item.Path.Substring(folder.Path.Length);
                                if (!File.Exists(path))
                                    files.Add(new KeyValuePair<String, String>(item.Path, path));
                            }
                            foreach (var item in current.GetFolders())
                            {
                                fs.Enqueue(item);
                                Directory.CreateDirectory(sfd.SelectedPath + item.Path.Substring(folder.Path.Length));
                            }
                        }

                        ExtractFile(files);
                    }
                }
            }
            else
            {
                subFile file = treeView.SelectedNode.Tag as subFile;

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Extract file " + file.name;
                    sfd.Filter = "All Files (*.*)|*.*";
                    sfd.FileName = file.name;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExtractFile(new KeyValuePair<String, String>[] { new KeyValuePair<String, String>(file.Path, sfd.FileName) });
                    }
                }
            }
        }
    }
}
