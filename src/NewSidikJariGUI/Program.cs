using Database;

namespace NewSidikJariGUI
{
    internal static class Program
    {

        public static FingerprintService fs = null;
        private static String db_path = "blogging.db";
        private static Form1 GUI;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // File integrity check
            if (!File.Exists("coconut.jpg"))
            {
                MessageBox.Show("Program failed to run! (Missing textures?)", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Failed to load!");
                //Console.WriteLine("Failed to load!");
            }

            // Init DB
            fs = new FingerprintService(db_path);


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            GUI = new Form1();
            Application.Run(GUI);
        }

        

        public static async Task SEEK_ANSWER(String imgpath, String Algo) {
            String fname = Program.fs.threadedGetBerkasByAlgo(imgpath, Algo);
            GUI.Complete_search(fname,fs.last_similarity);
        }
    }
}