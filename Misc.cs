using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AudioHash
{
  public static class Misc
  {
    public static void Log(string str)
    {
      Console.WriteLine(str);
    }

    public static string GetDropBoxPath()
    {
      string appDataPath = Environment.GetFolderPath(
                                   Environment.SpecialFolder.ApplicationData);
      string dbPath = System.IO.Path.Combine(appDataPath, "Dropbox\\host.db");
      string[] lines = System.IO.File.ReadAllLines(dbPath);
      byte[] dbBase64Text = Convert.FromBase64String(lines[1]);
      string folderPath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
      return folderPath;
    }

    public static string GetCurUserMyDocsPath()
    {
      return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }

    public static string GetAppSaveLocation()
    {
      return Path.Combine(GetCurUserMyDocsPath(), Application.ProductName.Replace(" ", ""));
    }
  }
}
