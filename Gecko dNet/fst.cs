using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Windows.Forms;
using FTDIUSBGecko;

using IconHelper;

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

        public subFile(String name, int tag,fileStructure parent)
        {
            PName = name;
            PTag = tag;
            PParent = parent;
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
        public int tag { get { return PTag; } }
        public fileStructure parent { get { return PParent; } }

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

        public void addFile(String name, int tag)
        {
            subFile nSF = new subFile(name, tag, this);
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
                subnode.Tag = nFS.tag;
                nFS.ToTreeNode(subnode);
            }
            foreach (subFile nSF in subFiles)
            {
                subnode = root.Nodes.Add(nSF.name);
                subnode.ImageIndex = 2;
                subnode.SelectedImageIndex = 2;
                subnode.Tag = nSF.tag;
            }
            if (subFiles.Count == 0 && subFolders.Count == 0)
            {
                subnode = root.Nodes.Add("");
                subnode.ImageIndex = 2;
                subnode.SelectedImageIndex = 2;
                subnode.Tag = -1;
            }
        }

        private void ToTreeNode(TreeNode tn)
        {
            TreeNode subnode;
            foreach (fileStructure nFS in subFolders)
            {
                subnode = tn.Nodes.Add(nFS.name);
                subnode.Tag = nFS.tag;
                subnode.ImageIndex = 0;
                subnode.SelectedImageIndex = 1;
                nFS.ToTreeNode(subnode);
            }
            foreach (subFile nSF in subFiles)
            {
                subnode = tn.Nodes.Add(nSF.name);
                subnode.ImageIndex = 2;
                subnode.SelectedImageIndex = 2;
                subnode.Tag = nSF.tag;
            }
            if (subFiles.Count == 0 && subFolders.Count == 0)
            {
                subnode = tn.Nodes.Add("");
                subnode.ImageIndex = 2;
                subnode.SelectedImageIndex = 2;
                subnode.Tag = -1;
            }
        }
    }

    public class fstEntry
    {
        public UInt32 dataAddress;
        public UInt32 nameOffset;
        public UInt32 offset;
        public UInt32 entries;

        public UInt32 nameAddress;

        public fstEntry(UInt32 UDataAddress, UInt32 UNameOffset, UInt32 UOffset,
            UInt32 UEntries, UInt32 UNameAddress)
        {
            dataAddress = UDataAddress;
            nameOffset = UNameOffset;
            offset = UOffset;
            entries = UEntries;
            nameAddress = UNameAddress;
        }
    }

    public class FST
    {
        private USBGecko gecko;
        private TreeView treeView;
        private fileStructure root;
        private TextBox fileSwapCode;

        private ImageList imgList;

        private List<fstEntry> fstTextPositions;
        private fstEntry sourceFile;
        private fstEntry targetFile;
        private ExceptionHandler exceptionHandling;

        private Button setAsSourceButton;
        private Button setAsTargetButton;
        private Button generateFileSwap;
        private Button swapFilesNow;
        private Label sourceFileName;
        private Label targetFileName;
        private TextBox generatedSwapCode;
        private int selectedFile;
        private String selFile;

        public FST(USBGecko UGecko, TreeView UTreeView, TextBox UFileSwapCode,
            Button USetAsSourceButton, Button USetAsTargetButton, Button UGenerateFileSwap,
            Label USourceFileName, Label UTargetFileName, TextBox UGeneratedSwapCode, 
            Button USwapNowButton, ExceptionHandler UExceptionHandling)
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
            gecko = UGecko;
            fstTextPositions = new List<fstEntry>();

            fileSwapCode = UFileSwapCode;

            sourceFile = null;
            targetFile = null;
            setAsSourceButton = USetAsSourceButton;
            setAsTargetButton = USetAsTargetButton;
            generateFileSwap = UGenerateFileSwap;
            sourceFileName = USourceFileName;
            targetFileName = UTargetFileName;
            generatedSwapCode = UGeneratedSwapCode;
            swapFilesNow = USwapNowButton;

            setAsSourceButton.Click += SourceButtonClick;
            setAsTargetButton.Click += TargetButtonClick;
            generateFileSwap.Click += GenSwapButtonClick;
            swapFilesNow.Click += ImmediateSwap;

            generatedSwapCode.Text = "";
            targetFileName.Text = "";
            sourceFileName.Text = "";
            setAsSourceButton.Enabled = false;
            setAsTargetButton.Enabled = false;
            generateFileSwap.Enabled = false;
            swapFilesNow.Enabled = false;
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
            //address will be alligned to 4
            UInt32 paddress=0x80000038;

            //Create a memory stream for the actual dump
            MemoryStream stream = new MemoryStream();

            try
            {

                //dump data
                gecko.Dump(paddress, paddress + 8, stream);

                //go to beginning
                stream.Seek(0, SeekOrigin.Begin);
                Byte[] buffer = new Byte[8];
                stream.Read(buffer, 0, 8);

                //Stream can be cleared now
                stream.Close();

                //Read buffer
                UInt32 fstadd = BitConverter.ToUInt32(buffer, 0);
                UInt32 fstsize = BitConverter.ToUInt32(buffer, 4);

                //Swap to machine endianness and return
                fstadd = ByteSwap.Swap(fstadd);
                fstsize = ByteSwap.Swap(fstsize);

                stream = new MemoryStream();
                gecko.Dump(fstadd, fstadd + fstsize + 1, stream);
                stream.Seek(-1, SeekOrigin.End);
                buffer = new Byte[] { 0xFF };
                stream.Write(buffer, 0, 1);

                stream.Seek(0, SeekOrigin.Begin);
                buffer = new Byte[0xC];
                stream.Read(buffer, 0, 12);

                Byte flag = buffer[0];
                UInt32 truenameoff;
                buffer[0] = 0;
                UInt32 nameoff = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0));
                UInt32 offset = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 4));
                UInt32 entries = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 8));
                long fstpos = stream.Position;
                UInt32 strpos = entries * 0x0C;
                UInt32 endpos = strpos;

                //List<TreeNode> rootArr = new List<TreeNode>();
                List<fileStructure> rootArr = new List<fileStructure>();
                List<UInt32> dirSize = new List<UInt32>();
                dirSize.Add(0);

                fstTextPositions.Clear();
                sourceFile = null;
                targetFile = null;
                generatedSwapCode.Text = "";
                targetFileName.Text = "";
                sourceFileName.Text = "";
                setAsSourceButton.Enabled = false;
                setAsTargetButton.Enabled = false;
                generateFileSwap.Enabled = false;
                swapFilesNow.Enabled = false;
                selectedFile = -1;

                //TreeNode current = treeView.Nodes.Add("Root");
                fileStructure current = new fileStructure("Root", -1);
                root = current;

                int tag;
                int curDir = 0;
                rootArr.Add(current);
                String nname;
                do
                {
                    stream.Seek(fstpos, SeekOrigin.Begin);
                    stream.Read(buffer, 0, 12);

                    flag = buffer[0];
                    truenameoff = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0));
                    buffer[0] = 0;
                    nameoff = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0));
                    offset = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 4));
                    entries = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 8));

                    fstTextPositions.Add(new fstEntry((UInt32)fstpos + fstadd,
                        truenameoff, offset, entries, (UInt32)fstpos + strpos + nameoff));
                    tag = fstTextPositions.Count - 1;

                    fstpos = stream.Position;

                    stream.Seek(strpos + nameoff, SeekOrigin.Begin);
                    //fstTextPositions.Add((UInt32)stream.Position + fstadd);
                    nname = ReadString(stream);

                    do
                    {
                        if (fstpos == dirSize[curDir] * 0x0C + 0x0C && curDir > 0)
                        {
                            dirSize[curDir] = 0;
                            curDir--;
                        }
                    } while (curDir != 0 && fstpos >= dirSize[curDir] * 0x0C + 0x0C);

                    if (flag == 0)
                    {
                        //current = rootArr[curDir].Nodes.Add(nname);
                        rootArr[curDir].addFile(nname, tag);
                        //image crap
                    }
                    else
                    {
                        curDir++;
                        current = rootArr[curDir - 1].addSubFolder(nname, tag);
                        //current = rootArr[curDir-1].Nodes.Add(nname);
                        //image crap
                        if (rootArr.Count > curDir)
                        {
                            rootArr[curDir] = current;
                            dirSize[curDir] = entries;
                        }
                        else
                        {
                            rootArr.Add(current);
                            dirSize.Add(entries);
                        }
                    }
                } while (fstpos < endpos);
                stream.Close();

                root.Sort();
                root.ToTreeView(treeView);
            }
            catch (EUSBGeckoException e)
            {
                exceptionHandling.HandleException(e);
            }
            catch
            {
            }
        }

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int tag = -1;
            if (e.Node != null && e.Node.Tag != null && int.TryParse(e.Node.Tag.ToString(), out tag)
                && tag != -1)
            {
                UInt32 code = fstTextPositions[tag].dataAddress - 0x79FFFFFC;
                fileSwapCode.Text =
                    GlobalFunctions.toHex(code) + " 00000008\r\n" +
                    GlobalFunctions.toHex(fstTextPositions[tag].offset) + " " +
                    GlobalFunctions.toHex(fstTextPositions[tag].entries);
                setAsTargetButton.Enabled = true;
                setAsSourceButton.Enabled = true;
                selFile = e.Node.Text;
            }
            else
            {
                fileSwapCode.Text = "";
                setAsTargetButton.Enabled = false;
                setAsSourceButton.Enabled = false;
            }
            selectedFile = tag;
        }

        private void SourceButtonClick(object sender, EventArgs e)
        {
            if (selectedFile == -1)
                return;
            fstEntry oldSource = sourceFile;
            String oldSourceFile = sourceFileName.Text;
            sourceFile = fstTextPositions[selectedFile];
            if (targetFile == sourceFile)
            {
                if (oldSource != null)
                {
                    targetFile = oldSource;
                    targetFileName.Text = oldSourceFile;
                }
                else
                {
                    targetFile = null;
                    targetFileName.Text = "";
                }
            }
            sourceFileName.Text = selFile;

            if (targetFile != null)
            {
                generateFileSwap.Enabled = true;
                swapFilesNow.Enabled = true;
            }
        }

        private void TargetButtonClick(object sender, EventArgs e)
        {
            if (selectedFile == -1)
                return;
            fstEntry oldTarget = targetFile;
            String oldTargetFile = targetFileName.Text;
            targetFile = fstTextPositions[selectedFile];
            if (targetFile == sourceFile)
            {
                if (oldTarget != null)
                {
                    sourceFile = oldTarget;
                    sourceFileName.Text = oldTargetFile;
                }
                else
                {
                    sourceFile = null;
                    sourceFileName.Text = "";
                }
            }
            targetFileName.Text = selFile;

            if (sourceFile != null)
            {
                generateFileSwap.Enabled = true;
                swapFilesNow.Enabled = true;
            }
        }

        private void GenSwapButtonClick(object sender, EventArgs e)
        {
            if (sourceFile == null || targetFile == null)
                return;
            UInt32 code = sourceFile.dataAddress - 0x79FFFFFC;
            generatedSwapCode.Text =
                GlobalFunctions.toHex(code) + " 00000008\r\n" +
                GlobalFunctions.toHex(targetFile.offset) + " " +
                GlobalFunctions.toHex(targetFile.entries);
        }

        private void ImmediateSwap(object sender, EventArgs e)
        {
            try
            {
                gecko.Pause();
                gecko.poke(sourceFile.dataAddress, targetFile.offset);
                gecko.poke(sourceFile.dataAddress + 1, targetFile.entries);
                gecko.Resume();
                MessageBox.Show("Files swapped");
            }
            catch (EUSBGeckoException exc)
            {
                exceptionHandling.HandleException(exc);
            }
        }
    }
}
