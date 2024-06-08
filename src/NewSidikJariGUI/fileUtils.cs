using System.IO;
using System.Windows.Forms;

namespace NewSidikJariGUI
{
    public class imageUtils
    {
        public static string fileDialog()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            bool ok = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //File should exist anyways so no need to check
                    
                    ok = true;
                }
            }
            if (ok)
            {
                return filePath;
            }

            return null;

        }

    }
}