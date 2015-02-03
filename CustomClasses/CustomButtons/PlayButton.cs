using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AudioHash
{
  class PlayButton : Button
  {
    public string SoundPath { get; set; }

    public PlayButton(string path)
    {
      this.Text = "Play";
      this.Width = 60;
      this.SoundPath = path;
    }
  }
}
