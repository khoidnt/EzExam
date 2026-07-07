namespace ExamClient
{
    partial class AdminForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOptA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOptB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOptC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOptD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorrect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbExam = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbCorrect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOptionD = new System.Windows.Forms.TextBox();
            this.txtOptionC = new System.Windows.Forms.TextBox();
            this.txtOptionB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOptionA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.ResultID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadResults = new System.Windows.Forms.Button();
            this.grpStatistic = new System.Windows.Forms.GroupBox();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblTotalAttempts = new System.Windows.Forms.Label();
            this.lblAverageScore = new System.Windows.Forms.Label();
            this.lblTotalQuestions = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.grpStatistic.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 701);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1142, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.dgvQuestions);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1103, 365);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QUẢN LÝ CÂU HỎI";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(983, 273);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(85, 41);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Làm mới";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.AllowUserToAddRows = false;
            this.dgvQuestions.AllowUserToDeleteRows = false;
            this.dgvQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colQuestion,
            this.colOptA,
            this.colOptB,
            this.colOptC,
            this.colOptD,
            this.colCorrect});
            this.dgvQuestions.Location = new System.Drawing.Point(5, 23);
            this.dgvQuestions.MultiSelect = false;
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.ReadOnly = true;
            this.dgvQuestions.RowHeadersVisible = false;
            this.dgvQuestions.RowHeadersWidth = 51;
            this.dgvQuestions.RowTemplate.Height = 24;
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.Size = new System.Drawing.Size(958, 324);
            this.dgvQuestions.TabIndex = 0;
            this.dgvQuestions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestions_CellContentClick);
            // 
            // colID
            // 
            this.colID.FillWeight = 433.7541F;
            this.colID.HeaderText = "QuestionID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 125;
            // 
            // colQuestion
            // 
            this.colQuestion.FillWeight = 17.23526F;
            this.colQuestion.HeaderText = "Nội dung câu hỏi";
            this.colQuestion.MinimumWidth = 6;
            this.colQuestion.Name = "colQuestion";
            this.colQuestion.ReadOnly = true;
            this.colQuestion.Width = 300;
            // 
            // colOptA
            // 
            this.colOptA.FillWeight = 17.23526F;
            this.colOptA.HeaderText = "Option A";
            this.colOptA.MinimumWidth = 6;
            this.colOptA.Name = "colOptA";
            this.colOptA.ReadOnly = true;
            this.colOptA.Width = 120;
            // 
            // colOptB
            // 
            this.colOptB.FillWeight = 17.23526F;
            this.colOptB.HeaderText = "Option B";
            this.colOptB.MinimumWidth = 6;
            this.colOptB.Name = "colOptB";
            this.colOptB.ReadOnly = true;
            this.colOptB.Width = 120;
            // 
            // colOptC
            // 
            this.colOptC.FillWeight = 17.23526F;
            this.colOptC.HeaderText = "Option C";
            this.colOptC.MinimumWidth = 6;
            this.colOptC.Name = "colOptC";
            this.colOptC.ReadOnly = true;
            this.colOptC.Width = 120;
            // 
            // colOptD
            // 
            this.colOptD.FillWeight = 17.23526F;
            this.colOptD.HeaderText = "Option D";
            this.colOptD.MinimumWidth = 6;
            this.colOptD.Name = "colOptD";
            this.colOptD.ReadOnly = true;
            this.colOptD.Width = 120;
            // 
            // colCorrect
            // 
            this.colCorrect.FillWeight = 17.23526F;
            this.colCorrect.HeaderText = "Câu trả lời";
            this.colCorrect.MinimumWidth = 6;
            this.colCorrect.Name = "colCorrect";
            this.colCorrect.ReadOnly = true;
            this.colCorrect.Width = 80;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(983, 197);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 42);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(983, 127);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 40);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(982, 52);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 43);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbExam);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cmbCorrect);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtOptionD);
            this.groupBox2.Controls.Add(this.txtOptionC);
            this.groupBox2.Controls.Add(this.txtOptionB);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtOptionA);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtQuestion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(17, 409);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(842, 136);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "THÔNG TIN CÂU HỎI ";
            // 
            // cmbExam
            // 
            this.cmbExam.FormattingEnabled = true;
            this.cmbExam.Location = new System.Drawing.Point(704, 29);
            this.cmbExam.Name = "cmbExam";
            this.cmbExam.Size = new System.Drawing.Size(121, 24);
            this.cmbExam.TabIndex = 14;
            this.cmbExam.SelectedIndexChanged += new System.EventHandler(this.cmbExam_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(701, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "Đề thi:";
            // 
            // cmbCorrect
            // 
            this.cmbCorrect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCorrect.FormattingEnabled = true;
            this.cmbCorrect.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cmbCorrect.Location = new System.Drawing.Point(563, 31);
            this.cmbCorrect.Name = "cmbCorrect";
            this.cmbCorrect.Size = new System.Drawing.Size(77, 24);
            this.cmbCorrect.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(560, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Đáp án đúng:";
            // 
            // txtOptionD
            // 
            this.txtOptionD.Location = new System.Drawing.Point(376, 84);
            this.txtOptionD.Name = "txtOptionD";
            this.txtOptionD.Size = new System.Drawing.Size(173, 22);
            this.txtOptionD.TabIndex = 9;
            // 
            // txtOptionC
            // 
            this.txtOptionC.Location = new System.Drawing.Point(376, 30);
            this.txtOptionC.Name = "txtOptionC";
            this.txtOptionC.Size = new System.Drawing.Size(173, 22);
            this.txtOptionC.TabIndex = 8;
            // 
            // txtOptionB
            // 
            this.txtOptionB.Location = new System.Drawing.Point(191, 83);
            this.txtOptionB.Name = "txtOptionB";
            this.txtOptionB.Size = new System.Drawing.Size(164, 22);
            this.txtOptionB.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(373, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Option D:";
            // 
            // txtOptionA
            // 
            this.txtOptionA.Location = new System.Drawing.Point(191, 31);
            this.txtOptionA.Name = "txtOptionA";
            this.txtOptionA.Size = new System.Drawing.Size(164, 22);
            this.txtOptionA.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Option C:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Option B:";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(-3, 46);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(185, 22);
            this.txtQuestion.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Option A:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Câu hỏi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(613, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "QUẢN TRỊ HỆ THỐNG THI TRẮC NGHIỆM ONLINE";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ResultID,
            this.Username,
            this.ExamName,
            this.Score,
            this.CreatedAt});
            this.dgvResults.Location = new System.Drawing.Point(17, 560);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(842, 138);
            this.dgvResults.TabIndex = 5;
            // 
            // ResultID
            // 
            this.ResultID.HeaderText = "Mã kết quả";
            this.ResultID.MinimumWidth = 6;
            this.ResultID.Name = "ResultID";
            this.ResultID.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.HeaderText = "Sinh viên";
            this.Username.MinimumWidth = 6;
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // ExamName
            // 
            this.ExamName.HeaderText = "Đề thi";
            this.ExamName.MinimumWidth = 6;
            this.ExamName.Name = "ExamName";
            this.ExamName.ReadOnly = true;
            // 
            // Score
            // 
            this.Score.HeaderText = "Điểm";
            this.Score.MinimumWidth = 6;
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            // 
            // CreatedAt
            // 
            this.CreatedAt.HeaderText = "Ngày thi";
            this.CreatedAt.MinimumWidth = 6;
            this.CreatedAt.Name = "CreatedAt";
            this.CreatedAt.ReadOnly = true;
            // 
            // btnLoadResults
            // 
            this.btnLoadResults.Location = new System.Drawing.Point(914, 598);
            this.btnLoadResults.Name = "btnLoadResults";
            this.btnLoadResults.Size = new System.Drawing.Size(118, 47);
            this.btnLoadResults.TabIndex = 6;
            this.btnLoadResults.Text = "Xem kết quả";
            this.btnLoadResults.UseVisualStyleBackColor = true;
            this.btnLoadResults.Click += new System.EventHandler(this.btnLoadResults_Click);
            // 
            // grpStatistic
            // 
            this.grpStatistic.Controls.Add(this.lblTotalStudents);
            this.grpStatistic.Controls.Add(this.lblTotalAttempts);
            this.grpStatistic.Controls.Add(this.lblAverageScore);
            this.grpStatistic.Controls.Add(this.lblTotalQuestions);
            this.grpStatistic.Controls.Add(this.label11);
            this.grpStatistic.Controls.Add(this.label10);
            this.grpStatistic.Controls.Add(this.label9);
            this.grpStatistic.Controls.Add(this.label8);
            this.grpStatistic.Location = new System.Drawing.Point(865, 416);
            this.grpStatistic.Name = "grpStatistic";
            this.grpStatistic.Size = new System.Drawing.Size(250, 129);
            this.grpStatistic.TabIndex = 7;
            this.grpStatistic.TabStop = false;
            this.grpStatistic.Text = "THỐNG KÊ";
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Location = new System.Drawing.Point(198, 82);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(16, 16);
            this.lblTotalStudents.TabIndex = 7;
            this.lblTotalStudents.Text = "...";
            // 
            // lblTotalAttempts
            // 
            this.lblTotalAttempts.AutoSize = true;
            this.lblTotalAttempts.Location = new System.Drawing.Point(187, 31);
            this.lblTotalAttempts.Name = "lblTotalAttempts";
            this.lblTotalAttempts.Size = new System.Drawing.Size(16, 16);
            this.lblTotalAttempts.TabIndex = 6;
            this.lblTotalAttempts.Text = "...";
            // 
            // lblAverageScore
            // 
            this.lblAverageScore.AutoSize = true;
            this.lblAverageScore.Location = new System.Drawing.Point(74, 82);
            this.lblAverageScore.Name = "lblAverageScore";
            this.lblAverageScore.Size = new System.Drawing.Size(16, 16);
            this.lblAverageScore.TabIndex = 5;
            this.lblAverageScore.Text = "...";
            // 
            // lblTotalQuestions
            // 
            this.lblTotalQuestions.AutoSize = true;
            this.lblTotalQuestions.Location = new System.Drawing.Point(94, 32);
            this.lblTotalQuestions.Name = "lblTotalQuestions";
            this.lblTotalQuestions.Size = new System.Drawing.Size(16, 16);
            this.lblTotalQuestions.TabIndex = 4;
            this.lblTotalQuestions.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(130, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Sinh viên:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(130, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Lượt thi:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Điểm TB:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tổng câu hỏi:";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 727);
            this.Controls.Add(this.grpStatistic);
            this.Controls.Add(this.btnLoadResults);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.grpStatistic.ResumeLayout(false);
            this.grpStatistic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOptionD;
        private System.Windows.Forms.TextBox txtOptionC;
        private System.Windows.Forms.TextBox txtOptionB;
        private System.Windows.Forms.TextBox txtOptionA;
        private System.Windows.Forms.ComboBox cmbCorrect;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExam;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOptA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOptB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOptC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOptD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorrect;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnLoadResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedAt;
        private System.Windows.Forms.GroupBox grpStatistic;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblTotalAttempts;
        private System.Windows.Forms.Label lblAverageScore;
        private System.Windows.Forms.Label lblTotalQuestions;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}