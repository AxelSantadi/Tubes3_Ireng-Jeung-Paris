using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SidikJariGUI
{
    public partial class Form1 : Form
    {
        private int count;
        public Form1()
        {
            InitializeComponent();
            this.count = 0;
        }

        public int tick()
        {
            this.count++;
            update_text();
            return count;
        }
        public void update_text()
        {
            this.label1.Text = $"TIMES CLICKED : {count}";
            this.Update();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            imageUtils.fileDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
