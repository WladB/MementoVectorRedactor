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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Figure.g = this.CreateGraphics();
            Figure.bkcolor = this.BackColor;
        }
        Random rand = new Random();
        string LastFig="";
        //  List<Figure> figures = new List<Figure>();
        Figures figures = new Figures();
        bool move=false;
        Color SaveColor = Color.Black;
        Point lastP;
       
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Rectangle_ rect = new Rectangle_();        
            rect.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            rect.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height-rect.size.Height));
            rect.color = Color.Blue;
            rect.show();
            figures.add(rect);
            comboBox1.Items.Add(rect);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Triangle triangle = new Triangle();
            triangle.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            triangle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - triangle.size.Height));
            triangle.DeltaApex = rand.Next(0, rand.Next(0, triangle.size.Width));
            triangle.type = "triangle";
            triangle.color = Color.Green;
            triangle.show();
            figures.add(triangle);
            comboBox1.Items.Add(triangle);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Circle circle = new Circle();
            circle.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            circle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - circle.size.Height));
            circle.color = Color.Red;
            circle.show();
            figures.add(circle);
            comboBox1.Items.Add(circle);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (LastFig != "")
            {
                ((Figure) comboBox1.Items[Convert.ToInt32(LastFig)]).color = SaveColor;
                ((Figure)comboBox1.Items[Convert.ToInt32(LastFig)]).show();
            }
             SaveColor = ((Figure)comboBox1.SelectedItem).color;
            
            ((Figure)comboBox1.SelectedItem).color = Color.Orange;
            label1.Text= "S = "+((Figure)comboBox1.SelectedItem).area();
            
            ((Figure)comboBox1.SelectedItem).show();
            LastFig = comboBox1.SelectedIndex.ToString();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Figure f = figures.selected(e.X,e.Y);
           
                 
                if (f!=null)
                {
                    if (LastFig == "")
                    {
                        SaveColor = f.color;
                    }
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(f);
                    
                    f.color = Color.Orange;
                    move = true;
                    lastP = new Point(e.X, e.Y);
    
                }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(move){
                ((Figure)comboBox1.SelectedItem).color= SaveColor;
                ((Figure)comboBox1.SelectedItem).show();
            }
          
            move = false;
           
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                ((Figure)comboBox1.SelectedItem).move(e.X - lastP.X, e.Y - lastP.Y);
                lastP.X = e.X;
                lastP.Y = e.Y;
               figures.show(); 
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (comboBox1.SelectedIndex != -1)
            {
                Editing f = new Editing();
                Editing.curfig = ((Figure)comboBox1.SelectedItem);

                f.ShowDialog();
                Figure.g = this.CreateGraphics();
                Figure.bkcolor = this.BackColor;
                if (f.DialogResult == DialogResult.OK)
                {
                    Figure.g.Clear(this.BackColor);
                   figures.show();
                }
            }
            else {
                MessageBox.Show("Фігуру не обрано, оберіть будь ласка фігуру!");
            }
            /*if (f.DialogResult == DialogResult.OK){
                ((Figure)comboBox1.SelectedItem).hide();
                ((Figure)comboBox1.SelectedItem).size.Width = f.curfig.size.Width;
                ((Figure)comboBox1.SelectedItem).size.Height = f.curfig.size.Height;
                ((Figure)comboBox1.SelectedItem).show();
            }*/
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Cube rect = new Cube();
            rect.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            rect.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - rect.size.Height));
            rect.color = Color.Blue;
            rect.show();
            figures.add(rect);
            comboBox1.Items.Add(rect);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Cilindr rect = new Cilindr();
            rect.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
          //  rect.d = rand.Next(10, 30);
            rect.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - rect.size.Height));
            rect.color = Color.Blue;
            rect.show();
            figures.add(rect);
            comboBox1.Items.Add(rect);
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            Triangle triangle = new Triangle();
            triangle.type = "triangle";
            triangle.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            triangle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - triangle.size.Height));
            triangle.DeltaApex = 0;
            triangle.color = Color.Green;
            triangle.show();
            figures.add(triangle);
            comboBox1.Items.Add(triangle);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Triangle triangle = new Triangle();
            triangle.type = "triangle";
            triangle.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            triangle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - triangle.size.Height));
            triangle.DeltaApex = triangle.size.Width/2;
            triangle.color = Color.Green;
            triangle.show();
            figures.add(triangle);
            comboBox1.Items.Add(triangle);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Triangle triangle = new Triangle();
            triangle.type = "triangle";
            int a = rand.Next(50, 100);
            triangle.size = new Size(a, a);
            triangle.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - triangle.size.Height));
            triangle.DeltaApex = triangle.size.Width / 2;
            triangle.color = Color.Green;
            triangle.show();
            figures.add(triangle);
            comboBox1.Items.Add(triangle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ellipse rect = new Ellipse();
            rect.size = new Size(rand.Next(50, 100), rand.Next(50, 100));
            rect.point = new Point(rand.Next(0, this.ClientRectangle.Width), rand.Next(panel1.Height + 10, this.ClientRectangle.Height - rect.size.Height));
            rect.color = Color.Blue;
            rect.show();
            figures.add(rect);
            comboBox1.Items.Add(rect);
        }

        private void SaveB_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK){
                figures.save(saveFileDialog1.FileName);
            }
           
        }

        private void OpenB_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBox1.Items.AddRange(figures.open(openFileDialog1.FileName, comboBox1.Items.Cast<Figure>().ToArray()));
            } 
        }
    }
}
