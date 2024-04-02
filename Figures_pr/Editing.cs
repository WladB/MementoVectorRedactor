using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figures_pr
{
    public partial class Editing : Form
    {
        public Editing()
        {
            InitializeComponent();
            
        }
        static public Figure curfig;
        Figure Savefig = curfig;
        Point savepoint = new Point();
        Triangle triangle;
        bool IsTriangle = false;
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void Editing_Load(object sender, EventArgs e)
        {
            Figure.g = panel1.CreateGraphics();
            Figure.bkcolor = panel1.BackColor;
           
            savepoint = curfig.point;
            WidthB.Value = curfig.size.Width;
            HeightB.Value = curfig.size.Height;
            if (curfig.type == "triangle"){
                DeltaApexB.Visible = true;
                label3.Visible = true;
                IsTriangle = true;
                triangle = new Triangle();
                triangle = (Triangle)curfig;
                DeltaApexB.Value = triangle.DeltaApex;
                DeltaApexB.Maximum = triangle.size.Width+1;
            }
        }

        private void Editing_MouseDown(object sender, MouseEventArgs e)
        {

           // if (curfig.C < e.X && )
          //  {
               
            //}
        }

        private void Editing_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Editing_MouseUp(object sender, MouseEventArgs e)
        {
          
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            curfig.hide();
            curfig.size.Width = WidthB.Value;
            curfig.show();
        }

        private void Height_Scroll(object sender, ScrollEventArgs e)
        {
            curfig.hide();
            curfig.size.Height = HeightB.Value;
            curfig.show();
        }

        private void Editing_Shown(object sender, EventArgs e)
        {
            curfig.point = new Point(panel1.Width / 2, panel1.Height / 2);
            curfig.show();
        }

        private void Editing_FormClosed(object sender, FormClosedEventArgs e)
        {
            curfig.point = savepoint;
            if (this.DialogResult == DialogResult.Cancel)
            {
                curfig = Savefig;
            }
        }

        private void DeltaApexB_Scroll(object sender, ScrollEventArgs e)
        {
            if (IsTriangle)
            {
                triangle.hide();
                triangle.DeltaApex = DeltaApexB.Value;
                triangle.show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
