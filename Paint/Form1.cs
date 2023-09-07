using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(image);
            g.Clear(Color.White);
            pictureBox1.Image = image;
            item = null;
            CurPen = new Pen(pictureBox2.BackColor, 2);
            CurBrush = new SolidBrush(pictureBox3.BackColor);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            numericUpDown1.Value = Convert.ToInt32(CurPen.Width);
            CurFont = new Font("Times New Roman", 12);
        }
        Graphics g;
        Bitmap image;
        Bitmap tmpImage;
        Bitmap CopyClipboard;
        MyList log = new MyList();
        MyList OldLog = new MyList();
        PictureBox tmp;
        TextBox tmpText;
        object item;
        int X0;
        int Y0;
        int xx0;
        int yy0;
        int LastX;
        int LastY;
        Pen CurPen;
        Brush CurBrush;
        Font CurFont;
        bool Moving = false;
        bool done = false;
        bool IsSaved = false;
        bool IsPen = true;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (done)
            {
                log = log.InsertAtEnd("Paste", tmp.Left, tmp.Top);
                OldLog = OldLog.InsertAtEnd("Paste", tmp.Left, tmp.Top);
                g.DrawImage(tmp.Image, tmp.Left, tmp.Top - panel1.Height - menuStrip1.Height);
                this.Controls.Remove(tmp);
                tmp.Dispose();
                done = false;
            }
            X0 = e.X;
            Y0 = e.Y;
            if (rPen.Checked)
            {
                item = "Pen";
                log = log.InsertAtEnd("Move", e.X, e.Y);
                LastX = e.X;
                LastY = e.Y;
            }
            if (rLine.Checked)
            {
                item = "Line";
                log = log.InsertAtEnd("Move", e.X, e.Y);
                tmpImage = (Bitmap)image.Clone();
                LastX = e.X;
                LastY = e.Y;
            }
            if (rRect.Checked)
            {
                item = "Rectangle";
                tmpImage = (Bitmap)image.Clone();
            }
            if (rElips.Checked)
            {
                item = "Elips";
                tmpImage = (Bitmap)image.Clone();
            }
            if (rPipette.Checked)
            {
                log = log.InsertAtEnd("Pipette", e.X, e.Y);
                if (IsPen)
                {
                    CurPen.Color = image.GetPixel(e.X, e.Y);
                    pictureBox2.BackColor = CurPen.Color;
                    log = log.InsertAtEnd("Pen", e.X, e.Y);
                }
                else
                {
                    ((SolidBrush)CurBrush).Color = image.GetPixel(e.X, e.Y);
                    pictureBox3.BackColor = ((SolidBrush)CurBrush).Color;
                    log = log.InsertAtEnd("Brush", e.X, e.Y);
                }
            }
            if (rErase.Checked)
            {
                item = "Erase";
                log = log.InsertAtEnd("EraseStart", e.X, e.Y);
                g.FillRectangle(new SolidBrush(Color.White), e.X - CurPen.Width, e.Y - CurPen.Width, CurPen.Width * 3, CurPen.Width * 3);
            }
            if (rFill.Checked)
            {
                log = log.InsertAtEnd("Fill", e.X, e.Y);
                if (comboBox3.SelectedIndex == 0)
                {
                    FloodFill(image, e.Location, ((SolidBrush)CurBrush).Color, CurPen.Color);
                }
                else
                {
                    FloodFill(image, e.Location, ((SolidBrush)CurBrush).Color, CurPen.Color, true);
                }
                pictureBox1.Refresh();
            }
            if (rCopy.Checked)
            {
                item = "Copy";
                tmpImage = (Bitmap)image.Clone();
            }
            if (rText.Checked)
            {
                item = "Text";
                
                LastX = e.X;
                LastY = e.Y;
                if (Controls.Contains(tmpText))
                {
                    tmpText.Left = e.X;
                    tmpText.Top = e.Y + panel1.Height + menuStrip1.Height;
                }
                else
                {
                    tmpText = new TextBox();
                    tmpText.Location = new System.Drawing.Point(e.X, e.Y + panel1.Height + menuStrip1.Height);
                    tmpText.Name = "tmpText";
                    tmpText.Size = new System.Drawing.Size(100, 20);
                    tmpText.TabIndex = 0;
                    tmpText.TabStop = false;
                    tmpText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tmpText_MouseDown);
                    tmpText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tmpText_MouseUp);
                    tmpText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tmpText_MouseMove);
                    tmpText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tmpText_KeyDown);
                    tmpText.Leave += new System.EventHandler(this.tmpText_Leave);
                    tmpText.Font = CurFont;
                    this.Controls.Add(tmpText);
                    tmpText.BringToFront();
                    tmpText.Focus();
                }
            }
        }

        private void tmpText_Leave(object sender, EventArgs e)
        {
            if (item != null && item.ToString() == "Text")
            {
                ((TextBox)sender).Focus();
            }
        }

        private void tmpText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                item = null;
                Focus();
                g.DrawString(((TextBox)sender).Text, CurFont, CurPen.Brush, X0, Y0);
                log = log.InsertAtEnd("Text", LastX, LastY, 0, 0, "", "", ((TextBox)sender).Text);
                Controls.Remove(tmpText);
                tmpText.Dispose();               
            }
            ((TextBox)sender).Width = TextRenderer.MeasureText(((TextBox)sender).Text + "###", CurFont).Width;
        }

        private void tmpText_MouseDown(object sender, MouseEventArgs e)
        {
            Moving = true;
            xx0 = e.X;
            yy0 = e.Y;
            item = null;
        }

        private void tmpText_MouseUp(object sender, MouseEventArgs e)
        {
            Moving = false;
        }

        private void tmpText_MouseMove(object sender, MouseEventArgs e)
        {
            if (Moving)
            {
                tmpText.Left += e.X - xx0;
                tmpText.Top += e.Y - yy0;
                X0 = tmpText.Left;
                Y0 = tmpText.Top;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (item)
            {
                case "Pen":
                    {
                        g.DrawLine(CurPen, LastX, LastY, e.X, e.Y);
                        log = log.InsertAtEnd("Line", e.X, e.Y);
                        LastX = e.X;
                        LastY = e.Y;
                    }
                    break;
                case "Line":
                    {
                        g.Clear(pictureBox1.BackColor);
                        g.DrawImage(tmpImage, 0, 0);
                        g.DrawLine(CurPen, X0, Y0, e.X, e.Y);
                    }
                    break;
                case "Rectangle":
                    {
                        g.Clear(pictureBox1.BackColor);
                        g.DrawImage(tmpImage, 0, 0);
                        g.DrawRectangle(CurPen, Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                        g.FillRectangle(CurBrush, Math.Min(X0, e.X) + CurPen.Width / 2, Math.Min(Y0, e.Y) + CurPen.Width / 2, Math.Abs(e.X - X0) - CurPen.Width, Math.Abs(e.Y - Y0) - CurPen.Width);
                    }
                    break;
                case "Elips":
                    {
                        g.Clear(pictureBox1.BackColor);
                        g.DrawImage(tmpImage, 0, 0);
                        g.DrawEllipse(CurPen, Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                        g.FillEllipse(CurBrush, Math.Min(X0, e.X) + CurPen.Width / 2, Math.Min(Y0, e.Y) + CurPen.Width / 2, Math.Abs(e.X - X0) - CurPen.Width, Math.Abs(e.Y - Y0) - CurPen.Width);
                    }
                    break;
                case "Erase":
                    {
                        log = log.InsertAtEnd("Erase", e.X, e.Y);
                        g.FillRectangle(new SolidBrush(pictureBox1.BackColor), e.X - CurPen.Width, e.Y - CurPen.Width, CurPen.Width * 3, CurPen.Width * 3);
                    }
                    break;
                case "Copy":
                    {
                        g.Clear(pictureBox1.BackColor);
                        g.DrawImage(tmpImage, 0, 0);
                        g.DrawRectangle(new Pen(Color.Black, 3), Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                    }
                    break;
                default:
                    break;
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (item)
            {
                case "Line":
                    {
                        g.Clear(pictureBox1.BackColor);
                        g.DrawImage(tmpImage, 0, 0);
                        g.DrawLine(CurPen, X0, Y0, e.X, e.Y);
                        log = log.InsertAtEnd("Line", e.X, e.Y);
                    }
                    break;
                case "Rectangle":
                    {
                        g.Clear(pictureBox1.BackColor);
                        g.DrawImage(tmpImage, 0, 0);
                        g.DrawRectangle(CurPen, Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                        g.FillRectangle(CurBrush, Math.Min(X0, e.X) + CurPen.Width / 2, Math.Min(Y0, e.Y) + CurPen.Width / 2, Math.Abs(e.X - X0) - CurPen.Width, Math.Abs(e.Y - Y0) - CurPen.Width);
                        log = log.InsertAtEnd("Rect", Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                    }
                    break;
                case "Elips":
                    {
                        g.Clear(pictureBox1.BackColor);
                        g.DrawImage(tmpImage, 0, 0);
                        g.DrawEllipse(CurPen, Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                        g.FillEllipse(CurBrush, Math.Min(X0, e.X) + CurPen.Width / 2, Math.Min(Y0, e.Y) + CurPen.Width / 2, Math.Abs(e.X - X0) - CurPen.Width, Math.Abs(e.Y - Y0) - CurPen.Width);
                        log = log.InsertAtEnd("Elips", Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                    }
                    break;
                case "Erase":
                    {
                        g.FillRectangle(new SolidBrush(pictureBox1.BackColor), e.X - CurPen.Width, e.Y - CurPen.Width, CurPen.Width * 3, CurPen.Width * 3);
                    }
                    break;
                case "Copy":
                    {
                        g.Clear(pictureBox1.BackColor);
                        g.DrawImage(tmpImage, 0, 0);
                        CopyClipboard = new Bitmap(Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                        Graphics.FromImage(CopyClipboard).DrawImage(image, 0, 0, new Rectangle(Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0)), GraphicsUnit.Pixel);
                        log = log.InsertAtEnd("Copy", Math.Min(X0, e.X), Math.Min(Y0, e.Y), Math.Abs(e.X - X0), Math.Abs(e.Y - Y0));
                    }
                    break;
                default:
                    break;
            }
            item = null;
            IsSaved = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    CurPen.DashStyle = DashStyle.Solid;
                    break;
                case 1:
                    CurPen.DashStyle = DashStyle.Dash;
                    break;
                case 2:
                    CurPen.DashStyle = DashStyle.DashDot;
                    break;
                case 3:
                    CurPen.DashStyle = DashStyle.DashDotDot;
                    break;
                default:
                    break;
            }
            log = log.InsertAtEnd("PenStyle", 0, 0, 0, 0, "", comboBox1.SelectedItem.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    ((SolidBrush)CurBrush).Color = Color.FromArgb(255, ((SolidBrush)CurBrush).Color);
                    break;
                case 1:
                    ((SolidBrush)CurBrush).Color = Color.FromArgb(0, ((SolidBrush)CurBrush).Color);
                    break;
                default:
                    break;
            }
            log = log.InsertAtEnd("BrushStyle", 0, 0, 0, 0, "", comboBox2.SelectedItem.ToString());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CurPen.Width = Convert.ToInt32(numericUpDown1.Value);
            log = log.InsertAtEnd("PenSize", Convert.ToInt32(numericUpDown1.Value), 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CopyClipboard != null)
            {
                tmp = new PictureBox();
                tmp.BackColor = System.Drawing.Color.Transparent;
                tmp.Image = CopyClipboard;
                tmp.Location = new System.Drawing.Point(0, 0 + panel1.Height + menuStrip1.Height);
                tmp.Name = "tmp";
                tmp.Size = new System.Drawing.Size(CopyClipboard.Width, CopyClipboard.Height);
                tmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                tmp.TabIndex = 0;
                tmp.TabStop = false;
                tmp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tmp_MouseDown);
                tmp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tmp_MouseUp);
                tmp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tmp_MouseMove);
                this.Controls.Add(tmp);
                tmp.BringToFront();
            }
            rCopy.Checked = false;
            rElips.Checked = false;
            rErase.Checked = false;
            rFill.Checked = false;
            rLine.Checked = false;
            rPen.Checked = false;
            rPipette.Checked = false;
            rRect.Checked = false;
            rText.Checked = false;
        }

        private void tmp_MouseDown(object sender, MouseEventArgs e)
        {
            done = false;
            Moving = true;
            xx0 = e.X;
            yy0 = e.Y;
            item = null;
        }

        private void tmp_MouseUp(object sender, MouseEventArgs e)
        {
            Moving = false;
            done = true;
        }

        private void tmp_MouseMove(object sender, MouseEventArgs e)
        {
            if (Moving)
            {
                tmp.Left += e.X - xx0;
                tmp.Top += e.Y - yy0;
                X0 = tmp.Left;
                Y0 = tmp.Top;
            }
        }

        private void FloodFill(Bitmap bmp, Point q, Color replaceColor, Color BorderColor, bool boundry = false)
        {           
            Color targetColor = bmp.GetPixel(q.X, q.Y);
            if (targetColor != replaceColor)
            {
                Stack<Point> pixels = new Stack<Point>();
                Point start = new Point(q.X, q.Y);
                pixels.Push(start);
                while (pixels.Count > 0)
                {
                    Point a = pixels.Pop();
                    if (a.X < bmp.Width && a.X > 0 &&
                            a.Y < bmp.Height && a.Y > 0)
                    {

                        if (boundry ? bmp.GetPixel(a.X, a.Y).ToArgb() != replaceColor.ToArgb() &&
                                        bmp.GetPixel(a.X, a.Y).ToArgb() != BorderColor.ToArgb() :
                                      bmp.GetPixel(a.X, a.Y).ToArgb() == targetColor.ToArgb())
                        {
                            bmp.SetPixel(a.X, a.Y, replaceColor);
                            pixels.Push(new Point(a.X - 1, a.Y));
                            pixels.Push(new Point(a.X + 1, a.Y));
                            pixels.Push(new Point(a.X, a.Y - 1));
                            pixels.Push(new Point(a.X, a.Y + 1));
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = CurFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK )
            {
                CurFont = fontDialog1.Font;
                log = log.InsertAtEnd("Font", 0, 0, 0, 0, "", fontDialog1.Font.Size.ToString(), fontDialog1.Font.Name);
            }
        }

        private void bRorate_Click(object sender, EventArgs e)
        {
            float radians = (float)(2 * 3.1416 * Convert.ToInt32(textBox1.Text)) / 360;
            float cosine = (float)Math.Cos(radians);
            float sine = (float)Math.Sin(radians);

            float Point1x = (-image.Height * sine);
            float Point1y = (image.Height * cosine);
            float Point2x = (image.Width * cosine - image.Height * sine);
            float Point2y = (image.Height * cosine + image.Width * sine);
            float Point3x = (image.Width * cosine);
            float Point3y = (image.Width * sine);

            float minx = Math.Min(0, Math.Min(Point1x, Math.Min(Point2x, Point3x)));
            float miny = Math.Min(0, Math.Min(Point1y, Math.Min(Point2y, Point3y)));
            float maxx = Math.Max(Point1x, Math.Max(Point2x, Point3x));
            float maxy = Math.Max(Point1y, Math.Max(Point2y, Point3y));

            int newWidth = (int)Math.Ceiling(Math.Abs(maxx) - minx);
            int newHeight = (int)Math.Ceiling(Math.Abs(maxy) - miny);

            Bitmap newBitMap = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newBitMap).Clear(Color.White);

            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    int SrcBitmapx = (int)((x + minx) * cosine + (y + miny) * sine);
                    int SrcBitmapy = (int)((y + miny) * cosine - (x + minx) * sine);
                    if (SrcBitmapx >= 0 &&
                        SrcBitmapx < image.Width &&
                    SrcBitmapy >= 0 &&
                        SrcBitmapy < image.Height)
                    {
                        newBitMap.SetPixel(x, y, image.GetPixel(SrcBitmapx, SrcBitmapy));
                    }
                }
            }
            pictureBox1.Image = newBitMap;
            g = Graphics.FromImage(newBitMap);
            log = log.InsertAtEnd("Rotate", Convert.ToInt32(textBox1.Text),0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            IsPen = false;
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ((PictureBox)sender).BackColor = colorDialog1.Color;
                ((SolidBrush)CurBrush).Color = colorDialog1.Color;
                log = log.InsertAtEnd("Brush Color", 0, 0, 0, 0, ColorTranslator.ToHtml(Color.FromArgb(colorDialog1.Color.ToArgb())));
            }
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ((PictureBox)sender).BackColor = colorDialog1.Color;
                CurPen.Color = colorDialog1.Color;
                log = log.InsertAtEnd("Pen Color", 0, 0, 0, 0, ColorTranslator.ToHtml(Color.FromArgb(colorDialog1.Color.ToArgb())));
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            IsPen = true;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            log = log.InsertAtEnd("Clear", 0, 0);
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.log = log;
            f.Show();            
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog1.FileName + ".png", ImageFormat.Png);
            }
        }

        private void parametricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog1.FileName + ".txt", ToParametric(log));
            }
        }

        private List<string> ToParametric(MyList log)
        {
            List<string> res= new List<string>();
            MyList cur = log.head;
            if (cur != null)
            {
                while (cur.pointerNext != null && cur != null)
                {
                    if (cur != null && cur.Data.action != "")
                    {
                        res.Add(cur.Data.action);
                        if (cur.Data.x != 0)
                            res.Add(cur.Data.x.ToString());
                        if (cur.Data.y != 0)
                            res.Add(cur.Data.y.ToString());
                        if (cur.Data.width != 0)
                            res.Add(cur.Data.width.ToString());
                        if (cur.Data.height != 0)
                            res.Add(cur.Data.height.ToString());
                        if (cur.Data.color != "")
                            res.Add(cur.Data.color);
                        if (cur.Data.style != "")
                            res.Add(cur.Data.style);
                        if (cur.Data.text != "")
                            res.Add(cur.Data.text);
                    }
                    cur = cur.pointerNext;
                    if (cur == null)
                    {
                        break;
                    }
                }
                if (cur != null && cur.Data.action != "")
                {
                    res.Add(cur.Data.action);
                    if (cur.Data.x != 0)
                        res.Add(cur.Data.x.ToString());
                    if (cur.Data.y != 0)
                        res.Add(cur.Data.y.ToString());
                    if (cur.Data.width != 0)
                        res.Add(cur.Data.width.ToString());
                    if (cur.Data.height != 0)
                        res.Add(cur.Data.height.ToString());
                    if (cur.Data.color != "")
                        res.Add(cur.Data.color);
                    if (cur.Data.style != "")
                        res.Add(cur.Data.style);
                    if (cur.Data.text != "")
                        res.Add(cur.Data.text);
                }
            }
            return res;
        }

        private void ReadLog(MyList log)
        {
            MyList cur = log.head;
            while (cur.pointerNext != null)
            {
                Check(cur);
                cur = cur.pointerNext;
            }
            Check(cur);
        }

        private void Check(MyList cur)
        {
            if (cur.Data.action == "Move")
            {
                LastX = cur.Data.x;
                LastY = cur.Data.y;
            }
            else if (cur.Data.action == "Line")
            {
                g.DrawLine(CurPen, LastX, LastY, cur.Data.x, cur.Data.y);
                LastX = cur.Data.x;
                LastY = cur.Data.y;
            }
            else if (cur.Data.action == "Pen Color")
            {
                CurPen.Color = ColorTranslator.FromHtml(cur.Data.color);
                pictureBox2.BackColor = CurPen.Color;
            }
            else if (cur.Data.action == "Brush Color")
            {
                ((SolidBrush)CurBrush).Color = ColorTranslator.FromHtml(cur.Data.color);
                pictureBox3.BackColor = ((SolidBrush)CurBrush).Color;
            }
            else if (cur.Data.action == "PenSize")
            {
                CurPen.Width = cur.Data.x;
                numericUpDown1.Value = cur.Data.x;
            }
            else if (cur.Data.action == "PenStyle")
            {
                switch (cur.Data.style)
                {
                    case "Solid":
                        CurPen.DashStyle = DashStyle.Solid;
                        break;
                    case "Dash":
                        CurPen.DashStyle = DashStyle.Dash;
                        break;
                    case "DashDot":
                        CurPen.DashStyle = DashStyle.DashDot;
                        break;
                    case "DashDotDot":
                        CurPen.DashStyle = DashStyle.DashDotDot;
                        break;
                    default:
                        break;
                }
            }
            else if (cur.Data.action == "BrushStyle")
            {
                switch (cur.Data.style)
                {
                    case "Solid":
                        ((SolidBrush)CurBrush).Color = Color.FromArgb(0, ((SolidBrush)CurBrush).Color);
                        break;
                    case "CLear":
                        ((SolidBrush)CurBrush).Color = Color.FromArgb(255, ((SolidBrush)CurBrush).Color);
                        break;
                    default:
                        break;
                }
            }
            else if (cur.Data.action == "Rect")
            {
                g.DrawRectangle(CurPen, cur.Data.x, cur.Data.y, cur.Data.width, cur.Data.height);
                g.FillRectangle(CurBrush, cur.Data.x + CurPen.Width / 2, cur.Data.y + CurPen.Width / 2, cur.Data.width - CurPen.Width, cur.Data.height - CurPen.Width);

            }
            else if (cur.Data.action == "Elips")
            {
                g.DrawEllipse(CurPen, cur.Data.x, cur.Data.y, cur.Data.width, cur.Data.height);
                g.FillEllipse(CurBrush, cur.Data.x + CurPen.Width / 2, cur.Data.y + CurPen.Width / 2, cur.Data.width - CurPen.Width, cur.Data.height - CurPen.Width);

            }
            else if (cur.Data.action == "Font")
            {
                CurFont = new Font(cur.Data.text, Convert.ToInt32(cur.Data.style));
            }
            else if (cur.Data.action == "Text")
            {
                g.DrawString(cur.Data.text, CurFont, CurPen.Brush, cur.Data.x, cur.Data.y);
            }
            else if (cur.Data.action == "Pen")
            {
                CurPen.Color = image.GetPixel(cur.Data.x, cur.Data.y);
                pictureBox2.BackColor = CurPen.Color;
            }
            else if (cur.Data.action == "Brush")
            {
                ((SolidBrush)CurBrush).Color = image.GetPixel(cur.Data.x, cur.Data.y);
                pictureBox3.BackColor = ((SolidBrush)CurBrush).Color;
            }
            else if (cur.Data.action == "EraseStart")
            {
                g.FillRectangle(new SolidBrush(Color.White), cur.Data.x - CurPen.Width, cur.Data.y - CurPen.Width, CurPen.Width * 3, CurPen.Width * 3);
            }
            else if (cur.Data.action == "Erase")
            {
                g.FillRectangle(new SolidBrush(Color.White), cur.Data.x - CurPen.Width, cur.Data.y - CurPen.Width, CurPen.Width * 3, CurPen.Width * 3);
            }
            else if (cur.Data.action == "Fill")
            {
                FloodFill(image, new Point(cur.Data.x,cur.Data.y), ((SolidBrush)CurBrush).Color, CurPen.Color);
            }
            else if (cur.Data.action == "Copy")
            {
                CopyClipboard = new Bitmap(cur.Data.width, cur.Data.height);
                Graphics.FromImage(CopyClipboard).DrawImage(image, 0, 0, new Rectangle(cur.Data.x, cur.Data.y, cur.Data.width, cur.Data.height), GraphicsUnit.Pixel);
            }
            else if (cur.Data.action == "Paste")
            {
                g.DrawImage(CopyClipboard, cur.Data.x, cur.Data.y);
            }
            else if (cur.Data.action == "Clear")
            {
                g.Clear(pictureBox1.BackColor);
            }
            else if (cur.Data.action == "Open")
            {
                image = new Bitmap(cur.Data.text);
            }
        }

        private void unDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsSaved)
            {
                OldLog = OldLog.Copy(log);
                IsSaved = true;
            }
            log = log.undo();
            upd(log);
        }

        private void reDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log = log.redo(OldLog);
            upd(log);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog1.FileName);
                g = Graphics.FromImage(image);
                pictureBox1.Image = image;
                log = log.InsertAtEnd("Open", 0, 0, 0, 0, "", "", openFileDialog1.FileName);
            }
        }

        private void upd(MyList log)
        {
            CurFont = new Font("Times New Roman", 12, FontStyle.Regular);
            CurPen.Width = 2;
            CurPen.Color = Color.Black;
            ((SolidBrush)CurBrush).Color = Color.White;

            g.Clear(Color.White);
            ReadLog(log);
            pictureBox1.Refresh();
        }

        private void openParametricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                log = log.ConvertToMyList(File.ReadAllLines(openFileDialog1.FileName).ToList());
            }
            upd(log);
        }
    }
}
