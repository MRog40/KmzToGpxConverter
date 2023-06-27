using System;
using System.IO;
using System.Windows.Forms;

namespace KmzToGpxConverter
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Files";
            ofd.Filter = "Polyline in format kmz|*.kmz";
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                for (int j = 0, n = ofd.FileNames.Length; j < n; j++)
                {
                    string directoryPath = Path.GetDirectoryName(ofd.FileNames[j]);
                    string fileName = Path.GetFileName(ofd.FileNames[j]);
                    try
                    {
                        Converter.Convert(directoryPath, fileName);
                    }
                    catch
                    {
                        MessageBox.Show("Failed to convert file '" + (directoryPath + "\\" + fileName) + "'");
                    }
                }
            }
        }
    }
}
