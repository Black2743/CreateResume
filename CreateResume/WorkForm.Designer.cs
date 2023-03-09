namespace CreateResume
{
    partial class WorkForm
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
            this.labelWorkPosition = new System.Windows.Forms.Label();
            this.textBoxWorkPosition = new System.Windows.Forms.TextBox();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.labelCompanyLocation = new System.Windows.Forms.Label();
            this.labelCompanyExpiriense = new System.Windows.Forms.Label();
            this.labelWorkTime = new System.Windows.Forms.Label();
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.textBoxCompanyLocation = new System.Windows.Forms.TextBox();
            this.textBoxCompanyExpiriense = new System.Windows.Forms.TextBox();
            this.dateTimePickerWorkEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerWorkStar = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonWorkContinue = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWorkPosition
            // 
            this.labelWorkPosition.AutoSize = true;
            this.labelWorkPosition.Location = new System.Drawing.Point(3, 0);
            this.labelWorkPosition.Name = "labelWorkPosition";
            this.labelWorkPosition.Padding = new System.Windows.Forms.Padding(5);
            this.labelWorkPosition.Size = new System.Drawing.Size(96, 30);
            this.labelWorkPosition.TabIndex = 0;
            this.labelWorkPosition.Text = "Должность";
            // 
            // textBoxWorkPosition
            // 
            this.textBoxWorkPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxWorkPosition.Location = new System.Drawing.Point(232, 3);
            this.textBoxWorkPosition.Name = "textBoxWorkPosition";
            this.textBoxWorkPosition.Size = new System.Drawing.Size(565, 27);
            this.textBoxWorkPosition.TabIndex = 1;
            this.textBoxWorkPosition.Text = " ";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.AutoSize = true;
            this.labelCompanyName.Location = new System.Drawing.Point(3, 33);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Padding = new System.Windows.Forms.Padding(5);
            this.labelCompanyName.Size = new System.Drawing.Size(162, 30);
            this.labelCompanyName.TabIndex = 2;
            this.labelCompanyName.Text = "Название компании";
            // 
            // labelCompanyLocation
            // 
            this.labelCompanyLocation.AutoSize = true;
            this.labelCompanyLocation.Location = new System.Drawing.Point(3, 66);
            this.labelCompanyLocation.Name = "labelCompanyLocation";
            this.labelCompanyLocation.Padding = new System.Windows.Forms.Padding(5);
            this.labelCompanyLocation.Size = new System.Drawing.Size(223, 30);
            this.labelCompanyLocation.TabIndex = 3;
            this.labelCompanyLocation.Text = "Местонахождение компании";
            // 
            // labelCompanyExpiriense
            // 
            this.labelCompanyExpiriense.AutoSize = true;
            this.labelCompanyExpiriense.Location = new System.Drawing.Point(3, 99);
            this.labelCompanyExpiriense.Name = "labelCompanyExpiriense";
            this.labelCompanyExpiriense.Padding = new System.Windows.Forms.Padding(5);
            this.labelCompanyExpiriense.Size = new System.Drawing.Size(139, 30);
            this.labelCompanyExpiriense.TabIndex = 4;
            this.labelCompanyExpiriense.Text = "Опыт, что делали";
            // 
            // labelWorkTime
            // 
            this.labelWorkTime.AutoSize = true;
            this.labelWorkTime.Location = new System.Drawing.Point(3, 236);
            this.labelWorkTime.Name = "labelWorkTime";
            this.labelWorkTime.Padding = new System.Windows.Forms.Padding(5);
            this.labelWorkTime.Size = new System.Drawing.Size(109, 30);
            this.labelWorkTime.TabIndex = 5;
            this.labelWorkTime.Text = "Срок работы";
            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCompanyName.Location = new System.Drawing.Point(232, 36);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(565, 27);
            this.textBoxCompanyName.TabIndex = 6;
            this.textBoxCompanyName.Text = " ";
            // 
            // textBoxCompanyLocation
            // 
            this.textBoxCompanyLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCompanyLocation.Location = new System.Drawing.Point(232, 69);
            this.textBoxCompanyLocation.Name = "textBoxCompanyLocation";
            this.textBoxCompanyLocation.Size = new System.Drawing.Size(565, 27);
            this.textBoxCompanyLocation.TabIndex = 7;
            this.textBoxCompanyLocation.Text = " ";
            // 
            // textBoxCompanyExpiriense
            // 
            this.textBoxCompanyExpiriense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCompanyExpiriense.Location = new System.Drawing.Point(232, 102);
            this.textBoxCompanyExpiriense.Multiline = true;
            this.textBoxCompanyExpiriense.Name = "textBoxCompanyExpiriense";
            this.textBoxCompanyExpiriense.Size = new System.Drawing.Size(565, 131);
            this.textBoxCompanyExpiriense.TabIndex = 8;
            this.textBoxCompanyExpiriense.Text = " ";
            // 
            // dateTimePickerWorkEnd
            // 
            this.dateTimePickerWorkEnd.CustomFormat = "yyyy/MM";
            this.dateTimePickerWorkEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWorkEnd.Location = new System.Drawing.Point(340, 239);
            this.dateTimePickerWorkEnd.Name = "dateTimePickerWorkEnd";
            this.dateTimePickerWorkEnd.Size = new System.Drawing.Size(91, 27);
            this.dateTimePickerWorkEnd.TabIndex = 9;
            // 
            // dateTimePickerWorkStar
            // 
            this.dateTimePickerWorkStar.CustomFormat = "yyyy/MM";
            this.dateTimePickerWorkStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWorkStar.Location = new System.Drawing.Point(232, 239);
            this.dateTimePickerWorkStar.Name = "dateTimePickerWorkStar";
            this.dateTimePickerWorkStar.Size = new System.Drawing.Size(91, 27);
            this.dateTimePickerWorkStar.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerWorkStar, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCompanyExpiriense, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelWorkPosition, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCompanyLocation, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCompanyName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCompanyName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelCompanyLocation, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxWorkPosition, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCompanyExpiriense, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelWorkTime, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonWorkContinue, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 357);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // buttonWorkContinue
            // 
            this.buttonWorkContinue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonWorkContinue.Location = new System.Drawing.Point(232, 272);
            this.buttonWorkContinue.Name = "buttonWorkContinue";
            this.buttonWorkContinue.Size = new System.Drawing.Size(565, 82);
            this.buttonWorkContinue.TabIndex = 11;
            this.buttonWorkContinue.Text = "Продолжить";
            this.buttonWorkContinue.UseVisualStyleBackColor = true;
            this.buttonWorkContinue.Click += new System.EventHandler(this.button1_Click);
            // 
            // WorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 357);
            this.Controls.Add(this.dateTimePickerWorkEnd);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WorkForm";
            this.Text = "Работа";
            this.Load += new System.EventHandler(this.WorkForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label labelWorkPosition;
        private TextBox textBoxWorkPosition;
        private Label labelCompanyName;
        private Label labelCompanyLocation;
        private Label labelCompanyExpiriense;
        private Label labelWorkTime;
        private TextBox textBoxCompanyName;
        private TextBox textBoxCompanyLocation;
        private TextBox textBoxCompanyExpiriense;
        private DateTimePicker dateTimePickerWorkEnd;
        private DateTimePicker dateTimePickerWorkStar;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonWorkContinue;
    }
}