namespace AudioHash
{
  partial class MainWin
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.pnlSounds = new System.Windows.Forms.FlowLayoutPanel();
      this.numericUpDownSampleLength = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.chkWholeSound = new System.Windows.Forms.CheckBox();
      this.toolStripMain = new System.Windows.Forms.ToolStrip();
      this.toolStripButtonAddSound = new System.Windows.Forms.ToolStripButton();
      this.toolStripButtonRemoveAll = new System.Windows.Forms.ToolStripButton();
      this.toolStripButtonMakeSampler = new System.Windows.Forms.ToolStripButton();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabelSoundContainerCount = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelSoundContainerCountText = new System.Windows.Forms.ToolStripStatusLabel();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleLength)).BeginInit();
      this.toolStripMain.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlSounds
      // 
      this.pnlSounds.AutoScroll = true;
      this.pnlSounds.Location = new System.Drawing.Point(12, 40);
      this.pnlSounds.Name = "pnlSounds";
      this.pnlSounds.Size = new System.Drawing.Size(388, 453);
      this.pnlSounds.TabIndex = 15;
      this.pnlSounds.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlSounds_ControlRemoved);
      // 
      // numericUpDownSampleLength
      // 
      this.numericUpDownSampleLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.numericUpDownSampleLength.Location = new System.Drawing.Point(432, 58);
      this.numericUpDownSampleLength.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.numericUpDownSampleLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownSampleLength.Name = "numericUpDownSampleLength";
      this.numericUpDownSampleLength.Size = new System.Drawing.Size(51, 29);
      this.numericUpDownSampleLength.TabIndex = 16;
      this.numericUpDownSampleLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(404, 39);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(140, 16);
      this.label1.TabIndex = 17;
      this.label1.Text = "Sound Sample Length";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(489, 62);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(52, 20);
      this.label2.TabIndex = 18;
      this.label2.Text = "sec(s)";
      // 
      // chkWholeSound
      // 
      this.chkWholeSound.AutoSize = true;
      this.chkWholeSound.Checked = true;
      this.chkWholeSound.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkWholeSound.Location = new System.Drawing.Point(410, 66);
      this.chkWholeSound.Name = "chkWholeSound";
      this.chkWholeSound.Size = new System.Drawing.Size(15, 14);
      this.chkWholeSound.TabIndex = 19;
      this.chkWholeSound.UseVisualStyleBackColor = true;
      this.chkWholeSound.CheckedChanged += new System.EventHandler(this.chkWholeSound_CheckedChanged);
      // 
      // toolStripMain
      // 
      this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddSound,
            this.toolStripButtonRemoveAll,
            this.toolStripButtonMakeSampler});
      this.toolStripMain.Location = new System.Drawing.Point(0, 0);
      this.toolStripMain.Name = "toolStripMain";
      this.toolStripMain.Size = new System.Drawing.Size(557, 33);
      this.toolStripMain.TabIndex = 20;
      // 
      // toolStripButtonAddSound
      // 
      this.toolStripButtonAddSound.AutoSize = false;
      this.toolStripButtonAddSound.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.toolStripButtonAddSound.Image = global::AudioHash.Properties.Resources.ButtonAddSound;
      this.toolStripButtonAddSound.Name = "toolStripButtonAddSound";
      this.toolStripButtonAddSound.Size = new System.Drawing.Size(103, 30);
      this.toolStripButtonAddSound.Text = "Add Sound";
      this.toolStripButtonAddSound.ToolTipText = "Add a new container for a sound";
      this.toolStripButtonAddSound.Click += new System.EventHandler(this.toolStripButtonAddSound_Click);
      // 
      // toolStripButtonRemoveAll
      // 
      this.toolStripButtonRemoveAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.toolStripButtonRemoveAll.Image = global::AudioHash.Properties.Resources.ButtonRemoveAll;
      this.toolStripButtonRemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonRemoveAll.Name = "toolStripButtonRemoveAll";
      this.toolStripButtonRemoveAll.Size = new System.Drawing.Size(105, 30);
      this.toolStripButtonRemoveAll.Text = "Remove All";
      this.toolStripButtonRemoveAll.ToolTipText = "Remove all sounds";
      this.toolStripButtonRemoveAll.Click += new System.EventHandler(this.toolStripButtonRemoveAll_Click);
      // 
      // toolStripButtonMakeSampler
      // 
      this.toolStripButtonMakeSampler.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.toolStripButtonMakeSampler.Image = global::AudioHash.Properties.Resources.ButtonMakeSampler;
      this.toolStripButtonMakeSampler.Name = "toolStripButtonMakeSampler";
      this.toolStripButtonMakeSampler.Size = new System.Drawing.Size(124, 30);
      this.toolStripButtonMakeSampler.Text = "Make Sampler";
      this.toolStripButtonMakeSampler.ToolTipText = "Make a sampler from the existing sounds";
      this.toolStripButtonMakeSampler.Click += new System.EventHandler(this.btnConcatenate_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSoundContainerCount,
            this.toolStripStatusLabelSoundContainerCountText});
      this.statusStrip1.Location = new System.Drawing.Point(0, 507);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(557, 22);
      this.statusStrip1.TabIndex = 21;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabelSoundContainerCount
      // 
      this.toolStripStatusLabelSoundContainerCount.Name = "toolStripStatusLabelSoundContainerCount";
      this.toolStripStatusLabelSoundContainerCount.Size = new System.Drawing.Size(13, 17);
      this.toolStripStatusLabelSoundContainerCount.Text = "0";
      // 
      // toolStripStatusLabelSoundContainerCountText
      // 
      this.toolStripStatusLabelSoundContainerCountText.Name = "toolStripStatusLabelSoundContainerCountText";
      this.toolStripStatusLabelSoundContainerCountText.Size = new System.Drawing.Size(53, 17);
      this.toolStripStatusLabelSoundContainerCountText.Text = "sound(s)";
      // 
      // MainWin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(557, 529);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.toolStripMain);
      this.Controls.Add(this.chkWholeSound);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.numericUpDownSampleLength);
      this.Controls.Add(this.pnlSounds);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainWin";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleLength)).EndInit();
      this.toolStripMain.ResumeLayout(false);
      this.toolStripMain.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.FlowLayoutPanel pnlSounds;
    private System.Windows.Forms.NumericUpDown numericUpDownSampleLength;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox chkWholeSound;
    private System.Windows.Forms.ToolStrip toolStripMain;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripButton toolStripButtonAddSound;
    private System.Windows.Forms.ToolStripButton toolStripButtonMakeSampler;
    private System.Windows.Forms.ToolStripButton toolStripButtonRemoveAll;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSoundContainerCount;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSoundContainerCountText;
  }
}

