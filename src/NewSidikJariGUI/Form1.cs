using SQLite;
using Database;
using System.Diagnostics;
using System.IO;

namespace NewSidikJariGUI
{
    public partial class Form1 : Form
    {
        
        public String current_imgpath = null;
        public String algo = "KMP";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                announce_text("IMG Loaded successfully!");
                current_imgpath = imgpath;
                pictureBox1.Image = Image.FromFile(imgpath);
            }
            else
            {
                announce_text("IMG Failed to load!");
            }
        }

        private bool search_lock = false;
        Stopwatch sw = new Stopwatch();

        public void Complete_search(String fname, double similarity)
        {
            String path;
            bool image_found = false;
            bool name_found = false;
            bool search_lock = true;

            sw.Stop();

            if (fname != null && fname != "")
            {

                announce_text("Found! :D");
                image_found = true;
                path = Path.Combine(@"..\..\..\..\Database", fname);
                pictureBox2.Image = Image.FromFile(path);
                Console.WriteLine("PATH");

                ReportResult1.Text = $"{sw.ElapsedMilliseconds}ms";
                ReportResult2.Text = $"{similarity}";

                //get biodata
                string[] splitPath = path.Split('\\');
                int size = splitPath.Length;
                String finalPath = Path.Combine(splitPath[size - 2], splitPath[size - 1]);
                String fake_name = Program.fs.GetNamaByBerkasCitra(finalPath);
                String real_name = Database.Regex.FindClosestMatch(fake_name);
                List<Biodata> biodata = Program.fs.GetBiodataByNama(real_name);

                if (biodata.Count > 0)
                {
                    var balls = biodata[0];
                    name_found = true;
                    textBox_set_biodata(balls);

                    //set text n shiz
                }
            }

            if (!image_found || !name_found)
            {
                announce_text("Not found :( !");
                ReportResult1.Text = $"{sw.ElapsedMilliseconds}ms";
                ReportResult2.Text = $"Not found!";
                BiodataLabel.Text = "NOT FOUND!!!";
            }

            search_lock = false;
        }
        private async void Search_Button_Click(object sender, EventArgs e)
        {
            announce_text("");
            if (search_lock)
            {
                announce_text("Wait until finished!");
            }
            else if (current_imgpath != null && current_imgpath != "")
            {
                announce_text("Seeking!");
                String path;

                sw.Reset();
                sw.Start();
                //String fname = fs.getBerkascitrabyAlgo(current_imgpath, algo);
                //String fname = fs.threadedGetBerkasByAlgo(current_imgpath, algo);
                await Program.SEEK_ANSWER(current_imgpath,algo);
                //Complete_search(fname);

            }
            else
            {
                announce_text("Choose image first!");
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
            announce_text("Swapped to KMP");
        }

        private void BM_Button_Click(object sender, EventArgs e)
        {
            swap_buttons(sender as Button);
            algo = "BM";
            announce_text("Swapped to BM");
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox_set_biodata(Biodata bd)
        {
            BiodataLabel.Text = "";
            if (bd != null)
            {
                BiodataLabel.Text += bd.Nama.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.NIK.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.TanggalLahir.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.TempatLahir.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.JenisKelamin.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.GolonganDarah.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.Alamat.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.Agama.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.Pekerjaan.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.StatusPerkawinan.ToString() + Environment.NewLine;
                BiodataLabel.Text += bd.Kewarganegaraan.ToString() + Environment.NewLine;

            }
        }

        private void announce_text(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                AnnouncementText.Visible = false;
            }
            else
            {
                AnnouncementText.Text = text;
                AnnouncementText.Visible = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }
    }
}
