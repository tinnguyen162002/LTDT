namespace LTDT_2._0
{
    partial class MainForm
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
            this.Toolpanel = new System.Windows.Forms.Panel();
            this.ThuatToangrpbox = new System.Windows.Forms.GroupBox();
            this.Dijkstrarbt = new System.Windows.Forms.RadioButton();
            this.Primrbt = new System.Windows.Forms.RadioButton();
            this.Toolgrpbox = new System.Windows.Forms.GroupBox();
            this.TaoDinhbtn = new System.Windows.Forms.Button();
            this.RunSpeed = new System.Windows.Forms.TrackBar();
            this.ChayThuatToanbtn = new System.Windows.Forms.Button();
            this.Newbtn = new System.Windows.Forms.Button();
            this.Movebtn = new System.Windows.Forms.Button();
            this.XemMaTranbtn = new System.Windows.Forms.Button();
            this.TaoDuongDibtn = new System.Windows.Forms.Button();
            this.Listviewpanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.runspeedlabel = new System.Windows.Forms.Label();
            this.Dijkstrapanelselect = new System.Windows.Forms.Panel();
            this.CancelDijbtn = new System.Windows.Forms.Button();
            this.Chaydijbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Dij2cbx = new System.Windows.Forms.ComboBox();
            this.Dij1cbx = new System.Windows.Forms.ComboBox();
            this.Result = new System.Windows.Forms.TextBox();
            this.MaTranLV = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Toolpanel.SuspendLayout();
            this.ThuatToangrpbox.SuspendLayout();
            this.Toolgrpbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunSpeed)).BeginInit();
            this.Listviewpanel.SuspendLayout();
            this.Dijkstrapanelselect.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toolpanel
            // 
            this.Toolpanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.Toolpanel.Controls.Add(this.ThuatToangrpbox);
            this.Toolpanel.Location = new System.Drawing.Point(24, 8);
            this.Toolpanel.Name = "Toolpanel";
            this.Toolpanel.Size = new System.Drawing.Size(183, 90);
            this.Toolpanel.TabIndex = 0;
            // 
            // ThuatToangrpbox
            // 
            this.ThuatToangrpbox.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ThuatToangrpbox.Controls.Add(this.Dijkstrarbt);
            this.ThuatToangrpbox.Controls.Add(this.Primrbt);
            this.ThuatToangrpbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThuatToangrpbox.Location = new System.Drawing.Point(6, 5);
            this.ThuatToangrpbox.Name = "ThuatToangrpbox";
            this.ThuatToangrpbox.Size = new System.Drawing.Size(171, 79);
            this.ThuatToangrpbox.TabIndex = 0;
            this.ThuatToangrpbox.TabStop = false;
            this.ThuatToangrpbox.Text = "Thuật toán";
            // 
            // Dijkstrarbt
            // 
            this.Dijkstrarbt.AutoSize = true;
            this.Dijkstrarbt.Location = new System.Drawing.Point(82, 34);
            this.Dijkstrarbt.Name = "Dijkstrarbt";
            this.Dijkstrarbt.Size = new System.Drawing.Size(80, 24);
            this.Dijkstrarbt.TabIndex = 2;
            this.Dijkstrarbt.Text = "Dijkstra";
            this.Dijkstrarbt.UseVisualStyleBackColor = true;
            this.Dijkstrarbt.CheckedChanged += new System.EventHandler(this.Dijkstrarbt_CheckedChanged);
            // 
            // Primrbt
            // 
            this.Primrbt.AutoSize = true;
            this.Primrbt.Checked = true;
            this.Primrbt.Location = new System.Drawing.Point(6, 34);
            this.Primrbt.Name = "Primrbt";
            this.Primrbt.Size = new System.Drawing.Size(58, 24);
            this.Primrbt.TabIndex = 1;
            this.Primrbt.TabStop = true;
            this.Primrbt.Text = "Prim";
            this.Primrbt.UseVisualStyleBackColor = true;
            this.Primrbt.CheckedChanged += new System.EventHandler(this.Primrbt_CheckedChanged);
            // 
            // Toolgrpbox
            // 
            this.Toolgrpbox.Controls.Add(this.TaoDinhbtn);
            this.Toolgrpbox.Controls.Add(this.RunSpeed);
            this.Toolgrpbox.Controls.Add(this.ChayThuatToanbtn);
            this.Toolgrpbox.Controls.Add(this.Newbtn);
            this.Toolgrpbox.Controls.Add(this.Movebtn);
            this.Toolgrpbox.Controls.Add(this.XemMaTranbtn);
            this.Toolgrpbox.Controls.Add(this.TaoDuongDibtn);
            this.Toolgrpbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Toolgrpbox.Location = new System.Drawing.Point(6, 8);
            this.Toolgrpbox.Name = "Toolgrpbox";
            this.Toolgrpbox.Size = new System.Drawing.Size(860, 85);
            this.Toolgrpbox.TabIndex = 1;
            this.Toolgrpbox.TabStop = false;
            this.Toolgrpbox.Text = "Chức năng";
            // 
            // TaoDinhbtn
            // 
            this.TaoDinhbtn.BackColor = System.Drawing.Color.White;
            this.TaoDinhbtn.FlatAppearance.BorderSize = 0;
            this.TaoDinhbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TaoDinhbtn.Image = global::LTDT_2._0.Properties.Resources.dinh2;
            this.TaoDinhbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TaoDinhbtn.Location = new System.Drawing.Point(6, 22);
            this.TaoDinhbtn.Name = "TaoDinhbtn";
            this.TaoDinhbtn.Size = new System.Drawing.Size(98, 50);
            this.TaoDinhbtn.TabIndex = 3;
            this.TaoDinhbtn.Text = "Tạo đỉnh";
            this.TaoDinhbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TaoDinhbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TaoDinhbtn.UseVisualStyleBackColor = false;
            this.TaoDinhbtn.Click += new System.EventHandler(this.TaoDinhbtn_Click);
            // 
            // RunSpeed
            // 
            this.RunSpeed.LargeChange = 100;
            this.RunSpeed.Location = new System.Drawing.Point(734, 22);
            this.RunSpeed.Maximum = 3000;
            this.RunSpeed.Minimum = 100;
            this.RunSpeed.Name = "RunSpeed";
            this.RunSpeed.Size = new System.Drawing.Size(119, 45);
            this.RunSpeed.SmallChange = 100;
            this.RunSpeed.TabIndex = 9;
            this.RunSpeed.TabStop = false;
            this.RunSpeed.TickFrequency = 20;
            this.RunSpeed.Value = 100;
            this.RunSpeed.Scroll += new System.EventHandler(this.RunSpeed_Scroll);
            // 
            // ChayThuatToanbtn
            // 
            this.ChayThuatToanbtn.BackColor = System.Drawing.Color.White;
            this.ChayThuatToanbtn.FlatAppearance.BorderSize = 0;
            this.ChayThuatToanbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChayThuatToanbtn.Image = global::LTDT_2._0.Properties.Resources.chay;
            this.ChayThuatToanbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChayThuatToanbtn.Location = new System.Drawing.Point(374, 22);
            this.ChayThuatToanbtn.Name = "ChayThuatToanbtn";
            this.ChayThuatToanbtn.Size = new System.Drawing.Size(116, 50);
            this.ChayThuatToanbtn.TabIndex = 6;
            this.ChayThuatToanbtn.Text = "Chạy thuật toán";
            this.ChayThuatToanbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChayThuatToanbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChayThuatToanbtn.UseVisualStyleBackColor = false;
            this.ChayThuatToanbtn.Click += new System.EventHandler(this.ChayThuatToanbtn_Click);
            // 
            // Newbtn
            // 
            this.Newbtn.BackColor = System.Drawing.Color.White;
            this.Newbtn.FlatAppearance.BorderSize = 0;
            this.Newbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Newbtn.Image = global::LTDT_2._0.Properties.Resources.khoidong;
            this.Newbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Newbtn.Location = new System.Drawing.Point(496, 22);
            this.Newbtn.Name = "Newbtn";
            this.Newbtn.Size = new System.Drawing.Size(98, 50);
            this.Newbtn.TabIndex = 7;
            this.Newbtn.Text = "Làm mới";
            this.Newbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Newbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Newbtn.UseVisualStyleBackColor = false;
            this.Newbtn.Click += new System.EventHandler(this.Newbtn_Click);
            // 
            // Movebtn
            // 
            this.Movebtn.BackColor = System.Drawing.Color.White;
            this.Movebtn.FlatAppearance.BorderSize = 0;
            this.Movebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Movebtn.Image = global::LTDT_2._0.Properties.Resources.dichuyen;
            this.Movebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Movebtn.Location = new System.Drawing.Point(600, 22);
            this.Movebtn.Name = "Movebtn";
            this.Movebtn.Size = new System.Drawing.Size(128, 50);
            this.Movebtn.TabIndex = 8;
            this.Movebtn.Text = "Di chuyển đỉnh";
            this.Movebtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Movebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Movebtn.UseVisualStyleBackColor = false;
            this.Movebtn.Click += new System.EventHandler(this.Movebtn_Click);
            // 
            // XemMaTranbtn
            // 
            this.XemMaTranbtn.BackColor = System.Drawing.Color.White;
            this.XemMaTranbtn.FlatAppearance.BorderSize = 0;
            this.XemMaTranbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XemMaTranbtn.Image = global::LTDT_2._0.Properties.Resources.xem;
            this.XemMaTranbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.XemMaTranbtn.Location = new System.Drawing.Point(245, 22);
            this.XemMaTranbtn.Name = "XemMaTranbtn";
            this.XemMaTranbtn.Size = new System.Drawing.Size(122, 50);
            this.XemMaTranbtn.TabIndex = 5;
            this.XemMaTranbtn.Text = "Xem ma trận";
            this.XemMaTranbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.XemMaTranbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.XemMaTranbtn.UseVisualStyleBackColor = false;
            this.XemMaTranbtn.Click += new System.EventHandler(this.XemMaTranbtn_Click);
            // 
            // TaoDuongDibtn
            // 
            this.TaoDuongDibtn.BackColor = System.Drawing.Color.White;
            this.TaoDuongDibtn.FlatAppearance.BorderSize = 0;
            this.TaoDuongDibtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TaoDuongDibtn.Image = global::LTDT_2._0.Properties.Resources.đường_đi;
            this.TaoDuongDibtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TaoDuongDibtn.Location = new System.Drawing.Point(110, 22);
            this.TaoDuongDibtn.Name = "TaoDuongDibtn";
            this.TaoDuongDibtn.Size = new System.Drawing.Size(130, 50);
            this.TaoDuongDibtn.TabIndex = 4;
            this.TaoDuongDibtn.Text = "Tạo đường đi";
            this.TaoDuongDibtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TaoDuongDibtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TaoDuongDibtn.UseVisualStyleBackColor = false;
            this.TaoDuongDibtn.Click += new System.EventHandler(this.TaoDuongDibtn_Click);
            // 
            // Listviewpanel
            // 
            this.Listviewpanel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Listviewpanel.Controls.Add(this.label4);
            this.Listviewpanel.Controls.Add(this.runspeedlabel);
            this.Listviewpanel.Controls.Add(this.Toolpanel);
            this.Listviewpanel.Controls.Add(this.Dijkstrapanelselect);
            this.Listviewpanel.Controls.Add(this.Result);
            this.Listviewpanel.Controls.Add(this.MaTranLV);
            this.Listviewpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Listviewpanel.Location = new System.Drawing.Point(0, 0);
            this.Listviewpanel.Name = "Listviewpanel";
            this.Listviewpanel.Size = new System.Drawing.Size(227, 594);
            this.Listviewpanel.TabIndex = 1;
            this.Listviewpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Listviewpanel_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tốc độ chạy của thuật toán";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // runspeedlabel
            // 
            this.runspeedlabel.AutoSize = true;
            this.runspeedlabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.runspeedlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runspeedlabel.Location = new System.Drawing.Point(67, 131);
            this.runspeedlabel.Name = "runspeedlabel";
            this.runspeedlabel.Size = new System.Drawing.Size(82, 16);
            this.runspeedlabel.TabIndex = 20;
            this.runspeedlabel.Text = "Tốc độ chạy";
            this.runspeedlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.runspeedlabel.Click += new System.EventHandler(this.runspeedlabel_Click);
            // 
            // Dijkstrapanelselect
            // 
            this.Dijkstrapanelselect.BackColor = System.Drawing.Color.PowderBlue;
            this.Dijkstrapanelselect.Controls.Add(this.CancelDijbtn);
            this.Dijkstrapanelselect.Controls.Add(this.Chaydijbtn);
            this.Dijkstrapanelselect.Controls.Add(this.label3);
            this.Dijkstrapanelselect.Controls.Add(this.label2);
            this.Dijkstrapanelselect.Controls.Add(this.label1);
            this.Dijkstrapanelselect.Controls.Add(this.Dij2cbx);
            this.Dijkstrapanelselect.Controls.Add(this.Dij1cbx);
            this.Dijkstrapanelselect.Location = new System.Drawing.Point(12, 328);
            this.Dijkstrapanelselect.Name = "Dijkstrapanelselect";
            this.Dijkstrapanelselect.Size = new System.Drawing.Size(204, 108);
            this.Dijkstrapanelselect.TabIndex = 3;
            this.Dijkstrapanelselect.Visible = false;
            this.Dijkstrapanelselect.Paint += new System.Windows.Forms.PaintEventHandler(this.Dijkstrapanelselect_Paint);
            // 
            // CancelDijbtn
            // 
            this.CancelDijbtn.Location = new System.Drawing.Point(111, 75);
            this.CancelDijbtn.Name = "CancelDijbtn";
            this.CancelDijbtn.Size = new System.Drawing.Size(63, 27);
            this.CancelDijbtn.TabIndex = 14;
            this.CancelDijbtn.Text = "Huỷ";
            this.CancelDijbtn.UseVisualStyleBackColor = true;
            this.CancelDijbtn.Click += new System.EventHandler(this.CancelDijbtn_Click);
            // 
            // Chaydijbtn
            // 
            this.Chaydijbtn.Location = new System.Drawing.Point(18, 75);
            this.Chaydijbtn.Name = "Chaydijbtn";
            this.Chaydijbtn.Size = new System.Drawing.Size(63, 27);
            this.Chaydijbtn.TabIndex = 13;
            this.Chaydijbtn.Text = "Chạy";
            this.Chaydijbtn.UseVisualStyleBackColor = true;
            this.Chaydijbtn.Click += new System.EventHandler(this.Chaydijbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dijkstra";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Dij2cbx
            // 
            this.Dij2cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dij2cbx.FormattingEnabled = true;
            this.Dij2cbx.Location = new System.Drawing.Point(120, 41);
            this.Dij2cbx.Name = "Dij2cbx";
            this.Dij2cbx.Size = new System.Drawing.Size(40, 21);
            this.Dij2cbx.TabIndex = 12;
            this.Dij2cbx.SelectedIndexChanged += new System.EventHandler(this.Dij2cbx_SelectedIndexChanged);
            // 
            // Dij1cbx
            // 
            this.Dij1cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dij1cbx.FormattingEnabled = true;
            this.Dij1cbx.Location = new System.Drawing.Point(38, 41);
            this.Dij1cbx.Name = "Dij1cbx";
            this.Dij1cbx.Size = new System.Drawing.Size(40, 21);
            this.Dij1cbx.TabIndex = 11;
            this.Dij1cbx.SelectedIndexChanged += new System.EventHandler(this.Dij1cbx_SelectedIndexChanged);
            // 
            // Result
            // 
            this.Result.AllowDrop = true;
            this.Result.BackColor = System.Drawing.Color.FloralWhite;
            this.Result.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(0, 484);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Result.Size = new System.Drawing.Size(227, 110);
            this.Result.TabIndex = 15;
            this.Result.TabStop = false;
            this.Result.TextChanged += new System.EventHandler(this.Result_TextChanged);
            // 
            // MaTranLV
            // 
            this.MaTranLV.BackColor = System.Drawing.Color.White;
            this.MaTranLV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MaTranLV.GridLines = true;
            this.MaTranLV.HideSelection = false;
            this.MaTranLV.Location = new System.Drawing.Point(12, 172);
            this.MaTranLV.Name = "MaTranLV";
            this.MaTranLV.Size = new System.Drawing.Size(205, 128);
            this.MaTranLV.TabIndex = 0;
            this.MaTranLV.TabStop = false;
            this.MaTranLV.UseCompatibleStateImageBehavior = false;
            this.MaTranLV.View = System.Windows.Forms.View.Details;
            this.MaTranLV.Visible = false;
            this.MaTranLV.SelectedIndexChanged += new System.EventHandler(this.MaTranLV_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.Toolgrpbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(227, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 102);
            this.panel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1107, 594);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Listviewpanel);
            this.Name = "MainForm";
            this.Text = "CTQM";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.Toolpanel.ResumeLayout(false);
            this.ThuatToangrpbox.ResumeLayout(false);
            this.ThuatToangrpbox.PerformLayout();
            this.Toolgrpbox.ResumeLayout(false);
            this.Toolgrpbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunSpeed)).EndInit();
            this.Listviewpanel.ResumeLayout(false);
            this.Listviewpanel.PerformLayout();
            this.Dijkstrapanelselect.ResumeLayout(false);
            this.Dijkstrapanelselect.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Toolpanel;
        private System.Windows.Forms.GroupBox ThuatToangrpbox;
        private System.Windows.Forms.GroupBox Toolgrpbox;
        private System.Windows.Forms.RadioButton Dijkstrarbt;
        private System.Windows.Forms.RadioButton Primrbt;
        private System.Windows.Forms.Button TaoDinhbtn;
        private System.Windows.Forms.Button TaoDuongDibtn;
        private System.Windows.Forms.Button XemMaTranbtn;
        private System.Windows.Forms.Button ChayThuatToanbtn;
        private System.Windows.Forms.Panel Listviewpanel;
        private System.Windows.Forms.ListView MaTranLV;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Panel Dijkstrapanelselect;
        private System.Windows.Forms.Button CancelDijbtn;
        private System.Windows.Forms.Button Chaydijbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Dij2cbx;
        private System.Windows.Forms.ComboBox Dij1cbx;
        private System.Windows.Forms.TrackBar RunSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Newbtn;
        private System.Windows.Forms.Button Movebtn;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label runspeedlabel;
    }
}

