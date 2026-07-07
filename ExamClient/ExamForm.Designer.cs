namespace ExamClient
{
    partial class ExamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rdA = new System.Windows.Forms.RadioButton();
            this.rdB = new System.Windows.Forms.RadioButton();
            this.rdC = new System.Windows.Forms.RadioButton();
            this.rdD = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlExam = new System.Windows.Forms.Panel();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstExams = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlExam.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(26, 68);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(111, 16);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Đang tải câu hỏi...";
            // 
            // rdA
            // 
            this.rdA.AutoSize = true;
            this.rdA.Location = new System.Drawing.Point(71, 131);
            this.rdA.Name = "rdA";
            this.rdA.Size = new System.Drawing.Size(103, 20);
            this.rdA.TabIndex = 1;
            this.rdA.TabStop = true;
            this.rdA.Text = "radioButton1";
            this.rdA.UseVisualStyleBackColor = true;
            // 
            // rdB
            // 
            this.rdB.AutoSize = true;
            this.rdB.Location = new System.Drawing.Point(71, 182);
            this.rdB.Name = "rdB";
            this.rdB.Size = new System.Drawing.Size(103, 20);
            this.rdB.TabIndex = 2;
            this.rdB.TabStop = true;
            this.rdB.Text = "radioButton2";
            this.rdB.UseVisualStyleBackColor = true;
            // 
            // rdC
            // 
            this.rdC.AutoSize = true;
            this.rdC.Location = new System.Drawing.Point(71, 229);
            this.rdC.Name = "rdC";
            this.rdC.Size = new System.Drawing.Size(103, 20);
            this.rdC.TabIndex = 3;
            this.rdC.TabStop = true;
            this.rdC.Text = "radioButton3";
            this.rdC.UseVisualStyleBackColor = true;
            // 
            // rdD
            // 
            this.rdD.AutoSize = true;
            this.rdD.Location = new System.Drawing.Point(71, 275);
            this.rdD.Name = "rdD";
            this.rdD.Size = new System.Drawing.Size(103, 20);
            this.rdD.TabIndex = 4;
            this.rdD.TabStop = true;
            this.rdD.Text = "radioButton4";
            this.rdD.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(543, 345);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(103, 31);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Câu tiếp theo";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(562, 22);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(100, 16);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "Thời gian: 10:00";
            this.lblTimer.Click += new System.EventHandler(this.timer1_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlExam
            // 
            this.pnlExam.Controls.Add(this.lblMSSV);
            this.pnlExam.Controls.Add(this.lblStudentName);
            this.pnlExam.Controls.Add(this.lblTitle);
            this.pnlExam.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlExam.ForeColor = System.Drawing.Color.Black;
            this.pnlExam.Location = new System.Drawing.Point(0, 0);
            this.pnlExam.Name = "pnlExam";
            this.pnlExam.Size = new System.Drawing.Size(1113, 74);
            this.pnlExam.TabIndex = 7;
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Location = new System.Drawing.Point(948, 33);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(0, 16);
            this.lblMSSV.TabIndex = 2;
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Location = new System.Drawing.Point(700, 33);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(0, 16);
            this.lblStudentName.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(548, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG TRẮC NGHIỆM TRỰC TUYẾN";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.lstExams);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 414);
            this.panel1.TabIndex = 8;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(79, 345);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(170, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstExams
            // 
            this.lstExams.FormattingEnabled = true;
            this.lstExams.ItemHeight = 16;
            this.lstExams.Location = new System.Drawing.Point(12, 54);
            this.lstExams.Name = "lstExams";
            this.lstExams.Size = new System.Drawing.Size(325, 260);
            this.lstExams.TabIndex = 1;
            this.lstExams.SelectedIndexChanged += new System.EventHandler(this.lstExams_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "DANH SÁCH ĐỀ THI";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPrev);
            this.panel3.Controls.Add(this.lblTimer);
            this.panel3.Controls.Add(this.lblQuestion);
            this.panel3.Controls.Add(this.rdA);
            this.panel3.Controls.Add(this.btnNext);
            this.panel3.Controls.Add(this.rdB);
            this.panel3.Controls.Add(this.rdD);
            this.panel3.Controls.Add(this.rdC);
            this.panel3.Location = new System.Drawing.Point(377, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(683, 414);
            this.panel3.TabIndex = 9;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(71, 345);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(103, 31);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "Câu trước";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(896, 527);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(127, 34);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Nộp Bài";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(333, 539);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(332, 22);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Tổng số câu: 0 | Đã làm: 0 | Chưa làm: 0";
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(44, 536);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(120, 33);
            this.btnHistory.TabIndex = 12;
            this.btnHistory.Text = "Xem lịch sử";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // ExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 592);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlExam);
            this.Name = "ExamForm";
            this.Text = "ExamForm";
            this.pnlExam.ResumeLayout(false);
            this.pnlExam.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rdA;
        private System.Windows.Forms.RadioButton rdB;
        private System.Windows.Forms.RadioButton rdC;
        private System.Windows.Forms.RadioButton rdD;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlExam;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstExams;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnHistory;
    }
}