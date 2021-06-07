using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Island_Levy
{
    public partial class Form1 : Form
    {
        Pen p;
        SolidBrush fon;
        Graphics gr;

        int i = 15;

        public Form1()
        {
            InitializeComponent();

            p = new Pen(Color.Black, 1);
            fon = new SolidBrush(Color.White);
            gr = pictureBox1.CreateGraphics();
        }

        void Draw_Levy(Graphics gr, Pen p, SolidBrush fon, double x1, double x2, double y1, double y2, int i)//x1начальная координата  x2 конечная
        {
            if (i == 0)
            {
                gr.DrawLine(p, (int) x1, (int) y1, (int)x2, (int)y2);
            }
            else
            {
                double x3 = (x1 + x2) / 2 + (y2 - y1) / 2;//задаем следующие координаты
                double y3 = (y1 + y2) / 2 - (x2 - x1) / 2;

                Draw_Levy(gr, p, fon, x1, x3, y1, y3, i - 1);
                Draw_Levy(gr, p, fon, x3, x2, y3, y2, i - 1);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            gr.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height);

            Draw_Levy(gr, p, fon, 250, 400, 160, 160, i); // Строим кривую Леви на каждой стороне квадрата
            Draw_Levy(gr, p, fon, 400, 400, 160, 310, i); 
            Draw_Levy(gr, p, fon, 400, 250, 310, 310, i); 
            Draw_Levy(gr, p, fon, 250, 250, 310, 160, i); 
        }

    }
}
