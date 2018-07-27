namespace PostingGroupVK
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.btnSnd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srchBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.albumID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.membersCnt = new System.Windows.Forms.NumericUpDown();
            this.msgWall = new System.Windows.Forms.TextBox();
            this.authorizeBox = new System.Windows.Forms.GroupBox();
            this.authPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersCnt)).BeginInit();
            this.authorizeBox.SuspendLayout();
            this.authPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ЛОГИН";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(521, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ПАРОЛЬ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(408, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(579, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(695, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSrch
            // 
            this.txtSrch.Location = new System.Drawing.Point(183, 22);
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.Size = new System.Drawing.Size(804, 20);
            this.txtSrch.TabIndex = 1;
            // 
            // btnSnd
            // 
            this.btnSnd.Location = new System.Drawing.Point(774, 397);
            this.btnSnd.Name = "btnSnd";
            this.btnSnd.Size = new System.Drawing.Size(312, 23);
            this.btnSnd.TabIndex = 3;
            this.btnSnd.Text = "Sending";
            this.btnSnd.UseVisualStyleBackColor = true;
            this.btnSnd.Click += new System.EventHandler(this.btnSnd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1074, 285);
            this.dataGridView1.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // srchBtn
            // 
            this.srchBtn.Location = new System.Drawing.Point(993, 22);
            this.srchBtn.Name = "srchBtn";
            this.srchBtn.Size = new System.Drawing.Size(75, 20);
            this.srchBtn.TabIndex = 3;
            this.srchBtn.Text = "Поиск";
            this.srchBtn.UseVisualStyleBackColor = true;
            this.srchBtn.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(848, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ALBUM";
            // 
            // albumID
            // 
            this.albumID.Location = new System.Drawing.Point(899, 371);
            this.albumID.Name = "albumID";
            this.albumID.Size = new System.Drawing.Size(100, 20);
            this.albumID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Участн.";
            // 
            // membersCnt
            // 
            this.membersCnt.Location = new System.Drawing.Point(68, 22);
            this.membersCnt.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.membersCnt.Name = "membersCnt";
            this.membersCnt.Size = new System.Drawing.Size(99, 20);
            this.membersCnt.TabIndex = 5;
            // 
            // msgWall
            // 
            this.msgWall.Location = new System.Drawing.Point(12, 368);
            this.msgWall.Multiline = true;
            this.msgWall.Name = "msgWall";
            this.msgWall.Size = new System.Drawing.Size(751, 49);
            this.msgWall.TabIndex = 6;
            // 
            // authorizeBox
            // 
            this.authorizeBox.Controls.Add(this.authPanel);
            this.authorizeBox.Controls.Add(this.txtSrch);
            this.authorizeBox.Controls.Add(this.label5);
            this.authorizeBox.Controls.Add(this.membersCnt);
            this.authorizeBox.Controls.Add(this.srchBtn);
            this.authorizeBox.Location = new System.Drawing.Point(12, 12);
            this.authorizeBox.Name = "authorizeBox";
            this.authorizeBox.Size = new System.Drawing.Size(1074, 58);
            this.authorizeBox.TabIndex = 7;
            this.authorizeBox.TabStop = false;
            this.authorizeBox.Text = "Не авторизован";
            // 
            // authPanel
            // 
            this.authPanel.Controls.Add(this.button1);
            this.authPanel.Controls.Add(this.label1);
            this.authPanel.Controls.Add(this.label2);
            this.authPanel.Controls.Add(this.textBox1);
            this.authPanel.Controls.Add(this.textBox2);
            this.authPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authPanel.Location = new System.Drawing.Point(3, 16);
            this.authPanel.Name = "authPanel";
            this.authPanel.Size = new System.Drawing.Size(1068, 39);
            this.authPanel.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 432);
            this.Controls.Add(this.authorizeBox);
            this.Controls.Add(this.msgWall);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSnd);
            this.Controls.Add(this.albumID);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersCnt)).EndInit();
            this.authorizeBox.ResumeLayout(false);
            this.authorizeBox.PerformLayout();
            this.authPanel.ResumeLayout(false);
            this.authPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSrch;
        private System.Windows.Forms.Button btnSnd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button srchBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox albumID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown membersCnt;
        private System.Windows.Forms.TextBox msgWall;
        private System.Windows.Forms.GroupBox authorizeBox;
        private System.Windows.Forms.Panel authPanel;
    }
}

