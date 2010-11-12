namespace GeckoApp
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("hupa");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.memViewGrid = new System.Windows.Forms.DataGridView();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.memViewSetBP = new System.Windows.Forms.ToolStripMenuItem();
            this.memViewAddToWatch = new System.Windows.Forms.ToolStripMenuItem();
            this.memViewAddGCTCode = new System.Windows.Forms.ToolStripMenuItem();
            this.gCTWizardToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.disassemblerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memViewUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.copySelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripSeparator();
            this.jumpToOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxMemViewOffset = new System.Windows.Forms.ToolStripTextBox();
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxMemViewFontSize = new System.Windows.Forms.ToolStripTextBox();
            this.MainControl = new System.Windows.Forms.TabControl();
            this.searchPage = new System.Windows.Forms.TabPage();
            this.buttonSerialPoke = new System.Windows.Forms.Button();
            this.numericUpDownNewSearchIndex = new System.Windows.Forms.NumericUpDown();
            this.buttonUndoSearch = new System.Windows.Forms.Button();
            this.labelSearchDataType = new System.Windows.Forms.Label();
            this.numericUpDownOldSearchIndex = new System.Windows.Forms.NumericUpDown();
            this.Search = new System.Windows.Forms.Button();
            this.comboBoxSearchDataType = new System.Windows.Forms.ComboBox();
            this.buttonCancelSearch = new System.Windows.Forms.Button();
            this.buttonSaveSearch = new System.Windows.Forms.Button();
            this.UpDownSearchResultPage = new System.Windows.Forms.NumericUpDown();
            this.buttonLoadSearch = new System.Windows.Forms.Button();
            this.PValue = new System.Windows.Forms.TextBox();
            this.InputConvert = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CvDecHex = new System.Windows.Forms.ToolStripMenuItem();
            this.CvFloatHex = new System.Windows.Forms.ToolStripMenuItem();
            this.convertASCIIToHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CvHexDec = new System.Windows.Forms.ToolStripMenuItem();
            this.cvHexFloat = new System.Windows.Forms.ToolStripMenuItem();
            this.convertHexToASCIIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputCvCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.InputCvCut = new System.Windows.Forms.ToolStripMenuItem();
            this.InputCvPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.InputCvSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.InputCvUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxDisplayType = new System.Windows.Forms.ComboBox();
            this.PButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.HistoryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutAllHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAllHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.showHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripSeparator();
            this.addOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxAddressAddOffset = new System.Windows.Forms.ToolStripTextBox();
            this.NxtPage = new System.Windows.Forms.Button();
            this.ResList = new System.Windows.Forms.Label();
            this.SearchResults = new System.Windows.Forms.DataGridView();
            this.ACol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DifferCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchResMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PkAddress = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowInMemView = new System.Windows.Forms.ToolStripMenuItem();
            this.BpSAddress = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowInDiss = new System.Windows.Forms.ToolStripMenuItem();
            this.showInWatchList = new System.Windows.Forms.ToolStripMenuItem();
            this.makeCode = new System.Windows.Forms.ToolStripMenuItem();
            this.gCTWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrvPage = new System.Windows.Forms.Button();
            this.ResSrch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.memRange = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxComparisonValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxComparisonType = new System.Windows.Forms.ComboBox();
            this.comboBoxComparisonRHS = new System.Windows.Forms.ComboBox();
            this.groupBoxSearchGroups = new System.Windows.Forms.GroupBox();
            this.buttonClearSearchGroup = new System.Windows.Forms.Button();
            this.buttonRemoveGroup = new System.Windows.Forms.Button();
            this.buttonAddSearchGroup = new System.Windows.Forms.Button();
            this.numericUpDownSearchGroup = new System.Windows.Forms.NumericUpDown();
            this.MemView = new System.Windows.Forms.TabPage();
            this.vScrollBarMemViewGrid = new System.Windows.Forms.VScrollBar();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.MemViewSearchType = new System.Windows.Forms.ComboBox();
            this.MemViewSearchPerfom = new System.Windows.Forms.Button();
            this.MemViewSearchString = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.MemViewFPValue = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBoxPokeOperation = new System.Windows.Forms.ComboBox();
            this.memViewPButton = new System.Windows.Forms.Button();
            this.memViewPValue = new System.Windows.Forms.TextBox();
            this.MemViewAutoUp = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.MemViewShowMode = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.MemViewScrollbar = new System.Windows.Forms.NumericUpDown();
            this.MemViewUpdate = new System.Windows.Forms.Button();
            this.MemViewARange = new System.Windows.Forms.ComboBox();
            this.BreakpointPage = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBoxLogSteps = new System.Windows.Forms.CheckBox();
            this.BPOutSwap = new System.Windows.Forms.Button();
            this.buttonShowMem = new System.Windows.Forms.Button();
            this.ShowMemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowMemAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxShowMemAddress = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowMemValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxShowMemValue = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripSeparator();
            this.SRR0NEQToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.SRR0EQToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
            this.viewFloatsInHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BPSkipCount = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.checkBoxBPCondEnable = new System.Windows.Forms.CheckBox();
            this.BPCondList = new System.Windows.Forms.ListBox();
            this.BPCondMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.sRR0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sRR0ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.setConditionGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetConditionGroupTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.BPCondClear = new System.Windows.Forms.Button();
            this.BPConditionAdd = new System.Windows.Forms.Button();
            this.BPCondDel = new System.Windows.Forms.Button();
            this.BPCondValue = new System.Windows.Forms.TextBox();
            this.BPConditionCompare = new System.Windows.Forms.ComboBox();
            this.BPConditionRegSelect = new System.Windows.Forms.ComboBox();
            this.groupBoxStep = new System.Windows.Forms.GroupBox();
            this.buttonStepUntil = new System.Windows.Forms.Button();
            this.BPStepButton = new System.Windows.Forms.Button();
            this.BPStepOverButton = new System.Windows.Forms.Button();
            this.buttonStepOutOf = new System.Windows.Forms.Button();
            this.StepOutContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.walkToBlrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stackFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leafToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.BPCancel = new System.Windows.Forms.Button();
            this.BPFire = new System.Windows.Forms.Button();
            this.BPType = new System.Windows.Forms.ComboBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.BPExact = new System.Windows.Forms.CheckBox();
            this.DisPage = new System.Windows.Forms.TabPage();
            this.groupBoxDisasmCallStack = new System.Windows.Forms.GroupBox();
            this.listBoxCallStack = new System.Windows.Forms.ListBox();
            this.CallStackContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxDisasm = new System.Windows.Forms.GroupBox();
            this.radioButtonSearchDisassemblyDown = new System.Windows.Forms.RadioButton();
            this.radioButtonSearchDisassemblyUp = new System.Windows.Forms.RadioButton();
            this.buttonDisassemblySearch = new System.Windows.Forms.Button();
            this.textBoxDisassemblySearch = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.Assemble = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.DisUpDown = new System.Windows.Forms.NumericUpDown();
            this.DisUpdateBtn = new System.Windows.Forms.Button();
            this.DisScroll = new System.Windows.Forms.VScrollBar();
            this.DisAssBox = new System.Windows.Forms.ListBox();
            this.disAssContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.DisAssSetBP = new System.Windows.Forms.ToolStripMenuItem();
            this.DisAssPoke = new System.Windows.Forms.ToolStripMenuItem();
            this.disAssGCTCode = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.setSRR0HereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripSeparator();
            this.gotoFunctionStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoFunctionEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shotPage = new System.Windows.Forms.TabPage();
            this.checkBoxAutoPreview = new System.Windows.Forms.CheckBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.JPGQualLabel = new System.Windows.Forms.Label();
            this.JPGQual = new System.Windows.Forms.TrackBar();
            this.ImgFormat = new System.Windows.Forms.ComboBox();
            this.ShotPreview = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.ShotSizingType = new System.Windows.Forms.ComboBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.ShotFilename = new System.Windows.Forms.TextBox();
            this.ShotCapture = new System.Windows.Forms.Button();
            this.ScreenshotCapBox = new System.Windows.Forms.PictureBox();
            this.GCTPage = new System.Windows.Forms.TabPage();
            this.checkBoxPauseCodes = new System.Windows.Forms.CheckBox();
            this.GCTStoreImm = new System.Windows.Forms.Button();
            this.GCTDisable = new System.Windows.Forms.Button();
            this.GCTListFileName = new System.Windows.Forms.Label();
            this.GCTLoadList = new System.Windows.Forms.Button();
            this.GCTSaveList = new System.Windows.Forms.Button();
            this.GCTSndButton = new System.Windows.Forms.Button();
            this.GCTDelBtn = new System.Windows.Forms.Button();
            this.GCTAddCode = new System.Windows.Forms.Button();
            this.GCTCodeValues = new System.Windows.Forms.TextBox();
            this.GCTCodeList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.gctCodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gctMenuAddCode = new System.Windows.Forms.ToolStripMenuItem();
            this.gctMenuDeleteCode = new System.Windows.Forms.ToolStripMenuItem();
            this.gCTWizardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DisableCodeLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WatchTab = new System.Windows.Forms.TabPage();
            this.WatchListClear = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.WatchIntervalSet = new System.Windows.Forms.NumericUpDown();
            this.WatchListOpenButton = new System.Windows.Forms.Button();
            this.WatchListSaveButton = new System.Windows.Forms.Button();
            this.WatchAdd = new System.Windows.Forms.Button();
            this.WatchList = new System.Windows.Forms.DataGridView();
            this.WatchCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchCAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchCType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchCValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchCM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WatchAddWatchCM = new System.Windows.Forms.ToolStripMenuItem();
            this.WatchDeleteCM = new System.Windows.Forms.ToolStripMenuItem();
            this.WatchPokeCM = new System.Windows.Forms.ToolStripMenuItem();
            this.WatchEditCM = new System.Windows.Forms.ToolStripMenuItem();
            this.FSTTab = new System.Windows.Forms.TabPage();
            this.FSTSwapNow = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.FSTGenSwap = new System.Windows.Forms.Button();
            this.FSTSwapCode = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.FSTSetAsTarget = new System.Windows.Forms.Button();
            this.FSTFileTarget = new System.Windows.Forms.Label();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.FSTSetAsSource = new System.Windows.Forms.Button();
            this.FSTFileSource = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.FSTCodeData = new System.Windows.Forms.TextBox();
            this.FSTRead = new System.Windows.Forms.Button();
            this.FSTTreeView = new System.Windows.Forms.TreeView();
            this.ToolPage = new System.Windows.Forms.TabPage();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.ToolsDump = new System.Windows.Forms.Button();
            this.ToolsBrowseDump = new System.Windows.Forms.Button();
            this.ToolsDumpFileName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ToolsDumpEnd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ToolsDumpStart = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ToolsDumpRegions = new System.Windows.Forms.ComboBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ToolsDisableWatchProtection = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ToolsDisableProtection = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.AbtPage = new System.Windows.Forms.TabPage();
            this.checkBoxRegexSearch = new System.Windows.Forms.CheckBox();
            this.checkBoxBPNext = new System.Windows.Forms.CheckBox();
            this.checkBoxFPS = new System.Windows.Forms.CheckBox();
            this.numericUpDownFPS = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.AbtText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OpenNotePad = new System.Windows.Forms.Button();
            this.RGame = new System.Windows.Forms.Button();
            this.PGame = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.CUSBGecko = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.PCent = new System.Windows.Forms.Label();
            this.StatusCap = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.WatchListOpen = new System.Windows.Forms.OpenFileDialog();
            this.WatchListSave = new System.Windows.Forms.SaveFileDialog();
            this.ToolsDumpSave = new System.Windows.Forms.SaveFileDialog();
            this.openBinary = new System.Windows.Forms.OpenFileDialog();
            this.timerFPS = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogSearch = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSearch = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogLogSteps = new System.Windows.Forms.SaveFileDialog();
            this.splitContainerRegASM = new System.Windows.Forms.SplitContainer();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BPClassic = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BPDiss = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.MEM2UpperBoundary = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PAddress = new GeckoApp.external.AddressTextBox();
            this.memEnd = new GeckoApp.external.AddressTextBox();
            this.memStart = new GeckoApp.external.AddressTextBox();
            this.memViewPAddress = new GeckoApp.external.AddressTextBox();
            this.memViewAValue = new GeckoApp.external.AddressTextBox();
            this.BPList = new GeckoApp.BPList();
            this.BPAddress = new GeckoApp.external.AddressTextBox();
            this.AsText = new GeckoApp.external.HistoryTextBox();
            this.AsAddress = new GeckoApp.external.AddressTextBox();
            this.DisRegion = new GeckoApp.external.AddressTextBox();
            this.addressTextBoxBPNext = new GeckoApp.external.AddressTextBox();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.memViewGrid)).BeginInit();
            this.memViewContextMenu.SuspendLayout();
            this.MainControl.SuspendLayout();
            this.searchPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewSearchIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOldSearchIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownSearchResultPage)).BeginInit();
            this.InputConvert.SuspendLayout();
            this.HistoryContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchResults)).BeginInit();
            this.SearchResMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBoxSearchGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchGroup)).BeginInit();
            this.MemView.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemViewScrollbar)).BeginInit();
            this.BreakpointPage.SuspendLayout();
            this.panel5.SuspendLayout();
            this.ShowMemContextMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.BPCondMenu.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBoxStep.SuspendLayout();
            this.StepOutContextMenu.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.DisPage.SuspendLayout();
            this.groupBoxDisasmCallStack.SuspendLayout();
            this.CallStackContextMenu.SuspendLayout();
            this.groupBoxDisasm.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisUpDown)).BeginInit();
            this.disAssContextMenu.SuspendLayout();
            this.shotPage.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JPGQual)).BeginInit();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenshotCapBox)).BeginInit();
            this.GCTPage.SuspendLayout();
            this.gctCodeMenu.SuspendLayout();
            this.WatchTab.SuspendLayout();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WatchIntervalSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WatchList)).BeginInit();
            this.WatchCM.SuspendLayout();
            this.FSTTab.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.ToolPage.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.AbtPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFPS)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.splitContainerRegASM.Panel1.SuspendLayout();
            this.splitContainerRegASM.Panel2.SuspendLayout();
            this.splitContainerRegASM.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // memViewGrid
            // 
            this.memViewGrid.AllowUserToAddRows = false;
            this.memViewGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 20F);
            this.memViewGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.memViewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memViewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.memViewGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.memViewGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.memViewGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.memViewGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.memViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memViewGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.address,
            this.c1,
            this.c2,
            this.c3,
            this.c4});
            this.memViewGrid.ContextMenuStrip = this.memViewContextMenu;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.memViewGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.memViewGrid.Location = new System.Drawing.Point(198, 12);
            this.memViewGrid.MultiSelect = false;
            this.memViewGrid.Name = "memViewGrid";
            this.memViewGrid.ReadOnly = true;
            this.memViewGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.memViewGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.memViewGrid.RowHeadersVisible = false;
            this.memViewGrid.RowHeadersWidth = 80;
            this.memViewGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Courier New", 12F);
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.memViewGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.memViewGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.memViewGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Courier New", 10F);
            this.memViewGrid.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.memViewGrid.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.memViewGrid.RowTemplate.Height = 16;
            this.memViewGrid.RowTemplate.ReadOnly = true;
            this.memViewGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memViewGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.memViewGrid.ShowCellErrors = false;
            this.memViewGrid.ShowCellToolTips = false;
            this.memViewGrid.ShowEditingIcon = false;
            this.memViewGrid.ShowRowErrors = false;
            this.memViewGrid.Size = new System.Drawing.Size(348, 278);
            this.memViewGrid.TabIndex = 0;
            this.memViewGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.memViewGrid_CellMouseDown);
            this.memViewGrid.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.memViewGrid_CellMouseMove);
            this.memViewGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.memViewGrid_CellMouseDoubleClick);
            this.memViewGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.memViewGrid_KeyDown);
            // 
            // address
            // 
            this.address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.address.DefaultCellStyle = dataGridViewCellStyle3;
            this.address.Frozen = true;
            this.address.HeaderText = "80000000";
            this.address.MaxInputLength = 8;
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.address.Width = 78;
            // 
            // c1
            // 
            this.c1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1.DefaultCellStyle = dataGridViewCellStyle4;
            this.c1.HeaderText = "00010203";
            this.c1.MaxInputLength = 8;
            this.c1.Name = "c1";
            this.c1.ReadOnly = true;
            this.c1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c1.Width = 78;
            // 
            // c2
            // 
            this.c2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2.DefaultCellStyle = dataGridViewCellStyle5;
            this.c2.HeaderText = "04050607";
            this.c2.MaxInputLength = 8;
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            this.c2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c2.Width = 78;
            // 
            // c3
            // 
            this.c3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c3.DefaultCellStyle = dataGridViewCellStyle6;
            this.c3.HeaderText = "08090A0B";
            this.c3.MaxInputLength = 8;
            this.c3.Name = "c3";
            this.c3.ReadOnly = true;
            this.c3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c3.Width = 78;
            // 
            // c4
            // 
            this.c4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c4.DefaultCellStyle = dataGridViewCellStyle7;
            this.c4.HeaderText = "0C0D0E0F";
            this.c4.MaxInputLength = 8;
            this.c4.Name = "c4";
            this.c4.ReadOnly = true;
            this.c4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c4.Width = 78;
            // 
            // memViewContextMenu
            // 
            this.memViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memViewSetBP,
            this.memViewAddToWatch,
            this.memViewAddGCTCode,
            this.gCTWizardToolStripMenuItem2,
            this.disassemblerToolStripMenuItem,
            this.memViewUpload,
            this.toolStripMenuItem5,
            this.copySelectionToolStripMenuItem,
            this.copyAllCellsToolStripMenuItem,
            this.toolStripMenuItem16,
            this.jumpToOffsetToolStripMenuItem,
            this.fontSizeToolStripMenuItem});
            this.memViewContextMenu.Name = "memViewContextMenu";
            this.memViewContextMenu.Size = new System.Drawing.Size(247, 236);
            // 
            // memViewSetBP
            // 
            this.memViewSetBP.Name = "memViewSetBP";
            this.memViewSetBP.Size = new System.Drawing.Size(246, 22);
            this.memViewSetBP.Text = "&Breakpoint";
            this.memViewSetBP.Click += new System.EventHandler(this.memViewSetBP_Click);
            // 
            // memViewAddToWatch
            // 
            this.memViewAddToWatch.Name = "memViewAddToWatch";
            this.memViewAddToWatch.Size = new System.Drawing.Size(246, 22);
            this.memViewAddToWatch.Text = "&Watchlist";
            this.memViewAddToWatch.Click += new System.EventHandler(this.memViewAddToWatch_Click);
            // 
            // memViewAddGCTCode
            // 
            this.memViewAddGCTCode.Name = "memViewAddGCTCode";
            this.memViewAddGCTCode.Size = new System.Drawing.Size(246, 22);
            this.memViewAddGCTCode.Text = "GCT code";
            this.memViewAddGCTCode.Click += new System.EventHandler(this.memViewAddGCTCode_Click);
            // 
            // gCTWizardToolStripMenuItem2
            // 
            this.gCTWizardToolStripMenuItem2.Name = "gCTWizardToolStripMenuItem2";
            this.gCTWizardToolStripMenuItem2.Size = new System.Drawing.Size(246, 22);
            this.gCTWizardToolStripMenuItem2.Text = "&GCT wizard...";
            this.gCTWizardToolStripMenuItem2.Click += new System.EventHandler(this.gCTWizardToolStripMenuItemMemView_Click);
            // 
            // disassemblerToolStripMenuItem
            // 
            this.disassemblerToolStripMenuItem.Name = "disassemblerToolStripMenuItem";
            this.disassemblerToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.disassemblerToolStripMenuItem.Text = "&Disassembler";
            this.disassemblerToolStripMenuItem.Click += new System.EventHandler(this.disassemblerToolStripMenuItem_Click);
            // 
            // memViewUpload
            // 
            this.memViewUpload.Name = "memViewUpload";
            this.memViewUpload.Size = new System.Drawing.Size(246, 22);
            this.memViewUpload.Text = "Upload data";
            this.memViewUpload.Click += new System.EventHandler(this.memViewUpload_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(243, 6);
            // 
            // copySelectionToolStripMenuItem
            // 
            this.copySelectionToolStripMenuItem.Name = "copySelectionToolStripMenuItem";
            this.copySelectionToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.copySelectionToolStripMenuItem.Text = "&Copy Selection  ( Ctrl + C )";
            this.copySelectionToolStripMenuItem.Click += new System.EventHandler(this.copySelectionToolStripMenuItem_Click);
            // 
            // copyAllCellsToolStripMenuItem
            // 
            this.copyAllCellsToolStripMenuItem.Name = "copyAllCellsToolStripMenuItem";
            this.copyAllCellsToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.copyAllCellsToolStripMenuItem.Text = "Copy &All Cells  ( Ctrl + Shift + C )";
            this.copyAllCellsToolStripMenuItem.Click += new System.EventHandler(this.copyAllCellsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(243, 6);
            // 
            // jumpToOffsetToolStripMenuItem
            // 
            this.jumpToOffsetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxMemViewOffset});
            this.jumpToOffsetToolStripMenuItem.Name = "jumpToOffsetToolStripMenuItem";
            this.jumpToOffsetToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.jumpToOffsetToolStripMenuItem.Text = "Jump To &Offset";
            this.jumpToOffsetToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.jumpToOffsetToolStripMenuItem_MouseMove);
            // 
            // toolStripTextBoxMemViewOffset
            // 
            this.toolStripTextBoxMemViewOffset.Name = "toolStripTextBoxMemViewOffset";
            this.toolStripTextBoxMemViewOffset.Size = new System.Drawing.Size(80, 23);
            this.toolStripTextBoxMemViewOffset.Text = "0";
            this.toolStripTextBoxMemViewOffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxMemViewOffset_KeyDown);
            // 
            // fontSizeToolStripMenuItem
            // 
            this.fontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxMemViewFontSize});
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.fontSizeToolStripMenuItem.Text = "Font Size";
            this.fontSizeToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fontSizeToolStripMenuItem_MouseMove);
            // 
            // toolStripTextBoxMemViewFontSize
            // 
            this.toolStripTextBoxMemViewFontSize.MaxLength = 8;
            this.toolStripTextBoxMemViewFontSize.Name = "toolStripTextBoxMemViewFontSize";
            this.toolStripTextBoxMemViewFontSize.Size = new System.Drawing.Size(80, 23);
            this.toolStripTextBoxMemViewFontSize.Text = "8.75";
            this.toolStripTextBoxMemViewFontSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxMemViewFontSize_KeyDown);
            // 
            // MainControl
            // 
            this.MainControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MainControl.Controls.Add(this.searchPage);
            this.MainControl.Controls.Add(this.MemView);
            this.MainControl.Controls.Add(this.BreakpointPage);
            this.MainControl.Controls.Add(this.DisPage);
            this.MainControl.Controls.Add(this.shotPage);
            this.MainControl.Controls.Add(this.GCTPage);
            this.MainControl.Controls.Add(this.WatchTab);
            this.MainControl.Controls.Add(this.FSTTab);
            this.MainControl.Controls.Add(this.ToolPage);
            this.MainControl.Controls.Add(this.AbtPage);
            this.MainControl.Location = new System.Drawing.Point(1, 1);
            this.MainControl.MinimumSize = new System.Drawing.Size(565, 322);
            this.MainControl.Name = "MainControl";
            this.MainControl.Padding = new System.Drawing.Point(4, 3);
            this.MainControl.SelectedIndex = 0;
            this.MainControl.Size = new System.Drawing.Size(573, 322);
            this.MainControl.TabIndex = 0;
            this.MainControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MainControl_Selecting);
            // 
            // searchPage
            // 
            this.searchPage.BackColor = System.Drawing.Color.Transparent;
            this.searchPage.Controls.Add(this.buttonSerialPoke);
            this.searchPage.Controls.Add(this.numericUpDownNewSearchIndex);
            this.searchPage.Controls.Add(this.buttonUndoSearch);
            this.searchPage.Controls.Add(this.labelSearchDataType);
            this.searchPage.Controls.Add(this.numericUpDownOldSearchIndex);
            this.searchPage.Controls.Add(this.Search);
            this.searchPage.Controls.Add(this.comboBoxSearchDataType);
            this.searchPage.Controls.Add(this.buttonCancelSearch);
            this.searchPage.Controls.Add(this.buttonSaveSearch);
            this.searchPage.Controls.Add(this.UpDownSearchResultPage);
            this.searchPage.Controls.Add(this.buttonLoadSearch);
            this.searchPage.Controls.Add(this.PValue);
            this.searchPage.Controls.Add(this.comboBoxDisplayType);
            this.searchPage.Controls.Add(this.PButton);
            this.searchPage.Controls.Add(this.label5);
            this.searchPage.Controls.Add(this.PAddress);
            this.searchPage.Controls.Add(this.NxtPage);
            this.searchPage.Controls.Add(this.ResList);
            this.searchPage.Controls.Add(this.SearchResults);
            this.searchPage.Controls.Add(this.PrvPage);
            this.searchPage.Controls.Add(this.ResSrch);
            this.searchPage.Controls.Add(this.groupBox1);
            this.searchPage.Controls.Add(this.groupBox4);
            this.searchPage.Controls.Add(this.groupBoxSearchGroups);
            this.searchPage.Location = new System.Drawing.Point(4, 22);
            this.searchPage.Name = "searchPage";
            this.searchPage.Padding = new System.Windows.Forms.Padding(3);
            this.searchPage.Size = new System.Drawing.Size(565, 296);
            this.searchPage.TabIndex = 0;
            this.searchPage.Text = "Search";
            this.searchPage.UseVisualStyleBackColor = true;
            // 
            // buttonSerialPoke
            // 
            this.buttonSerialPoke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSerialPoke.Location = new System.Drawing.Point(490, 269);
            this.buttonSerialPoke.Name = "buttonSerialPoke";
            this.buttonSerialPoke.Size = new System.Drawing.Size(69, 21);
            this.buttonSerialPoke.TabIndex = 23;
            this.buttonSerialPoke.Tag = "0";
            this.buttonSerialPoke.Text = "Serial Poke";
            this.buttonSerialPoke.UseVisualStyleBackColor = true;
            this.buttonSerialPoke.Click += new System.EventHandler(this.buttonSerialPoke_Click);
            // 
            // numericUpDownNewSearchIndex
            // 
            this.numericUpDownNewSearchIndex.Location = new System.Drawing.Point(436, 3);
            this.numericUpDownNewSearchIndex.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownNewSearchIndex.Name = "numericUpDownNewSearchIndex";
            this.numericUpDownNewSearchIndex.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownNewSearchIndex.TabIndex = 21;
            this.numericUpDownNewSearchIndex.ValueChanged += new System.EventHandler(this.numericUpDownNewSearchIndex_ValueChanged);
            // 
            // buttonUndoSearch
            // 
            this.buttonUndoSearch.Location = new System.Drawing.Point(7, 258);
            this.buttonUndoSearch.Name = "buttonUndoSearch";
            this.buttonUndoSearch.Size = new System.Drawing.Size(87, 32);
            this.buttonUndoSearch.TabIndex = 18;
            this.buttonUndoSearch.Text = "Undo Search";
            this.buttonUndoSearch.UseVisualStyleBackColor = true;
            this.buttonUndoSearch.Click += new System.EventHandler(this.buttonUndoSearch_Click);
            // 
            // labelSearchDataType
            // 
            this.labelSearchDataType.AutoSize = true;
            this.labelSearchDataType.Location = new System.Drawing.Point(10, 59);
            this.labelSearchDataType.Name = "labelSearchDataType";
            this.labelSearchDataType.Size = new System.Drawing.Size(57, 13);
            this.labelSearchDataType.TabIndex = 22;
            this.labelSearchDataType.Text = "Data Type";
            // 
            // numericUpDownOldSearchIndex
            // 
            this.numericUpDownOldSearchIndex.Location = new System.Drawing.Point(373, 3);
            this.numericUpDownOldSearchIndex.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownOldSearchIndex.Name = "numericUpDownOldSearchIndex";
            this.numericUpDownOldSearchIndex.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownOldSearchIndex.TabIndex = 19;
            this.numericUpDownOldSearchIndex.ValueChanged += new System.EventHandler(this.numericUpDownOldSearchIndex_ValueChanged);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(7, 220);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(87, 32);
            this.Search.TabIndex = 4;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // comboBoxSearchDataType
            // 
            this.comboBoxSearchDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchDataType.FormattingEnabled = true;
            this.comboBoxSearchDataType.Items.AddRange(new object[] {
            "8 bit",
            "16 bit",
            "32 bit",
            "Single"});
            this.comboBoxSearchDataType.Location = new System.Drawing.Point(72, 56);
            this.comboBoxSearchDataType.Name = "comboBoxSearchDataType";
            this.comboBoxSearchDataType.Size = new System.Drawing.Size(68, 21);
            this.comboBoxSearchDataType.TabIndex = 1;
            this.comboBoxSearchDataType.SelectedIndexChanged += new System.EventHandler(this.ValueLength_SelectedIndexChanged);
            // 
            // buttonCancelSearch
            // 
            this.buttonCancelSearch.Location = new System.Drawing.Point(98, 220);
            this.buttonCancelSearch.Name = "buttonCancelSearch";
            this.buttonCancelSearch.Size = new System.Drawing.Size(87, 32);
            this.buttonCancelSearch.TabIndex = 15;
            this.buttonCancelSearch.Text = "Cancel Search";
            this.buttonCancelSearch.UseVisualStyleBackColor = true;
            this.buttonCancelSearch.Click += new System.EventHandler(this.buttonCancelSearch_Click);
            // 
            // buttonSaveSearch
            // 
            this.buttonSaveSearch.Location = new System.Drawing.Point(98, 258);
            this.buttonSaveSearch.Name = "buttonSaveSearch";
            this.buttonSaveSearch.Size = new System.Drawing.Size(87, 32);
            this.buttonSaveSearch.TabIndex = 14;
            this.buttonSaveSearch.Text = "Save Search";
            this.buttonSaveSearch.UseVisualStyleBackColor = true;
            this.buttonSaveSearch.Click += new System.EventHandler(this.buttonSaveSearch_Click);
            // 
            // UpDownSearchResultPage
            // 
            this.UpDownSearchResultPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpDownSearchResultPage.Location = new System.Drawing.Point(422, 242);
            this.UpDownSearchResultPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownSearchResultPage.Name = "UpDownSearchResultPage";
            this.UpDownSearchResultPage.Size = new System.Drawing.Size(62, 20);
            this.UpDownSearchResultPage.TabIndex = 16;
            this.UpDownSearchResultPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpDownSearchResultPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonLoadSearch
            // 
            this.buttonLoadSearch.Location = new System.Drawing.Point(190, 258);
            this.buttonLoadSearch.Name = "buttonLoadSearch";
            this.buttonLoadSearch.Size = new System.Drawing.Size(87, 32);
            this.buttonLoadSearch.TabIndex = 13;
            this.buttonLoadSearch.Text = "Load Search";
            this.buttonLoadSearch.UseVisualStyleBackColor = true;
            this.buttonLoadSearch.Click += new System.EventHandler(this.buttonLoadSearch_Click);
            // 
            // PValue
            // 
            this.PValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PValue.ContextMenuStrip = this.InputConvert;
            this.PValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PValue.Location = new System.Drawing.Point(350, 269);
            this.PValue.MaxLength = 8;
            this.PValue.Name = "PValue";
            this.PValue.Size = new System.Drawing.Size(62, 20);
            this.PValue.TabIndex = 11;
            this.PValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lowerValue_MouseClick);
            this.PValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PValue_KeyPress);
            // 
            // InputConvert
            // 
            this.InputConvert.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CvDecHex,
            this.CvFloatHex,
            this.convertASCIIToHexToolStripMenuItem,
            this.CvHexDec,
            this.cvHexFloat,
            this.convertHexToASCIIToolStripMenuItem,
            toolStripMenuItem1,
            this.InputCvCopy,
            this.InputCvCut,
            this.InputCvPaste,
            this.toolStripMenuItem2,
            this.InputCvSelectAll,
            this.InputCvUndo});
            this.InputConvert.Name = "InputEdit";
            this.InputConvert.Size = new System.Drawing.Size(185, 258);
            // 
            // CvDecHex
            // 
            this.CvDecHex.Name = "CvDecHex";
            this.CvDecHex.Size = new System.Drawing.Size(184, 22);
            this.CvDecHex.Text = "Convert Dec to Hex";
            this.CvDecHex.Click += new System.EventHandler(this.CvDecHexClick);
            // 
            // CvFloatHex
            // 
            this.CvFloatHex.Name = "CvFloatHex";
            this.CvFloatHex.Size = new System.Drawing.Size(184, 22);
            this.CvFloatHex.Text = "Convert Float to Hex";
            this.CvFloatHex.Click += new System.EventHandler(this.CvFloatHex_Click);
            // 
            // convertASCIIToHexToolStripMenuItem
            // 
            this.convertASCIIToHexToolStripMenuItem.Name = "convertASCIIToHexToolStripMenuItem";
            this.convertASCIIToHexToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.convertASCIIToHexToolStripMenuItem.Text = "Convert ASCII to Hex";
            this.convertASCIIToHexToolStripMenuItem.Click += new System.EventHandler(this.convertASCIIToHexToolStripMenuItem_Click);
            // 
            // CvHexDec
            // 
            this.CvHexDec.Name = "CvHexDec";
            this.CvHexDec.Size = new System.Drawing.Size(184, 22);
            this.CvHexDec.Text = "Convert Hex to Dec";
            this.CvHexDec.Click += new System.EventHandler(this.CvHexDec_Click);
            // 
            // cvHexFloat
            // 
            this.cvHexFloat.Name = "cvHexFloat";
            this.cvHexFloat.Size = new System.Drawing.Size(184, 22);
            this.cvHexFloat.Text = "Convert Hex to Float";
            this.cvHexFloat.Click += new System.EventHandler(this.cvHexFloat_Click);
            // 
            // convertHexToASCIIToolStripMenuItem
            // 
            this.convertHexToASCIIToolStripMenuItem.Name = "convertHexToASCIIToolStripMenuItem";
            this.convertHexToASCIIToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.convertHexToASCIIToolStripMenuItem.Text = "Convert Hex to ASCII";
            this.convertHexToASCIIToolStripMenuItem.Click += new System.EventHandler(this.convertHexToASCIIToolStripMenuItem_Click);
            // 
            // InputCvCopy
            // 
            this.InputCvCopy.Name = "InputCvCopy";
            this.InputCvCopy.Size = new System.Drawing.Size(184, 22);
            this.InputCvCopy.Text = "Copy";
            this.InputCvCopy.Click += new System.EventHandler(this.InputCvCopy_Click);
            // 
            // InputCvCut
            // 
            this.InputCvCut.Name = "InputCvCut";
            this.InputCvCut.Size = new System.Drawing.Size(184, 22);
            this.InputCvCut.Text = "Cut";
            this.InputCvCut.Click += new System.EventHandler(this.InputCvCut_Click);
            // 
            // InputCvPaste
            // 
            this.InputCvPaste.Name = "InputCvPaste";
            this.InputCvPaste.Size = new System.Drawing.Size(184, 22);
            this.InputCvPaste.Text = "Paste";
            this.InputCvPaste.Click += new System.EventHandler(this.InputCvPaste_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
            // 
            // InputCvSelectAll
            // 
            this.InputCvSelectAll.Name = "InputCvSelectAll";
            this.InputCvSelectAll.Size = new System.Drawing.Size(184, 22);
            this.InputCvSelectAll.Text = "Select All";
            this.InputCvSelectAll.Click += new System.EventHandler(this.InputCvSelectAll_Click);
            // 
            // InputCvUndo
            // 
            this.InputCvUndo.Name = "InputCvUndo";
            this.InputCvUndo.Size = new System.Drawing.Size(184, 22);
            this.InputCvUndo.Text = "Undo";
            this.InputCvUndo.Click += new System.EventHandler(this.InputCvUndo_Click);
            // 
            // comboBoxDisplayType
            // 
            this.comboBoxDisplayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisplayType.FormattingEnabled = true;
            this.comboBoxDisplayType.Items.AddRange(new object[] {
            "Hex",
            "Dec",
            "Single"});
            this.comboBoxDisplayType.Location = new System.Drawing.Point(211, 56);
            this.comboBoxDisplayType.Name = "comboBoxDisplayType";
            this.comboBoxDisplayType.Size = new System.Drawing.Size(63, 21);
            this.comboBoxDisplayType.TabIndex = 17;
            this.comboBoxDisplayType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisplayType_SelectedIndexChanged);
            // 
            // PButton
            // 
            this.PButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PButton.Location = new System.Drawing.Point(422, 269);
            this.PButton.Name = "PButton";
            this.PButton.Size = new System.Drawing.Size(62, 21);
            this.PButton.TabIndex = 12;
            this.PButton.Tag = "0";
            this.PButton.Text = "Poke";
            this.PButton.UseVisualStyleBackColor = true;
            this.PButton.Click += new System.EventHandler(this.PButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "View Mode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HistoryContextMenu
            // 
            this.HistoryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem8,
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.toolStripMenuItem6,
            this.clearAllHistoryToolStripMenuItem,
            this.cutAllHistoryToolStripMenuItem,
            this.copyAllHistoryToolStripMenuItem,
            this.pasteAllHistoryToolStripMenuItem,
            this.toolStripMenuItem7,
            this.showHistoryToolStripMenuItem,
            this.autoHistoryToolStripMenuItem,
            this.toolStripMenuItem19,
            this.addOffsetToolStripMenuItem});
            this.HistoryContextMenu.Name = "addressContextMenu";
            this.HistoryContextMenu.Size = new System.Drawing.Size(268, 270);
            this.HistoryContextMenu.Opened += new System.EventHandler(this.addressContextMenu_Opened);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(267, 22);
            this.copyToolStripMenuItem1.Text = "&Copy  ( Ctrl + C )";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.pasteToolStripMenuItem.Text = "&Paste  ( Ctrl + V )";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(264, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.addToolStripMenuItem.Text = "Add to History  ( Ctrl + Enter )";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.removeToolStripMenuItem.Text = "Remove from History  ( Ctrl + Del )";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(264, 6);
            // 
            // clearAllHistoryToolStripMenuItem
            // 
            this.clearAllHistoryToolStripMenuItem.Name = "clearAllHistoryToolStripMenuItem";
            this.clearAllHistoryToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.clearAllHistoryToolStripMenuItem.Text = "Clear All History  ( Ctrl + Shift + Del )";
            this.clearAllHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearAllHistoryToolStripMenuItem_Click);
            // 
            // cutAllHistoryToolStripMenuItem
            // 
            this.cutAllHistoryToolStripMenuItem.Name = "cutAllHistoryToolStripMenuItem";
            this.cutAllHistoryToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.cutAllHistoryToolStripMenuItem.Text = "Cut All History  ( Ctrl + Shift + X )";
            this.cutAllHistoryToolStripMenuItem.Click += new System.EventHandler(this.cutAllHistoryToolStripMenuItem_Click);
            // 
            // copyAllHistoryToolStripMenuItem
            // 
            this.copyAllHistoryToolStripMenuItem.Name = "copyAllHistoryToolStripMenuItem";
            this.copyAllHistoryToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.copyAllHistoryToolStripMenuItem.Text = "Copy All History  ( Ctrl + Shift + C )";
            this.copyAllHistoryToolStripMenuItem.Click += new System.EventHandler(this.copyAllHistoryToolStripMenuItem_Click);
            // 
            // pasteAllHistoryToolStripMenuItem
            // 
            this.pasteAllHistoryToolStripMenuItem.Name = "pasteAllHistoryToolStripMenuItem";
            this.pasteAllHistoryToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.pasteAllHistoryToolStripMenuItem.Text = "Paste All History  ( Ctrl + Shift + V )";
            this.pasteAllHistoryToolStripMenuItem.Click += new System.EventHandler(this.pasteAllHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(264, 6);
            // 
            // showHistoryToolStripMenuItem
            // 
            this.showHistoryToolStripMenuItem.Name = "showHistoryToolStripMenuItem";
            this.showHistoryToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.showHistoryToolStripMenuItem.Text = "Show History  ( double-click )";
            this.showHistoryToolStripMenuItem.Click += new System.EventHandler(this.showHistoryToolStripMenuItem_Click);
            // 
            // autoHistoryToolStripMenuItem
            // 
            this.autoHistoryToolStripMenuItem.Name = "autoHistoryToolStripMenuItem";
            this.autoHistoryToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.autoHistoryToolStripMenuItem.Text = "&Auto Add History";
            this.autoHistoryToolStripMenuItem.Click += new System.EventHandler(this.autoHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(264, 6);
            // 
            // addOffsetToolStripMenuItem
            // 
            this.addOffsetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxAddressAddOffset});
            this.addOffsetToolStripMenuItem.Name = "addOffsetToolStripMenuItem";
            this.addOffsetToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.addOffsetToolStripMenuItem.Text = "Add &Offset";
            this.addOffsetToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.addOffsetToolStripMenuItem_MouseMove);
            // 
            // toolStripTextBoxAddressAddOffset
            // 
            this.toolStripTextBoxAddressAddOffset.Name = "toolStripTextBoxAddressAddOffset";
            this.toolStripTextBoxAddressAddOffset.Size = new System.Drawing.Size(80, 23);
            this.toolStripTextBoxAddressAddOffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxAddressAddOffset_KeyDown);
            // 
            // NxtPage
            // 
            this.NxtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NxtPage.Enabled = false;
            this.NxtPage.Location = new System.Drawing.Point(527, 242);
            this.NxtPage.Name = "NxtPage";
            this.NxtPage.Size = new System.Drawing.Size(32, 21);
            this.NxtPage.TabIndex = 9;
            this.NxtPage.Text = "-->";
            this.NxtPage.UseVisualStyleBackColor = true;
            // 
            // ResList
            // 
            this.ResList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResList.AutoEllipsis = true;
            this.ResList.Location = new System.Drawing.Point(280, 242);
            this.ResList.Name = "ResList";
            this.ResList.Size = new System.Drawing.Size(144, 20);
            this.ResList.TabIndex = 7;
            this.ResList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchResults
            // 
            this.SearchResults.AllowUserToAddRows = false;
            this.SearchResults.AllowUserToResizeRows = false;
            this.SearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchResults.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SearchResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SearchResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.SearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.SearchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ACol,
            this.OVal,
            this.NVal,
            this.DifferCol});
            this.SearchResults.ContextMenuStrip = this.SearchResMenu;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SearchResults.DefaultCellStyle = dataGridViewCellStyle12;
            this.SearchResults.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.SearchResults.Location = new System.Drawing.Point(285, 25);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SearchResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.SearchResults.RowHeadersVisible = false;
            this.SearchResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchResults.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.SearchResults.RowTemplate.Height = 24;
            this.SearchResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SearchResults.ShowCellErrors = false;
            this.SearchResults.ShowCellToolTips = false;
            this.SearchResults.ShowEditingIcon = false;
            this.SearchResults.ShowRowErrors = false;
            this.SearchResults.Size = new System.Drawing.Size(273, 211);
            this.SearchResults.TabIndex = 6;
            this.SearchResults.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.SearchResults_UserDeletingRow);
            this.SearchResults.Sorted += new System.EventHandler(this.SearchResults_Sorted);
            this.SearchResults.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SearchResults_CellMouseDown);
            this.SearchResults.ColumnDividerDoubleClick += new System.Windows.Forms.DataGridViewColumnDividerDoubleClickEventHandler(this.SearchResults_ColumnDividerDoubleClick);
            // 
            // ACol
            // 
            this.ACol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ACol.HeaderText = "Address";
            this.ACol.Name = "ACol";
            this.ACol.ReadOnly = true;
            this.ACol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ACol.Width = 80;
            // 
            // OVal
            // 
            this.OVal.HeaderText = "Old";
            this.OVal.Name = "OVal";
            this.OVal.ReadOnly = true;
            this.OVal.Width = 53;
            // 
            // NVal
            // 
            this.NVal.HeaderText = "New";
            this.NVal.Name = "NVal";
            this.NVal.ReadOnly = true;
            this.NVal.Width = 53;
            // 
            // DifferCol
            // 
            this.DifferCol.HeaderText = "Diff";
            this.DifferCol.Name = "DifferCol";
            this.DifferCol.ReadOnly = true;
            this.DifferCol.Width = 60;
            // 
            // SearchResMenu
            // 
            this.SearchResMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PkAddress,
            this.ShowInMemView,
            this.BpSAddress,
            this.ShowInDiss,
            this.showInWatchList,
            this.makeCode,
            this.gCTWizardToolStripMenuItem,
            this.toolStripMenuItem3,
            this.copyToolStripMenuItem,
            this.SortToolStripMenuItem,
            this.toolStripMenuItem4,
            this.deleteToolStripMenuItem});
            this.SearchResMenu.Name = "SearchResMenu";
            this.SearchResMenu.Size = new System.Drawing.Size(161, 236);
            // 
            // PkAddress
            // 
            this.PkAddress.Name = "PkAddress";
            this.PkAddress.Size = new System.Drawing.Size(160, 22);
            this.PkAddress.Text = "&Poke";
            this.PkAddress.Click += new System.EventHandler(this.PkAddress_Click);
            // 
            // ShowInMemView
            // 
            this.ShowInMemView.Name = "ShowInMemView";
            this.ShowInMemView.Size = new System.Drawing.Size(160, 22);
            this.ShowInMemView.Text = "&Memory Viewer";
            this.ShowInMemView.Click += new System.EventHandler(this.ShowInMemView_Click);
            // 
            // BpSAddress
            // 
            this.BpSAddress.Name = "BpSAddress";
            this.BpSAddress.Size = new System.Drawing.Size(160, 22);
            this.BpSAddress.Text = "&Breakpoint";
            this.BpSAddress.Click += new System.EventHandler(this.BpSAddress_Click);
            // 
            // ShowInDiss
            // 
            this.ShowInDiss.Name = "ShowInDiss";
            this.ShowInDiss.Size = new System.Drawing.Size(160, 22);
            this.ShowInDiss.Text = "&Disassembler";
            this.ShowInDiss.Click += new System.EventHandler(this.ShowInDiss_Click);
            // 
            // showInWatchList
            // 
            this.showInWatchList.Name = "showInWatchList";
            this.showInWatchList.Size = new System.Drawing.Size(160, 22);
            this.showInWatchList.Text = "Add to &watchlist";
            this.showInWatchList.Click += new System.EventHandler(this.showInWatchList_Click);
            // 
            // makeCode
            // 
            this.makeCode.Name = "makeCode";
            this.makeCode.Size = new System.Drawing.Size(160, 22);
            this.makeCode.Text = "New GCT code";
            this.makeCode.Click += new System.EventHandler(this.makeCode_Click);
            // 
            // gCTWizardToolStripMenuItem
            // 
            this.gCTWizardToolStripMenuItem.Name = "gCTWizardToolStripMenuItem";
            this.gCTWizardToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.gCTWizardToolStripMenuItem.Text = "&GCT Wizard...";
            this.gCTWizardToolStripMenuItem.Click += new System.EventHandler(this.gCTWizardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // SortToolStripMenuItem
            // 
            this.SortToolStripMenuItem.Name = "SortToolStripMenuItem";
            this.SortToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.SortToolStripMenuItem.Text = "&Sort";
            this.SortToolStripMenuItem.Click += new System.EventHandler(this.SortToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(157, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // PrvPage
            // 
            this.PrvPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrvPage.Enabled = false;
            this.PrvPage.Location = new System.Drawing.Point(490, 242);
            this.PrvPage.Name = "PrvPage";
            this.PrvPage.Size = new System.Drawing.Size(32, 21);
            this.PrvPage.TabIndex = 8;
            this.PrvPage.Text = "<--";
            this.PrvPage.UseVisualStyleBackColor = true;
            // 
            // ResSrch
            // 
            this.ResSrch.Enabled = false;
            this.ResSrch.Location = new System.Drawing.Point(190, 220);
            this.ResSrch.Name = "ResSrch";
            this.ResSrch.Size = new System.Drawing.Size(87, 32);
            this.ResSrch.TabIndex = 5;
            this.ResSrch.Text = "Restart search";
            this.ResSrch.UseVisualStyleBackColor = true;
            this.ResSrch.Click += new System.EventHandler(this.ResSrch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.memEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.memStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.memRange);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memory Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start:";
            // 
            // memRange
            // 
            this.memRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memRange.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memRange.FormattingEnabled = true;
            this.memRange.Location = new System.Drawing.Point(6, 19);
            this.memRange.Name = "memRange";
            this.memRange.Size = new System.Drawing.Size(43, 22);
            this.memRange.TabIndex = 0;
            this.memRange.SelectedIndexChanged += new System.EventHandler(this.memRange_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxComparisonValue);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.comboBoxComparisonType);
            this.groupBox4.Controls.Add(this.comboBoxComparisonRHS);
            this.groupBox4.Location = new System.Drawing.Point(7, 83);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(133, 105);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search Condition";
            // 
            // textBoxComparisonValue
            // 
            this.textBoxComparisonValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxComparisonValue.ContextMenuStrip = this.InputConvert;
            this.textBoxComparisonValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComparisonValue.Location = new System.Drawing.Point(52, 77);
            this.textBoxComparisonValue.MaxLength = 8;
            this.textBoxComparisonValue.Name = "textBoxComparisonValue";
            this.textBoxComparisonValue.Size = new System.Drawing.Size(62, 20);
            this.textBoxComparisonValue.TabIndex = 3;
            this.textBoxComparisonValue.Text = "00000000";
            this.textBoxComparisonValue.TextChanged += new System.EventHandler(this.lowerValue_TextChanged);
            this.textBoxComparisonValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lowerValue_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Value:";
            // 
            // comboBoxComparisonType
            // 
            this.comboBoxComparisonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComparisonType.FormattingEnabled = true;
            this.comboBoxComparisonType.Items.AddRange(new object[] {
            "Equal",
            "Not equal",
            "Less than",
            "Less or equal",
            "Greater than",
            "Greater or equal",
            "Different by",
            "Different by less than",
            "Different by more than"});
            this.comboBoxComparisonType.Location = new System.Drawing.Point(6, 50);
            this.comboBoxComparisonType.MaxDropDownItems = 11;
            this.comboBoxComparisonType.Name = "comboBoxComparisonType";
            this.comboBoxComparisonType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxComparisonType.TabIndex = 0;
            this.comboBoxComparisonType.SelectedIndexChanged += new System.EventHandler(this.cmpType_SelectedIndexChanged);
            // 
            // comboBoxComparisonRHS
            // 
            this.comboBoxComparisonRHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComparisonRHS.FormattingEnabled = true;
            this.comboBoxComparisonRHS.Items.AddRange(new object[] {
            "Specific Value",
            "Unknown Value"});
            this.comboBoxComparisonRHS.Location = new System.Drawing.Point(6, 19);
            this.comboBoxComparisonRHS.Name = "comboBoxComparisonRHS";
            this.comboBoxComparisonRHS.Size = new System.Drawing.Size(121, 21);
            this.comboBoxComparisonRHS.TabIndex = 0;
            this.comboBoxComparisonRHS.SelectedIndexChanged += new System.EventHandler(this.comboBoxComparisonRHS_SelectedIndexChanged);
            // 
            // groupBoxSearchGroups
            // 
            this.groupBoxSearchGroups.Controls.Add(this.buttonClearSearchGroup);
            this.groupBoxSearchGroups.Controls.Add(this.buttonRemoveGroup);
            this.groupBoxSearchGroups.Controls.Add(this.buttonAddSearchGroup);
            this.groupBoxSearchGroups.Controls.Add(this.numericUpDownSearchGroup);
            this.groupBoxSearchGroups.Location = new System.Drawing.Point(146, 83);
            this.groupBoxSearchGroups.Name = "groupBoxSearchGroups";
            this.groupBoxSearchGroups.Size = new System.Drawing.Size(133, 74);
            this.groupBoxSearchGroups.TabIndex = 2;
            this.groupBoxSearchGroups.TabStop = false;
            this.groupBoxSearchGroups.Text = "Search Groups (1)";
            // 
            // buttonClearSearchGroup
            // 
            this.buttonClearSearchGroup.Location = new System.Drawing.Point(6, 46);
            this.buttonClearSearchGroup.Name = "buttonClearSearchGroup";
            this.buttonClearSearchGroup.Size = new System.Drawing.Size(55, 21);
            this.buttonClearSearchGroup.TabIndex = 3;
            this.buttonClearSearchGroup.Text = "Clear";
            this.buttonClearSearchGroup.UseVisualStyleBackColor = true;
            this.buttonClearSearchGroup.Click += new System.EventHandler(this.buttonClearSearchGroup_Click);
            // 
            // buttonRemoveGroup
            // 
            this.buttonRemoveGroup.Location = new System.Drawing.Point(6, 19);
            this.buttonRemoveGroup.Name = "buttonRemoveGroup";
            this.buttonRemoveGroup.Size = new System.Drawing.Size(55, 21);
            this.buttonRemoveGroup.TabIndex = 2;
            this.buttonRemoveGroup.Text = "Remove";
            this.buttonRemoveGroup.UseVisualStyleBackColor = true;
            this.buttonRemoveGroup.Click += new System.EventHandler(this.buttonRemoveGroup_Click);
            // 
            // buttonAddSearchGroup
            // 
            this.buttonAddSearchGroup.Location = new System.Drawing.Point(79, 19);
            this.buttonAddSearchGroup.Name = "buttonAddSearchGroup";
            this.buttonAddSearchGroup.Size = new System.Drawing.Size(49, 21);
            this.buttonAddSearchGroup.TabIndex = 1;
            this.buttonAddSearchGroup.Text = "Add";
            this.buttonAddSearchGroup.UseVisualStyleBackColor = true;
            this.buttonAddSearchGroup.Click += new System.EventHandler(this.buttonAddSearchGroup_Click);
            // 
            // numericUpDownSearchGroup
            // 
            this.numericUpDownSearchGroup.Location = new System.Drawing.Point(79, 47);
            this.numericUpDownSearchGroup.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownSearchGroup.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSearchGroup.Name = "numericUpDownSearchGroup";
            this.numericUpDownSearchGroup.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownSearchGroup.TabIndex = 0;
            this.numericUpDownSearchGroup.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSearchGroup.ValueChanged += new System.EventHandler(this.numericUpDownSearchGroup_ValueChanged);
            // 
            // MemView
            // 
            this.MemView.Controls.Add(this.vScrollBarMemViewGrid);
            this.MemView.Controls.Add(this.memViewGrid);
            this.MemView.Controls.Add(this.groupBox27);
            this.MemView.Controls.Add(this.groupBox9);
            this.MemView.Controls.Add(this.groupBox8);
            this.MemView.Controls.Add(this.MemViewAutoUp);
            this.MemView.Controls.Add(this.groupBox7);
            this.MemView.Controls.Add(this.groupBox6);
            this.MemView.Location = new System.Drawing.Point(4, 22);
            this.MemView.Name = "MemView";
            this.MemView.Padding = new System.Windows.Forms.Padding(3);
            this.MemView.Size = new System.Drawing.Size(565, 296);
            this.MemView.TabIndex = 1;
            this.MemView.Text = "Memory Viewer";
            this.MemView.UseVisualStyleBackColor = true;
            this.MemView.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // vScrollBarMemViewGrid
            // 
            this.vScrollBarMemViewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBarMemViewGrid.LargeChange = 256;
            this.vScrollBarMemViewGrid.Location = new System.Drawing.Point(540, 12);
            this.vScrollBarMemViewGrid.Maximum = 25165824;
            this.vScrollBarMemViewGrid.Name = "vScrollBarMemViewGrid";
            this.vScrollBarMemViewGrid.Size = new System.Drawing.Size(17, 278);
            this.vScrollBarMemViewGrid.SmallChange = 16;
            this.vScrollBarMemViewGrid.TabIndex = 8;
            this.vScrollBarMemViewGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBarMemViewGrid_Scroll);
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.MemViewSearchType);
            this.groupBox27.Controls.Add(this.MemViewSearchPerfom);
            this.groupBox27.Controls.Add(this.MemViewSearchString);
            this.groupBox27.Location = new System.Drawing.Point(3, 190);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(187, 65);
            this.groupBox27.TabIndex = 7;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Search";
            // 
            // MemViewSearchType
            // 
            this.MemViewSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MemViewSearchType.FormattingEnabled = true;
            this.MemViewSearchType.Items.AddRange(new object[] {
            "ANSI",
            "ANSI case sensitive",
            "Unicode",
            "Unicode case sensitive",
            "Hex"});
            this.MemViewSearchType.Location = new System.Drawing.Point(6, 15);
            this.MemViewSearchType.Name = "MemViewSearchType";
            this.MemViewSearchType.Size = new System.Drawing.Size(112, 21);
            this.MemViewSearchType.TabIndex = 9;
            // 
            // MemViewSearchPerfom
            // 
            this.MemViewSearchPerfom.Location = new System.Drawing.Point(124, 15);
            this.MemViewSearchPerfom.Name = "MemViewSearchPerfom";
            this.MemViewSearchPerfom.Size = new System.Drawing.Size(57, 22);
            this.MemViewSearchPerfom.TabIndex = 8;
            this.MemViewSearchPerfom.Tag = "1";
            this.MemViewSearchPerfom.Text = "Search";
            this.MemViewSearchPerfom.UseVisualStyleBackColor = true;
            this.MemViewSearchPerfom.Click += new System.EventHandler(this.MemViewSearchPerfom_Click);
            // 
            // MemViewSearchString
            // 
            this.MemViewSearchString.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemViewSearchString.Location = new System.Drawing.Point(6, 42);
            this.MemViewSearchString.MaxLength = 256;
            this.MemViewSearchString.Name = "MemViewSearchString";
            this.MemViewSearchString.Size = new System.Drawing.Size(175, 20);
            this.MemViewSearchString.TabIndex = 5;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.MemViewFPValue);
            this.groupBox9.Location = new System.Drawing.Point(87, 68);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(103, 45);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Floating point";
            // 
            // MemViewFPValue
            // 
            this.MemViewFPValue.Location = new System.Drawing.Point(6, 16);
            this.MemViewFPValue.Name = "MemViewFPValue";
            this.MemViewFPValue.Size = new System.Drawing.Size(94, 20);
            this.MemViewFPValue.TabIndex = 0;
            this.MemViewFPValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBoxPokeOperation);
            this.groupBox8.Controls.Add(this.memViewPButton);
            this.groupBox8.Controls.Add(this.memViewPValue);
            this.groupBox8.Controls.Add(this.memViewPAddress);
            this.groupBox8.Location = new System.Drawing.Point(3, 113);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(187, 71);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Value poke";
            // 
            // comboBoxPokeOperation
            // 
            this.comboBoxPokeOperation.FormattingEnabled = true;
            this.comboBoxPokeOperation.Items.AddRange(new object[] {
            "Write",
            "OR",
            "AND",
            "XOR",
            "ADD",
            "SUB",
            "MUL",
            "DIV"});
            this.comboBoxPokeOperation.Location = new System.Drawing.Point(100, 45);
            this.comboBoxPokeOperation.Name = "comboBoxPokeOperation";
            this.comboBoxPokeOperation.Size = new System.Drawing.Size(67, 21);
            this.comboBoxPokeOperation.TabIndex = 13;
            // 
            // memViewPButton
            // 
            this.memViewPButton.Location = new System.Drawing.Point(27, 43);
            this.memViewPButton.Name = "memViewPButton";
            this.memViewPButton.Size = new System.Drawing.Size(62, 22);
            this.memViewPButton.TabIndex = 8;
            this.memViewPButton.Tag = "1";
            this.memViewPButton.Text = "Poke";
            this.memViewPButton.UseVisualStyleBackColor = true;
            this.memViewPButton.Click += new System.EventHandler(this.PButton_Click);
            // 
            // memViewPValue
            // 
            this.memViewPValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.memViewPValue.ContextMenuStrip = this.InputConvert;
            this.memViewPValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memViewPValue.Location = new System.Drawing.Point(100, 19);
            this.memViewPValue.MaxLength = 8;
            this.memViewPValue.Name = "memViewPValue";
            this.memViewPValue.Size = new System.Drawing.Size(62, 20);
            this.memViewPValue.TabIndex = 7;
            this.memViewPValue.Text = "00000000";
            this.memViewPValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lowerValue_MouseClick);
            // 
            // MemViewAutoUp
            // 
            this.MemViewAutoUp.AutoSize = true;
            this.MemViewAutoUp.Location = new System.Drawing.Point(10, 51);
            this.MemViewAutoUp.Name = "MemViewAutoUp";
            this.MemViewAutoUp.Size = new System.Drawing.Size(84, 17);
            this.MemViewAutoUp.TabIndex = 3;
            this.MemViewAutoUp.Text = "Auto update";
            this.MemViewAutoUp.UseVisualStyleBackColor = true;
            this.MemViewAutoUp.Click += new System.EventHandler(this.MemViewAutoUp_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.MemViewShowMode);
            this.groupBox7.Location = new System.Drawing.Point(3, 68);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(78, 45);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "View mode";
            // 
            // MemViewShowMode
            // 
            this.MemViewShowMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MemViewShowMode.FormattingEnabled = true;
            this.MemViewShowMode.Items.AddRange(new object[] {
            "Hex",
            "ASCII",
            "ANSI",
            "Unicode",
            "Single",
            "Auto 0",
            "Auto ."});
            this.MemViewShowMode.Location = new System.Drawing.Point(6, 16);
            this.MemViewShowMode.Name = "MemViewShowMode";
            this.MemViewShowMode.Size = new System.Drawing.Size(66, 21);
            this.MemViewShowMode.TabIndex = 0;
            this.MemViewShowMode.SelectedIndexChanged += new System.EventHandler(this.MemViewShowMode_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.memViewAValue);
            this.groupBox6.Controls.Add(this.MemViewScrollbar);
            this.groupBox6.Controls.Add(this.MemViewUpdate);
            this.groupBox6.Controls.Add(this.MemViewARange);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(187, 47);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Address";
            // 
            // MemViewScrollbar
            // 
            this.MemViewScrollbar.DecimalPlaces = 8;
            this.MemViewScrollbar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemViewScrollbar.Location = new System.Drawing.Point(110, 19);
            this.MemViewScrollbar.Margin = new System.Windows.Forms.Padding(0);
            this.MemViewScrollbar.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MemViewScrollbar.Name = "MemViewScrollbar";
            this.MemViewScrollbar.Size = new System.Drawing.Size(16, 20);
            this.MemViewScrollbar.TabIndex = 2;
            this.MemViewScrollbar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MemViewScrollbar.ValueChanged += new System.EventHandler(this.MemViewScrollbar_ValueChanged);
            this.MemViewScrollbar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MemViewScrollbar_KeyDown);
            // 
            // MemViewUpdate
            // 
            this.MemViewUpdate.Location = new System.Drawing.Point(131, 19);
            this.MemViewUpdate.Name = "MemViewUpdate";
            this.MemViewUpdate.Size = new System.Drawing.Size(50, 22);
            this.MemViewUpdate.TabIndex = 5;
            this.MemViewUpdate.Text = "Update";
            this.MemViewUpdate.UseVisualStyleBackColor = true;
            this.MemViewUpdate.Click += new System.EventHandler(this.MemViewUpdate_Click);
            // 
            // MemViewARange
            // 
            this.MemViewARange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MemViewARange.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemViewARange.FormattingEnabled = true;
            this.MemViewARange.Location = new System.Drawing.Point(4, 19);
            this.MemViewARange.Name = "MemViewARange";
            this.MemViewARange.Size = new System.Drawing.Size(38, 22);
            this.MemViewARange.TabIndex = 4;
            this.MemViewARange.SelectedIndexChanged += new System.EventHandler(this.MemViewARange_SelectedIndexChanged);
            // 
            // BreakpointPage
            // 
            this.BreakpointPage.Controls.Add(this.panel5);
            this.BreakpointPage.Controls.Add(this.panel3);
            this.BreakpointPage.Controls.Add(this.groupBoxStep);
            this.BreakpointPage.Controls.Add(this.splitContainerRegASM);
            this.BreakpointPage.Controls.Add(this.groupBox11);
            this.BreakpointPage.Controls.Add(this.groupBox10);
            this.BreakpointPage.Location = new System.Drawing.Point(4, 22);
            this.BreakpointPage.Name = "BreakpointPage";
            this.BreakpointPage.Size = new System.Drawing.Size(565, 296);
            this.BreakpointPage.TabIndex = 2;
            this.BreakpointPage.Text = "Breakpoints";
            this.BreakpointPage.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checkBoxLogSteps);
            this.panel5.Controls.Add(this.BPOutSwap);
            this.panel5.Controls.Add(this.buttonShowMem);
            this.panel5.Controls.Add(this.BPSkipCount);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Location = new System.Drawing.Point(394, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(176, 67);
            this.panel5.TabIndex = 11;
            // 
            // checkBoxLogSteps
            // 
            this.checkBoxLogSteps.AutoSize = true;
            this.checkBoxLogSteps.Location = new System.Drawing.Point(89, 15);
            this.checkBoxLogSteps.Name = "checkBoxLogSteps";
            this.checkBoxLogSteps.Size = new System.Drawing.Size(74, 17);
            this.checkBoxLogSteps.TabIndex = 11;
            this.checkBoxLogSteps.Text = "Log Steps";
            this.checkBoxLogSteps.UseVisualStyleBackColor = true;
            this.checkBoxLogSteps.CheckedChanged += new System.EventHandler(this.checkBoxLogSteps_CheckedChanged);
            // 
            // BPOutSwap
            // 
            this.BPOutSwap.Location = new System.Drawing.Point(5, 9);
            this.BPOutSwap.Name = "BPOutSwap";
            this.BPOutSwap.Size = new System.Drawing.Size(68, 24);
            this.BPOutSwap.TabIndex = 5;
            this.BPOutSwap.Text = "Text view";
            this.BPOutSwap.UseVisualStyleBackColor = true;
            this.BPOutSwap.Click += new System.EventHandler(this.BPOutSwap_Click);
            // 
            // buttonShowMem
            // 
            this.buttonShowMem.ContextMenuStrip = this.ShowMemContextMenu;
            this.buttonShowMem.Location = new System.Drawing.Point(5, 38);
            this.buttonShowMem.Name = "buttonShowMem";
            this.buttonShowMem.Size = new System.Drawing.Size(68, 24);
            this.buttonShowMem.TabIndex = 10;
            this.buttonShowMem.Text = "Show Mem";
            this.buttonShowMem.UseVisualStyleBackColor = true;
            this.buttonShowMem.Click += new System.EventHandler(this.buttonShowMem_Click);
            // 
            // ShowMemContextMenu
            // 
            this.ShowMemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowMemAddressToolStripMenuItem,
            this.toolStripTextBoxShowMemAddress,
            this.toolStripMenuItem14,
            this.ShowMemValueToolStripMenuItem,
            this.toolStripTextBoxShowMemValue,
            this.toolStripMenuItem15,
            this.SRR0NEQToolStripMenuItem2,
            this.SRR0EQToolStripMenuItem2,
            this.toolStripMenuItem17,
            this.viewFloatsInHexToolStripMenuItem});
            this.ShowMemContextMenu.Name = "ShowMemContextMenu";
            this.ShowMemContextMenu.Size = new System.Drawing.Size(170, 182);
            this.ShowMemContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ShowMemContextMenu_Opening);
            // 
            // ShowMemAddressToolStripMenuItem
            // 
            this.ShowMemAddressToolStripMenuItem.Name = "ShowMemAddressToolStripMenuItem";
            this.ShowMemAddressToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.ShowMemAddressToolStripMenuItem.Text = "&Address";
            this.ShowMemAddressToolStripMenuItem.Click += new System.EventHandler(this.ShowMemAddressToolStripMenuItem_Click);
            // 
            // toolStripTextBoxShowMemAddress
            // 
            this.toolStripTextBoxShowMemAddress.Name = "toolStripTextBoxShowMemAddress";
            this.toolStripTextBoxShowMemAddress.Size = new System.Drawing.Size(80, 23);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(166, 6);
            // 
            // ShowMemValueToolStripMenuItem
            // 
            this.ShowMemValueToolStripMenuItem.Name = "ShowMemValueToolStripMenuItem";
            this.ShowMemValueToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.ShowMemValueToolStripMenuItem.Text = "&Value";
            this.ShowMemValueToolStripMenuItem.Click += new System.EventHandler(this.ShowMemValueToolStripMenuItem_Click);
            // 
            // toolStripTextBoxShowMemValue
            // 
            this.toolStripTextBoxShowMemValue.Name = "toolStripTextBoxShowMemValue";
            this.toolStripTextBoxShowMemValue.Size = new System.Drawing.Size(80, 23);
            this.toolStripTextBoxShowMemValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxShowMemValue_KeyDown);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(166, 6);
            // 
            // SRR0NEQToolStripMenuItem2
            // 
            this.SRR0NEQToolStripMenuItem2.Name = "SRR0NEQToolStripMenuItem2";
            this.SRR0NEQToolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.SRR0NEQToolStripMenuItem2.Text = "&SRR0 !=";
            this.SRR0NEQToolStripMenuItem2.Click += new System.EventHandler(this.SRR0NEQToolStripMenuItem_Click);
            // 
            // SRR0EQToolStripMenuItem2
            // 
            this.SRR0EQToolStripMenuItem2.Name = "SRR0EQToolStripMenuItem2";
            this.SRR0EQToolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.SRR0EQToolStripMenuItem2.Text = "S&RR0 ==";
            this.SRR0EQToolStripMenuItem2.Click += new System.EventHandler(this.SRR0EQToolStripMenuItem_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(166, 6);
            // 
            // viewFloatsInHexToolStripMenuItem
            // 
            this.viewFloatsInHexToolStripMenuItem.CheckOnClick = true;
            this.viewFloatsInHexToolStripMenuItem.Name = "viewFloatsInHexToolStripMenuItem";
            this.viewFloatsInHexToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.viewFloatsInHexToolStripMenuItem.Text = "View Floats in Hex";
            this.viewFloatsInHexToolStripMenuItem.CheckedChanged += new System.EventHandler(this.viewFloatsInHexToolStripMenuItem_CheckedChanged);
            // 
            // BPSkipCount
            // 
            this.BPSkipCount.AutoSize = true;
            this.BPSkipCount.Location = new System.Drawing.Point(130, 44);
            this.BPSkipCount.Name = "BPSkipCount";
            this.BPSkipCount.Size = new System.Drawing.Size(25, 13);
            this.BPSkipCount.TabIndex = 7;
            this.BPSkipCount.Text = "000";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(86, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Skipped:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.groupBox26);
            this.panel3.Controls.Add(this.groupBox25);
            this.panel3.Location = new System.Drawing.Point(417, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 212);
            this.panel3.TabIndex = 14;
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.checkBoxBPCondEnable);
            this.groupBox26.Controls.Add(this.BPCondList);
            this.groupBox26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox26.Location = new System.Drawing.Point(0, 103);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(145, 109);
            this.groupBox26.TabIndex = 8;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "    Active conditions";
            // 
            // checkBoxBPCondEnable
            // 
            this.checkBoxBPCondEnable.AutoSize = true;
            this.checkBoxBPCondEnable.Location = new System.Drawing.Point(6, 0);
            this.checkBoxBPCondEnable.Name = "checkBoxBPCondEnable";
            this.checkBoxBPCondEnable.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBPCondEnable.TabIndex = 11;
            this.checkBoxBPCondEnable.UseVisualStyleBackColor = true;
            this.checkBoxBPCondEnable.CheckedChanged += new System.EventHandler(this.checkBoxBPCondEnable_CheckedChanged);
            // 
            // BPCondList
            // 
            this.BPCondList.ContextMenuStrip = this.BPCondMenu;
            this.BPCondList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BPCondList.FormattingEnabled = true;
            this.BPCondList.Location = new System.Drawing.Point(3, 16);
            this.BPCondList.Name = "BPCondList";
            this.BPCondList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.BPCondList.Size = new System.Drawing.Size(139, 82);
            this.BPCondList.TabIndex = 12;
            this.BPCondList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BPCondList_MouseDown);
            this.BPCondList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BPCondList_KeyDown);
            // 
            // BPCondMenu
            // 
            this.BPCondMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem4,
            this.copyToolStripMenuItem2,
            this.pasteToolStripMenuItem1,
            this.toolStripMenuItem9,
            this.sRR0ToolStripMenuItem,
            this.sRR0ToolStripMenuItem1,
            this.toolStripMenuItem10,
            this.deleteToolStripMenuItem1,
            this.clearAllToolStripMenuItem,
            this.toolStripMenuItem12,
            this.setConditionGroupToolStripMenuItem});
            this.BPCondMenu.Name = "BPCondMenu";
            this.BPCondMenu.Size = new System.Drawing.Size(183, 198);
            this.BPCondMenu.Opened += new System.EventHandler(this.BPCondMenu_Opened);
            // 
            // copyToolStripMenuItem4
            // 
            this.copyToolStripMenuItem4.Name = "copyToolStripMenuItem4";
            this.copyToolStripMenuItem4.Size = new System.Drawing.Size(182, 22);
            this.copyToolStripMenuItem4.Text = "Copy";
            this.copyToolStripMenuItem4.Click += new System.EventHandler(this.copyToolStripMenuItem4_Click);
            // 
            // copyToolStripMenuItem2
            // 
            this.copyToolStripMenuItem2.Name = "copyToolStripMenuItem2";
            this.copyToolStripMenuItem2.Size = new System.Drawing.Size(182, 22);
            this.copyToolStripMenuItem2.Text = "Copy All";
            this.copyToolStripMenuItem2.Click += new System.EventHandler(this.copyToolStripMenuItem2_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(179, 6);
            // 
            // sRR0ToolStripMenuItem
            // 
            this.sRR0ToolStripMenuItem.Name = "sRR0ToolStripMenuItem";
            this.sRR0ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.sRR0ToolStripMenuItem.Text = "SRR0 !=";
            this.sRR0ToolStripMenuItem.Click += new System.EventHandler(this.SRR0NEQToolStripMenuItem_Click);
            // 
            // sRR0ToolStripMenuItem1
            // 
            this.sRR0ToolStripMenuItem1.Name = "sRR0ToolStripMenuItem1";
            this.sRR0ToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.sRR0ToolStripMenuItem1.Text = "SRR0 ==";
            this.sRR0ToolStripMenuItem1.Click += new System.EventHandler(this.SRR0EQToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(179, 6);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(179, 6);
            // 
            // setConditionGroupToolStripMenuItem
            // 
            this.setConditionGroupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetConditionGroupTextBox});
            this.setConditionGroupToolStripMenuItem.Name = "setConditionGroupToolStripMenuItem";
            this.setConditionGroupToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.setConditionGroupToolStripMenuItem.Text = "Set Condition Group";
            this.setConditionGroupToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.setConditionGroupToolStripMenuItem_MouseMove);
            // 
            // SetConditionGroupTextBox
            // 
            this.SetConditionGroupTextBox.HideSelection = false;
            this.SetConditionGroupTextBox.Name = "SetConditionGroupTextBox";
            this.SetConditionGroupTextBox.Size = new System.Drawing.Size(100, 23);
            this.SetConditionGroupTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetConditionGroupTextBox_KeyDown);
            this.SetConditionGroupTextBox.TextChanged += new System.EventHandler(this.SetConditionGroupTextBox_TextChanged);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.BPCondClear);
            this.groupBox25.Controls.Add(this.BPConditionAdd);
            this.groupBox25.Controls.Add(this.BPCondDel);
            this.groupBox25.Controls.Add(this.BPCondValue);
            this.groupBox25.Controls.Add(this.BPConditionCompare);
            this.groupBox25.Controls.Add(this.BPConditionRegSelect);
            this.groupBox25.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox25.Location = new System.Drawing.Point(0, 0);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(145, 103);
            this.groupBox25.TabIndex = 7;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Add BP condition";
            // 
            // BPCondClear
            // 
            this.BPCondClear.Location = new System.Drawing.Point(87, 75);
            this.BPCondClear.Name = "BPCondClear";
            this.BPCondClear.Size = new System.Drawing.Size(52, 24);
            this.BPCondClear.TabIndex = 11;
            this.BPCondClear.Text = "Clear all";
            this.BPCondClear.UseVisualStyleBackColor = true;
            this.BPCondClear.Click += new System.EventHandler(this.BPCondClear_Click);
            // 
            // BPConditionAdd
            // 
            this.BPConditionAdd.Location = new System.Drawing.Point(87, 15);
            this.BPConditionAdd.Name = "BPConditionAdd";
            this.BPConditionAdd.Size = new System.Drawing.Size(52, 24);
            this.BPConditionAdd.TabIndex = 9;
            this.BPConditionAdd.Text = "Add";
            this.BPConditionAdd.UseVisualStyleBackColor = true;
            this.BPConditionAdd.Click += new System.EventHandler(this.BPConditionAdd_Click);
            // 
            // BPCondDel
            // 
            this.BPCondDel.Location = new System.Drawing.Point(87, 45);
            this.BPCondDel.Name = "BPCondDel";
            this.BPCondDel.Size = new System.Drawing.Size(52, 24);
            this.BPCondDel.TabIndex = 10;
            this.BPCondDel.Text = "Delete";
            this.BPCondDel.UseVisualStyleBackColor = true;
            this.BPCondDel.Click += new System.EventHandler(this.BPCondDel_Click);
            // 
            // BPCondValue
            // 
            this.BPCondValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.BPCondValue.ContextMenuStrip = this.InputConvert;
            this.BPCondValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPCondValue.Location = new System.Drawing.Point(6, 75);
            this.BPCondValue.MaxLength = 8;
            this.BPCondValue.Name = "BPCondValue";
            this.BPCondValue.Size = new System.Drawing.Size(62, 20);
            this.BPCondValue.TabIndex = 8;
            this.BPCondValue.Text = "00000000";
            // 
            // BPConditionCompare
            // 
            this.BPConditionCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BPConditionCompare.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.BPConditionCompare.FormattingEnabled = true;
            this.BPConditionCompare.Items.AddRange(new object[] {
            "==",
            "!=",
            ">=",
            ">",
            "<=",
            "<"});
            this.BPConditionCompare.Location = new System.Drawing.Point(26, 45);
            this.BPConditionCompare.Name = "BPConditionCompare";
            this.BPConditionCompare.Size = new System.Drawing.Size(42, 22);
            this.BPConditionCompare.TabIndex = 1;
            // 
            // BPConditionRegSelect
            // 
            this.BPConditionRegSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BPConditionRegSelect.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.BPConditionRegSelect.FormattingEnabled = true;
            this.BPConditionRegSelect.Location = new System.Drawing.Point(12, 15);
            this.BPConditionRegSelect.Name = "BPConditionRegSelect";
            this.BPConditionRegSelect.Size = new System.Drawing.Size(56, 22);
            this.BPConditionRegSelect.TabIndex = 0;
            this.BPConditionRegSelect.SelectedIndexChanged += new System.EventHandler(this.BPConditionRegSelect_SelectedIndexChanged);
            // 
            // groupBoxStep
            // 
            this.groupBoxStep.Controls.Add(this.buttonStepUntil);
            this.groupBoxStep.Controls.Add(this.BPStepButton);
            this.groupBoxStep.Controls.Add(this.BPStepOverButton);
            this.groupBoxStep.Controls.Add(this.buttonStepOutOf);
            this.groupBoxStep.Location = new System.Drawing.Point(224, 3);
            this.groupBoxStep.Name = "groupBoxStep";
            this.groupBoxStep.Size = new System.Drawing.Size(158, 76);
            this.groupBoxStep.TabIndex = 13;
            this.groupBoxStep.TabStop = false;
            this.groupBoxStep.Text = "Step";
            // 
            // buttonStepUntil
            // 
            this.buttonStepUntil.Location = new System.Drawing.Point(81, 46);
            this.buttonStepUntil.Name = "buttonStepUntil";
            this.buttonStepUntil.Size = new System.Drawing.Size(69, 23);
            this.buttonStepUntil.TabIndex = 12;
            this.buttonStepUntil.Text = "Step until";
            this.buttonStepUntil.UseVisualStyleBackColor = true;
            this.buttonStepUntil.Click += new System.EventHandler(this.buttonStepUntil_Click);
            // 
            // BPStepButton
            // 
            this.BPStepButton.ContextMenuStrip = this.ShowMemContextMenu;
            this.BPStepButton.Location = new System.Drawing.Point(6, 16);
            this.BPStepButton.Name = "BPStepButton";
            this.BPStepButton.Size = new System.Drawing.Size(69, 24);
            this.BPStepButton.TabIndex = 6;
            this.BPStepButton.Text = "Step into";
            this.BPStepButton.UseVisualStyleBackColor = true;
            this.BPStepButton.Click += new System.EventHandler(this.BPStepButton_Click);
            // 
            // BPStepOverButton
            // 
            this.BPStepOverButton.ContextMenuStrip = this.ShowMemContextMenu;
            this.BPStepOverButton.Location = new System.Drawing.Point(6, 46);
            this.BPStepOverButton.Name = "BPStepOverButton";
            this.BPStepOverButton.Size = new System.Drawing.Size(69, 24);
            this.BPStepOverButton.TabIndex = 9;
            this.BPStepOverButton.Text = "Step over";
            this.BPStepOverButton.UseVisualStyleBackColor = true;
            this.BPStepOverButton.Click += new System.EventHandler(this.BPStepOverButton_Click);
            // 
            // buttonStepOutOf
            // 
            this.buttonStepOutOf.ContextMenuStrip = this.StepOutContextMenu;
            this.buttonStepOutOf.Location = new System.Drawing.Point(81, 16);
            this.buttonStepOutOf.Name = "buttonStepOutOf";
            this.buttonStepOutOf.Size = new System.Drawing.Size(69, 24);
            this.buttonStepOutOf.TabIndex = 11;
            this.buttonStepOutOf.Text = "Step out";
            this.buttonStepOutOf.UseVisualStyleBackColor = true;
            this.buttonStepOutOf.Click += new System.EventHandler(this.buttonStepOutOf_Click);
            // 
            // StepOutContextMenu
            // 
            this.StepOutContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.walkToBlrToolStripMenuItem,
            this.stackFrameToolStripMenuItem,
            this.leafToolStripMenuItem});
            this.StepOutContextMenu.Name = "StepOutContextMenu";
            this.StepOutContextMenu.Size = new System.Drawing.Size(137, 70);
            // 
            // walkToBlrToolStripMenuItem
            // 
            this.walkToBlrToolStripMenuItem.Name = "walkToBlrToolStripMenuItem";
            this.walkToBlrToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.walkToBlrToolStripMenuItem.Text = "&Walk to blr";
            this.walkToBlrToolStripMenuItem.Click += new System.EventHandler(this.walkToBlrToolStripMenuItem_Click);
            // 
            // stackFrameToolStripMenuItem
            // 
            this.stackFrameToolStripMenuItem.Name = "stackFrameToolStripMenuItem";
            this.stackFrameToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.stackFrameToolStripMenuItem.Text = "&Stack frame";
            this.stackFrameToolStripMenuItem.Click += new System.EventHandler(this.stackFrameToolStripMenuItem_Click);
            // 
            // leafToolStripMenuItem
            // 
            this.leafToolStripMenuItem.Name = "leafToolStripMenuItem";
            this.leafToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.leafToolStripMenuItem.Text = "&Leaf";
            this.leafToolStripMenuItem.Click += new System.EventHandler(this.leafToolStripMenuItem_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.BPCancel);
            this.groupBox11.Controls.Add(this.BPFire);
            this.groupBox11.Controls.Add(this.BPType);
            this.groupBox11.Location = new System.Drawing.Point(113, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(98, 76);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Breakpoint type";
            // 
            // BPCancel
            // 
            this.BPCancel.Enabled = false;
            this.BPCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPCancel.Location = new System.Drawing.Point(42, 46);
            this.BPCancel.Name = "BPCancel";
            this.BPCancel.Size = new System.Drawing.Size(50, 24);
            this.BPCancel.TabIndex = 5;
            this.BPCancel.Text = "Cancel";
            this.BPCancel.UseVisualStyleBackColor = true;
            this.BPCancel.Click += new System.EventHandler(this.BPCancel_Click);
            // 
            // BPFire
            // 
            this.BPFire.ContextMenuStrip = this.ShowMemContextMenu;
            this.BPFire.Location = new System.Drawing.Point(6, 46);
            this.BPFire.Name = "BPFire";
            this.BPFire.Size = new System.Drawing.Size(31, 24);
            this.BPFire.TabIndex = 10;
            this.BPFire.Text = "Set";
            this.BPFire.UseVisualStyleBackColor = true;
            this.BPFire.Click += new System.EventHandler(this.BPFire_Click);
            // 
            // BPType
            // 
            this.BPType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BPType.FormattingEnabled = true;
            this.BPType.Items.AddRange(new object[] {
            "Read",
            "Write",
            "Read / Write",
            "Execute"});
            this.BPType.Location = new System.Drawing.Point(6, 19);
            this.BPType.Name = "BPType";
            this.BPType.Size = new System.Drawing.Size(85, 21);
            this.BPType.TabIndex = 9;
            this.BPType.SelectedIndexChanged += new System.EventHandler(this.BPType_SelectedIndexChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.BPExact);
            this.groupBox10.Controls.Add(this.BPAddress);
            this.groupBox10.Location = new System.Drawing.Point(3, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(98, 76);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Address";
            // 
            // BPExact
            // 
            this.BPExact.AutoSize = true;
            this.BPExact.Checked = true;
            this.BPExact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BPExact.Location = new System.Drawing.Point(6, 50);
            this.BPExact.Name = "BPExact";
            this.BPExact.Size = new System.Drawing.Size(85, 17);
            this.BPExact.TabIndex = 8;
            this.BPExact.Text = "Exact match";
            this.BPExact.UseVisualStyleBackColor = true;
            // 
            // DisPage
            // 
            this.DisPage.Controls.Add(this.groupBoxDisasmCallStack);
            this.DisPage.Controls.Add(this.groupBoxDisasm);
            this.DisPage.Controls.Add(this.groupBox13);
            this.DisPage.Controls.Add(this.groupBox12);
            this.DisPage.Controls.Add(this.DisScroll);
            this.DisPage.Controls.Add(this.DisAssBox);
            this.DisPage.Location = new System.Drawing.Point(4, 22);
            this.DisPage.Name = "DisPage";
            this.DisPage.Size = new System.Drawing.Size(565, 296);
            this.DisPage.TabIndex = 3;
            this.DisPage.Text = "Disassembler";
            this.DisPage.UseVisualStyleBackColor = true;
            this.DisPage.Enter += new System.EventHandler(this.DisPage_Enter);
            // 
            // groupBoxDisasmCallStack
            // 
            this.groupBoxDisasmCallStack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxDisasmCallStack.Controls.Add(this.listBoxCallStack);
            this.groupBoxDisasmCallStack.Location = new System.Drawing.Point(3, 213);
            this.groupBoxDisasmCallStack.Name = "groupBoxDisasmCallStack";
            this.groupBoxDisasmCallStack.Size = new System.Drawing.Size(192, 77);
            this.groupBoxDisasmCallStack.TabIndex = 8;
            this.groupBoxDisasmCallStack.TabStop = false;
            this.groupBoxDisasmCallStack.Text = "Call Stack";
            // 
            // listBoxCallStack
            // 
            this.listBoxCallStack.ContextMenuStrip = this.CallStackContextMenu;
            this.listBoxCallStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCallStack.FormattingEnabled = true;
            this.listBoxCallStack.Location = new System.Drawing.Point(3, 16);
            this.listBoxCallStack.Name = "listBoxCallStack";
            this.listBoxCallStack.Size = new System.Drawing.Size(186, 56);
            this.listBoxCallStack.TabIndex = 0;
            this.listBoxCallStack.DoubleClick += new System.EventHandler(this.listBoxCallStack_DoubleClick);
            // 
            // CallStackContextMenu
            // 
            this.CallStackContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem5,
            this.copyAllToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.CallStackContextMenu.Name = "CallStackContextMenu";
            this.CallStackContextMenu.Size = new System.Drawing.Size(120, 70);
            // 
            // copyToolStripMenuItem5
            // 
            this.copyToolStripMenuItem5.Name = "copyToolStripMenuItem5";
            this.copyToolStripMenuItem5.Size = new System.Drawing.Size(119, 22);
            this.copyToolStripMenuItem5.Text = "&Copy";
            this.copyToolStripMenuItem5.Click += new System.EventHandler(this.copyToolStripMenuItem5_Click);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.copyAllToolStripMenuItem.Text = "Copy &All";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // groupBoxDisasm
            // 
            this.groupBoxDisasm.Controls.Add(this.radioButtonSearchDisassemblyDown);
            this.groupBoxDisasm.Controls.Add(this.radioButtonSearchDisassemblyUp);
            this.groupBoxDisasm.Controls.Add(this.buttonDisassemblySearch);
            this.groupBoxDisasm.Controls.Add(this.textBoxDisassemblySearch);
            this.groupBoxDisasm.Location = new System.Drawing.Point(3, 58);
            this.groupBoxDisasm.Name = "groupBoxDisasm";
            this.groupBoxDisasm.Size = new System.Drawing.Size(192, 69);
            this.groupBoxDisasm.TabIndex = 7;
            this.groupBoxDisasm.TabStop = false;
            this.groupBoxDisasm.Text = "Regex Search";
            // 
            // radioButtonSearchDisassemblyDown
            // 
            this.radioButtonSearchDisassemblyDown.AutoSize = true;
            this.radioButtonSearchDisassemblyDown.Location = new System.Drawing.Point(46, 18);
            this.radioButtonSearchDisassemblyDown.Name = "radioButtonSearchDisassemblyDown";
            this.radioButtonSearchDisassemblyDown.Size = new System.Drawing.Size(51, 17);
            this.radioButtonSearchDisassemblyDown.TabIndex = 5;
            this.radioButtonSearchDisassemblyDown.Text = "down";
            this.radioButtonSearchDisassemblyDown.UseVisualStyleBackColor = true;
            // 
            // radioButtonSearchDisassemblyUp
            // 
            this.radioButtonSearchDisassemblyUp.AutoSize = true;
            this.radioButtonSearchDisassemblyUp.Checked = true;
            this.radioButtonSearchDisassemblyUp.Location = new System.Drawing.Point(6, 18);
            this.radioButtonSearchDisassemblyUp.Name = "radioButtonSearchDisassemblyUp";
            this.radioButtonSearchDisassemblyUp.Size = new System.Drawing.Size(37, 17);
            this.radioButtonSearchDisassemblyUp.TabIndex = 4;
            this.radioButtonSearchDisassemblyUp.TabStop = true;
            this.radioButtonSearchDisassemblyUp.Text = "up";
            this.radioButtonSearchDisassemblyUp.UseVisualStyleBackColor = true;
            // 
            // buttonDisassemblySearch
            // 
            this.buttonDisassemblySearch.Location = new System.Drawing.Point(103, 12);
            this.buttonDisassemblySearch.Name = "buttonDisassemblySearch";
            this.buttonDisassemblySearch.Size = new System.Drawing.Size(79, 23);
            this.buttonDisassemblySearch.TabIndex = 3;
            this.buttonDisassemblySearch.Text = "Search";
            this.buttonDisassemblySearch.UseVisualStyleBackColor = true;
            this.buttonDisassemblySearch.Click += new System.EventHandler(this.buttonDisassemblySearch_Click);
            // 
            // textBoxDisassemblySearch
            // 
            this.textBoxDisassemblySearch.Location = new System.Drawing.Point(6, 41);
            this.textBoxDisassemblySearch.Name = "textBoxDisassemblySearch";
            this.textBoxDisassemblySearch.Size = new System.Drawing.Size(176, 20);
            this.textBoxDisassemblySearch.TabIndex = 2;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.AsText);
            this.groupBox13.Controls.Add(this.Assemble);
            this.groupBox13.Controls.Add(this.AsAddress);
            this.groupBox13.Location = new System.Drawing.Point(3, 133);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(192, 73);
            this.groupBox13.TabIndex = 6;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Selected Address";
            // 
            // Assemble
            // 
            this.Assemble.Location = new System.Drawing.Point(76, 19);
            this.Assemble.Name = "Assemble";
            this.Assemble.Size = new System.Drawing.Size(106, 22);
            this.Assemble.TabIndex = 8;
            this.Assemble.Tag = "1";
            this.Assemble.Text = "Assemble";
            this.Assemble.UseVisualStyleBackColor = true;
            this.Assemble.Click += new System.EventHandler(this.Assemble_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.DisUpDown);
            this.groupBox12.Controls.Add(this.DisRegion);
            this.groupBox12.Controls.Add(this.DisUpdateBtn);
            this.groupBox12.Location = new System.Drawing.Point(3, 6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(192, 46);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Visible Address";
            this.groupBox12.UseCompatibleTextRendering = true;
            // 
            // DisUpDown
            // 
            this.DisUpDown.DecimalPlaces = 8;
            this.DisUpDown.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisUpDown.Location = new System.Drawing.Point(73, 18);
            this.DisUpDown.Margin = new System.Windows.Forms.Padding(0);
            this.DisUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.DisUpDown.Name = "DisUpDown";
            this.DisUpDown.Size = new System.Drawing.Size(16, 20);
            this.DisUpDown.TabIndex = 2;
            this.DisUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DisUpDown.ValueChanged += new System.EventHandler(this.DisUpDown_ValueChanged);
            // 
            // DisUpdateBtn
            // 
            this.DisUpdateBtn.Location = new System.Drawing.Point(95, 16);
            this.DisUpdateBtn.Name = "DisUpdateBtn";
            this.DisUpdateBtn.Size = new System.Drawing.Size(87, 22);
            this.DisUpdateBtn.TabIndex = 5;
            this.DisUpdateBtn.Text = "Update";
            this.DisUpdateBtn.UseVisualStyleBackColor = true;
            this.DisUpdateBtn.Click += new System.EventHandler(this.DisUpdateBtn_Click);
            // 
            // DisScroll
            // 
            this.DisScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DisScroll.LargeChange = 0;
            this.DisScroll.Location = new System.Drawing.Point(527, 6);
            this.DisScroll.Maximum = 2;
            this.DisScroll.Name = "DisScroll";
            this.DisScroll.Size = new System.Drawing.Size(21, 284);
            this.DisScroll.SmallChange = 0;
            this.DisScroll.TabIndex = 1;
            this.DisScroll.Value = 1;
            // 
            // DisAssBox
            // 
            this.DisAssBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DisAssBox.ContextMenuStrip = this.disAssContextMenu;
            this.DisAssBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisAssBox.ItemHeight = 14;
            this.DisAssBox.Location = new System.Drawing.Point(197, 6);
            this.DisAssBox.Name = "DisAssBox";
            this.DisAssBox.Size = new System.Drawing.Size(351, 284);
            this.DisAssBox.TabIndex = 0;
            // 
            // disAssContextMenu
            // 
            this.disAssContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem3,
            this.copyFunctionToolStripMenuItem,
            this.toolStripMenuItem11,
            this.DisAssSetBP,
            this.DisAssPoke,
            this.disAssGCTCode,
            this.memoryViewerToolStripMenuItem,
            this.toolStripMenuItem13,
            this.setSRR0HereToolStripMenuItem,
            this.toolStripMenuItem18,
            this.gotoFunctionStartToolStripMenuItem,
            this.gotoFunctionEndToolStripMenuItem});
            this.disAssContextMenu.Name = "contextMenuStrip1";
            this.disAssContextMenu.Size = new System.Drawing.Size(178, 220);
            this.disAssContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.disAssContextMenu_Opening);
            // 
            // copyToolStripMenuItem3
            // 
            this.copyToolStripMenuItem3.Name = "copyToolStripMenuItem3";
            this.copyToolStripMenuItem3.Size = new System.Drawing.Size(177, 22);
            this.copyToolStripMenuItem3.Text = "&Copy";
            this.copyToolStripMenuItem3.Click += new System.EventHandler(this.copyToolStripMenuItem3_Click);
            // 
            // copyFunctionToolStripMenuItem
            // 
            this.copyFunctionToolStripMenuItem.Name = "copyFunctionToolStripMenuItem";
            this.copyFunctionToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.copyFunctionToolStripMenuItem.Text = "Copy &Function";
            this.copyFunctionToolStripMenuItem.Click += new System.EventHandler(this.copyFunctionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(174, 6);
            // 
            // DisAssSetBP
            // 
            this.DisAssSetBP.Name = "DisAssSetBP";
            this.DisAssSetBP.Size = new System.Drawing.Size(177, 22);
            this.DisAssSetBP.Text = "&Breakpoint";
            this.DisAssSetBP.Click += new System.EventHandler(this.DisAssSetBP_Click);
            // 
            // DisAssPoke
            // 
            this.DisAssPoke.Name = "DisAssPoke";
            this.DisAssPoke.Size = new System.Drawing.Size(177, 22);
            this.DisAssPoke.Text = "&Poke";
            this.DisAssPoke.Click += new System.EventHandler(this.DisAssPoke_Click);
            // 
            // disAssGCTCode
            // 
            this.disAssGCTCode.Name = "disAssGCTCode";
            this.disAssGCTCode.Size = new System.Drawing.Size(177, 22);
            this.disAssGCTCode.Text = "&GCT code";
            this.disAssGCTCode.Click += new System.EventHandler(this.disAssGCTCode_Click);
            // 
            // memoryViewerToolStripMenuItem
            // 
            this.memoryViewerToolStripMenuItem.Name = "memoryViewerToolStripMenuItem";
            this.memoryViewerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.memoryViewerToolStripMenuItem.Text = "&Memory Viewer";
            this.memoryViewerToolStripMenuItem.Click += new System.EventHandler(this.memoryViewerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(174, 6);
            // 
            // setSRR0HereToolStripMenuItem
            // 
            this.setSRR0HereToolStripMenuItem.Name = "setSRR0HereToolStripMenuItem";
            this.setSRR0HereToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.setSRR0HereToolStripMenuItem.Text = "&Set SRR0 Here";
            this.setSRR0HereToolStripMenuItem.Click += new System.EventHandler(this.setSRR0HereToolStripMenuItem_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(174, 6);
            // 
            // gotoFunctionStartToolStripMenuItem
            // 
            this.gotoFunctionStartToolStripMenuItem.Name = "gotoFunctionStartToolStripMenuItem";
            this.gotoFunctionStartToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.gotoFunctionStartToolStripMenuItem.Text = "Goto Function S&tart";
            this.gotoFunctionStartToolStripMenuItem.Click += new System.EventHandler(this.gotoFunctionStartToolStripMenuItem_Click);
            // 
            // gotoFunctionEndToolStripMenuItem
            // 
            this.gotoFunctionEndToolStripMenuItem.Name = "gotoFunctionEndToolStripMenuItem";
            this.gotoFunctionEndToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.gotoFunctionEndToolStripMenuItem.Text = "Goto Function &End";
            this.gotoFunctionEndToolStripMenuItem.Click += new System.EventHandler(this.gotoFunctionEndToolStripMenuItem_Click);
            // 
            // shotPage
            // 
            this.shotPage.Controls.Add(this.checkBoxAutoPreview);
            this.shotPage.Controls.Add(this.groupBox17);
            this.shotPage.Controls.Add(this.ShotPreview);
            this.shotPage.Controls.Add(this.groupBox16);
            this.shotPage.Controls.Add(this.groupBox15);
            this.shotPage.Controls.Add(this.groupBox14);
            this.shotPage.Controls.Add(this.ScreenshotCapBox);
            this.shotPage.Location = new System.Drawing.Point(4, 22);
            this.shotPage.Name = "shotPage";
            this.shotPage.Size = new System.Drawing.Size(565, 296);
            this.shotPage.TabIndex = 4;
            this.shotPage.Text = "Screenshots";
            this.shotPage.UseVisualStyleBackColor = true;
            this.shotPage.Enter += new System.EventHandler(this.shotPage_Enter);
            // 
            // checkBoxAutoPreview
            // 
            this.checkBoxAutoPreview.AutoSize = true;
            this.checkBoxAutoPreview.Location = new System.Drawing.Point(127, 266);
            this.checkBoxAutoPreview.Name = "checkBoxAutoPreview";
            this.checkBoxAutoPreview.Size = new System.Drawing.Size(89, 17);
            this.checkBoxAutoPreview.TabIndex = 6;
            this.checkBoxAutoPreview.Text = "Auto-Preview";
            this.checkBoxAutoPreview.UseVisualStyleBackColor = true;
            this.checkBoxAutoPreview.Click += new System.EventHandler(this.checkBoxAutoPreview_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox17.Controls.Add(this.label10);
            this.groupBox17.Controls.Add(this.JPGQualLabel);
            this.groupBox17.Controls.Add(this.JPGQual);
            this.groupBox17.Controls.Add(this.ImgFormat);
            this.groupBox17.Location = new System.Drawing.Point(5, 178);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(211, 73);
            this.groupBox17.TabIndex = 5;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Image format";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 23);
            this.label10.TabIndex = 3;
            this.label10.Text = "JPEG Quality:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // JPGQualLabel
            // 
            this.JPGQualLabel.Location = new System.Drawing.Point(172, 44);
            this.JPGQualLabel.Name = "JPGQualLabel";
            this.JPGQualLabel.Size = new System.Drawing.Size(33, 23);
            this.JPGQualLabel.TabIndex = 2;
            this.JPGQualLabel.Text = "85%";
            this.JPGQualLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // JPGQual
            // 
            this.JPGQual.AutoSize = false;
            this.JPGQual.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.JPGQual.Location = new System.Drawing.Point(68, 44);
            this.JPGQual.Maximum = 100;
            this.JPGQual.Minimum = 1;
            this.JPGQual.Name = "JPGQual";
            this.JPGQual.Size = new System.Drawing.Size(98, 23);
            this.JPGQual.TabIndex = 1;
            this.JPGQual.TickStyle = System.Windows.Forms.TickStyle.None;
            this.JPGQual.Value = 85;
            this.JPGQual.Scroll += new System.EventHandler(this.JPGQual_Scroll);
            // 
            // ImgFormat
            // 
            this.ImgFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImgFormat.FormattingEnabled = true;
            this.ImgFormat.Items.AddRange(new object[] {
            "PNG (recommended)",
            "BMP",
            "JPEG",
            "TIFF"});
            this.ImgFormat.Location = new System.Drawing.Point(5, 19);
            this.ImgFormat.Name = "ImgFormat";
            this.ImgFormat.Size = new System.Drawing.Size(200, 21);
            this.ImgFormat.TabIndex = 0;
            this.ImgFormat.SelectedIndexChanged += new System.EventHandler(this.ImgFormat_SelectedIndexChanged);
            // 
            // ShotPreview
            // 
            this.ShotPreview.Location = new System.Drawing.Point(5, 257);
            this.ShotPreview.Name = "ShotPreview";
            this.ShotPreview.Size = new System.Drawing.Size(116, 33);
            this.ShotPreview.TabIndex = 4;
            this.ShotPreview.Text = "Preview";
            this.ShotPreview.UseVisualStyleBackColor = true;
            this.ShotPreview.Click += new System.EventHandler(this.ShotPreview_Click);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.ShotSizingType);
            this.groupBox16.Location = new System.Drawing.Point(5, 123);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(211, 49);
            this.groupBox16.TabIndex = 3;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Sizing";
            // 
            // ShotSizingType
            // 
            this.ShotSizingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShotSizingType.FormattingEnabled = true;
            this.ShotSizingType.Items.AddRange(new object[] {
            "Do not resize",
            "Resize to 16:9",
            "Resize to 4:3"});
            this.ShotSizingType.Location = new System.Drawing.Point(5, 19);
            this.ShotSizingType.Name = "ShotSizingType";
            this.ShotSizingType.Size = new System.Drawing.Size(200, 21);
            this.ShotSizingType.TabIndex = 0;
            this.ShotSizingType.SelectedIndexChanged += new System.EventHandler(this.ShotSizingType_SelectedIndexChanged);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.label9);
            this.groupBox15.Location = new System.Drawing.Point(5, 50);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(211, 65);
            this.groupBox15.TabIndex = 2;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Information";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 42);
            this.label9.TabIndex = 0;
            this.label9.Text = "Files will not be overwritten. They will all end with a number at the end countin" +
                "g up!";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.ShotFilename);
            this.groupBox14.Controls.Add(this.ShotCapture);
            this.groupBox14.Location = new System.Drawing.Point(5, 0);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(552, 44);
            this.groupBox14.TabIndex = 1;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Filename";
            // 
            // ShotFilename
            // 
            this.ShotFilename.Location = new System.Drawing.Point(106, 16);
            this.ShotFilename.Name = "ShotFilename";
            this.ShotFilename.Size = new System.Drawing.Size(436, 20);
            this.ShotFilename.TabIndex = 1;
            // 
            // ShotCapture
            // 
            this.ShotCapture.Location = new System.Drawing.Point(7, 13);
            this.ShotCapture.Name = "ShotCapture";
            this.ShotCapture.Size = new System.Drawing.Size(93, 25);
            this.ShotCapture.TabIndex = 0;
            this.ShotCapture.Text = "Capture";
            this.ShotCapture.UseVisualStyleBackColor = true;
            this.ShotCapture.Click += new System.EventHandler(this.ShotCapture_Click);
            // 
            // ScreenshotCapBox
            // 
            this.ScreenshotCapBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScreenshotCapBox.BackColor = System.Drawing.Color.Black;
            this.ScreenshotCapBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ScreenshotCapBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ScreenshotCapBox.Location = new System.Drawing.Point(229, 50);
            this.ScreenshotCapBox.Name = "ScreenshotCapBox";
            this.ScreenshotCapBox.Size = new System.Drawing.Size(319, 240);
            this.ScreenshotCapBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ScreenshotCapBox.TabIndex = 0;
            this.ScreenshotCapBox.TabStop = false;
            // 
            // GCTPage
            // 
            this.GCTPage.Controls.Add(this.checkBoxPauseCodes);
            this.GCTPage.Controls.Add(this.GCTStoreImm);
            this.GCTPage.Controls.Add(this.GCTDisable);
            this.GCTPage.Controls.Add(this.GCTListFileName);
            this.GCTPage.Controls.Add(this.GCTLoadList);
            this.GCTPage.Controls.Add(this.GCTSaveList);
            this.GCTPage.Controls.Add(this.GCTSndButton);
            this.GCTPage.Controls.Add(this.GCTDelBtn);
            this.GCTPage.Controls.Add(this.GCTAddCode);
            this.GCTPage.Controls.Add(this.GCTCodeValues);
            this.GCTPage.Controls.Add(this.GCTCodeList);
            this.GCTPage.Location = new System.Drawing.Point(4, 22);
            this.GCTPage.Name = "GCTPage";
            this.GCTPage.Size = new System.Drawing.Size(565, 296);
            this.GCTPage.TabIndex = 5;
            this.GCTPage.Text = "GCT codes";
            this.GCTPage.UseVisualStyleBackColor = true;
            this.GCTPage.Enter += new System.EventHandler(this.GCTPage_Enter);
            // 
            // checkBoxPauseCodes
            // 
            this.checkBoxPauseCodes.AutoSize = true;
            this.checkBoxPauseCodes.Location = new System.Drawing.Point(10, 271);
            this.checkBoxPauseCodes.Name = "checkBoxPauseCodes";
            this.checkBoxPauseCodes.Size = new System.Drawing.Size(128, 17);
            this.checkBoxPauseCodes.TabIndex = 14;
            this.checkBoxPauseCodes.Text = "Pause While Sending";
            this.checkBoxPauseCodes.UseVisualStyleBackColor = true;
            this.checkBoxPauseCodes.CheckedChanged += new System.EventHandler(this.checkBoxPauseCodes_CheckedChanged);
            // 
            // GCTStoreImm
            // 
            this.GCTStoreImm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GCTStoreImm.Location = new System.Drawing.Point(375, 267);
            this.GCTStoreImm.Name = "GCTStoreImm";
            this.GCTStoreImm.Size = new System.Drawing.Size(173, 23);
            this.GCTStoreImm.TabIndex = 13;
            this.GCTStoreImm.Text = "Store immediantely";
            this.GCTStoreImm.UseVisualStyleBackColor = true;
            this.GCTStoreImm.Click += new System.EventHandler(this.GCTStoreImm_Click);
            // 
            // GCTDisable
            // 
            this.GCTDisable.Location = new System.Drawing.Point(10, 193);
            this.GCTDisable.Name = "GCTDisable";
            this.GCTDisable.Size = new System.Drawing.Size(145, 25);
            this.GCTDisable.TabIndex = 12;
            this.GCTDisable.Text = "Disable codes";
            this.GCTDisable.UseVisualStyleBackColor = true;
            this.GCTDisable.Click += new System.EventHandler(this.GCTDisable_Click);
            // 
            // GCTListFileName
            // 
            this.GCTListFileName.Location = new System.Drawing.Point(5, 161);
            this.GCTListFileName.Name = "GCTListFileName";
            this.GCTListFileName.Size = new System.Drawing.Size(150, 20);
            this.GCTListFileName.TabIndex = 11;
            this.GCTListFileName.Text = "code list file name here";
            this.GCTListFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GCTLoadList
            // 
            this.GCTLoadList.Location = new System.Drawing.Point(5, 131);
            this.GCTLoadList.Name = "GCTLoadList";
            this.GCTLoadList.Size = new System.Drawing.Size(150, 27);
            this.GCTLoadList.TabIndex = 10;
            this.GCTLoadList.Text = "Load code list";
            this.GCTLoadList.UseVisualStyleBackColor = true;
            this.GCTLoadList.Click += new System.EventHandler(this.GCTLoadList_Click);
            // 
            // GCTSaveList
            // 
            this.GCTSaveList.Location = new System.Drawing.Point(5, 98);
            this.GCTSaveList.Name = "GCTSaveList";
            this.GCTSaveList.Size = new System.Drawing.Size(150, 27);
            this.GCTSaveList.TabIndex = 9;
            this.GCTSaveList.Text = "Save code list";
            this.GCTSaveList.UseVisualStyleBackColor = true;
            this.GCTSaveList.Click += new System.EventHandler(this.GCTSaveList_Click);
            // 
            // GCTSndButton
            // 
            this.GCTSndButton.Location = new System.Drawing.Point(10, 226);
            this.GCTSndButton.Name = "GCTSndButton";
            this.GCTSndButton.Size = new System.Drawing.Size(145, 39);
            this.GCTSndButton.TabIndex = 8;
            this.GCTSndButton.Text = "Send to game";
            this.GCTSndButton.UseVisualStyleBackColor = true;
            this.GCTSndButton.Click += new System.EventHandler(this.GCTSndButton_Click);
            // 
            // GCTDelBtn
            // 
            this.GCTDelBtn.Location = new System.Drawing.Point(5, 45);
            this.GCTDelBtn.Name = "GCTDelBtn";
            this.GCTDelBtn.Size = new System.Drawing.Size(150, 27);
            this.GCTDelBtn.TabIndex = 7;
            this.GCTDelBtn.Text = "Delete code";
            this.GCTDelBtn.UseVisualStyleBackColor = true;
            this.GCTDelBtn.Click += new System.EventHandler(this.GCTDelBtn_Click);
            // 
            // GCTAddCode
            // 
            this.GCTAddCode.Location = new System.Drawing.Point(5, 12);
            this.GCTAddCode.Name = "GCTAddCode";
            this.GCTAddCode.Size = new System.Drawing.Size(150, 27);
            this.GCTAddCode.TabIndex = 6;
            this.GCTAddCode.Text = "Add code";
            this.GCTAddCode.UseVisualStyleBackColor = true;
            this.GCTAddCode.Click += new System.EventHandler(this.GCTAddCode_Click);
            // 
            // GCTCodeValues
            // 
            this.GCTCodeValues.AcceptsReturn = true;
            this.GCTCodeValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GCTCodeValues.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.GCTCodeValues.Enabled = false;
            this.GCTCodeValues.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCTCodeValues.Location = new System.Drawing.Point(375, 12);
            this.GCTCodeValues.MaxLength = 32000;
            this.GCTCodeValues.Multiline = true;
            this.GCTCodeValues.Name = "GCTCodeValues";
            this.GCTCodeValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GCTCodeValues.Size = new System.Drawing.Size(173, 249);
            this.GCTCodeValues.TabIndex = 5;
            this.GCTCodeValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GCTCodeValues_KeyDown);
            // 
            // GCTCodeList
            // 
            this.GCTCodeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GCTCodeList.CheckBoxes = true;
            this.GCTCodeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.GCTCodeList.ContextMenuStrip = this.gctCodeMenu;
            this.GCTCodeList.FullRowSelect = true;
            this.GCTCodeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem1.StateImageIndex = 0;
            this.GCTCodeList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.GCTCodeList.LabelEdit = true;
            this.GCTCodeList.Location = new System.Drawing.Point(161, 12);
            this.GCTCodeList.MultiSelect = false;
            this.GCTCodeList.Name = "GCTCodeList";
            this.GCTCodeList.ShowGroups = false;
            this.GCTCodeList.Size = new System.Drawing.Size(208, 278);
            this.GCTCodeList.TabIndex = 4;
            this.GCTCodeList.UseCompatibleStateImageBehavior = false;
            this.GCTCodeList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 185;
            // 
            // gctCodeMenu
            // 
            this.gctCodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gctMenuAddCode,
            this.gctMenuDeleteCode,
            this.gCTWizardToolStripMenuItem1,
            this.DisableCodeLinesToolStripMenuItem,
            this.enableToolStripMenuItem});
            this.gctCodeMenu.Name = "gctCodeMenu";
            this.gctCodeMenu.Size = new System.Drawing.Size(174, 114);
            // 
            // gctMenuAddCode
            // 
            this.gctMenuAddCode.Name = "gctMenuAddCode";
            this.gctMenuAddCode.Size = new System.Drawing.Size(173, 22);
            this.gctMenuAddCode.Text = "Add code";
            this.gctMenuAddCode.Click += new System.EventHandler(this.GCTAddCode_Click);
            // 
            // gctMenuDeleteCode
            // 
            this.gctMenuDeleteCode.Name = "gctMenuDeleteCode";
            this.gctMenuDeleteCode.Size = new System.Drawing.Size(173, 22);
            this.gctMenuDeleteCode.Text = "Delete selected";
            this.gctMenuDeleteCode.Click += new System.EventHandler(this.GCTDelBtn_Click);
            // 
            // gCTWizardToolStripMenuItem1
            // 
            this.gCTWizardToolStripMenuItem1.Name = "gCTWizardToolStripMenuItem1";
            this.gCTWizardToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.gCTWizardToolStripMenuItem1.Text = "GCT Wizard...";
            this.gCTWizardToolStripMenuItem1.Click += new System.EventHandler(this.gCTWizardToolStripMenuItem_Click);
            // 
            // DisableCodeLinesToolStripMenuItem
            // 
            this.DisableCodeLinesToolStripMenuItem.Name = "DisableCodeLinesToolStripMenuItem";
            this.DisableCodeLinesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.DisableCodeLinesToolStripMenuItem.Text = "Disable Code Lines";
            this.DisableCodeLinesToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.enableToolStripMenuItem.Text = "Enable Code Lines";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // WatchTab
            // 
            this.WatchTab.Controls.Add(this.WatchListClear);
            this.WatchTab.Controls.Add(this.groupBox18);
            this.WatchTab.Controls.Add(this.WatchListOpenButton);
            this.WatchTab.Controls.Add(this.WatchListSaveButton);
            this.WatchTab.Controls.Add(this.WatchAdd);
            this.WatchTab.Controls.Add(this.WatchList);
            this.WatchTab.Location = new System.Drawing.Point(4, 22);
            this.WatchTab.Name = "WatchTab";
            this.WatchTab.Size = new System.Drawing.Size(565, 296);
            this.WatchTab.TabIndex = 7;
            this.WatchTab.Text = "Watch List";
            this.WatchTab.UseVisualStyleBackColor = true;
            // 
            // WatchListClear
            // 
            this.WatchListClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WatchListClear.Location = new System.Drawing.Point(106, 250);
            this.WatchListClear.Name = "WatchListClear";
            this.WatchListClear.Size = new System.Drawing.Size(90, 40);
            this.WatchListClear.TabIndex = 5;
            this.WatchListClear.Text = "Clear list";
            this.WatchListClear.UseVisualStyleBackColor = true;
            this.WatchListClear.Click += new System.EventHandler(this.WatchListClear_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox18.Controls.Add(this.WatchIntervalSet);
            this.groupBox18.Location = new System.Drawing.Point(432, 250);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(116, 40);
            this.groupBox18.TabIndex = 4;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Update interval (ms)";
            // 
            // WatchIntervalSet
            // 
            this.WatchIntervalSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WatchIntervalSet.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.WatchIntervalSet.Location = new System.Drawing.Point(10, 14);
            this.WatchIntervalSet.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.WatchIntervalSet.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.WatchIntervalSet.Name = "WatchIntervalSet";
            this.WatchIntervalSet.Size = new System.Drawing.Size(100, 20);
            this.WatchIntervalSet.TabIndex = 0;
            this.WatchIntervalSet.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // WatchListOpenButton
            // 
            this.WatchListOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WatchListOpenButton.Location = new System.Drawing.Point(315, 250);
            this.WatchListOpenButton.Name = "WatchListOpenButton";
            this.WatchListOpenButton.Size = new System.Drawing.Size(107, 40);
            this.WatchListOpenButton.TabIndex = 3;
            this.WatchListOpenButton.Text = "Load watch list";
            this.WatchListOpenButton.UseVisualStyleBackColor = true;
            this.WatchListOpenButton.Click += new System.EventHandler(this.WatchListOpenButton_Click);
            // 
            // WatchListSaveButton
            // 
            this.WatchListSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WatchListSaveButton.Location = new System.Drawing.Point(202, 250);
            this.WatchListSaveButton.Name = "WatchListSaveButton";
            this.WatchListSaveButton.Size = new System.Drawing.Size(107, 40);
            this.WatchListSaveButton.TabIndex = 2;
            this.WatchListSaveButton.Text = "Save watch list";
            this.WatchListSaveButton.UseVisualStyleBackColor = true;
            this.WatchListSaveButton.Click += new System.EventHandler(this.WatchListSaveButton_Click);
            // 
            // WatchAdd
            // 
            this.WatchAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WatchAdd.Location = new System.Drawing.Point(10, 250);
            this.WatchAdd.Name = "WatchAdd";
            this.WatchAdd.Size = new System.Drawing.Size(90, 40);
            this.WatchAdd.TabIndex = 1;
            this.WatchAdd.Text = "Add watch";
            this.WatchAdd.UseVisualStyleBackColor = true;
            this.WatchAdd.Click += new System.EventHandler(this.WatchAdd_Click);
            // 
            // WatchList
            // 
            this.WatchList.AllowUserToAddRows = false;
            this.WatchList.AllowUserToDeleteRows = false;
            this.WatchList.AllowUserToResizeRows = false;
            this.WatchList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WatchList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.WatchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WatchList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WatchCName,
            this.WatchCAddress,
            this.WatchCType,
            this.WatchCValue});
            this.WatchList.ContextMenuStrip = this.WatchCM;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WatchList.DefaultCellStyle = dataGridViewCellStyle18;
            this.WatchList.Location = new System.Drawing.Point(9, 8);
            this.WatchList.Name = "WatchList";
            this.WatchList.ReadOnly = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WatchList.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.WatchList.RowHeadersVisible = false;
            this.WatchList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.WatchList.RowTemplate.Height = 24;
            this.WatchList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.WatchList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WatchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WatchList.ShowCellErrors = false;
            this.WatchList.ShowCellToolTips = false;
            this.WatchList.ShowEditingIcon = false;
            this.WatchList.ShowRowErrors = false;
            this.WatchList.Size = new System.Drawing.Size(539, 236);
            this.WatchList.TabIndex = 0;
            this.WatchList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WatchList_CellContentDoubleClick);
            // 
            // WatchCName
            // 
            this.WatchCName.HeaderText = "Name";
            this.WatchCName.Name = "WatchCName";
            this.WatchCName.ReadOnly = true;
            this.WatchCName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WatchCName.Width = 200;
            // 
            // WatchCAddress
            // 
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WatchCAddress.DefaultCellStyle = dataGridViewCellStyle16;
            this.WatchCAddress.HeaderText = "Address";
            this.WatchCAddress.Name = "WatchCAddress";
            this.WatchCAddress.ReadOnly = true;
            this.WatchCAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WatchCType
            // 
            this.WatchCType.HeaderText = "Type";
            this.WatchCType.Name = "WatchCType";
            this.WatchCType.ReadOnly = true;
            this.WatchCType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WatchCType.Width = 80;
            // 
            // WatchCValue
            // 
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WatchCValue.DefaultCellStyle = dataGridViewCellStyle17;
            this.WatchCValue.HeaderText = "Value";
            this.WatchCValue.Name = "WatchCValue";
            this.WatchCValue.ReadOnly = true;
            this.WatchCValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WatchCM
            // 
            this.WatchCM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WatchAddWatchCM,
            this.WatchDeleteCM,
            this.WatchPokeCM,
            this.WatchEditCM});
            this.WatchCM.Name = "contextMenuStrip1";
            this.WatchCM.Size = new System.Drawing.Size(178, 92);
            this.WatchCM.Opening += new System.ComponentModel.CancelEventHandler(this.WatchCM_Opening);
            // 
            // WatchAddWatchCM
            // 
            this.WatchAddWatchCM.Name = "WatchAddWatchCM";
            this.WatchAddWatchCM.Size = new System.Drawing.Size(177, 22);
            this.WatchAddWatchCM.Text = "Add watch";
            this.WatchAddWatchCM.Click += new System.EventHandler(this.WatchAddWatchCM_Click);
            // 
            // WatchDeleteCM
            // 
            this.WatchDeleteCM.Enabled = false;
            this.WatchDeleteCM.Name = "WatchDeleteCM";
            this.WatchDeleteCM.Size = new System.Drawing.Size(177, 22);
            this.WatchDeleteCM.Text = "Delete";
            this.WatchDeleteCM.Click += new System.EventHandler(this.WatchDeleteCM_Click);
            // 
            // WatchPokeCM
            // 
            this.WatchPokeCM.Enabled = false;
            this.WatchPokeCM.Name = "WatchPokeCM";
            this.WatchPokeCM.Size = new System.Drawing.Size(177, 22);
            this.WatchPokeCM.Text = "Poke (first selected)";
            this.WatchPokeCM.Click += new System.EventHandler(this.WatchPokeCM_Click);
            // 
            // WatchEditCM
            // 
            this.WatchEditCM.Enabled = false;
            this.WatchEditCM.Name = "WatchEditCM";
            this.WatchEditCM.Size = new System.Drawing.Size(177, 22);
            this.WatchEditCM.Text = "Edit (first selected)";
            this.WatchEditCM.Click += new System.EventHandler(this.WatchEditCM_Click);
            // 
            // FSTTab
            // 
            this.FSTTab.Controls.Add(this.FSTSwapNow);
            this.FSTTab.Controls.Add(this.groupBox22);
            this.FSTTab.Controls.Add(this.groupBox21);
            this.FSTTab.Controls.Add(this.groupBox20);
            this.FSTTab.Controls.Add(this.groupBox19);
            this.FSTTab.Controls.Add(this.FSTRead);
            this.FSTTab.Controls.Add(this.FSTTreeView);
            this.FSTTab.Location = new System.Drawing.Point(4, 22);
            this.FSTTab.Name = "FSTTab";
            this.FSTTab.Size = new System.Drawing.Size(565, 296);
            this.FSTTab.TabIndex = 8;
            this.FSTTab.Text = "FST";
            this.FSTTab.UseVisualStyleBackColor = true;
            // 
            // FSTSwapNow
            // 
            this.FSTSwapNow.Enabled = false;
            this.FSTSwapNow.Location = new System.Drawing.Point(8, 270);
            this.FSTSwapNow.Name = "FSTSwapNow";
            this.FSTSwapNow.Size = new System.Drawing.Size(146, 20);
            this.FSTSwapNow.TabIndex = 6;
            this.FSTSwapNow.Text = "Swap now";
            this.FSTSwapNow.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.FSTGenSwap);
            this.groupBox22.Controls.Add(this.FSTSwapCode);
            this.groupBox22.Location = new System.Drawing.Point(8, 192);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(146, 72);
            this.groupBox22.TabIndex = 5;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Fileswap code data";
            // 
            // FSTGenSwap
            // 
            this.FSTGenSwap.Enabled = false;
            this.FSTGenSwap.Location = new System.Drawing.Point(10, 14);
            this.FSTGenSwap.Name = "FSTGenSwap";
            this.FSTGenSwap.Size = new System.Drawing.Size(127, 20);
            this.FSTGenSwap.TabIndex = 3;
            this.FSTGenSwap.Text = "Generate swap code";
            this.FSTGenSwap.UseVisualStyleBackColor = true;
            // 
            // FSTSwapCode
            // 
            this.FSTSwapCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FSTSwapCode.Location = new System.Drawing.Point(10, 35);
            this.FSTSwapCode.Multiline = true;
            this.FSTSwapCode.Name = "FSTSwapCode";
            this.FSTSwapCode.ReadOnly = true;
            this.FSTSwapCode.Size = new System.Drawing.Size(127, 34);
            this.FSTSwapCode.TabIndex = 0;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.FSTSetAsTarget);
            this.groupBox21.Controls.Add(this.FSTFileTarget);
            this.groupBox21.Location = new System.Drawing.Point(8, 136);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(146, 52);
            this.groupBox21.TabIndex = 4;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "File target";
            // 
            // FSTSetAsTarget
            // 
            this.FSTSetAsTarget.Enabled = false;
            this.FSTSetAsTarget.Location = new System.Drawing.Point(7, 30);
            this.FSTSetAsTarget.Name = "FSTSetAsTarget";
            this.FSTSetAsTarget.Size = new System.Drawing.Size(127, 20);
            this.FSTSetAsTarget.TabIndex = 2;
            this.FSTSetAsTarget.Text = "Set selected as target";
            this.FSTSetAsTarget.UseVisualStyleBackColor = true;
            // 
            // FSTFileTarget
            // 
            this.FSTFileTarget.Location = new System.Drawing.Point(4, 13);
            this.FSTFileTarget.Name = "FSTFileTarget";
            this.FSTFileTarget.Size = new System.Drawing.Size(130, 16);
            this.FSTFileTarget.TabIndex = 0;
            this.FSTFileTarget.Text = "abc";
            this.FSTFileTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.FSTSetAsSource);
            this.groupBox20.Controls.Add(this.FSTFileSource);
            this.groupBox20.Location = new System.Drawing.Point(8, 83);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(146, 52);
            this.groupBox20.TabIndex = 3;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "File source";
            // 
            // FSTSetAsSource
            // 
            this.FSTSetAsSource.Enabled = false;
            this.FSTSetAsSource.Location = new System.Drawing.Point(7, 30);
            this.FSTSetAsSource.Name = "FSTSetAsSource";
            this.FSTSetAsSource.Size = new System.Drawing.Size(127, 20);
            this.FSTSetAsSource.TabIndex = 2;
            this.FSTSetAsSource.Text = "Set selected as source";
            this.FSTSetAsSource.UseVisualStyleBackColor = true;
            // 
            // FSTFileSource
            // 
            this.FSTFileSource.Location = new System.Drawing.Point(4, 13);
            this.FSTFileSource.Name = "FSTFileSource";
            this.FSTFileSource.Size = new System.Drawing.Size(130, 16);
            this.FSTFileSource.TabIndex = 0;
            this.FSTFileSource.Text = "abc";
            this.FSTFileSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.FSTCodeData);
            this.groupBox19.Location = new System.Drawing.Point(8, 32);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(146, 51);
            this.groupBox19.TabIndex = 2;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Memory data";
            // 
            // FSTCodeData
            // 
            this.FSTCodeData.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FSTCodeData.Location = new System.Drawing.Point(10, 14);
            this.FSTCodeData.Multiline = true;
            this.FSTCodeData.Name = "FSTCodeData";
            this.FSTCodeData.ReadOnly = true;
            this.FSTCodeData.Size = new System.Drawing.Size(127, 34);
            this.FSTCodeData.TabIndex = 0;
            // 
            // FSTRead
            // 
            this.FSTRead.Location = new System.Drawing.Point(8, 9);
            this.FSTRead.Name = "FSTRead";
            this.FSTRead.Size = new System.Drawing.Size(146, 20);
            this.FSTRead.TabIndex = 1;
            this.FSTRead.Text = "Read FST";
            this.FSTRead.UseVisualStyleBackColor = true;
            this.FSTRead.Click += new System.EventHandler(this.FSTRead_Click);
            // 
            // FSTTreeView
            // 
            this.FSTTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FSTTreeView.Location = new System.Drawing.Point(160, 9);
            this.FSTTreeView.Name = "FSTTreeView";
            this.FSTTreeView.Size = new System.Drawing.Size(387, 281);
            this.FSTTreeView.TabIndex = 0;
            // 
            // ToolPage
            // 
            this.ToolPage.Controls.Add(this.groupBox24);
            this.ToolPage.Controls.Add(this.groupBox23);
            this.ToolPage.Controls.Add(this.label11);
            this.ToolPage.Location = new System.Drawing.Point(4, 22);
            this.ToolPage.Name = "ToolPage";
            this.ToolPage.Size = new System.Drawing.Size(565, 296);
            this.ToolPage.TabIndex = 9;
            this.ToolPage.Text = "Tools";
            this.ToolPage.UseVisualStyleBackColor = true;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.ToolsDump);
            this.groupBox24.Controls.Add(this.ToolsBrowseDump);
            this.groupBox24.Controls.Add(this.ToolsDumpFileName);
            this.groupBox24.Controls.Add(this.label16);
            this.groupBox24.Controls.Add(this.ToolsDumpEnd);
            this.groupBox24.Controls.Add(this.label14);
            this.groupBox24.Controls.Add(this.ToolsDumpStart);
            this.groupBox24.Controls.Add(this.label15);
            this.groupBox24.Controls.Add(this.ToolsDumpRegions);
            this.groupBox24.Location = new System.Drawing.Point(6, 203);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(543, 87);
            this.groupBox24.TabIndex = 2;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Memory dumping:";
            // 
            // ToolsDump
            // 
            this.ToolsDump.Location = new System.Drawing.Point(6, 47);
            this.ToolsDump.Name = "ToolsDump";
            this.ToolsDump.Size = new System.Drawing.Size(530, 34);
            this.ToolsDump.TabIndex = 8;
            this.ToolsDump.Text = "Dump";
            this.ToolsDump.UseVisualStyleBackColor = true;
            this.ToolsDump.Click += new System.EventHandler(this.ToolsDump_Click);
            // 
            // ToolsBrowseDump
            // 
            this.ToolsBrowseDump.Location = new System.Drawing.Point(475, 19);
            this.ToolsBrowseDump.Name = "ToolsBrowseDump";
            this.ToolsBrowseDump.Size = new System.Drawing.Size(61, 22);
            this.ToolsBrowseDump.TabIndex = 7;
            this.ToolsBrowseDump.Text = "Browse";
            this.ToolsBrowseDump.UseVisualStyleBackColor = true;
            this.ToolsBrowseDump.Click += new System.EventHandler(this.ToolsBrowseDump_Click);
            // 
            // ToolsDumpFileName
            // 
            this.ToolsDumpFileName.Location = new System.Drawing.Point(325, 19);
            this.ToolsDumpFileName.Name = "ToolsDumpFileName";
            this.ToolsDumpFileName.Size = new System.Drawing.Size(143, 20);
            this.ToolsDumpFileName.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(267, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Filename:";
            // 
            // ToolsDumpEnd
            // 
            this.ToolsDumpEnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ToolsDumpEnd.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolsDumpEnd.Location = new System.Drawing.Point(199, 19);
            this.ToolsDumpEnd.MaxLength = 8;
            this.ToolsDumpEnd.Name = "ToolsDumpEnd";
            this.ToolsDumpEnd.Size = new System.Drawing.Size(62, 20);
            this.ToolsDumpEnd.TabIndex = 4;
            this.ToolsDumpEnd.Text = "00000000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(164, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "End:";
            // 
            // ToolsDumpStart
            // 
            this.ToolsDumpStart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ToolsDumpStart.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolsDumpStart.Location = new System.Drawing.Point(93, 19);
            this.ToolsDumpStart.MaxLength = 8;
            this.ToolsDumpStart.Name = "ToolsDumpStart";
            this.ToolsDumpStart.Size = new System.Drawing.Size(62, 20);
            this.ToolsDumpStart.TabIndex = 2;
            this.ToolsDumpStart.Text = "00000000";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(55, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Start:";
            // 
            // ToolsDumpRegions
            // 
            this.ToolsDumpRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToolsDumpRegions.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolsDumpRegions.FormattingEnabled = true;
            this.ToolsDumpRegions.Location = new System.Drawing.Point(6, 19);
            this.ToolsDumpRegions.Name = "ToolsDumpRegions";
            this.ToolsDumpRegions.Size = new System.Drawing.Size(43, 22);
            this.ToolsDumpRegions.TabIndex = 0;
            this.ToolsDumpRegions.SelectedIndexChanged += new System.EventHandler(this.ToolsDumpRegions_SelectedIndexChanged);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.label3);
            this.groupBox23.Controls.Add(this.MEM2UpperBoundary);
            this.groupBox23.Controls.Add(this.label13);
            this.groupBox23.Controls.Add(this.ToolsDisableWatchProtection);
            this.groupBox23.Controls.Add(this.label12);
            this.groupBox23.Controls.Add(this.ToolsDisableProtection);
            this.groupBox23.Location = new System.Drawing.Point(6, 62);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(543, 135);
            this.groupBox23.TabIndex = 1;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Address protection settings";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(530, 28);
            this.label13.TabIndex = 3;
            this.label13.Text = "Even with the box above checked, the watch list will still use the address protec" +
                "tion. You can disable that behaviour here, but BE CAREFUL what you\'re doing here" +
                "!";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ToolsDisableWatchProtection
            // 
            this.ToolsDisableWatchProtection.AutoSize = true;
            this.ToolsDisableWatchProtection.Enabled = false;
            this.ToolsDisableWatchProtection.Location = new System.Drawing.Point(11, 84);
            this.ToolsDisableWatchProtection.Name = "ToolsDisableWatchProtection";
            this.ToolsDisableWatchProtection.Size = new System.Drawing.Size(173, 17);
            this.ToolsDisableWatchProtection.TabIndex = 2;
            this.ToolsDisableWatchProtection.Text = "Disable it for the watch list, too!";
            this.ToolsDisableWatchProtection.UseVisualStyleBackColor = true;
            this.ToolsDisableWatchProtection.CheckedChanged += new System.EventHandler(this.ToolsDisableWatchProtection_CheckedChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(7, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(530, 42);
            this.label12.TabIndex = 1;
            this.label12.Text = resources.GetString("label12.Text");
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ToolsDisableProtection
            // 
            this.ToolsDisableProtection.AutoSize = true;
            this.ToolsDisableProtection.Location = new System.Drawing.Point(11, 18);
            this.ToolsDisableProtection.Name = "ToolsDisableProtection";
            this.ToolsDisableProtection.Size = new System.Drawing.Size(151, 17);
            this.ToolsDisableProtection.TabIndex = 0;
            this.ToolsDisableProtection.Text = "Disable address protection";
            this.ToolsDisableProtection.UseVisualStyleBackColor = true;
            this.ToolsDisableProtection.CheckedChanged += new System.EventHandler(this.ToolsDisableProtection_CheckedChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(7, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(536, 42);
            this.label11.TabIndex = 0;
            this.label11.Text = resources.GetString("label11.Text");
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AbtPage
            // 
            this.AbtPage.Controls.Add(this.checkBoxRegexSearch);
            this.AbtPage.Controls.Add(this.checkBoxBPNext);
            this.AbtPage.Controls.Add(this.numericUpDownFPS);
            this.AbtPage.Controls.Add(this.checkBoxFPS);
            this.AbtPage.Controls.Add(this.checkBoxAlwaysOnTop);
            this.AbtPage.Controls.Add(this.AbtText);
            this.AbtPage.Controls.Add(this.addressTextBoxBPNext);
            this.AbtPage.Location = new System.Drawing.Point(4, 22);
            this.AbtPage.Name = "AbtPage";
            this.AbtPage.Size = new System.Drawing.Size(565, 296);
            this.AbtPage.TabIndex = 6;
            this.AbtPage.Text = "About";
            this.AbtPage.UseVisualStyleBackColor = true;
            // 
            // checkBoxRegexSearch
            // 
            this.checkBoxRegexSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxRegexSearch.AutoSize = true;
            this.checkBoxRegexSearch.Location = new System.Drawing.Point(359, 277);
            this.checkBoxRegexSearch.Name = "checkBoxRegexSearch";
            this.checkBoxRegexSearch.Size = new System.Drawing.Size(94, 17);
            this.checkBoxRegexSearch.TabIndex = 6;
            this.checkBoxRegexSearch.Text = "Regex Search";
            this.checkBoxRegexSearch.UseVisualStyleBackColor = true;
            // 
            // checkBoxBPNext
            // 
            this.checkBoxBPNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxBPNext.AutoSize = true;
            this.checkBoxBPNext.Location = new System.Drawing.Point(222, 277);
            this.checkBoxBPNext.Name = "checkBoxBPNext";
            this.checkBoxBPNext.Size = new System.Drawing.Size(62, 17);
            this.checkBoxBPNext.TabIndex = 4;
            this.checkBoxBPNext.Text = "BPNext";
            this.checkBoxBPNext.UseVisualStyleBackColor = true;
            this.checkBoxBPNext.CheckedChanged += new System.EventHandler(this.checkBoxBPNext_CheckedChanged);
            // 
            // checkBoxFPS
            // 
            this.checkBoxFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxFPS.AutoSize = true;
            this.checkBoxFPS.Location = new System.Drawing.Point(98, 277);
            this.checkBoxFPS.Name = "checkBoxFPS";
            this.checkBoxFPS.Size = new System.Drawing.Size(49, 17);
            this.checkBoxFPS.TabIndex = 3;
            this.checkBoxFPS.Text = "Slow";
            this.checkBoxFPS.UseVisualStyleBackColor = true;
            this.checkBoxFPS.CheckedChanged += new System.EventHandler(this.checkBoxFPS_CheckedChanged);
            // 
            // numericUpDownFPS
            // 
            this.numericUpDownFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownFPS.DecimalPlaces = 1;
            this.numericUpDownFPS.Location = new System.Drawing.Point(157, 273);
            this.numericUpDownFPS.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownFPS.Name = "numericUpDownFPS";
            this.numericUpDownFPS.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownFPS.TabIndex = 2;
            this.numericUpDownFPS.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownFPS.ValueChanged += new System.EventHandler(this.numericUpDownFPS_ValueChanged);
            // 
            // checkBoxAlwaysOnTop
            // 
            this.checkBoxAlwaysOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAlwaysOnTop.AutoSize = true;
            this.checkBoxAlwaysOnTop.Location = new System.Drawing.Point(3, 277);
            this.checkBoxAlwaysOnTop.Name = "checkBoxAlwaysOnTop";
            this.checkBoxAlwaysOnTop.Size = new System.Drawing.Size(92, 17);
            this.checkBoxAlwaysOnTop.TabIndex = 1;
            this.checkBoxAlwaysOnTop.Text = "Always on top";
            this.checkBoxAlwaysOnTop.UseVisualStyleBackColor = true;
            this.checkBoxAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkBoxAlwaysOnTop_CheckedChanged);
            // 
            // AbtText
            // 
            this.AbtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbtText.Location = new System.Drawing.Point(6, 7);
            this.AbtText.Name = "AbtText";
            this.AbtText.Size = new System.Drawing.Size(543, 235);
            this.AbtText.TabIndex = 0;
            this.AbtText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.OpenNotePad);
            this.panel1.Controls.Add(this.RGame);
            this.panel1.Controls.Add(this.PGame);
            this.panel1.Location = new System.Drawing.Point(1, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 31);
            this.panel1.TabIndex = 1;
            // 
            // OpenNotePad
            // 
            this.OpenNotePad.Enabled = false;
            this.OpenNotePad.Location = new System.Drawing.Point(193, 4);
            this.OpenNotePad.Name = "OpenNotePad";
            this.OpenNotePad.Size = new System.Drawing.Size(90, 21);
            this.OpenNotePad.TabIndex = 8;
            this.OpenNotePad.Text = "Open notepad";
            this.OpenNotePad.UseVisualStyleBackColor = true;
            this.OpenNotePad.Click += new System.EventHandler(this.OpenNotePad_Click);
            // 
            // RGame
            // 
            this.RGame.Enabled = false;
            this.RGame.Location = new System.Drawing.Point(101, 4);
            this.RGame.Name = "RGame";
            this.RGame.Size = new System.Drawing.Size(85, 21);
            this.RGame.TabIndex = 7;
            this.RGame.Text = "Run game";
            this.RGame.UseVisualStyleBackColor = true;
            this.RGame.Click += new System.EventHandler(this.RGame_Click);
            // 
            // PGame
            // 
            this.PGame.Location = new System.Drawing.Point(8, 4);
            this.PGame.Name = "PGame";
            this.PGame.Size = new System.Drawing.Size(85, 21);
            this.PGame.TabIndex = 6;
            this.PGame.Text = "Pause game";
            this.PGame.UseVisualStyleBackColor = true;
            this.PGame.Click += new System.EventHandler(this.PGame_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.DisconnectButton);
            this.panel2.Controls.Add(this.CUSBGecko);
            this.panel2.Location = new System.Drawing.Point(285, 320);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 31);
            this.panel2.TabIndex = 2;
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(148, 4);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(130, 21);
            this.DisconnectButton.TabIndex = 1;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // CUSBGecko
            // 
            this.CUSBGecko.Location = new System.Drawing.Point(7, 4);
            this.CUSBGecko.Name = "CUSBGecko";
            this.CUSBGecko.Size = new System.Drawing.Size(130, 21);
            this.CUSBGecko.TabIndex = 0;
            this.CUSBGecko.Text = "Connect to Gecko";
            this.CUSBGecko.UseVisualStyleBackColor = true;
            this.CUSBGecko.Click += new System.EventHandler(this.CUSBGecko_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.PCent);
            this.groupBox5.Controls.Add(this.StatusCap);
            this.groupBox5.Controls.Add(this.progressBar);
            this.groupBox5.Location = new System.Drawing.Point(1, 353);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(573, 55);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Status";
            // 
            // PCent
            // 
            this.PCent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PCent.Location = new System.Drawing.Point(502, 16);
            this.PCent.Name = "PCent";
            this.PCent.Size = new System.Drawing.Size(62, 13);
            this.PCent.TabIndex = 2;
            this.PCent.Text = "0%";
            this.PCent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StatusCap
            // 
            this.StatusCap.AutoSize = true;
            this.StatusCap.Location = new System.Drawing.Point(11, 16);
            this.StatusCap.Name = "StatusCap";
            this.StatusCap.Size = new System.Drawing.Size(38, 13);
            this.StatusCap.TabIndex = 1;
            this.StatusCap.Text = "Ready";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(9, 32);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(555, 19);
            this.progressBar.TabIndex = 0;
            // 
            // WatchListOpen
            // 
            this.WatchListOpen.DefaultExt = "xwl";
            this.WatchListOpen.Filter = "Watch list (*.xwl)|*.xwl|All files (*.*)|*.*";
            // 
            // WatchListSave
            // 
            this.WatchListSave.DefaultExt = "xwl";
            this.WatchListSave.Filter = "Watch list (*.xwl)|*.xwl|All files (*.*)|*.*";
            // 
            // ToolsDumpSave
            // 
            this.ToolsDumpSave.DefaultExt = "bin";
            this.ToolsDumpSave.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            // 
            // openBinary
            // 
            this.openBinary.FileName = "binary.bin";
            this.openBinary.Filter = "All files (*.*)|*.*";
            this.openBinary.ReadOnlyChecked = true;
            this.openBinary.Title = "Select a file to upload";
            // 
            // timerFPS
            // 
            this.timerFPS.Tick += new System.EventHandler(this.timerFPS_Tick);
            // 
            // openFileDialogSearch
            // 
            this.openFileDialogSearch.DefaultExt = "bin";
            this.openFileDialogSearch.FileName = "results.zip";
            this.openFileDialogSearch.Filter = "\"Search Results|*.zip|All Files|*.*\"";
            this.openFileDialogSearch.Title = "Load Search Result";
            // 
            // saveFileDialogSearch
            // 
            this.saveFileDialogSearch.DefaultExt = "bin";
            this.saveFileDialogSearch.FileName = "results.zip";
            this.saveFileDialogSearch.Filter = "\"Search Results|*.zip|All Files|*.*\"";
            this.saveFileDialogSearch.Title = "Save Search Result";
            // 
            // saveFileDialogLogSteps
            // 
            this.saveFileDialogLogSteps.DefaultExt = "log";
            this.saveFileDialogLogSteps.FileName = "BPSteps";
            this.saveFileDialogLogSteps.Filter = "Logs|*.log|All Files|*.*";
            this.saveFileDialogLogSteps.Title = "Save Step Log";
            // 
            // splitContainerRegASM
            // 
            this.splitContainerRegASM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerRegASM.Location = new System.Drawing.Point(0, 83);
            this.splitContainerRegASM.Name = "splitContainerRegASM";
            this.splitContainerRegASM.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRegASM.Panel1
            // 
            this.splitContainerRegASM.Panel1.Controls.Add(this.panel6);
            // 
            // splitContainerRegASM.Panel2
            // 
            this.splitContainerRegASM.Panel2.Controls.Add(this.panel4);
            this.splitContainerRegASM.Size = new System.Drawing.Size(418, 212);
            this.splitContainerRegASM.SplitterDistance = 125;
            this.splitContainerRegASM.TabIndex = 12;
            this.splitContainerRegASM.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerRegASM_SplitterMoved);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BPList);
            this.panel6.Controls.Add(this.BPClassic);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(418, 125);
            this.panel6.TabIndex = 12;
            // 
            // BPClassic
            // 
            this.BPClassic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BPClassic.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPClassic.Location = new System.Drawing.Point(0, 0);
            this.BPClassic.Multiline = true;
            this.BPClassic.Name = "BPClassic";
            this.BPClassic.ReadOnly = true;
            this.BPClassic.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.BPClassic.Size = new System.Drawing.Size(418, 125);
            this.BPClassic.TabIndex = 4;
            this.BPClassic.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BPDiss);
            this.panel4.Controls.Add(this.richTextBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(418, 83);
            this.panel4.TabIndex = 9;
            // 
            // BPDiss
            // 
            this.BPDiss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BPDiss.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPDiss.Location = new System.Drawing.Point(0, 0);
            this.BPDiss.Multiline = true;
            this.BPDiss.Name = "BPDiss";
            this.BPDiss.ReadOnly = true;
            this.BPDiss.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BPDiss.Size = new System.Drawing.Size(418, 83);
            this.BPDiss.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(394, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(17, 17);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // MEM2UpperBoundary
            // 
            this.MEM2UpperBoundary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MEM2UpperBoundary.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MEM2UpperBoundary.FormattingEnabled = true;
            this.MEM2UpperBoundary.Items.AddRange(new object[] {
            "93400000",
            "93800000",
            "93C00000",
            "94000000"});
            this.MEM2UpperBoundary.Location = new System.Drawing.Point(457, 14);
            this.MEM2UpperBoundary.Name = "MEM2UpperBoundary";
            this.MEM2UpperBoundary.Size = new System.Drawing.Size(81, 22);
            this.MEM2UpperBoundary.TabIndex = 4;
            this.MEM2UpperBoundary.SelectedIndexChanged += new System.EventHandler(this.MEM2UpperBoundary_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "MEM2 boundary:";
            // 
            // PAddress
            // 
            this.PAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PAddress.AutoHistory = true;
            this.PAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PAddress.ContextMenuStrip = this.HistoryContextMenu;
            this.PAddress.EndingAddress = false;
            this.PAddress.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAddress.Location = new System.Drawing.Point(282, 269);
            this.PAddress.MaxLength = 8;
            this.PAddress.MultiPokeAddress = true;
            this.PAddress.Name = "PAddress";
            this.PAddress.Size = new System.Drawing.Size(62, 20);
            this.PAddress.TabIndex = 10;
            this.PAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PAddress_KeyPress);
            // 
            // memEnd
            // 
            this.memEnd.AutoHistory = true;
            this.memEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.memEnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.memEnd.ContextMenuStrip = this.HistoryContextMenu;
            this.memEnd.EndingAddress = true;
            this.memEnd.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memEnd.Location = new System.Drawing.Point(199, 19);
            this.memEnd.MaxLength = 8;
            this.memEnd.MultiPokeAddress = false;
            this.memEnd.Name = "memEnd";
            this.memEnd.Size = new System.Drawing.Size(62, 20);
            this.memEnd.TabIndex = 4;
            // 
            // memStart
            // 
            this.memStart.AutoHistory = true;
            this.memStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.memStart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.memStart.ContextMenuStrip = this.HistoryContextMenu;
            this.memStart.EndingAddress = false;
            this.memStart.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memStart.Location = new System.Drawing.Point(93, 19);
            this.memStart.MaxLength = 8;
            this.memStart.MultiPokeAddress = false;
            this.memStart.Name = "memStart";
            this.memStart.Size = new System.Drawing.Size(62, 20);
            this.memStart.TabIndex = 2;
            // 
            // memViewPAddress
            // 
            this.memViewPAddress.AutoHistory = true;
            this.memViewPAddress.BackColor = System.Drawing.SystemColors.Window;
            this.memViewPAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.memViewPAddress.ContextMenuStrip = this.HistoryContextMenu;
            this.memViewPAddress.EndingAddress = false;
            this.memViewPAddress.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memViewPAddress.Location = new System.Drawing.Point(27, 19);
            this.memViewPAddress.MaxLength = 8;
            this.memViewPAddress.MultiPokeAddress = false;
            this.memViewPAddress.Name = "memViewPAddress";
            this.memViewPAddress.Size = new System.Drawing.Size(62, 20);
            this.memViewPAddress.TabIndex = 5;
            this.memViewPAddress.Text = "80000000";
            // 
            // memViewAValue
            // 
            this.memViewAValue.AutoHistory = true;
            this.memViewAValue.BackColor = System.Drawing.SystemColors.Window;
            this.memViewAValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.memViewAValue.ContextMenuStrip = this.HistoryContextMenu;
            this.memViewAValue.EndingAddress = false;
            this.memViewAValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memViewAValue.Location = new System.Drawing.Point(48, 19);
            this.memViewAValue.MaxLength = 8;
            this.memViewAValue.MultiPokeAddress = false;
            this.memViewAValue.Name = "memViewAValue";
            this.memViewAValue.Size = new System.Drawing.Size(62, 20);
            this.memViewAValue.TabIndex = 6;
            this.memViewAValue.Text = "80000000";
            this.memViewAValue.TextChanged += new System.EventHandler(this.memViewAValue_TextChanged);
            this.memViewAValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.memViewAValue_KeyDown);
            this.memViewAValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PAddress_KeyPress);
            // 
            // BPList
            // 
            this.BPList.AutoScroll = true;
            this.BPList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BPList.Cursor = System.Windows.Forms.Cursors.Default;
            this.BPList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BPList.Location = new System.Drawing.Point(0, 0);
            this.BPList.Margin = new System.Windows.Forms.Padding(4);
            this.BPList.Name = "BPList";
            this.BPList.Size = new System.Drawing.Size(418, 125);
            this.BPList.TabIndex = 2;
            // 
            // BPAddress
            // 
            this.BPAddress.AutoHistory = true;
            this.BPAddress.BackColor = System.Drawing.SystemColors.Window;
            this.BPAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.BPAddress.ContextMenuStrip = this.HistoryContextMenu;
            this.BPAddress.EndingAddress = false;
            this.BPAddress.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPAddress.Location = new System.Drawing.Point(18, 19);
            this.BPAddress.MaxLength = 8;
            this.BPAddress.MultiPokeAddress = false;
            this.BPAddress.Name = "BPAddress";
            this.BPAddress.Size = new System.Drawing.Size(62, 20);
            this.BPAddress.TabIndex = 7;
            this.BPAddress.Text = "80000000";
            this.BPAddress.TextChanged += new System.EventHandler(this.BPAddress_TextChanged);
            // 
            // AsText
            // 
            this.AsText.AutoHistory = false;
            this.AsText.ContextMenuStrip = this.HistoryContextMenu;
            this.AsText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsText.Location = new System.Drawing.Point(6, 46);
            this.AsText.MaxLength = 100;
            this.AsText.Name = "AsText";
            this.AsText.Size = new System.Drawing.Size(177, 20);
            this.AsText.TabIndex = 7;
            this.AsText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AsText_KeyDown);
            // 
            // AsAddress
            // 
            this.AsAddress.AutoHistory = true;
            this.AsAddress.BackColor = System.Drawing.SystemColors.Window;
            this.AsAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AsAddress.ContextMenuStrip = this.HistoryContextMenu;
            this.AsAddress.EndingAddress = false;
            this.AsAddress.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsAddress.Location = new System.Drawing.Point(7, 20);
            this.AsAddress.MaxLength = 8;
            this.AsAddress.MultiPokeAddress = false;
            this.AsAddress.Name = "AsAddress";
            this.AsAddress.Size = new System.Drawing.Size(62, 20);
            this.AsAddress.TabIndex = 5;
            this.AsAddress.Text = "80000000";
            // 
            // DisRegion
            // 
            this.DisRegion.AutoHistory = true;
            this.DisRegion.BackColor = System.Drawing.SystemColors.Window;
            this.DisRegion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DisRegion.ContextMenuStrip = this.HistoryContextMenu;
            this.DisRegion.EndingAddress = false;
            this.DisRegion.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisRegion.Location = new System.Drawing.Point(11, 18);
            this.DisRegion.MaxLength = 8;
            this.DisRegion.MultiPokeAddress = false;
            this.DisRegion.Name = "DisRegion";
            this.DisRegion.Size = new System.Drawing.Size(62, 20);
            this.DisRegion.TabIndex = 6;
            this.DisRegion.Text = "80000000";
            this.DisRegion.TextChanged += new System.EventHandler(this.DisRegion_TextChanged);
            this.DisRegion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DisRegion_KeyPress);
            // 
            // addressTextBoxBPNext
            // 
            this.addressTextBoxBPNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addressTextBoxBPNext.AutoHistory = true;
            this.addressTextBoxBPNext.BackColor = System.Drawing.SystemColors.Window;
            this.addressTextBoxBPNext.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.addressTextBoxBPNext.ContextMenuStrip = this.HistoryContextMenu;
            this.addressTextBoxBPNext.EndingAddress = false;
            this.addressTextBoxBPNext.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.addressTextBoxBPNext.Location = new System.Drawing.Point(291, 272);
            this.addressTextBoxBPNext.MaxLength = 8;
            this.addressTextBoxBPNext.MultiPokeAddress = false;
            this.addressTextBoxBPNext.Name = "addressTextBoxBPNext";
            this.addressTextBoxBPNext.Size = new System.Drawing.Size(62, 20);
            this.addressTextBoxBPNext.TabIndex = 5;
            this.addressTextBoxBPNext.Text = "800018A8";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 410);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainControl);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(591, 441);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gecko dotNET";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.memViewGrid)).EndInit();
            this.memViewContextMenu.ResumeLayout(false);
            this.MainControl.ResumeLayout(false);
            this.searchPage.ResumeLayout(false);
            this.searchPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewSearchIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOldSearchIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownSearchResultPage)).EndInit();
            this.InputConvert.ResumeLayout(false);
            this.HistoryContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchResults)).EndInit();
            this.SearchResMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBoxSearchGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchGroup)).EndInit();
            this.MemView.ResumeLayout(false);
            this.MemView.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemViewScrollbar)).EndInit();
            this.BreakpointPage.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ShowMemContextMenu.ResumeLayout(false);
            this.ShowMemContextMenu.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.BPCondMenu.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBoxStep.ResumeLayout(false);
            this.StepOutContextMenu.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.DisPage.ResumeLayout(false);
            this.groupBoxDisasmCallStack.ResumeLayout(false);
            this.CallStackContextMenu.ResumeLayout(false);
            this.groupBoxDisasm.ResumeLayout(false);
            this.groupBoxDisasm.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisUpDown)).EndInit();
            this.disAssContextMenu.ResumeLayout(false);
            this.shotPage.ResumeLayout(false);
            this.shotPage.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JPGQual)).EndInit();
            this.groupBox16.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenshotCapBox)).EndInit();
            this.GCTPage.ResumeLayout(false);
            this.GCTPage.PerformLayout();
            this.gctCodeMenu.ResumeLayout(false);
            this.WatchTab.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WatchIntervalSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WatchList)).EndInit();
            this.WatchCM.ResumeLayout(false);
            this.FSTTab.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.ToolPage.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.AbtPage.ResumeLayout(false);
            this.AbtPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFPS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.splitContainerRegASM.Panel1.ResumeLayout(false);
            this.splitContainerRegASM.Panel2.ResumeLayout(false);
            this.splitContainerRegASM.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainControl;
        private System.Windows.Forms.TabPage searchPage;
        private System.Windows.Forms.TabPage MemView;
        private System.Windows.Forms.GroupBox groupBox1;
        private GeckoApp.external.AddressTextBox memEnd;
        private System.Windows.Forms.Label label2;
        private GeckoApp.external.AddressTextBox memStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox memRange;
        private System.Windows.Forms.TextBox textBoxComparisonValue;
        private System.Windows.Forms.ComboBox comboBoxSearchDataType;
        private System.Windows.Forms.GroupBox groupBoxSearchGroups;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxComparisonType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ResSrch;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView SearchResults;
        private System.Windows.Forms.Button RGame;
        private System.Windows.Forms.Button PGame;
        private System.Windows.Forms.Button CUSBGecko;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label PCent;
        private System.Windows.Forms.Label StatusCap;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label ResList;
        private System.Windows.Forms.ContextMenuStrip SearchResMenu;
        private System.Windows.Forms.ToolStripMenuItem PkAddress;
        private System.Windows.Forms.Button PButton;
        private System.Windows.Forms.TextBox PValue;
        private GeckoApp.external.AddressTextBox PAddress;
        private System.Windows.Forms.Button NxtPage;
        private System.Windows.Forms.Button PrvPage;
        private System.Windows.Forms.DataGridView memViewGrid;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button MemViewUpdate;
        private System.Windows.Forms.ComboBox MemViewARange;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox MemViewShowMode;
        private System.Windows.Forms.CheckBox MemViewAutoUp;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button memViewPButton;
        private System.Windows.Forms.TextBox memViewPValue;
        private GeckoApp.external.AddressTextBox memViewPAddress;
        private System.Windows.Forms.NumericUpDown MemViewScrollbar;
        private GeckoApp.external.AddressTextBox memViewAValue;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label MemViewFPValue;
        private System.Windows.Forms.ToolStripMenuItem ShowInMemView;
        private System.Windows.Forms.TabPage BreakpointPage;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ComboBox BPType;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox BPExact;
        private GeckoApp.external.AddressTextBox BPAddress;
        private System.Windows.Forms.Button BPFire;
        private GeckoApp.BPList BPList;
        private System.Windows.Forms.Button BPCancel;
        private System.Windows.Forms.TabPage DisPage;
        private System.Windows.Forms.ListBox DisAssBox;
        private System.Windows.Forms.VScrollBar DisScroll;
        private System.Windows.Forms.TextBox BPDiss;
        private System.Windows.Forms.GroupBox groupBox12;
        private GeckoApp.external.AddressTextBox DisRegion;
        private System.Windows.Forms.NumericUpDown DisUpDown;
        private System.Windows.Forms.Button DisUpdateBtn;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button Assemble;
        private GeckoApp.external.HistoryTextBox AsText;
        private GeckoApp.external.AddressTextBox AsAddress;
        private System.Windows.Forms.TabPage shotPage;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button ShotCapture;
        private System.Windows.Forms.PictureBox ScreenshotCapBox;
        private System.Windows.Forms.TextBox ShotFilename;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.ComboBox ShotSizingType;
        private System.Windows.Forms.Button ShotPreview;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.ComboBox ImgFormat;
        private System.Windows.Forms.Label JPGQualLabel;
        private System.Windows.Forms.TrackBar JPGQual;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage GCTPage;
        private System.Windows.Forms.Button GCTSndButton;
        private System.Windows.Forms.Button GCTDelBtn;
        private System.Windows.Forms.Button GCTAddCode;
        public System.Windows.Forms.TextBox GCTCodeValues;
        public System.Windows.Forms.ListView GCTCodeList;
        private System.Windows.Forms.Button GCTLoadList;
        private System.Windows.Forms.Button GCTSaveList;
        private System.Windows.Forms.Label GCTListFileName;
        private System.Windows.Forms.Button GCTDisable;
        private System.Windows.Forms.ToolStripMenuItem BpSAddress;
        private System.Windows.Forms.ToolStripMenuItem makeCode;
        private System.Windows.Forms.ToolStripMenuItem ShowInDiss;
        private System.Windows.Forms.TabPage AbtPage;
        private System.Windows.Forms.Label AbtText;
        private System.Windows.Forms.Button BPOutSwap;
        private System.Windows.Forms.TextBox BPClassic;
        private System.Windows.Forms.Button BPStepButton;
        private System.Windows.Forms.TabPage WatchTab;
        private System.Windows.Forms.DataGridView WatchList;
        private System.Windows.Forms.Button WatchListOpenButton;
        private System.Windows.Forms.Button WatchListSaveButton;
        private System.Windows.Forms.Button WatchAdd;
        private System.Windows.Forms.ContextMenuStrip WatchCM;
        private System.Windows.Forms.ToolStripMenuItem WatchAddWatchCM;
        private System.Windows.Forms.ToolStripMenuItem WatchDeleteCM;
        private System.Windows.Forms.ToolStripMenuItem WatchPokeCM;
        private System.Windows.Forms.ToolStripMenuItem WatchEditCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn WatchCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WatchCAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn WatchCType;
        private System.Windows.Forms.DataGridViewTextBoxColumn WatchCValue;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.NumericUpDown WatchIntervalSet;
        private System.Windows.Forms.TabPage FSTTab;
        private System.Windows.Forms.Button FSTRead;
        private System.Windows.Forms.TreeView FSTTreeView;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.TextBox FSTCodeData;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Button FSTSetAsTarget;
        private System.Windows.Forms.Label FSTFileTarget;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button FSTSetAsSource;
        private System.Windows.Forms.Label FSTFileSource;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Button FSTGenSwap;
        private System.Windows.Forms.TextBox FSTSwapCode;
        private System.Windows.Forms.OpenFileDialog WatchListOpen;
        private System.Windows.Forms.SaveFileDialog WatchListSave;
        private System.Windows.Forms.Button WatchListClear;
        private System.Windows.Forms.TabPage ToolPage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ToolsDisableProtection;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox ToolsDisableWatchProtection;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.Button ToolsDump;
        private System.Windows.Forms.Button ToolsBrowseDump;
        private System.Windows.Forms.TextBox ToolsDumpFileName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox ToolsDumpEnd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ToolsDumpStart;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox ToolsDumpRegions;
        private System.Windows.Forms.SaveFileDialog ToolsDumpSave;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.ToolStripMenuItem showInWatchList;
        private System.Windows.Forms.ContextMenuStrip memViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem memViewSetBP;
        private System.Windows.Forms.ToolStripMenuItem memViewAddToWatch;
        private System.Windows.Forms.ToolStripMenuItem memViewAddGCTCode;
        private System.Windows.Forms.ToolStripMenuItem memViewUpload;
        private System.Windows.Forms.OpenFileDialog openBinary;
        private System.Windows.Forms.ContextMenuStrip gctCodeMenu;
        private System.Windows.Forms.ToolStripMenuItem gctMenuAddCode;
        private System.Windows.Forms.ToolStripMenuItem gctMenuDeleteCode;
        private System.Windows.Forms.Button OpenNotePad;
        private System.Windows.Forms.Button GCTStoreImm;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.TextBox BPCondValue;
        private System.Windows.Forms.ComboBox BPConditionCompare;
        private System.Windows.Forms.ComboBox BPConditionRegSelect;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.Button BPCondClear;
        private System.Windows.Forms.Button BPCondDel;
        private System.Windows.Forms.Button BPConditionAdd;
        private System.Windows.Forms.ListBox BPCondList;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label BPSkipCount;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.Button MemViewSearchPerfom;
        private System.Windows.Forms.TextBox MemViewSearchString;
        private System.Windows.Forms.ComboBox MemViewSearchType;
        private System.Windows.Forms.ContextMenuStrip InputConvert;
        private System.Windows.Forms.ToolStripMenuItem CvDecHex;
        private System.Windows.Forms.ToolStripMenuItem CvFloatHex;
        private System.Windows.Forms.ToolStripMenuItem CvHexDec;
        private System.Windows.Forms.ToolStripMenuItem cvHexFloat;
        private System.Windows.Forms.ToolStripMenuItem InputCvCopy;
        private System.Windows.Forms.ToolStripMenuItem InputCvCut;
        private System.Windows.Forms.ToolStripMenuItem InputCvPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem InputCvUndo;
        private System.Windows.Forms.ToolStripMenuItem InputCvSelectAll;
        private System.Windows.Forms.Button FSTSwapNow;
        private System.Windows.Forms.ContextMenuStrip disAssContextMenu;
        private System.Windows.Forms.ToolStripMenuItem DisAssSetBP;
        private System.Windows.Forms.ToolStripMenuItem DisAssPoke;
        private System.Windows.Forms.ToolStripMenuItem disAssGCTCode;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BPStepOverButton;
        private System.Windows.Forms.CheckBox checkBoxAutoPreview;
        private System.Windows.Forms.ComboBox comboBoxPokeOperation;
        private System.Windows.Forms.CheckBox checkBoxAlwaysOnTop;
        private System.Windows.Forms.NumericUpDown numericUpDownFPS;
        private System.Windows.Forms.CheckBox checkBoxFPS;
        private System.Windows.Forms.Timer timerFPS;
        private System.Windows.Forms.Button buttonSaveSearch;
        private System.Windows.Forms.Button buttonLoadSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialogSearch;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSearch;
        private System.Windows.Forms.Button buttonCancelSearch;
        private System.Windows.Forms.Button buttonShowMem;
        private System.Windows.Forms.NumericUpDown UpDownSearchResultPage;
        private System.Windows.Forms.Button buttonStepOutOf;
        private System.Windows.Forms.ComboBox comboBoxDisplayType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACol;
        private System.Windows.Forms.DataGridViewTextBoxColumn OVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn DifferCol;
        private System.Windows.Forms.ToolStripMenuItem gCTWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gCTWizardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gCTWizardToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxBPNext;
        private System.Windows.Forms.CheckBox checkBoxPauseCodes;
        private System.Windows.Forms.SplitContainer splitContainerRegASM;
        private System.Windows.Forms.VScrollBar vScrollBarMemViewGrid;
        private System.Windows.Forms.ToolStripMenuItem disassemblerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SortToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem copySelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllCellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisableCodeLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip HistoryContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem clearAllHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutAllHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteAllHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem autoHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ContextMenuStrip BPCondMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem sRR0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sRR0ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBoxStep;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem setConditionGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox SetConditionGroupTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem4;
        private System.Windows.Forms.Button buttonStepUntil;
        private System.Windows.Forms.CheckBox checkBoxBPCondEnable;
        private GeckoApp.external.AddressTextBox addressTextBoxBPNext;
        private System.Windows.Forms.CheckBox checkBoxLogSteps;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLogSteps;
        private System.Windows.Forms.Button buttonUndoSearch;
        private System.Windows.Forms.NumericUpDown numericUpDownOldSearchIndex;
        private System.Windows.Forms.NumericUpDown numericUpDownNewSearchIndex;
        private System.Windows.Forms.Button buttonRemoveGroup;
        private System.Windows.Forms.Button buttonAddSearchGroup;
        private System.Windows.Forms.NumericUpDown numericUpDownSearchGroup;
        private System.Windows.Forms.Button buttonClearSearchGroup;
        private System.Windows.Forms.Label labelSearchDataType;
        private System.Windows.Forms.ComboBox comboBoxComparisonRHS;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem setSRR0HereToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ShowMemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowMemAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxShowMemAddress;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem ShowMemValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxShowMemValue;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ContextMenuStrip StepOutContextMenu;
        private System.Windows.Forms.ToolStripMenuItem walkToBlrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stackFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leafToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxDisasm;
        private System.Windows.Forms.TextBox textBoxDisassemblySearch;
        private System.Windows.Forms.Button buttonDisassemblySearch;
        private System.Windows.Forms.RadioButton radioButtonSearchDisassemblyDown;
        private System.Windows.Forms.RadioButton radioButtonSearchDisassemblyUp;
        private System.Windows.Forms.Button buttonSerialPoke;
        private System.Windows.Forms.ToolStripMenuItem copyFunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem SRR0NEQToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem SRR0EQToolStripMenuItem2;
        private System.Windows.Forms.CheckBox checkBoxRegexSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c3;
        private System.Windows.Forms.DataGridViewTextBoxColumn c4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem fontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMemViewFontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem viewFloatsInHexToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxDisasmCallStack;
        private System.Windows.Forms.ListBox listBoxCallStack;
        private System.Windows.Forms.ToolStripMenuItem gotoFunctionStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoFunctionEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem18;
        private System.Windows.Forms.ContextMenuStrip CallStackContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertASCIIToHexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertHexToASCIIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jumpToOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMemViewOffset;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem addOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxAddressAddOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox MEM2UpperBoundary;
    }
}

