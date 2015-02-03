using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

using NAudio;
using NAudio.Wave;

namespace AudioHash
{
  public static class AudioWriter
  {
    // create a concatenated file of all the files loaded in the form
    public static void CreateConcatAudioFile(List<string> sourceFiles, Panel pnlSounds, double sampleLen)
    {
      WaveFileWriter writer = null;
      string defaultSaveLocation = Path.Combine(Misc.GetCurUserMyDocsPath(), Application.ProductName.Replace(" ", ""));
      string defaultOutputFile = Path.Combine(defaultSaveLocation, @"concat.wav");
      bool boolAudioFileWrittenSuccessfully = true;
      bool writeWavFileOldWay = true;
      
      string soundPath;
      string outputFile;
      
      if (!Directory.Exists(defaultSaveLocation))
      {
        Directory.CreateDirectory(defaultSaveLocation);
      }

      // clear sourceFiles before adding
      sourceFiles.Clear();

      foreach (SoundContainer snd in pnlSounds.Controls.OfType<SoundContainer>().OrderBy(c => c.TabIndex))
      {
        soundPath = snd.txtFilePath.Text;
        if (!String.IsNullOrEmpty(soundPath))
        {
          sourceFiles.Add(soundPath);
        }
      }

      if (sourceFiles.Count <= 0)
      {
        MessageBox.Show("No source files have been loaded.");
        return;
      }

      #if DEBUG
        outputFile = defaultOutputFile;
      #else
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "WAV file|*.wav";
        saveFileDialog.Title = "Output WAV file name";
        saveFileDialog.ShowDialog();
        outputFile = saveFileDialog.FileName;  
      #endif
      
      if (!String.IsNullOrEmpty(outputFile))
      {
        try
        {
          foreach (string sourceFile in sourceFiles)
          {
            using (WaveFileReader reader = new WaveFileReader(sourceFile))
            {
              if (writer == null)
              {
                writer = new WaveFileWriter(outputFile, reader.WaveFormat);
              }
              else
              {
                if (!reader.WaveFormat.Equals(writer.WaveFormat))
                {
                  throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                }
              }

              /*
               * BEGIN OLD WAY
               * just combines files in whole
               */

              if (writeWavFileOldWay)
              {
                int read;
                byte[] buffer = new byte[reader.WaveFormat.BlockAlign * 1024];
                int soundLen = (int)reader.TotalTime.TotalMilliseconds;
                TimeSpan sampleStartPos = GenRandomStart(soundLen);
                TimeSpan sampleDuration = new TimeSpan(0, 0, 0, 0, soundLen);

                double bytesPerMs = reader.WaveFormat.AverageBytesPerSecond / 1000;
                double startPos = sampleStartPos.TotalMilliseconds * bytesPerMs;
                startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

                reader.Position = (long)startPos;

                sampleLen = Math.Min(sampleLen, soundLen);

                if (sampleLen > 0)
                {
                  sampleStartPos = GenRandomStart(soundLen);
                  sampleDuration = new TimeSpan(0, 0, 0, 0, (int)sampleLen);
                }

                double endBytes = sampleDuration.TotalMilliseconds * bytesPerMs;
                endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
                double endPos = startPos + endBytes;

                while ((read = reader.Read(buffer, 0, buffer.Length)) > 0 && reader.Position < endPos)
                {
                  writer.Write(buffer, 0, read);
                }
              }
              else
              {
                /*
                 * BEGIN NEW WAY
                 * Grab random chunks of files
                 */

                int soundLen = (int)reader.TotalTime.TotalMilliseconds;

                sampleLen = Math.Min(sampleLen, soundLen);

                TimeSpan sampleStartPos = new TimeSpan(0, 0, 0, 0, 0);
                TimeSpan sampleDuration = new TimeSpan(0, 0, 0, 0, soundLen);

                if (sampleLen > 0)
                {
                  sampleStartPos = GenRandomStart(soundLen);
                  sampleDuration = new TimeSpan(0, 0, 0, 0, (int)sampleLen);
                }

                boolAudioFileWrittenSuccessfully = WriteAudioFileToDisk(reader, writer, sourceFile, outputFile, sampleStartPos, sampleDuration);

              }

              /*
               * END NEW WAY
               */
            }
          }
        }
        catch (Exception ex)
        {
          Misc.Log("Exception: " + ex);
          boolAudioFileWrittenSuccessfully = false;
        }
        finally
        {
          if (writer != null && boolAudioFileWrittenSuccessfully)
          {
            writer.Dispose();
            MessageBox.Show("Sounds successfully concatenated!", "Success!");
            Process.Start(Path.GetDirectoryName(outputFile));
          }
          else
          {
            MessageBox.Show("Something went wrong :-(");
          }
        }
      }
      else
      {
        MessageBox.Show("Output path/file invalid.");
      }
    }
  
    // actually write data from the loaded files into the concatenated file
    private static bool WriteAudioFileToDisk(WaveFileReader reader, WaveFileWriter writer, string inPath, string outPath, TimeSpan sampleStartPosition, TimeSpan sampleDuration)
    {
      using (reader)
      {
        using (writer)
        {
          byte[] buffer = new byte[reader.WaveFormat.BlockAlign * 1024];
          double bytesPerMs = reader.WaveFormat.AverageBytesPerSecond / 1000;
          double startPos = sampleStartPosition.TotalMilliseconds * bytesPerMs;
          startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

          double endBytes = sampleDuration.TotalMilliseconds * bytesPerMs;
          endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
          double endPos = startPos + endBytes;

          try
          {
            while (reader.Position < endPos)
            {
              int bytesRequired = (int)(endPos - reader.Position);
              if (bytesRequired > 0)
              {
                int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                int bytesRead = reader.Read(buffer, 0, bytesToRead);
                if (bytesRead > 0)
                {
                  writer.Write(buffer, 0, bytesRead);
                }
              }
            }
            return true;
          }
          catch (Exception ex)
          {
            MessageBox.Show("Error writing file: " + ex);
            return false;
          }
        }
      }
    }
  
    private static TimeSpan GenRandomStart(int soundLen)
    {
      Random r = new Random();
      return new TimeSpan(0, 0, 0, 0, r.Next(0, soundLen));
    }
  }
}
