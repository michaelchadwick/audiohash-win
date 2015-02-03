using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using NAudio;
using NAudio.Wave;

namespace AudioHash
{
  class SoundContainer : GroupBox
  {
    private TimeSpan defaultSoundTime;

    private Timer timerElapsed { get; set; }
    private Timer timerTrackBar { get; set; }
    public TextBox txtFilePath { get; set; }
    private Button btnBrowse { get; set; }
    private Button btnPlay { get; set; }
    private Button btnStop { get; set; }
    private Button btnDelete { get; set; }
    private TrackBar trackBar { get; set; }
    private TextBox txtSoundTime { get; set; }
    private OpenFileDialog openFileDialog;
    private AudioFileReader audioFileReader;
    private IWavePlayer audioFilePlayer;

    public SoundContainer(int soundIndex, string soundPath = "")
    {
      defaultSoundTime = new TimeSpan(0, 0, 0, 0, 0);

      // SoundContainer dimensions
      this.Name = "snd" + soundIndex;
      this.Text = "Sound " + soundIndex;
      this.Visible = true;
      this.Size = new Size(362, 106);

      // SoundContainer controls
      this.timerElapsed = new Timer();
      this.timerTrackBar = new Timer();
      this.txtFilePath = new TextBox();
      this.btnBrowse = new Button();
      this.btnPlay = new PlayButton(txtFilePath.Text);
      this.btnStop = new StopButton();
      this.btnDelete = new Button();
      this.trackBar = new TrackBar();
      this.txtSoundTime = new TextBox();
      this.openFileDialog = new OpenFileDialog();
      this.audioFilePlayer = new WaveOut(WaveCallbackInfo.FunctionCallback());

      if (!String.IsNullOrEmpty(txtFilePath.Text) && File.Exists(txtFilePath.Text))
      {
        this.audioFileReader = new AudioFileReader(txtFilePath.Text);
      }

      // Sound control attributes
      this.txtFilePath.Width = 270;
      this.txtFilePath.Location = new Point(6, 19);
      this.txtFilePath.Name = "txtFilePath" + soundIndex;
      this.txtFilePath.Text = soundPath;

      this.btnBrowse.Width = 69;
      this.btnBrowse.Location = new Point(282, 17);
      this.btnBrowse.Text = "Browse...";
      this.btnBrowse.Name = "btnBrowse" + soundIndex;
      
      this.btnPlay.Location = new Point(6, 46);
      this.btnPlay.Name = "btnPlay" + soundIndex;
      this.btnPlay.Enabled = false;

      this.btnStop.Location = new Point(72, 46);
      this.btnStop.Name = "btnStop" + soundIndex;
      this.btnStop.Enabled = false;

      this.btnDelete.Size = new Size(22, 22);
      this.btnDelete.Name = "btnDelete" + soundIndex;
      this.btnDelete.Location = new Point(340, 84);
      this.btnDelete.Image = Properties.Resources.ButtonRemoveAll;
      
      this.trackBar.Location = new Point(138, 46);
      this.trackBar.Name = "trackBar" + soundIndex;
      this.trackBar.Minimum = 0;
      this.trackBar.Width = 144;
      this.trackBar.TickStyle = TickStyle.None;

      this.txtSoundTime.Location = new Point(282, 46);
      this.txtSoundTime.Name = "txtSoundTime" + soundIndex;
      this.txtSoundTime.Width = 48;
      this.txtSoundTime.Enabled = false;

      // only dealing with WAVs for now
      //this.openFileDialog.Filter += "MP3 file|*.mp3";
      this.openFileDialog.Filter += "WAV file|*.wav";
     
      // SoundContainer control event handlers
      this.timerElapsed.Tick += new EventHandler(timerElapsed_Tick);
      this.timerTrackBar.Tick += new EventHandler(timerTrackBar_Tick);
      this.txtFilePath.DoubleClick += new EventHandler(txtFilePath_DoubleClick);
      this.btnBrowse.Click += new EventHandler(btnBrowseFile_Click);
      this.btnPlay.Click += new EventHandler(btnPlayFile_Click);
      this.btnStop.Click += new EventHandler(btnStop_Click);
      this.trackBar.Scroll += new EventHandler(trackBar_Scroll);
      this.btnDelete.Click += new EventHandler(btnDelete_Click);
      this.audioFilePlayer.PlaybackStopped += new EventHandler<StoppedEventArgs>(audioFilePlayer_PlaybackStopped);

      // add the controls to the SoundContainer
      this.Controls.Add(txtFilePath);
      this.Controls.Add(btnBrowse);
      this.Controls.Add(btnPlay);
      this.Controls.Add(btnStop);
      this.Controls.Add(trackBar);
      this.Controls.Add(txtSoundTime);
      this.Controls.Add(btnDelete);
    }

    // EVENT HANDLERS

    // update sound time display
    private void timerElapsed_Tick(object sender, EventArgs e)
    {
      TimeSpan soundCurrentTime = this.audioFileReader.CurrentTime;
      this.txtSoundTime.Text = soundCurrentTime.ToString();
    }

    // update trackbar position
    private void timerTrackBar_Tick(object sender, EventArgs e)
    {
      int soundCurrentTime = (int)this.audioFileReader.CurrentTime.TotalSeconds;
      this.trackBar.Value = soundCurrentTime;
    }
    
    private void audioFilePlayer_PlaybackStopped(object sender, EventArgs e)
    {
      if (this.audioFilePlayer.PlaybackState.ToString().Equals("Stopped"))
      {
        this.trackBar.Value = 0;
        this.txtSoundTime.Text = defaultSoundTime.ToString();
        timerElapsed.Stop();
        timerTrackBar.Stop();
      }
    }

    private void txtFilePath_DoubleClick(object sender, EventArgs e)
    {
      this.btnBrowse.PerformClick();
    }
    private void btnBrowseFile_Click(object sender, EventArgs e)
    {
      DialogResult result = this.openFileDialog.ShowDialog(); // Show the dialog.
      if (result == DialogResult.OK) // Test result.
      {
        this.txtFilePath.Text = this.openFileDialog.FileName;
        this.btnPlay.Enabled = true;
      }
    }
    private void btnPlayFile_Click(object sender, EventArgs e)
    {
      if (!String.IsNullOrEmpty(this.txtFilePath.Text) && File.Exists(this.txtFilePath.Text))
      {
        this.audioFileReader = new AudioFileReader(txtFilePath.Text);
        if (this.audioFileReader.Length > 0)
        {
          int fileInSeconds = (int)this.audioFileReader.TotalTime.TotalSeconds;
          this.trackBar.Maximum = fileInSeconds;
          
          if (this.audioFilePlayer.PlaybackState.ToString().Equals("Playing"))
          {
            this.audioFilePlayer.Stop();
            this.timerElapsed.Stop();
            this.timerTrackBar.Stop();
            this.audioFilePlayer.Init(this.audioFileReader);
            this.audioFileReader.SetPosition(0.0);
            this.audioFilePlayer.Play();
          }
          else
          {
            this.audioFilePlayer.Init(this.audioFileReader);
            this.audioFilePlayer.Play();
          }
          this.btnStop.Enabled = true;
          this.timerElapsed.Start();
          this.timerTrackBar.Start();
        }
      }
    }
    private void btnStop_Click(object sender, EventArgs e)
    {
      this.txtSoundTime.Text = defaultSoundTime.ToString();
      this.trackBar.Value = 0;
      this.audioFilePlayer.Stop();
    }
    private void btnDelete_Click(object sender, EventArgs e)
    {
      Panel pnlParent = (Panel)this.Parent;
      this.Parent.Controls.Remove(this);
      pnlParent.Update();
      MainWin mw = new MainWin();
      mw.statusBarUpdate();
    }
    private void trackBar_Scroll(object sender, EventArgs e)
    {
      if (this.audioFileReader != null)
      {
        double tbVal = this.trackBar.Value;
        this.audioFileReader.SetPosition(tbVal);
      }
    }
    
  }
}
