using SQLite;

namespace NewSidikJariGUI
{
    public partial class Form1 : Form
    {
        private FingerprintService fs = null;
        private String db_path = "blogging.db";
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
                pictureBox1.Image = Image.FromFile(imgpath);
            }
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            String fname = fs.GetAllBerkasCitra()[0].BerkasCitra;
            if (fname != null) { 
                pictureBox2.Image = Image.FromFile(fname);
            }
            else
            {
                Console.WriteLine("IMG SOMEHOW NOT FOUND " + fname);
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
        }

        private void BM_Button_Click(object sender, EventArgs e)
        {
            swap_buttons(sender as Button);
        }

        
    }
}
