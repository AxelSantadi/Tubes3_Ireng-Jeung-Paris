using SQLite;
using Database;
using System.Diagnostics;

namespace NewSidikJariGUI
{
    public partial class Form1 : Form
    {
        private FingerprintService fs = null;
        private String db_path = "blogging.db";
        private String current_imgpath = null;
        private String algo = "KMP";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fs = new FingerprintService(db_path);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String imgpath = imageUtils.fileDialog();
            if (imgpath != null)
            {
                current_imgpath = imgpath;
                pictureBox1.Image = Image.FromFile(imgpath);
            }
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            if (current_imgpath != null)
            {
                Stopwatch sw = Stopwatch.StartNew();
                String fname = fs.getBerkascitrabyAlgo(current_imgpath, algo);
                if (fname != null && fname != "");
                {
                    String path = Path.Combine(@"..\..\..\..\Database", fname);
                    pictureBox2.Image = Image.FromFile(path);
                    Console.WriteLine("PATH");
                    sw.Stop();
                    ReportResult1.Text = $"{sw.ElapsedMilliseconds}ms";
                    ReportResult2.Text = $"{fs.last_similarity}";
                    string[] splitPath = path.Split('\\');
                    int size = splitPath.Length;
                    String finalPath = Path.Combine(splitPath[size - 2], splitPath[size - 1]);
                    String name = fs.GetNamaByBerkasCitra(finalPath);
                    List<Biodata> biodata = fs.GetBiodataByNama(name);
                    var balls = biodata.Count;

                }
                else
                {
                    sw.Stop();
                    ReportResult1.Text = $"{sw.ElapsedMilliseconds}ms";
                    ReportResult2.Text = $"Not found!";
                }

            }


        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void swap_buttons(object button)
        {
            foreach (Button bref in AlgorithmChoice.Controls)
            {
                if (bref == button)
                {
                    bref.BackColor = SystemColors.Control;
                }
                else
                {
                    bref.BackColor = SystemColors.ControlLight;
                }
            }
        }

        private void KMP_Button_Click(object sender, EventArgs e)
        {
            swap_buttons(sender as Button);
            algo = "KMP";
        }

        private void BM_Button_Click(object sender, EventArgs e)
        {
            swap_buttons(sender as Button);
            algo = "BM";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
