namespace Mouse_Macro
{
    partial class TimePicker
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
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_end = new System.Windows.Forms.Button();
            this.Btn_start = new System.Windows.Forms.Button();
            this.Btn_order = new System.Windows.Forms.Button();
            this.Btn_edit = new System.Windows.Forms.Button();
            this.Btn_del = new System.Windows.Forms.Button();
            this.Btn_add = new System.Windows.Forms.Button();
            this.Textbox_entertime = new System.Windows.Forms.MaskedTextBox();
            this.Textbox_filename = new System.Windows.Forms.MaskedTextBox();
            this.DP = new System.Windows.Forms.DateTimePicker();
            this.Label_enter = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Label_filename = new System.Windows.Forms.Label();
            this.Label_date = new System.Windows.Forms.Label();
            this.TP = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "마우스 매크로 동작 여부";
            // 
            // Btn_end
            // 
            this.Btn_end.Location = new System.Drawing.Point(500, 135);
            this.Btn_end.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_end.Name = "Btn_end";
            this.Btn_end.Size = new System.Drawing.Size(59, 21);
            this.Btn_end.TabIndex = 30;
            this.Btn_end.Text = "종료";
            this.Btn_end.UseVisualStyleBackColor = true;
            this.Btn_end.Click += new System.EventHandler(this.Btn_end_Click);
            // 
            // Btn_start
            // 
            this.Btn_start.Location = new System.Drawing.Point(500, 103);
            this.Btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_start.Name = "Btn_start";
            this.Btn_start.Size = new System.Drawing.Size(59, 21);
            this.Btn_start.TabIndex = 29;
            this.Btn_start.Text = "시작";
            this.Btn_start.UseVisualStyleBackColor = true;
            this.Btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // Btn_order
            // 
            this.Btn_order.Location = new System.Drawing.Point(436, 71);
            this.Btn_order.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_order.Name = "Btn_order";
            this.Btn_order.Size = new System.Drawing.Size(59, 21);
            this.Btn_order.TabIndex = 28;
            this.Btn_order.Text = "재정렬";
            this.Btn_order.UseVisualStyleBackColor = true;
            this.Btn_order.Click += new System.EventHandler(this.Btn_order_Click);
            // 
            // Btn_edit
            // 
            this.Btn_edit.Location = new System.Drawing.Point(373, 70);
            this.Btn_edit.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_edit.Name = "Btn_edit";
            this.Btn_edit.Size = new System.Drawing.Size(59, 21);
            this.Btn_edit.TabIndex = 27;
            this.Btn_edit.Text = "수정";
            this.Btn_edit.UseVisualStyleBackColor = true;
            this.Btn_edit.Click += new System.EventHandler(this.Btn_edit_Click);
            // 
            // Btn_del
            // 
            this.Btn_del.Location = new System.Drawing.Point(310, 71);
            this.Btn_del.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_del.Name = "Btn_del";
            this.Btn_del.Size = new System.Drawing.Size(59, 21);
            this.Btn_del.TabIndex = 26;
            this.Btn_del.Text = "삭제";
            this.Btn_del.UseVisualStyleBackColor = true;
            this.Btn_del.Click += new System.EventHandler(this.Btn_del_Click);
            // 
            // Btn_add
            // 
            this.Btn_add.Location = new System.Drawing.Point(247, 71);
            this.Btn_add.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_add.Name = "Btn_add";
            this.Btn_add.Size = new System.Drawing.Size(59, 21);
            this.Btn_add.TabIndex = 25;
            this.Btn_add.Text = "추가";
            this.Btn_add.UseVisualStyleBackColor = true;
            this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // Textbox_entertime
            // 
            this.Textbox_entertime.Location = new System.Drawing.Point(578, 71);
            this.Textbox_entertime.Margin = new System.Windows.Forms.Padding(2);
            this.Textbox_entertime.Name = "Textbox_entertime";
            this.Textbox_entertime.Size = new System.Drawing.Size(45, 21);
            this.Textbox_entertime.TabIndex = 24;
            // 
            // Textbox_filename
            // 
            this.Textbox_filename.Location = new System.Drawing.Point(62, 71);
            this.Textbox_filename.Margin = new System.Windows.Forms.Padding(2);
            this.Textbox_filename.Name = "Textbox_filename";
            this.Textbox_filename.Size = new System.Drawing.Size(181, 21);
            this.Textbox_filename.TabIndex = 23;
            this.Textbox_filename.Click += new System.EventHandler(this.Textbox_filename_Click);
            // 
            // DP
            // 
            this.DP.CustomFormat = "yyyy-MM-dd";
            this.DP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DP.Location = new System.Drawing.Point(61, 46);
            this.DP.Margin = new System.Windows.Forms.Padding(2);
            this.DP.Name = "DP";
            this.DP.Size = new System.Drawing.Size(105, 21);
            this.DP.TabIndex = 21;
            // 
            // Label_enter
            // 
            this.Label_enter.AutoSize = true;
            this.Label_enter.Location = new System.Drawing.Point(499, 75);
            this.Label_enter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_enter.Name = "Label_enter";
            this.Label_enter.Size = new System.Drawing.Size(75, 12);
            this.Label_enter.TabIndex = 20;
            this.Label_enter.Text = "입력시간(분)";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(16, 97);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.Size = new System.Drawing.Size(479, 223);
            this.dataGridView.TabIndex = 19;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // Label_filename
            // 
            this.Label_filename.AutoSize = true;
            this.Label_filename.Location = new System.Drawing.Point(14, 75);
            this.Label_filename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_filename.Name = "Label_filename";
            this.Label_filename.Size = new System.Drawing.Size(41, 12);
            this.Label_filename.TabIndex = 18;
            this.Label_filename.Text = "파일명";
            // 
            // Label_date
            // 
            this.Label_date.AutoSize = true;
            this.Label_date.BackColor = System.Drawing.SystemColors.Control;
            this.Label_date.Location = new System.Drawing.Point(26, 50);
            this.Label_date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_date.Name = "Label_date";
            this.Label_date.Size = new System.Drawing.Size(29, 12);
            this.Label_date.TabIndex = 16;
            this.Label_date.Text = "날짜";
            // 
            // TP
            // 
            this.TP.CustomFormat = "HH:mm";
            this.TP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TP.Location = new System.Drawing.Point(170, 46);
            this.TP.Margin = new System.Windows.Forms.Padding(2);
            this.TP.Name = "TP";
            this.TP.Size = new System.Drawing.Size(73, 21);
            this.TP.TabIndex = 32;
            // 
            // TimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 330);
            this.Controls.Add(this.TP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_end);
            this.Controls.Add(this.Btn_start);
            this.Controls.Add(this.Btn_order);
            this.Controls.Add(this.Btn_edit);
            this.Controls.Add(this.Btn_del);
            this.Controls.Add(this.Btn_add);
            this.Controls.Add(this.Textbox_entertime);
            this.Controls.Add(this.Textbox_filename);
            this.Controls.Add(this.DP);
            this.Controls.Add(this.Label_enter);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Label_filename);
            this.Controls.Add(this.Label_date);
            this.Name = "TimePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_end;
        private System.Windows.Forms.Button Btn_start;
        private System.Windows.Forms.Button Btn_order;
        private System.Windows.Forms.Button Btn_edit;
        private System.Windows.Forms.Button Btn_del;
        private System.Windows.Forms.Button Btn_add;
        private System.Windows.Forms.MaskedTextBox Textbox_entertime;
        private System.Windows.Forms.MaskedTextBox Textbox_filename;
        private System.Windows.Forms.DateTimePicker DP;
        private System.Windows.Forms.Label Label_enter;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label Label_filename;
        private System.Windows.Forms.Label Label_date;
        private System.Windows.Forms.DateTimePicker TP;
    }
}