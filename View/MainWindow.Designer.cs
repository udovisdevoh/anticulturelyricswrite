using System.Windows.Forms;

namespace Ac.Lw.View
{
    partial class MainWindow : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.buttonBuild = new System.Windows.Forms.Button();
            this.comboBoxDesiredTheme0 = new System.Windows.Forms.ComboBox();
            this.richTextBoxOutputField = new System.Windows.Forms.RichTextBox();
            this.comboBoxDesiredTheme1 = new System.Windows.Forms.ComboBox();
            this.comboBoxDesiredTheme2 = new System.Windows.Forms.ComboBox();
            this.comboBoxDesiredTheme3 = new System.Windows.Forms.ComboBox();
            this.comboBoxDesiredTheme4 = new System.Windows.Forms.ComboBox();
            this.comboBoxDesiredTheme5 = new System.Windows.Forms.ComboBox();
            this.comboBoxDesiredTheme6 = new System.Windows.Forms.ComboBox();
            this.comboBoxDesiredTheme7 = new System.Windows.Forms.ComboBox();
            this.comboBoxDesiredTheme8 = new System.Windows.Forms.ComboBox();
            this.comboBoxDesiredTheme9 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme0 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme1 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme2 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme3 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme4 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme5 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme6 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme7 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme8 = new System.Windows.Forms.ComboBox();
            this.comboBoxUndesiredTheme9 = new System.Windows.Forms.ComboBox();
            this.trackBarVerseLength = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarVerseLengthEntropy = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.checkBoxChorusMode = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.trackWavVolume = new System.Windows.Forms.TrackBar();
            this.trackBarMidiVolume = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interpretToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxGenerateVideo = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayForVocoder = new System.Windows.Forms.CheckBox();
            this.trackBarThemeFidelity = new System.Windows.Forms.TrackBar();
            this.labelThemeFidelity = new System.Windows.Forms.Label();
            this.checkBoxModerateSpeed = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableIntro = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableSolo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVerseLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVerseLengthEntropy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackWavVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMidiVolume)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThemeFidelity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(390, 48);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(152, 23);
            this.buttonBuild.TabIndex = 0;
            this.buttonBuild.Text = "Build";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // comboBoxDesiredTheme0
            // 
            this.comboBoxDesiredTheme0.FormattingEnabled = true;
            this.comboBoxDesiredTheme0.Location = new System.Drawing.Point(6, 15);
            this.comboBoxDesiredTheme0.Name = "comboBoxDesiredTheme0";
            this.comboBoxDesiredTheme0.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme0.TabIndex = 2;
            this.comboBoxDesiredTheme0.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme0_SelectedIndexChanged);
            // 
            // richTextBoxOutputField
            // 
            this.richTextBoxOutputField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOutputField.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxOutputField.Location = new System.Drawing.Point(278, 27);
            this.richTextBoxOutputField.Name = "richTextBoxOutputField";
            this.richTextBoxOutputField.ReadOnly = true;
            this.richTextBoxOutputField.Size = new System.Drawing.Size(422, 318);
            this.richTextBoxOutputField.TabIndex = 3;
            this.richTextBoxOutputField.Text = "";
            // 
            // comboBoxDesiredTheme1
            // 
            this.comboBoxDesiredTheme1.FormattingEnabled = true;
            this.comboBoxDesiredTheme1.Location = new System.Drawing.Point(133, 15);
            this.comboBoxDesiredTheme1.Name = "comboBoxDesiredTheme1";
            this.comboBoxDesiredTheme1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme1.TabIndex = 6;
            this.comboBoxDesiredTheme1.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme1_SelectedIndexChanged);
            // 
            // comboBoxDesiredTheme2
            // 
            this.comboBoxDesiredTheme2.FormattingEnabled = true;
            this.comboBoxDesiredTheme2.Location = new System.Drawing.Point(6, 42);
            this.comboBoxDesiredTheme2.Name = "comboBoxDesiredTheme2";
            this.comboBoxDesiredTheme2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme2.TabIndex = 7;
            this.comboBoxDesiredTheme2.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme2_SelectedIndexChanged);
            // 
            // comboBoxDesiredTheme3
            // 
            this.comboBoxDesiredTheme3.FormattingEnabled = true;
            this.comboBoxDesiredTheme3.Location = new System.Drawing.Point(133, 42);
            this.comboBoxDesiredTheme3.Name = "comboBoxDesiredTheme3";
            this.comboBoxDesiredTheme3.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme3.TabIndex = 8;
            this.comboBoxDesiredTheme3.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme3_SelectedIndexChanged);
            // 
            // comboBoxDesiredTheme4
            // 
            this.comboBoxDesiredTheme4.FormattingEnabled = true;
            this.comboBoxDesiredTheme4.Location = new System.Drawing.Point(6, 69);
            this.comboBoxDesiredTheme4.Name = "comboBoxDesiredTheme4";
            this.comboBoxDesiredTheme4.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme4.TabIndex = 9;
            this.comboBoxDesiredTheme4.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme4_SelectedIndexChanged);
            // 
            // comboBoxDesiredTheme5
            // 
            this.comboBoxDesiredTheme5.FormattingEnabled = true;
            this.comboBoxDesiredTheme5.Location = new System.Drawing.Point(133, 69);
            this.comboBoxDesiredTheme5.Name = "comboBoxDesiredTheme5";
            this.comboBoxDesiredTheme5.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme5.TabIndex = 10;
            this.comboBoxDesiredTheme5.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme5_SelectedIndexChanged);
            // 
            // comboBoxDesiredTheme6
            // 
            this.comboBoxDesiredTheme6.FormattingEnabled = true;
            this.comboBoxDesiredTheme6.Location = new System.Drawing.Point(6, 96);
            this.comboBoxDesiredTheme6.Name = "comboBoxDesiredTheme6";
            this.comboBoxDesiredTheme6.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme6.TabIndex = 11;
            this.comboBoxDesiredTheme6.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme6_SelectedIndexChanged);
            // 
            // comboBoxDesiredTheme7
            // 
            this.comboBoxDesiredTheme7.FormattingEnabled = true;
            this.comboBoxDesiredTheme7.Location = new System.Drawing.Point(133, 96);
            this.comboBoxDesiredTheme7.Name = "comboBoxDesiredTheme7";
            this.comboBoxDesiredTheme7.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme7.TabIndex = 12;
            this.comboBoxDesiredTheme7.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme7_SelectedIndexChanged);
            // 
            // comboBoxDesiredTheme8
            // 
            this.comboBoxDesiredTheme8.FormattingEnabled = true;
            this.comboBoxDesiredTheme8.Location = new System.Drawing.Point(6, 123);
            this.comboBoxDesiredTheme8.Name = "comboBoxDesiredTheme8";
            this.comboBoxDesiredTheme8.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme8.TabIndex = 13;
            this.comboBoxDesiredTheme8.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme8_SelectedIndexChanged);
            // 
            // comboBoxDesiredTheme9
            // 
            this.comboBoxDesiredTheme9.FormattingEnabled = true;
            this.comboBoxDesiredTheme9.Location = new System.Drawing.Point(133, 123);
            this.comboBoxDesiredTheme9.Name = "comboBoxDesiredTheme9";
            this.comboBoxDesiredTheme9.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDesiredTheme9.TabIndex = 14;
            this.comboBoxDesiredTheme9.SelectedIndexChanged += new System.EventHandler(this.comboBoxDesiredTheme9_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme0
            // 
            this.comboBoxUndesiredTheme0.FormattingEnabled = true;
            this.comboBoxUndesiredTheme0.Location = new System.Drawing.Point(6, 19);
            this.comboBoxUndesiredTheme0.Name = "comboBoxUndesiredTheme0";
            this.comboBoxUndesiredTheme0.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme0.TabIndex = 15;
            this.comboBoxUndesiredTheme0.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme0_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme1
            // 
            this.comboBoxUndesiredTheme1.FormattingEnabled = true;
            this.comboBoxUndesiredTheme1.Location = new System.Drawing.Point(133, 19);
            this.comboBoxUndesiredTheme1.Name = "comboBoxUndesiredTheme1";
            this.comboBoxUndesiredTheme1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme1.TabIndex = 16;
            this.comboBoxUndesiredTheme1.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme1_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme2
            // 
            this.comboBoxUndesiredTheme2.FormattingEnabled = true;
            this.comboBoxUndesiredTheme2.Location = new System.Drawing.Point(6, 46);
            this.comboBoxUndesiredTheme2.Name = "comboBoxUndesiredTheme2";
            this.comboBoxUndesiredTheme2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme2.TabIndex = 17;
            this.comboBoxUndesiredTheme2.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme2_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme3
            // 
            this.comboBoxUndesiredTheme3.FormattingEnabled = true;
            this.comboBoxUndesiredTheme3.Location = new System.Drawing.Point(133, 46);
            this.comboBoxUndesiredTheme3.Name = "comboBoxUndesiredTheme3";
            this.comboBoxUndesiredTheme3.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme3.TabIndex = 18;
            this.comboBoxUndesiredTheme3.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme3_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme4
            // 
            this.comboBoxUndesiredTheme4.FormattingEnabled = true;
            this.comboBoxUndesiredTheme4.Location = new System.Drawing.Point(6, 73);
            this.comboBoxUndesiredTheme4.Name = "comboBoxUndesiredTheme4";
            this.comboBoxUndesiredTheme4.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme4.TabIndex = 19;
            this.comboBoxUndesiredTheme4.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme4_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme5
            // 
            this.comboBoxUndesiredTheme5.FormattingEnabled = true;
            this.comboBoxUndesiredTheme5.Location = new System.Drawing.Point(133, 73);
            this.comboBoxUndesiredTheme5.Name = "comboBoxUndesiredTheme5";
            this.comboBoxUndesiredTheme5.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme5.TabIndex = 20;
            this.comboBoxUndesiredTheme5.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme5_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme6
            // 
            this.comboBoxUndesiredTheme6.FormattingEnabled = true;
            this.comboBoxUndesiredTheme6.Location = new System.Drawing.Point(6, 100);
            this.comboBoxUndesiredTheme6.Name = "comboBoxUndesiredTheme6";
            this.comboBoxUndesiredTheme6.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme6.TabIndex = 21;
            this.comboBoxUndesiredTheme6.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme6_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme7
            // 
            this.comboBoxUndesiredTheme7.FormattingEnabled = true;
            this.comboBoxUndesiredTheme7.Location = new System.Drawing.Point(133, 100);
            this.comboBoxUndesiredTheme7.Name = "comboBoxUndesiredTheme7";
            this.comboBoxUndesiredTheme7.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme7.TabIndex = 22;
            this.comboBoxUndesiredTheme7.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme7_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme8
            // 
            this.comboBoxUndesiredTheme8.FormattingEnabled = true;
            this.comboBoxUndesiredTheme8.Location = new System.Drawing.Point(6, 127);
            this.comboBoxUndesiredTheme8.Name = "comboBoxUndesiredTheme8";
            this.comboBoxUndesiredTheme8.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme8.TabIndex = 23;
            this.comboBoxUndesiredTheme8.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme8_SelectedIndexChanged);
            // 
            // comboBoxUndesiredTheme9
            // 
            this.comboBoxUndesiredTheme9.FormattingEnabled = true;
            this.comboBoxUndesiredTheme9.Location = new System.Drawing.Point(133, 127);
            this.comboBoxUndesiredTheme9.Name = "comboBoxUndesiredTheme9";
            this.comboBoxUndesiredTheme9.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUndesiredTheme9.TabIndex = 24;
            this.comboBoxUndesiredTheme9.SelectedIndexChanged += new System.EventHandler(this.comboBoxUndesiredTheme9_SelectedIndexChanged);
            // 
            // trackBarVerseLength
            // 
            this.trackBarVerseLength.LargeChange = 2000;
            this.trackBarVerseLength.Location = new System.Drawing.Point(94, 32);
            this.trackBarVerseLength.Maximum = 32767;
            this.trackBarVerseLength.Name = "trackBarVerseLength";
            this.trackBarVerseLength.Size = new System.Drawing.Size(121, 42);
            this.trackBarVerseLength.SmallChange = 200;
            this.trackBarVerseLength.TabIndex = 25;
            this.trackBarVerseLength.TickFrequency = 0;
            this.trackBarVerseLength.Scroll += new System.EventHandler(this.trackBarVerseLength_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Verse Length";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Verse Length Entropy";
            // 
            // trackBarVerseLengthEntropy
            // 
            this.trackBarVerseLengthEntropy.LargeChange = 2000;
            this.trackBarVerseLengthEntropy.Location = new System.Drawing.Point(94, 93);
            this.trackBarVerseLengthEntropy.Maximum = 32767;
            this.trackBarVerseLengthEntropy.Name = "trackBarVerseLengthEntropy";
            this.trackBarVerseLengthEntropy.Size = new System.Drawing.Size(121, 42);
            this.trackBarVerseLengthEntropy.SmallChange = 200;
            this.trackBarVerseLengthEntropy.TabIndex = 28;
            this.trackBarVerseLengthEntropy.TickFrequency = 0;
            this.trackBarVerseLengthEntropy.Scroll += new System.EventHandler(this.trackBarVerseLengthEntropy_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Default";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "Randomize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // play
            // 
            this.play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("play.BackgroundImage")));
            this.play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.play.Location = new System.Drawing.Point(469, 77);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(73, 23);
            this.play.TabIndex = 31;
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // checkBoxChorusMode
            // 
            this.checkBoxChorusMode.AutoSize = true;
            this.checkBoxChorusMode.Location = new System.Drawing.Point(548, 19);
            this.checkBoxChorusMode.Name = "checkBoxChorusMode";
            this.checkBoxChorusMode.Size = new System.Drawing.Size(89, 17);
            this.checkBoxChorusMode.TabIndex = 34;
            this.checkBoxChorusMode.Text = "Chorus Mode";
            this.checkBoxChorusMode.UseVisualStyleBackColor = true;
            this.checkBoxChorusMode.CheckedChanged += new System.EventHandler(this.checkBoxChorusMode_CheckedChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonStop.BackgroundImage")));
            this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonStop.Location = new System.Drawing.Point(390, 77);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(73, 23);
            this.buttonStop.TabIndex = 35;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // trackWavVolume
            // 
            this.trackWavVolume.LargeChange = 7;
            this.trackWavVolume.Location = new System.Drawing.Point(6, 14);
            this.trackWavVolume.Maximum = 100;
            this.trackWavVolume.Name = "trackWavVolume";
            this.trackWavVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackWavVolume.Size = new System.Drawing.Size(42, 109);
            this.trackWavVolume.TabIndex = 36;
            this.trackWavVolume.TickFrequency = 0;
            this.trackWavVolume.Scroll += new System.EventHandler(this.trackWavVolume_Scroll);
            // 
            // trackBarMidiVolume
            // 
            this.trackBarMidiVolume.LargeChange = 8;
            this.trackBarMidiVolume.Location = new System.Drawing.Point(46, 14);
            this.trackBarMidiVolume.Maximum = 127;
            this.trackBarMidiVolume.Name = "trackBarMidiVolume";
            this.trackBarMidiVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarMidiVolume.Size = new System.Drawing.Size(42, 109);
            this.trackBarMidiVolume.SmallChange = 2;
            this.trackBarMidiVolume.TabIndex = 37;
            this.trackBarMidiVolume.TickFrequency = 8;
            this.trackBarMidiVolume.Value = 127;
            this.trackBarMidiVolume.ValueChanged += new System.EventHandler(this.trackBarMidiVolume_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Voice";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Music";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.interpretToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // interpretToolStripMenuItem
            // 
            this.interpretToolStripMenuItem.Name = "interpretToolStripMenuItem";
            this.interpretToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.interpretToolStripMenuItem.Text = "&Interpret";
            this.interpretToolStripMenuItem.Click += new System.EventHandler(this.interpretToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(175, 38);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme0);
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme1);
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme2);
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme3);
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme4);
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme5);
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme6);
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme7);
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme8);
            this.groupBox1.Controls.Add(this.comboBoxDesiredTheme9);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 154);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Desired Themes";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBoxGenerateVideo);
            this.groupBox2.Controls.Add(this.checkBoxPlayForVocoder);
            this.groupBox2.Controls.Add(this.trackBarThemeFidelity);
            this.groupBox2.Controls.Add(this.labelThemeFidelity);
            this.groupBox2.Controls.Add(this.checkBoxModerateSpeed);
            this.groupBox2.Controls.Add(this.checkBoxEnableIntro);
            this.groupBox2.Controls.Add(this.trackWavVolume);
            this.groupBox2.Controls.Add(this.checkBoxEnableSolo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.trackBarSpeed);
            this.groupBox2.Controls.Add(this.trackBarVerseLength);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.play);
            this.groupBox2.Controls.Add(this.buttonStop);
            this.groupBox2.Controls.Add(this.checkBoxChorusMode);
            this.groupBox2.Controls.Add(this.trackBarVerseLengthEntropy);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.buttonBuild);
            this.groupBox2.Controls.Add(this.trackBarMidiVolume);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 351);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 142);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // checkBoxGenerateVideo
            // 
            this.checkBoxGenerateVideo.AutoSize = true;
            this.checkBoxGenerateVideo.Location = new System.Drawing.Point(390, 111);
            this.checkBoxGenerateVideo.Name = "checkBoxGenerateVideo";
            this.checkBoxGenerateVideo.Size = new System.Drawing.Size(100, 17);
            this.checkBoxGenerateVideo.TabIndex = 48;
            this.checkBoxGenerateVideo.Text = "Generate Video";
            this.checkBoxGenerateVideo.UseVisualStyleBackColor = true;
            this.checkBoxGenerateVideo.CheckedChanged += new System.EventHandler(this.checkBoxGenerateVideo_CheckedChanged);
            // 
            // checkBoxPlayForVocoder
            // 
            this.checkBoxPlayForVocoder.AutoSize = true;
            this.checkBoxPlayForVocoder.Location = new System.Drawing.Point(548, 111);
            this.checkBoxPlayForVocoder.Name = "checkBoxPlayForVocoder";
            this.checkBoxPlayForVocoder.Size = new System.Drawing.Size(107, 17);
            this.checkBoxPlayForVocoder.TabIndex = 47;
            this.checkBoxPlayForVocoder.Text = "Play For Vocoder";
            this.checkBoxPlayForVocoder.UseVisualStyleBackColor = true;
            this.checkBoxPlayForVocoder.CheckedChanged += new System.EventHandler(this.checkBoxPlayForVocoder_CheckedChanged);
            // 
            // trackBarThemeFidelity
            // 
            this.trackBarThemeFidelity.LargeChange = 2000;
            this.trackBarThemeFidelity.Location = new System.Drawing.Point(224, 93);
            this.trackBarThemeFidelity.Maximum = 20000;
            this.trackBarThemeFidelity.Minimum = 200;
            this.trackBarThemeFidelity.Name = "trackBarThemeFidelity";
            this.trackBarThemeFidelity.Size = new System.Drawing.Size(118, 42);
            this.trackBarThemeFidelity.SmallChange = 200;
            this.trackBarThemeFidelity.TabIndex = 46;
            this.trackBarThemeFidelity.TickFrequency = 0;
            this.trackBarThemeFidelity.Value = 200;
            this.trackBarThemeFidelity.ValueChanged += new System.EventHandler(this.trackBarThemeFidelity_ValueChanged);
            // 
            // labelThemeFidelity
            // 
            this.labelThemeFidelity.AutoSize = true;
            this.labelThemeFidelity.Location = new System.Drawing.Point(221, 77);
            this.labelThemeFidelity.Name = "labelThemeFidelity";
            this.labelThemeFidelity.Size = new System.Drawing.Size(75, 13);
            this.labelThemeFidelity.TabIndex = 45;
            this.labelThemeFidelity.Text = "Theme Fidelity";
            // 
            // checkBoxModerateSpeed
            // 
            this.checkBoxModerateSpeed.AutoSize = true;
            this.checkBoxModerateSpeed.Location = new System.Drawing.Point(548, 88);
            this.checkBoxModerateSpeed.Name = "checkBoxModerateSpeed";
            this.checkBoxModerateSpeed.Size = new System.Drawing.Size(136, 17);
            this.checkBoxModerateSpeed.TabIndex = 44;
            this.checkBoxModerateSpeed.Text = "Moderate Speech Flow";
            this.checkBoxModerateSpeed.UseVisualStyleBackColor = true;
            this.checkBoxModerateSpeed.CheckedChanged += new System.EventHandler(this.enableSpeedRegulation_CheckedChanged);
            // 
            // checkBoxEnableIntro
            // 
            this.checkBoxEnableIntro.AutoSize = true;
            this.checkBoxEnableIntro.Location = new System.Drawing.Point(548, 42);
            this.checkBoxEnableIntro.Name = "checkBoxEnableIntro";
            this.checkBoxEnableIntro.Size = new System.Drawing.Size(83, 17);
            this.checkBoxEnableIntro.TabIndex = 43;
            this.checkBoxEnableIntro.Text = "Enable Intro";
            this.checkBoxEnableIntro.UseVisualStyleBackColor = true;
            this.checkBoxEnableIntro.CheckedChanged += new System.EventHandler(this.checkBoxEnableIntro_CheckedChanged);
            // 
            // checkBoxEnableSolo
            // 
            this.checkBoxEnableSolo.AutoSize = true;
            this.checkBoxEnableSolo.Location = new System.Drawing.Point(548, 65);
            this.checkBoxEnableSolo.Name = "checkBoxEnableSolo";
            this.checkBoxEnableSolo.Size = new System.Drawing.Size(83, 17);
            this.checkBoxEnableSolo.TabIndex = 42;
            this.checkBoxEnableSolo.Text = "Enable Solo";
            this.checkBoxEnableSolo.UseVisualStyleBackColor = true;
            this.checkBoxEnableSolo.CheckedChanged += new System.EventHandler(this.checkBoxEnableSolo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Voice Speed";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.LargeChange = 1;
            this.trackBarSpeed.Location = new System.Drawing.Point(224, 32);
            this.trackBarSpeed.Maximum = 3;
            this.trackBarSpeed.Minimum = -3;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(118, 42);
            this.trackBarSpeed.TabIndex = 40;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme0);
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme1);
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme2);
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme3);
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme4);
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme5);
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme6);
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme9);
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme7);
            this.groupBox3.Controls.Add(this.comboBoxUndesiredTheme8);
            this.groupBox3.Location = new System.Drawing.Point(12, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 158);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Undesired Themes";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 505);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBoxOutputField);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(720, 532);
            this.Name = "MainWindow";
            this.Text = "Lyric Builder";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVerseLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVerseLengthEntropy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackWavVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMidiVolume)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThemeFidelity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonBuild;
        private ComboBox comboBoxDesiredTheme0;
        private RichTextBox richTextBoxOutputField;
        private ComboBox comboBoxDesiredTheme1;
        private ComboBox comboBoxDesiredTheme2;
        private ComboBox comboBoxDesiredTheme3;
        private ComboBox comboBoxDesiredTheme4;
        private ComboBox comboBoxDesiredTheme5;
        private ComboBox comboBoxDesiredTheme6;
        private ComboBox comboBoxDesiredTheme7;
        private ComboBox comboBoxDesiredTheme8;
        private ComboBox comboBoxDesiredTheme9;
        private ComboBox comboBoxUndesiredTheme0;
        private ComboBox comboBoxUndesiredTheme1;
        private ComboBox comboBoxUndesiredTheme2;
        private ComboBox comboBoxUndesiredTheme3;
        private ComboBox comboBoxUndesiredTheme4;
        private ComboBox comboBoxUndesiredTheme5;
        private ComboBox comboBoxUndesiredTheme6;
        private ComboBox comboBoxUndesiredTheme7;
        private ComboBox comboBoxUndesiredTheme8;
        private ComboBox comboBoxUndesiredTheme9;
        private TrackBar trackBarVerseLength;
        private Label label3;
        private Label label4;
        private TrackBar trackBarVerseLengthEntropy;
        private Button button1;
        private Button button2;
        private Button play;
        private CheckBox checkBoxChorusMode;
        private Button buttonStop;
        private TrackBar trackWavVolume;
        private TrackBar trackBarMidiVolume;
        private Label label5;
        private Label label6;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem interpretToolStripMenuItem;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private TrackBar trackBarSpeed;
        private Label label1;
        private CheckBox checkBoxEnableSolo;
        private CheckBox checkBoxEnableIntro;
        private CheckBox checkBoxModerateSpeed;
        private TrackBar trackBarThemeFidelity;
        private Label labelThemeFidelity;
        private CheckBox checkBoxPlayForVocoder;
        private CheckBox checkBoxGenerateVideo;
    }
}

