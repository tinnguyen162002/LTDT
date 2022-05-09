using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTDT_2._0
{
    public partial class MainForm : Form
    {
        public static MainForm instance;
        public Label lb1;
        public Label lb2;
        public int number;
        public bool CheckTaobtn;

        Pen pen; Point cur;       // tạo bút và hình ảnh để vẻ

        // Các đỉnh và ma trận
        int SoDinh = 0;                          // lưu lại số đỉnh
        Point[] vtDinh = new Point[100];         // lưu lại vị trí của 100 cái đỉnh
        Label[] lblDinh = new Label[100];        // tạo 100 cái label để lưu trữ 100 cái đỉnh
        int[,] MaTran = new int[100, 100];       // tạo ma trận để lưu trữ các dữ liệu

        // Đường đi
        int SoDuongDi = 0;                       // lưu trữ số đường đi đã tạo
        int[,] DuongDi = new int[2, 200];        // tạo 200 đường đi lưu trữ các dường đi
        Point[,] vtDuongDi = new Point[2, 100];
        int[] TrongSo = new int[100];
        Point[] vtTrongSo = new Point[100];
        Label[] lblTrongSo = new Label[100];
        int A = new int();                       // Đi từ A ------> B
        int B = new int();
        bool TaoDinh = false;                       // Button tạo đỉnh
        bool TaoDuongDi = false;                    // Button tạo đường đi
        bool ChonDuongDi = false;
        Point ConChuotXY;
        bool XemMaTran = false;                     // Button xem ma trận
        bool ChayThuatToan = false;                 // Button chạy thuật toán
        bool DiChuyenDinh = false;                  // Button di chuyển các đỉnh
        bool Moving = false;
        int dinh = new int();
        const int MAX = 100;
        const int Vc = -1;

        public MainForm()
        {
            InitializeComponent();
            instance = this;
            pen = new Pen(Color.Black, 3);
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Graphics Hinh = this.CreateGraphics();
            // vẽ vòng tròn
            for (int i = 0; i < SoDinh; i++)
            {
                Hinh.DrawEllipse(pen, vtDinh[i].X, vtDinh[i].Y, 40, 40);    // khắc phục lỗi bị mất hình
            }
            // vẽ đường đi
            if (Primrbt.Checked == true)        // vô hướng
            {
                pen = new Pen(Color.Black, 4);
                for (int i = 0; i < SoDuongDi; i++)
                {
                    /*
                    Point p1 = new Point(lblDinh[DuongDi[0, i]].Left + lblDinh[DuongDi[0, i]].Width / 2,
                                         lblDinh[DuongDi[0, i]].Top  + lblDinh[DuongDi[0, i]].Height / 2);
                    Point p2 = new Point(lblDinh[DuongDi[1, i]].Left + lblDinh[DuongDi[1, i]].Width / 2,
                                         lblDinh[DuongDi[1, i]].Top  + lblDinh[DuongDi[1, i]].Height / 2);
                    */
                    Hinh.DrawLine(pen, vtDuongDi[0, i], vtDuongDi[1, i]);
                    //Hinh.DrawLine(pen, p1, p2);
                }
            }

            if (Dijkstrarbt.Checked == true)        // có hướng
            {
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 7);     // chỉnh bút vẽ lại thành dấu mủi tên
                pen.CustomEndCap = bigArrow;
                for (int i = 0; i < SoDuongDi; i++)
                {
                    /*
                    Point p1 = new Point(lblDinh[DuongDi[0, i]].Left + lblDinh[DuongDi[0, i]].Width / 2,
                                         lblDinh[DuongDi[0, i]].Top  + lblDinh[DuongDi[0, i]].Height / 2);
                    Point p2 = new Point(lblDinh[DuongDi[1, i]].Left + lblDinh[DuongDi[1, i]].Width / 2,
                                         lblDinh[DuongDi[1, i]].Top  + lblDinh[DuongDi[1, i]].Height / 2);*/
                    Hinh.DrawLine(pen, vtDuongDi[0, i], vtDuongDi[1, i]);
                    //Hinh.DrawLine(pen, p1, p2);
                }
            }
            // tải ma trận
            MatranLoad();
            if (TaoDuongDi == false && DiChuyenDinh == false) TatLabel();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            MainForm_Load(sender, e);
            Graphics Hinh = this.CreateGraphics();
            if (TaoDinh == true)     // thực hiện chức năng tạo đỉnh
            {
                Result.Text = "Click chuột để tạo đỉnh\r\n";
                // vẽ hình tròn
                cur = e.Location;
                //cur = this.PointToClient(Cursor.Position);      // lấy vị trí của con trỏ chuột dựa trên bảng chạy
                Hinh.DrawEllipse(pen, cur.X, cur.Y, 40, 40);    // tạo hình tròn tại vị trí con trỏ
                vtDinh[SoDinh] = new Point(cur.X, cur.Y);     // lưu lại để có thể update lại

                // tạo đỉnh
                Label tmp = new Label();                        // Tạo label tạm thời
                tmp.Location = new Point(cur.X + 7, cur.Y + 7); // tạo vị trí dựa vào con trỏ chuột
                tmp.Text = SoDinh.ToString();                   // thứ tự các đỉnh
                tmp.BackColor = Color.Transparent;              // Tạo hiện ứng nền để không bị đè lẫn nhau
                tmp.Size = new Size(20, 20);
                tmp.Click += new EventHandler(this.labelClick);
                lblDinh[SoDinh++] = tmp;
                this.Controls.Add(tmp);
                MaTranListViewLoad();
            }
            if (Moving == true)
            {
                Moving = false;
                ConChuotXY = e.Location;
                Result.Text = "Di chuyển xong";
                lblDinh[dinh].Location = new Point(ConChuotXY.X + 7, ConChuotXY.Y + 7);
                vtDinh[dinh] = new Point(ConChuotXY.X, ConChuotXY.Y);
                if (Primrbt.Checked == true)
                {
                    pen = new Pen(Color.Black, 3); 
                    int tbcwidthform = (this.Width / 2) + (Listviewpanel.Width / 2);
                    int tbcheightform = (this.Height / 2) + (Toolpanel.Height / 2);
                    Point p1 = new Point(lblDinh[dinh].Left + lblDinh[dinh].Width / 2,
                                         lblDinh[dinh].Top + lblDinh[dinh].Height / 2);
                    if (p1.X < tbcwidthform) p1.X = p1.X + (p1.X / 40);
                    if (p1.X > tbcwidthform) p1.X = p1.X - (p1.X / 40);
                    if (p1.Y < tbcheightform) p1.Y = p1.Y + (p1.Y / 40);
                    if (p1.Y > tbcheightform) p1.Y = p1.Y - (p1.Y / 40);
                    for (int i = 0; i < SoDuongDi; i++)
                    {
                        if (DuongDi[0, i] == dinh)
                        {
                            vtDuongDi[0, i] = new Point(p1.X, p1.Y);
                            Point p3 = new Point();
                            if (p1.X < vtDuongDi[1, i].X) p3.X = p1.X + ((vtDuongDi[1, i].X - p1.X) / 2);
                            else p3.X = vtDuongDi[1, i].X + ((p1.X - vtDuongDi[1, i].X) / 2);
                            if (p1.Y < vtDuongDi[1, i].Y) p3.Y = p1.Y + ((vtDuongDi[1, i].Y - p1.Y) / 2);
                            else p3.Y = vtDuongDi[1, i].Y + ((p1.Y - vtDuongDi[1, i].Y) / 2);
                            lblTrongSo[i].Location = new Point(p3.X, p3.Y);
                            vtTrongSo[i] = p3;
                        }
                        if (DuongDi[1, i] == dinh)
                        {
                            vtDuongDi[1, i] = new Point(p1.X, p1.Y);
                            Point p3 = new Point();
                            if (p1.X < vtDuongDi[0, i].X) p3.X = p1.X + ((vtDuongDi[0, i].X - p1.X) / 2);
                            else p3.X = vtDuongDi[0, i].X + ((p1.X - vtDuongDi[0, i].X) / 2);
                            if (p1.Y < vtDuongDi[0, i].Y) p3.Y = p1.Y + ((vtDuongDi[0, i].Y - p1.Y) / 2);
                            else p3.Y = vtDuongDi[0, i].Y + ((p1.Y - vtDuongDi[0, i].Y) / 2);
                            lblTrongSo[i].Location = new Point(p3.X, p3.Y);
                            vtTrongSo[i] = p3;
                        }
                    }

                }
                if (Dijkstrarbt.Checked == true)
                {
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 7);     // chỉnh bút vẽ lại thành dấu mủi tên
                    pen.CustomEndCap = bigArrow;
                    int tbcwidthform = (this.Width / 2) + (Listviewpanel.Width / 2);
                    int tbcheightform = (this.Height / 2) + (Toolpanel.Height / 2);
                    Point p1 = new Point(lblDinh[dinh].Left + lblDinh[dinh].Width / 2,
                                         lblDinh[dinh].Top + lblDinh[dinh].Height / 2);
                    if (p1.X < tbcwidthform) p1.X = p1.X + (p1.X / 40);
                    if (p1.X > tbcwidthform) p1.X = p1.X - (p1.X / 40);
                    if (p1.Y < tbcheightform) p1.Y = p1.Y + (p1.Y / 40);
                    if (p1.Y > tbcheightform) p1.Y = p1.Y - (p1.Y / 40);
                    for (int i = 0; i < SoDuongDi; i++)
                    {
                        if (DuongDi[0, i] == dinh)
                        {
                            vtDuongDi[0, i] = new Point(p1.X, p1.Y);
                            Point p3 = new Point();
                            if (p1.X < vtDuongDi[1, i].X) p3.X = p1.X + ((vtDuongDi[1, i].X - p1.X) / 2);
                            else p3.X = vtDuongDi[1, i].X + ((p1.X - vtDuongDi[1, i].X) / 2);
                            if (p1.Y < vtDuongDi[1, i].Y) p3.Y = p1.Y + ((vtDuongDi[1, i].Y - p1.Y) / 2);
                            else p3.Y = vtDuongDi[1, i].Y + ((p1.Y - vtDuongDi[1, i].Y) / 2);
                            lblTrongSo[i].Location = new Point(p3.X, p3.Y);
                            vtTrongSo[i] = p3;
                        }
                        if (DuongDi[1, i] == dinh)
                        {
                            vtDuongDi[1, i] = new Point(p1.X, p1.Y);
                            Point p3 = new Point();
                            if (p1.X < vtDuongDi[0, i].X) p3.X = p1.X + ((vtDuongDi[0, i].X - p1.X) / 2);
                            else p3.X = vtDuongDi[0, i].X + ((p1.X - vtDuongDi[0, i].X) / 2);
                            if (p1.Y < vtDuongDi[0, i].Y) p3.Y = p1.Y + ((vtDuongDi[0, i].Y - p1.Y) / 2);
                            else p3.Y = vtDuongDi[0, i].Y + ((p1.Y - vtDuongDi[0, i].Y) / 2);
                            lblTrongSo[i].Location = new Point(p3.X, p3.Y);
                            vtTrongSo[i] = p3;
                        }
                    }
                }
                this.Refresh();
                MainForm_Load(sender, e);
            }
        }

        private void TatLabel()
        {
            foreach (var ctl in this.Controls)      // làm cho các label không bị đè lên khi người dùng vẽ
            {
                if (ctl.GetType() == typeof(Label))
                {
                    ((Label)ctl).Visible = false;
                }
            }
        }

        private void BatLabel()
        {
            foreach (var ctl in this.Controls)      // làm cho các label không còn ẩn nữa
            {
                if (ctl.GetType() == typeof(Label))
                {
                    ((Label)ctl).Visible = true;
                }
            }
        }

        private void labelClick(object sender, EventArgs e)
        {
            Graphics Hinh = this.CreateGraphics();
            if (TaoDuongDi == true)
            {
                Result.Text = "\tChọn đường đi từ: ";
                if (ChonDuongDi == false)
                {
                    Label currlabel = (Label)sender;
                    currlabel.ForeColor = Color.Green;
                    currlabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); ;
                    A = int.Parse(currlabel.Text);                    
                    //MessageBox.Show(A.ToString(), "TU");
                    ChonDuongDi = true;
                }
                else if (ChonDuongDi == true)
                {
                    Label currlabel = (Label)sender;
                    currlabel.ForeColor = Color.Green;
                    currlabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    B = int.Parse(currlabel.Text);

                    if (A == B)
                    {
                        MessageBox.Show("Chọn sai đường đi, đường đi không dược trùng");
                        Result.Text = "Tạo đường đi không công!";
                    }
                    else
                    {
                        Result.Text = "Đã chọn " + A.ToString() + " và " + B.ToString();
                        // Trả về font ban đầu
                        lblDinh[A].Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        lblDinh[A].ForeColor = Color.Black;
                        lblDinh[B].Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        lblDinh[B].ForeColor = Color.Black;

                        // Vẽ đường đi
                        int tbcwidthform = (this.Width / 2) + (Listviewpanel.Width / 2);
                        int tbcheightform = (this.Height / 2) + (Toolpanel.Height / 2);
                        Point p1 = new Point(lblDinh[A].Left + lblDinh[A].Width / 2,
                                             lblDinh[A].Top + lblDinh[A].Height / 2);
                        Point p2 = new Point(lblDinh[B].Left + lblDinh[B].Width / 2,
                                             lblDinh[B].Top + lblDinh[B].Height / 2);
                        if (p1.X < tbcwidthform) p1.X = p1.X + (p1.X / 40);
                        if (p2.X < tbcwidthform) p2.X = p2.X + (p2.X / 40);
                        if (p1.X > tbcwidthform) p1.X = p1.X - (p1.X / 40);
                        if (p2.X > tbcwidthform) p2.X = p2.X - (p2.X / 40);
                        if (p1.Y < tbcheightform) p1.Y = p1.Y + (p1.Y / 40);
                        if (p2.Y < tbcheightform) p2.Y = p2.Y + (p2.Y / 40);
                        if (p1.Y > tbcheightform) p1.Y = p1.Y - (p1.Y / 40);
                        if (p2.Y > tbcheightform) p2.Y = p2.Y - (p2.Y / 40);

                        Hinh.DrawLine(pen, p1, p2);
                        // Lưu lại đường đi từ 2 label
                        vtDuongDi[0, SoDuongDi] = p1;
                        vtDuongDi[1, SoDuongDi] = p2;
                        lb1 = lblDinh[A]; // chuyển qua FormTrọng số
                        lb2 = lblDinh[B];

                        // Gọi form Trọng số để lấy trọng số từ textbox
                        TrongSoForm form = new TrongSoForm();
                        form.ShowDialog();
                        Result.Text = "Đang chọn trọng số!";
                        if (CheckTaobtn == true)
                        {
                            Result.Text = "Đã chọn " + B.ToString() + " là đích đến.";
                            if (number == 0)
                            {
                                MessageBox.Show("Trọng số của đường đi không được bẳng 0");
                            }
                            else if (Dijkstrarbt.Checked == true && number < 0)
                            {
                                MessageBox.Show("Trọng số trong đồ thị Dijkstra không được âm!");
                            }
                            else
                            {
                                MaTran[A, B] = number;
                                TrongSo[SoDuongDi] = number;

                                // Lưu lại vị trí của trọng số
                                Point p3 = new Point();
                                if (p1.X < p2.X) p3.X = p1.X + ((p2.X - p1.X) / 2);
                                else p3.X = p2.X + ((p1.X - p2.X) / 2);
                                if (p1.Y < p2.Y) p3.Y = p1.Y + ((p2.Y - p1.Y) / 2);
                                else p3.Y = p2.Y + ((p1.Y - p2.Y) / 2);

                                // Tạo trọng số bên cạnh đường đi
                                Label tmp = new Label();                        // Tạo label tạm thời
                                tmp.Text = number.ToString();                   // thứ tự các đỉnh
                                tmp.BackColor = Color.Transparent;              // Tạo hiện ứng nền để không bị đè lẫn nhau
                                tmp.Size = new Size(45, 20);
                                tmp.Location = new Point(p3.X, p3.Y);
                                tmp.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                                lblTrongSo[SoDuongDi] = tmp;
                                this.Controls.Add(tmp);
                                vtTrongSo[SoDuongDi] = p3;

                                // Lưu vào mảng
                                DuongDi[0, SoDuongDi] = A;
                                DuongDi[1, SoDuongDi] = B;
                                SoDuongDi++;
                                ChonDuongDi = false;
                                Refresh();
                                MainForm_Load(sender, e);   // tải lại để hiện lên các đường đi
                            }
                        }
                    }
                }
                Result.Text = "Tạo đường đi thành công!";
                MaTranListViewLoad();
            }
            else if (DiChuyenDinh == true)
            {
                Moving = true;
                Label currlabel = (Label)sender;
                dinh = int.Parse(currlabel.Text);
            }
        }

        private void MatranLoad()
        {
            for (int i = 0; i < SoDinh; i++)
            {
                for (int j = 0; j < SoDinh; j++)
                {
                    MaTran[i, j] = 0;
                }
            }

            if (Primrbt.Checked == true)
            {
                for (int i = 0; i < SoDuongDi; i++)
                {
                    MaTran[DuongDi[0, i], DuongDi[1, i]] = TrongSo[i];
                    MaTran[DuongDi[1, i], DuongDi[0, i]] = TrongSo[i];
                }
            }
            else if (Dijkstrarbt.Checked == true)
            {
                for (int i = 0; i < SoDuongDi; i++)
                {
                    MaTran[DuongDi[0, i], DuongDi[1, i]] = TrongSo[i];
                }
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            MainForm_Load(sender, e); // cập nhật lại các vòng tròn mỗi khi vẽ để không bị mất
            Graphics Hinh = this.CreateGraphics();
            // chuyển label thành hình vẽ ngay dưới vị trí đó
            foreach (var ctl in this.Controls)
            {
                if (ctl.GetType() == typeof(Label))
                {
                    e.Graphics.DrawString(((Label)ctl).Text, ((Label)ctl).Font, new SolidBrush(((Label)ctl).ForeColor), ((Label)ctl).Location);
                }
            }

            if (ChonDuongDi == true && TaoDuongDi == true)
            {
                Point p1 = new Point(lblDinh[A].Left + lblDinh[A].Width / 2,
                                     lblDinh[A].Top + lblDinh[A].Height / 2);

                if (Primrbt.Checked == true)
                    Hinh.DrawLine(pen, p1.X, p1.Y, ConChuotXY.X, ConChuotXY.Y);
                //e.Graphics.DrawLine(pen, p1.X, p1.Y, ConChuotXY.X, ConChuotXY.Y);
                if (Dijkstrarbt.Checked == true)
                {
                    Result.Text = "Đang chọn đỉnh đến";
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 7);     // chỉnh bút vẽ lại thành dấu mủi tên
                    pen.CustomEndCap = bigArrow;
                    Hinh.DrawLine(pen, p1.X, p1.Y, ConChuotXY.X, ConChuotXY.Y);
                }

            }

            if (Moving == true)
            {
                e.Graphics.DrawString((lblDinh[dinh]).Text, (lblDinh[dinh]).Font, new SolidBrush((lblDinh[dinh]).ForeColor), ConChuotXY.X + 10, ConChuotXY.Y + 10);
                Hinh.DrawEllipse(pen, ConChuotXY.X, ConChuotXY.Y, 50, 50);
                if (Primrbt.Checked == true)
                {
                    pen = new Pen(Color.Black, 3);
                    for (int i = 0; i < SoDuongDi; i++)
                    {
                        if (DuongDi[0, i] == dinh) Hinh.DrawLine(pen, ConChuotXY, vtDuongDi[1, i]);
                        if (DuongDi[1, i] == dinh) Hinh.DrawLine(pen, vtDuongDi[0, i], ConChuotXY);
                    }
                }
                if (Dijkstrarbt.Checked == true)
                {
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 7);     // chỉnh bút vẽ lại thành dấu mủi tên
                    pen.CustomEndCap = bigArrow;
                    for (int i = 0; i < SoDuongDi; i++)
                    {
                        if (DuongDi[0, i] == dinh) Hinh.DrawLine(pen, ConChuotXY, vtDuongDi[1, i]);
                        if (DuongDi[1, i] == dinh) Hinh.DrawLine(pen, vtDuongDi[0, i], ConChuotXY);
                    }
                }
            }
        }

        private void TaoDinhbtn_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);
            if (TaoDuongDi == true)
            {
                TaoDuongDi = false;
                TaoDuongDibtn.BackColor = Color.FromArgb(224, 224, 224);
                TatLabel();
                Result.Text = "Đã tắt tạo đường đi!";
            }
            if (ChayThuatToan == true)
            {
                ChayThuatToanbtn.BackColor = Color.FromArgb(224, 224, 224);
                ChayThuatToan = false;
                Dijkstrapanelselect.Visible = false;
                Result.Text = "Đã tắt chạy thuật toán!";
            }
            if (DiChuyenDinh == true)
            {
                Movebtn.BackColor = Color.FromArgb(224, 224, 224);
                DiChuyenDinh = false;
                TatLabel();
                Result.Text = "Đã tắt di chuyển các đỉnh!";
            }
            if (TaoDinh == false)
            {
                TaoDinh = true;
                TaoDinhbtn.BackColor = Color.Green;
                Result.Text = "Kích hoạt tạo Đỉnh!"; 
            }
            else if (TaoDinh == true)
            {
                TaoDinh = false;
                TaoDinhbtn.BackColor = Color.FromArgb(224, 224, 224);
                Result.Text = "Đã tắt tạo đỉnh!";
            }
        }

        private void TaoDuongDibtn_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);
            if (TaoDinh == true)
            {
                TaoDinh = false;
                TaoDinhbtn.BackColor = Color.FromArgb(224, 224, 224);
                Result.Text = "Đã tắt tạo đỉnh!";
            }
            if (ChayThuatToan == true)
            {
                ChayThuatToanbtn.BackColor = Color.FromArgb(224, 224, 224);
                ChayThuatToan = false;
                Dijkstrapanelselect.Visible = false;
                Result.Text = "Đã tắt chạy thuật toán";
            }
            if (DiChuyenDinh == true)
            {
                Movebtn.BackColor = Color.FromArgb(224, 224, 224);
                DiChuyenDinh = false;
                TatLabel();
                Result.Text = "Đã tắt di chuyển các đỉnh!";
            }
            if (TaoDuongDi == false)
            {
                TaoDuongDi = true;
                TaoDuongDibtn.BackColor = Color.Green;
                BatLabel();
                Result.Text = "Kích hoạt tạo đường đi!";
            }
            else if (TaoDuongDi == true)
            {
                TatLabel();
                TaoDuongDi = false;
                ChonDuongDi = false;
                foreach (var ctl in this.Controls)      // làm cho các label không bị đè lên khi người dùng vẽ
                {
                    if (ctl.GetType() == typeof(Label))
                    {
                        ((Label)ctl).Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        ((Label)ctl).ForeColor = Color.Black;
                    }
                }
                TaoDuongDibtn.BackColor = Color.FromArgb(224, 224, 224);
                Result.Text = "Đã tắt tạo đường đi!";
                this.Refresh();
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (TaoDuongDi == true)
            {
                if (ChonDuongDi == true)
                {
                    ConChuotXY = e.Location;
                    Result.Text = "Đang tìm vị trí";
                    Refresh();
                }
            }
            else if (Moving == true)
            {
                ConChuotXY = e.Location;
                Result.Text = "Đang tìm vị trí";
                Refresh();
            }
        }

        private void Primrbt_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
            Result.Text = "\tPRIM\r\n";
            if (TaoDinh == true)
            {
                TaoDinh = false;
                TaoDinhbtn.BackColor = Color.FromArgb(224, 224, 224);
            }
            if (TaoDuongDi == true)
            {
                TaoDuongDi = false;
                TaoDuongDibtn.BackColor = Color.FromArgb(224, 224, 224);
                TatLabel();
            }
            if (ChayThuatToan == true)
            {
                ChayThuatToanbtn.BackColor = Color.FromArgb(224, 224, 224);
                ChayThuatToan = false;
                Dijkstrapanelselect.Visible = false;
            }
            if (Primrbt.Checked == true)
            {
                MainForm_Load(sender, e);
                MaTranListViewLoad();
            }
        }

        private void Dijkstrarbt_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
            Result.Text = "\tDIJKSTRA\r\n";
            if (TaoDinh == true)
            {
                TaoDinh = false;
                TaoDinhbtn.BackColor = Color.FromArgb(224, 224, 224);
            }
            if (TaoDuongDi == true)
            {
                TaoDuongDi = false;
                TaoDuongDibtn.BackColor = Color.FromArgb(224, 224, 224);
                TatLabel();
            }
            if (ChayThuatToan == true)
            {
                ChayThuatToanbtn.BackColor = Color.FromArgb(224, 224, 224);
                ChayThuatToan = false;
                Dijkstrapanelselect.Visible = false;
            }
            if (Dijkstrarbt.Checked == true)
            {
                MainForm_Load(sender, e);
                MaTranListViewLoad();
            }
        }

        private void XemMaTranbtn_Click(object sender, EventArgs e)
        {
            MatranLoad();
            if (XemMaTran == false)
            {
                XemMaTran = true;
                XemMaTranbtn.BackColor = Color.Green;
                MaTranLV.Visible = true;
                MaTranListViewLoad();
                Result.Text = "Kích hoạt xem ma trận!";
            }
            else if (XemMaTran == true)
            {
                XemMaTran = false;
                XemMaTranbtn.BackColor = Color.FromArgb(224, 224, 224);
                MaTranLV.Visible = false;
                Result.Text = "Đã tắt xem ma trận!";
            }
        }

        private void MaTranListViewLoad()
        {
            MaTranLV.Items.Clear();
            MaTranLV.Columns.Clear();
            for (int i = 0; i < SoDinh; i++)
            {
                MaTranLV.Columns.Add(i.ToString(), 20);
            }

            string[] row = new string[100];
            for (int i = 0; i < SoDinh; i++)
            {
                for (int j = 0; j < SoDinh; j++)
                {
                    if (i == j) row[j] = "-";
                    else row[j] = MaTran[i, j].ToString();
                }
                ListViewItem lvi = new ListViewItem(row);
                MaTranLV.Items.Add(lvi);
            }
        }

        public class CANH
        {
            public int u;       //Đỉnh thứ nhất
            public int v;       //Đỉnh thứ hai
            public int trongso;
        }

        public void VeDuongTron(Pen pendraw, int dinh1)
        {
            Graphics Hinh = this.CreateGraphics();
            Hinh.DrawEllipse(pendraw, vtDinh[dinh1].X, vtDinh[dinh1].Y, 40, 40);
        }

        public void VeDuongThang(Pen pendraw, int dinh1, int dinh2)
        {
            Graphics Hinh = this.CreateGraphics();
            int tbcwidthform = (this.Width / 2) + (Listviewpanel.Width / 2);
            int tbcheightform = (this.Height / 2) + (Toolpanel.Height / 2);
            Point p1 = new Point(lblDinh[dinh1].Left + lblDinh[dinh1].Width / 2,
                                 lblDinh[dinh1].Top + lblDinh[dinh1].Height / 2);
            Point p2 = new Point(lblDinh[dinh2].Left + lblDinh[dinh2].Width / 2,
                                 lblDinh[dinh2].Top + lblDinh[dinh2].Height / 2);
            if (p1.X < tbcwidthform) p1.X = p1.X + (p1.X / 40);
            if (p2.X < tbcwidthform) p2.X = p2.X + (p2.X / 40);
            if (p1.X > tbcwidthform) p1.X = p1.X - (p1.X / 40);
            if (p2.X > tbcwidthform) p2.X = p2.X - (p2.X / 40);
            if (p1.Y < tbcheightform) p1.Y = p1.Y + (p1.Y / 40);
            if (p2.Y < tbcheightform) p2.Y = p2.Y + (p2.Y / 40);
            if (p1.Y > tbcheightform) p1.Y = p1.Y - (p1.Y / 40);
            if (p2.Y > tbcheightform) p2.Y = p2.Y - (p2.Y / 40);
            Hinh.DrawLine(pendraw, p1, p2);
        }

        private void PrimMin()
        {
            Pen pen2 = new Pen(Color.Green, 3);
            Pen pen3 = new Pen(Color.Blue, 3);
            Pen pen4 = new Pen(Color.Red, 3);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 7);     // chỉnh bút vẽ lại thành dấu mủi tên
            pen2.CustomEndCap = bigArrow;
            pen3.CustomEndCap = bigArrow;
            pen4.CustomEndCap = bigArrow;
            MatranLoad();
            int[] visited = new int[100];             // Prim Đánh dấu đỉnh đã đi hay chưa
            CANH[] CanhMin = new CANH[MAX];           // Prim
            int SoCanhMin = 0;                        // Prim
            for (int i = 0; i < SoDinh; i++)
                visited[i] = 0;

            visited[0] = 1;
            VeDuongTron(pen3, 0);
            while (SoCanhMin < SoDinh - 1)
            {
                CANH canhnhonhat = new CANH();
                int min = -1;
                for (int i = 0; i < SoDinh; i++)
                {
                    if (visited[i] == 0)
                    {
                        for (int j = 0; j < SoDinh; j++)
                        {
                            if (visited[j] == 1 && (MaTran[i, j] != 0))
                            {                                
                                VeDuongThang(pen3, j, i);
                                Thread.Sleep(RunSpeed.Value);
                                VeDuongTron(pen3, i);
                                Thread.Sleep(RunSpeed.Value);
                                if (min == -1 || MaTran[i, j] < min)
                                {
                                    min = MaTran[i, j];
                                    canhnhonhat.u = i;
                                    canhnhonhat.v = j;
                                    canhnhonhat.trongso = MaTran[i, j];
                                }
                            }
                        }
                    }
                }
                
                VeDuongTron(pen2, canhnhonhat.v);
                Thread.Sleep(RunSpeed.Value);
                VeDuongThang(pen2, canhnhonhat.v, canhnhonhat.u);
                Thread.Sleep(RunSpeed.Value);
                VeDuongTron(pen2, canhnhonhat.u);
                Thread.Sleep(RunSpeed.Value);
                CanhMin[SoCanhMin] = canhnhonhat;
                SoCanhMin++;
                visited[canhnhonhat.u] = 1;
            }
            // tạo 1 hàm xuất prim để dùng thread chạy 1 luồng riêng và có thể thấy được từng bước
            int sum = 0;
            Result.Text = "Đã chạy xong thuật toán PRIM!\r\n";
            Result.Text += "\tPRIM\r\n";
            Result.Text += "Cây khung nhỏ nhất của đồ thị với: \r\n";
            for (int i = 0; i < SoCanhMin; i++)
            {
                Result.Text += "(" + CanhMin[i].v + ", " + CanhMin[i].u + ") ";
                sum += CanhMin[i].trongso;
            }
            Result.Text += "\r\n";
            Result.Text += "Tổng giá trị của cây: " + sum.ToString();
            if (sum == 0) Result.Text = "Không có cây khung nhỏ nhất!";

            ChayThuatToanbtn.BackColor = Color.FromArgb(224, 224, 224);
            ChayThuatToan = false;
        }

        private void DijkstraFind()
        {
            Pen pen2 = new Pen(Color.Green, 3);
            Pen pen3 = new Pen(Color.Blue, 3);
            Pen pen4 = new Pen(Color.Red, 3);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 7);     // chỉnh bút vẽ lại thành dấu mủi tên
            pen2.CustomEndCap = bigArrow;
            pen3.CustomEndCap = bigArrow;
            pen4.CustomEndCap = bigArrow;
            MatranLoad();
            int[] Road = new int[MAX]; // Dijkstra
            int roadid = 0;            // Dijkstra
            int roadi;                 // Dijkstra
            bool[] ThuocT = new bool[MAX];
            int[] Length = new int[MAX];
            int[] LastV = new int[MAX];

            for (roadi = 0; roadi < SoDinh; roadi++)
            {
                ThuocT[roadi] = true;
                Length[roadi] = Vc;
                LastV[roadi] = -1;
            }
            Length[A] = 0;
            ThuocT[A] = false;
            LastV[A] = A;
            int vdij = A;

            while (ThuocT[B])
            {
                for (int k = 0; k < SoDinh; k++)
                {

                    if (vdij == -1)
                    {
                        Result.Text = "Chạy thuật toán dijkstra thất bại, không có đường đi nào hợp lệ!";
                        return;
                    }
                    else if (MaTran[vdij, k] != 0 && ThuocT[k] == true && (Length[k] == Vc || Length[k] > Length[vdij] + MaTran[vdij, k]))
                    {
                        Length[k] = Length[vdij] + MaTran[vdij, k];
                        LastV[k] = vdij;
                        VeDuongTron(pen3, vdij);
                        Thread.Sleep(RunSpeed.Value);
                        VeDuongThang(pen3, vdij, k);
                        Thread.Sleep(RunSpeed.Value);
                        VeDuongTron(pen3, k);
                        Thread.Sleep(RunSpeed.Value);
                    }
                }

                vdij = -1;
                for (roadi = 0; roadi < SoDinh; roadi++)
                {
                    if (ThuocT[roadi] == true && Length[roadi] != Vc)
                    {
                        if (vdij == -1 || Length[vdij] > Length[roadi])
                        {
                            vdij = roadi;
                            VeDuongTron(pen2, LastV[vdij]);
                            Thread.Sleep(RunSpeed.Value);
                            VeDuongThang(pen2, LastV[vdij], roadi);
                            Thread.Sleep(RunSpeed.Value);
                            VeDuongTron(pen2, roadi);
                            Thread.Sleep(RunSpeed.Value);
                        }
                    }
                }
                if (vdij != -1)
                {
                    ThuocT[vdij] = false;
                }
            }

            vdij = B;
            //Tìm đường đi: truy xuất từ LastV
            while (vdij != A)
            {
                Road[roadid] = vdij;
                vdij = LastV[vdij];
                roadid++;
            }
            Road[roadid] = A;

            // cũng tương tự như prim tạo 1 luồng thread mới để chạy từng bước
            //Xuất ngược để tìm đường đi dinhDau -> dinhCuoi            

            Result.Text = "Đã chạy xong thuật toán Dijkstra\r\n";
            Result.Text += "\tDIJKSTRA\r\n";
            Result.Text += "Đường đi ngắn nhất từ đỉnh " + A.ToString() + " đến " + B.ToString() + ": \r\n";
            for (roadi = roadid; roadi > 0; roadi--)
            {
                Result.Text += Road[roadi].ToString() + " --> ";
            }
            Result.Text += Road[roadi].ToString();
        }

        private void DijkstraComBoBox1_Load()
        {
            List<int> cb1 = new List<int>();
            for (int i = 0; i < SoDinh; i++) cb1.Add(i);
            Dij1cbx.DataSource = cb1;
        }

        private void DijkstraComBoBox2_Load()
        {
            List<int> cb2 = new List<int>();
            for (int i = 0; i < SoDinh; i++) if (i != int.Parse(Dij1cbx.Text)) cb2.Add(i);
            Dij2cbx.DataSource = cb2;
        }

        private void ChayThuatToanbtn_Click(object sender, EventArgs e)
        {
            if (TaoDinh == true)
            {
                TaoDinh = false;
                TaoDinhbtn.BackColor = Color.FromArgb(224, 224, 224);
                Result.Text = "Đã tắt tạo đỉnh!";
            }
            if (TaoDuongDi == true)
            {
                TaoDuongDi = false;
                TaoDuongDibtn.BackColor = Color.FromArgb(224, 224, 224);
                TatLabel();
                Result.Text = "Đã tắt tạo đường đi!";
            }
            if (DiChuyenDinh == true)
            {
                Movebtn.BackColor = Color.FromArgb(224, 224, 224);
                DiChuyenDinh = false;
                TatLabel();
                Result.Text = "Đã tắt di chuyển các đỉnh!";
            }
            if (ChayThuatToan == false)
            {
                Result.Text = "Kích hoạt chạy thuật toán!";
                ChayThuatToanbtn.BackColor = Color.Green;
                if (Primrbt.Checked == true)
                {
                    Result.Text = "Đang chạy thuật toán PRIM...";
                    ThreadStart ts = new ThreadStart(PrimMin); // tạo thread mới để có thể thấy được quá trình chạy prim
                    Thread thrd = new Thread(ts);
                    thrd.IsBackground = true;                   // tạo luồng thread mới để có thể coi quá trình chạy
                    thrd.Start();
                }
                else if (Dijkstrarbt.Checked == true)
                {
                    Dijkstrapanelselect.Visible = true;
                    DijkstraComBoBox1_Load();
                    DijkstraComBoBox2_Load();
                }
                ChayThuatToan = true;
            }
            else if (ChayThuatToan == true)
            {
                ChayThuatToanbtn.BackColor = Color.FromArgb(224, 224, 224);
                ChayThuatToan = false;
                Dijkstrapanelselect.Visible = false;
                Result.Text = "Đã tắt chạy thuật toán!";
            }
        }

        private void Dij1cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            DijkstraComBoBox2_Load();
            MainForm_Load(sender, e);
        }

        private void Dij2cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DijkstraComBoBox1_Load();
            MainForm_Load(sender, e);
        }

        private void Chaydijbtn_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);
            Result.Text = "Đang chạy thuật toán Dijkstra...";
            A = int.Parse(Dij1cbx.Text);
            B = int.Parse(Dij2cbx.Text);
            for (int i = 0; i < SoDinh; i++)    // Kiểm tra có trọng số âm hay không
            {
                for (int j = 0; j < SoDinh; j++)
                {
                    if (MaTran[i, j] < 0)
                    {
                        MessageBox.Show("Chạy thuật toán Dijkstra thất bại, đồ thị có trọng số âm!");
                        Result.Text = "Đồ thị có trọng số ÂM!, chạy Dijkstra thất bại";
                        return;
                    }
                }
            }
            ThreadStart ts = new ThreadStart(DijkstraFind); // tạo thread mới để có thể thấy được quá trình chạy prim
            Thread thrd = new Thread(ts);
            thrd.IsBackground = true;                   // tạo luồng thread mới để có thể coi quá trình chạy
            thrd.Start();
            Result.Text = "";
        }

        private void CancelDijbtn_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);
            Result.Text = "Huỷ chạy thuật toán";
            ChayThuatToanbtn.BackColor = Color.FromArgb(224, 224, 224);
            ChayThuatToan = false;
            Dijkstrapanelselect.Visible = false;
            Result.Text = "";
        }

        private void RunSpeed_Scroll(object sender, EventArgs e)
        {
            runspeedlabel.Text = RunSpeed.Value.ToString() + " ms";

            Result.Text = "Tốc Độ chạy theo mili giây!";
        }

        private void Newbtn_Click(object sender, EventArgs e)
        {
            // khởi tạo lại tất cả các giá trị để làm mới
            SoDinh = 0;                          // lưu lại số đỉnh
            vtDinh = new Point[100];         // lưu lại vị trí của 100 cái đỉnh
            lblDinh = new Label[100];        // tạo 100 cái label để lưu trữ 100 cái đỉnh
            MaTran = new int[100, 100];       // tạo ma trận để lưu trữ các dữ liệu

            // Đường đi
            SoDuongDi = 0;                       // lưu trữ số đường đi đã tạo
            DuongDi = new int[2, 200];        // tạo 200 đường đi lưu trữ các dường đi
            vtDuongDi = new Point[2, 100];
            TrongSo = new int[100];
            vtTrongSo = new Point[100];
            lblTrongSo = new Label[100];
            A = new int();                       // Đi từ A ------> B
            B = new int();
            // Xoá các label đã tạo
            foreach (Control c in Controls.OfType<Label>().ToList())
            {
                this.Controls.Remove(c);
            }
            if (TaoDinh == true)
            {
                TaoDinh = false;
                TaoDinhbtn.BackColor = Color.FromArgb(224, 224, 224);
                Result.Text = "Đã tắt tạo đỉnh!";
            }
            if (TaoDuongDi == true)
            {
                TaoDuongDi = false;
                TaoDuongDibtn.BackColor = Color.FromArgb(224, 224, 224);
                TatLabel();
                Result.Text = "Đã tắt tạo đường đi!";
            }
            if (ChayThuatToan == true)
            {
                ChayThuatToanbtn.BackColor = Color.FromArgb(224, 224, 224);
                ChayThuatToan = false;
                Dijkstrapanelselect.Visible = false;
                Result.Text = "Đã tắt chạy thuật toán!";
            }
            if (DiChuyenDinh == true)
            {
                Movebtn.BackColor = Color.FromArgb(224, 224, 224);
                DiChuyenDinh = false;
                TatLabel();
                Result.Text = "Đã tắt di chuyển các đỉnh!";
            }
            if (XemMaTran == true)
            {
                XemMaTran = false;
                XemMaTranbtn.BackColor = Color.FromArgb(224, 224, 224);
                MaTranLV.Visible = false;
                Result.Text = "Đã tắt xem ma trận!";
            }
            this.Refresh();
            Result.Text = "Làm mới đồ thị";

        }

        private void Movebtn_Click(object sender, EventArgs e)
        {
            if (TaoDinh == true)
            {
                TaoDinh = false;
                TaoDinhbtn.BackColor = Color.FromArgb(224, 224, 224);
                Result.Text = "Đã tắt tạo đỉnh!";
            }
            if (TaoDuongDi == true)
            {
                TaoDuongDi = false;
                TaoDuongDibtn.BackColor = Color.FromArgb(224, 224, 224);
                TatLabel();
                Result.Text = "Đã tắt tạo đường đi!";
            }
            if (ChayThuatToan == true)
            {
                ChayThuatToanbtn.BackColor = Color.FromArgb(224, 224, 224);
                ChayThuatToan = false;
                Dijkstrapanelselect.Visible = false;
                Result.Text = "Đã tắt chạy thuật toán!";
            }
            if (DiChuyenDinh == false)
            {
                Movebtn.BackColor = Color.Green;
                DiChuyenDinh = true;
                BatLabel();
                Result.Text = "Kích hoạt di chuyển đỉnh!";
            }
            else if (DiChuyenDinh == true)
            {
                Movebtn.BackColor = Color.FromArgb(224, 224, 224);
                DiChuyenDinh = false;
                TatLabel();
                Result.Text = "Đã tắt di chuyển các đỉnh!";
            }
        }

        private void Dijkstrapanelselect_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void runspeedlabel_Click(object sender, EventArgs e)
        {

        }

        private void Listviewpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Result_TextChanged(object sender, EventArgs e)
        {

        }

        private void MaTranLV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}