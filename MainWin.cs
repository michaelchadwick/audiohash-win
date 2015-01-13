using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AudioHash
{
  public partial class MainWin : Form
  {
    List<string> sourceFiles = new List<string>();
    int soundIndex = 0;
    int defaultSoundCount = 4;
    string testPath = Misc.GetAppSaveLocation();
    string testFilePrefix = "snd";
    string testFileFormat = ".wav";

    public string tsNumOfSounds
    {
      get { return this.toolStripStatusLabelSoundContainerCount.Text; }
      set { toolStripStatusLabelSoundContainerCount.Text = value; }
    }

    public MainWin()
    {
      InitializeComponent();

      // set window name
      this.Text = Application.ProductName + " - " + Application.ProductVersion;
      
      // add some sample sound containers
      for (int i = 0; i < defaultSoundCount; i++)
      {
        //pnlSounds.Controls.Add(new SoundContainer(soundIndex++, testPath + "\\" + testFilePrefix + "0" + i.ToString() + testFileFormat));
        pnlSounds.Controls.Add(new SoundContainer(soundIndex++));
      }

      statusBarUpdate();
    }

    // event handlers
    private void chkWholeSound_CheckedChanged(object sender, EventArgs e)
    {
      numericUpDownSampleLength.Enabled = chkWholeSound.Checked ? true : false;
    }
    
    private void toolStripButtonAddSound_Click(object sender, EventArgs e)
    {
      pnlSounds.Controls.Add(new SoundContainer(soundIndex++));
      pnlSounds.Update();
      statusBarUpdate();
    }
    
    private void toolStripButtonRemoveAll_Click(object sender, EventArgs e)
    {
      pnlSounds.Controls.Clear();
      statusBarUpdate();
    }
    
    private void btnConcatenate_Click(object sender, EventArgs e)
    {
      double sampleLen = 0;
      if (numericUpDownSampleLength.Enabled)
      {
        sampleLen = (double)numericUpDownSampleLength.Value * 1000;
      }
      AudioWriter.CreateConcatAudioFile(sourceFiles, (Panel)pnlSounds, sampleLen);
    }
    
    private void pnlSounds_ControlRemoved(object sender, ControlEventArgs e)
    {
      if (this.pnlSounds.Controls.Count <= 0)
      {
        this.pnlSounds.Text = "Add some sounds!";
      }
    }

    // misc methods
    public void statusBarUpdate()
    {
      this.tsNumOfSounds = pnlSounds.Controls.Count.ToString();
    }

  }
}
