using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace AnimateIt
{
    class BackgroundManager
    {
        String[] Paths;
        int Framerate = 5;
        public BackgroundManager(String folder, int framerate)
        {
            this.Framerate = framerate;
            // Get all files (pictures) in Folder
            string[] foldercontent = Directory.GetFiles(folder);

            List<String> filepaths = new List<string>();
            
            foreach (String filepath in foldercontent)
            {
                if (filepath.ToLower().EndsWith(".bmp")) // Only bmp supported
                {
                    filepaths.Add(filepath);
                }
            }

            // Convert list to array
            Paths = filepaths.ToArray();
        }

        public void Start()
        {
            while (true)
            {
                // Iterate through files array
                for (int i = 0; i < Paths.Length; i++)
                {
                    SetBackground(Paths[i]);
                    Thread.Sleep(1000 / Framerate);
                }
            }
        }

        // Methods to change background
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);
        private static UInt32 SPI_SETDESKWALLPAPER = 20;
        private static UInt32 SPIF_UPDATEINIFILE = 0x1;


        private static void SetBackground(string filename)
        {
            try
            {
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, filename, SPIF_UPDATEINIFILE);
            }
            catch { }
        }
    }
}
