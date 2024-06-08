namespace NewSidikJariGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ResultHeader = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            IMGPick_Button = new Button();
            AlgorithmChoice = new TableLayoutPanel();
            KMP_Button = new Button();
            BM_Button = new Button();
            panel1 = new Panel();
            ReportResult2 = new Label();
            ReportResult1 = new Label();
            ReportName2 = new Label();
            ReportName1 = new Label();
            Search_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            AlgorithmChoice.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 288);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(303, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(240, 288);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(pictureBox2, 1, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 2, 0);
            tableLayoutPanel1.Location = new Point(37, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 72.74939F));
            tableLayoutPanel1.Size = new Size(751, 324);
            tableLayoutPanel1.TabIndex = 2;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(ResultHeader);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(603, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(145, 288);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // ResultHeader
            // 
            ResultHeader.AutoSize = true;
            ResultHeader.Location = new Point(3, 0);
            ResultHeader.Name = "ResultHeader";
            ResultHeader.Size = new Size(62, 20);
            ResultHeader.TabIndex = 0;
            ResultHeader.Text = "Results :";
            ResultHeader.Click += label1_Click_1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(IMGPick_Button, 0, 0);
            tableLayoutPanel2.Controls.Add(AlgorithmChoice, 1, 0);
            tableLayoutPanel2.Controls.Add(panel1, 3, 0);
            tableLayoutPanel2.Controls.Add(Search_Button, 2, 0);
            tableLayoutPanel2.Location = new Point(40, 342);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(745, 104);
            tableLayoutPanel2.TabIndex = 3;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // IMGPick_Button
            // 
            IMGPick_Button.AutoSize = true;
            IMGPick_Button.Location = new Point(3, 3);
            IMGPick_Button.Name = "IMGPick_Button";
            IMGPick_Button.Size = new Size(180, 98);
            IMGPick_Button.TabIndex = 0;
            IMGPick_Button.Text = "Select Image";
            IMGPick_Button.UseVisualStyleBackColor = true;
            IMGPick_Button.Click += button1_Click;
            // 
            // AlgorithmChoice
            // 
            AlgorithmChoice.ColumnCount = 1;
            AlgorithmChoice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            AlgorithmChoice.Controls.Add(KMP_Button, 0, 0);
            AlgorithmChoice.Controls.Add(BM_Button, 0, 1);
            AlgorithmChoice.Location = new Point(189, 3);
            AlgorithmChoice.Name = "AlgorithmChoice";
            AlgorithmChoice.RowCount = 2;
            AlgorithmChoice.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            AlgorithmChoice.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            AlgorithmChoice.Size = new Size(180, 98);
            AlgorithmChoice.TabIndex = 1;
            // 
            // KMP_Button
            // 
            KMP_Button.AutoSize = true;
            KMP_Button.BackColor = SystemColors.Control;
            KMP_Button.Location = new Point(3, 3);
            KMP_Button.Name = "KMP_Button";
            KMP_Button.Size = new Size(174, 42);
            KMP_Button.TabIndex = 0;
            KMP_Button.Text = "KMP";
            KMP_Button.UseVisualStyleBackColor = false;
            KMP_Button.Click += KMP_Button_Click;
            // 
            // BM_Button
            // 
            BM_Button.AutoSize = true;
            BM_Button.BackColor = SystemColors.ControlLight;
            BM_Button.Location = new Point(3, 52);
            BM_Button.Name = "BM_Button";
            BM_Button.Size = new Size(174, 42);
            BM_Button.TabIndex = 0;
            BM_Button.Text = "BM";
            BM_Button.UseVisualStyleBackColor = false;
            BM_Button.Click += BM_Button_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ReportResult2);
            panel1.Controls.Add(ReportResult1);
            panel1.Controls.Add(ReportName2);
            panel1.Controls.Add(ReportName1);
            panel1.Location = new Point(561, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(181, 98);
            panel1.TabIndex = 2;
            // 
            // ReportResult2
            // 
            ReportResult2.AutoSize = true;
            ReportResult2.Location = new Point(117, 39);
            ReportResult2.Name = "ReportResult2";
            ReportResult2.Size = new Size(50, 20);
            ReportResult2.TabIndex = 1;
            ReportResult2.Text = "label2";
            ReportResult2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ReportResult1
            // 
            ReportResult1.AutoSize = true;
            ReportResult1.Location = new Point(117, 15);
            ReportResult1.Name = "ReportResult1";
            ReportResult1.Size = new Size(50, 20);
            ReportResult1.TabIndex = 1;
            ReportResult1.Text = "label2";
            ReportResult1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ReportName2
            // 
            ReportName2.AutoSize = true;
            ReportName2.Location = new Point(13, 39);
            ReportName2.Name = "ReportName2";
            ReportName2.Size = new Size(71, 20);
            ReportName2.TabIndex = 0;
            ReportName2.Text = "Similarity";
            ReportName2.TextAlign = ContentAlignment.MiddleLeft;
            ReportName2.Click += label1_Click_2;
            // 
            // ReportName1
            // 
            ReportName1.AutoSize = true;
            ReportName1.Location = new Point(13, 15);
            ReportName1.Name = "ReportName1";
            ReportName1.Size = new Size(42, 20);
            ReportName1.TabIndex = 0;
            ReportName1.Text = "Time";
            ReportName1.TextAlign = ContentAlignment.MiddleLeft;
            ReportName1.Click += label1_Click_2;
            // 
            // Search_Button
            // 
            Search_Button.Location = new Point(375, 3);
            Search_Button.Name = "Search_Button";
            Search_Button.Size = new Size(180, 98);
            Search_Button.TabIndex = 3;
            Search_Button.Text = "Search";
            Search_Button.UseVisualStyleBackColor = true;
            Search_Button.Click += Search_Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            AlgorithmChoice.ResumeLayout(false);
            AlgorithmChoice.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label ResultHeader;
        private TableLayoutPanel tableLayoutPanel2;
        private Button IMGPick_Button;
        private TableLayoutPanel AlgorithmChoice;
        private Button KMP_Button;
        private Button BM_Button;
        private Panel panel1;
        private Label ReportName1;
        private Label ReportResult2;
        private Label ReportResult1;
        private Label ReportName2;
        private Button Search_Button;
    }
}
