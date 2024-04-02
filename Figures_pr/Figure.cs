using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Figures_pr
{
     public class Figure
    {
        public static Graphics g;
        public Point point;
        public Color color;
        public static Color bkcolor;
        public Size size;
        public string type="default";
        public int DeltaApex;
        public Figure(){ 
        
        }
        public Figure(Figure f)
        {
         point=f.point;
         color= f.color;
         size= f.size;
        }
        protected virtual void draw(Color cl) { }
        public virtual double area() { return 0; }

        public void move(int dx, int dy){
            hide();
            point.X += dx;
            point.Y += dy;
            show();
        }

        public void hide(){
            draw(bkcolor);
        }
        public void show()
        {
            draw(color);
            area();
        }
    }

    class Rectangle_ : Figure
    {
        public Rectangle_()
        {
            type = "rect";
        }
        public Rectangle_(Figure f):base(f)
        {
            type = "rect";
        }
        public override double area(){
            return size.Width*size.Height;
        }
        protected override void draw(Color cl) {
            g.DrawRectangle(new Pen(cl), point.X, point.Y, size.Width, size.Height);
        }
    }
    class Triangle : Figure
    {
        public Triangle()
        {
            type = "triangle";
            
        }
        public Triangle(Figure f):base(f)
        {
            type = "triangle";
            DeltaApex = f.DeltaApex;
        }
     
        public Point A = new Point();
        public Point B = new Point();
        public Point C = new Point();
        public override double area()
        {
            

           // S = 0.5 * Math.Abs((point.X* point.Y)+ ((point.X + DeltaApex)* (point.Y + size.Height))+(point.X* (point.Y + size.Height))-((point.X+DeltaApex)* (point.Y + size.Height))-(point.X*point.Y)-(point.X*(point.Y+ size.Height)));
              System.Windows.Vector AB = new System.Windows.Vector(point.X + size.Width - point.X, point.Y + size.Height - (point.Y + size.Height));
              System.Windows.Vector AC = new System.Windows.Vector(point.X + DeltaApex - point.X, point.Y - (point.Y + size.Height));
              return Math.Abs(AB.X * AC.Y - AB.Y * AC.X)/2;


             
            /*PointF A = new PointF(point.X, point.Y + size.Height);
            PointF B = new PointF(point.X + size.Width, point.Y + size.Height);
            PointF C = new PointF(point.X + DeltaApex, point.Y);
            double x1 = point.X;
            double y1 = point.Y + size.Height;
            double x2 = point.X + DeltaApex;
            double y2 = point.Y;
            double x3 = point.X;
            double y3 = point.Y + size.Height;
           
                double AB = Math.Sqrt((B.x - A.x) * (B.x - A.x) + (B.Y - A.Y) * (B.Y - A.Y));
            double AC = Math.Sqrt((C.x - A.x) * (C.x - A.x) + (C.Y - A.Y) * (C.Y - A.Y));
            double BC = Math.Sqrt((C.x - B.x) * (C.x - B.x) + (C.Y - B.Y) * (C.Y - B.Y));
            double p = (AB + AC + BC) / 2;
            S = Math.Sqrt(p * (p - AC) * (p - AB) * (p - BC));*/
          
        }
        
        protected override void draw(Color cl)
        {
             A = new Point(point.X, point.Y + size.Height);
             B = new Point(point.X + size.Width, point.Y + size.Height);
             C = new Point(point.X + DeltaApex, point.Y);

            g.DrawLine(new Pen(cl), point.X, point.Y+size.Height, point.X+size.Width, point.Y +size.Height);
            g.DrawLine(new Pen(cl), point.X + size.Width, point.Y + size.Height, point.X+DeltaApex,point.Y);
            g.DrawLine(new Pen(cl), point.X + DeltaApex, point.Y, point.X, point.Y + size.Height);
        }
    }
    class Cube : Figure {

        public Cube()
        {
            type = "cube";
        }
        public Cube(Figure f):base(f)
        {
            type = "cube";
        }
        public override double area()
        {
            float dx = size.Width / 17;
            float dy = size.Height / 17;
            double a = Math.Sqrt(Math.Pow(((point.X + 8 * dx) - (point.X + 8 * dx)), 2) + Math.Pow(((point.Y + 17 * dy) - (point.Y + 7.5f * dy)), 2));
            double b = Math.Sqrt(Math.Pow(((point.X + 1 * dx) - (point.X + 1 * dx)), 2) + Math.Pow(((point.Y + 14 * dy) - (point.Y + 4.2f * dy)), 2));
            double c = Math.Sqrt(Math.Pow(((point.X + 15 * dx) - (point.X + 15 * dx)), 2) + Math.Pow(((point.Y + 14 * dy) - (point.Y + 4.2f * dy)), 2));

           
            return 2 * (a * b + b * c + a * c);
        }
        protected override void draw(Color cl)
        {
             float dx = size.Width / 17;
             float dy = size.Height / 17;
             Pen pen = new Pen(cl, 2);


            g.DrawLine(pen, point.X + 1 * dx, point.Y + 4 * dy, point.X + 8 * dx, point.Y + 1 * dy);
            g.DrawLine(pen, point.X + 8 * dx, point.Y + 1 * dy, point.X + 15 * dx, point.Y + 4 * dy);
            g.DrawLine(pen, point.X + 1 * dx, point.Y + 4.2f * dy, point.X + 8 * dx, point.Y + 7.5f * dy);
            g.DrawLine(pen, point.X + 15 * dx, point.Y + 4.2f * dy, point.X + 8 * dx, point.Y + 7.5f * dy);
            g.DrawLine(pen, point.X + 1 * dx, point.Y + 14 * dy, point.X + 8 * dx, point.Y + 17 * dy);
            g.DrawLine(pen, point.X + 15 * dx, point.Y + 14 * dy, point.X + 8 * dx, point.Y + 17 * dy);
            //b
            g.DrawLine(pen, point.X + 1 * dx, point.Y + 4.2f * dy, point.X + 1 * dx, point.Y + 14 * dy);
            //c
            g.DrawLine(pen, point.X + 15 * dx, point.Y + 4.2f * dy, point.X + 15 * dx, point.Y + 14 * dy);
            //a
            g.DrawLine(pen, point.X + 8 * dx, point.Y + 7.5f * dy, point.X + 8 * dx, point.Y + 17 * dy);

          
        }
    }
    class Cilindr : Figure
    {
        public float R;
        public Cilindr(){
            type = "cilindr";
        }
        public Cilindr(Figure f):base(f)
        {
            type = "cilindr";
        }
        public override double area()
        {
            //2πR2 + 2πRH
            R = size.Width / 2;
           //double h= Math.Sqrt(Math.Pow(((point.X) - (point.X)), 2) + Math.Pow(((point.Y + size.Height + R / 2) - (point.Y + R / 2)), 2));
           
            return 2*(Math.PI*R*size.Height)+ 2* (Math.PI*(R*R));

        }

        protected override void draw(Color cl)
        {
            float dx = size.Width / 17;
            float dy = size.Height / 17;
            Pen pen = new Pen(cl, 2);
            R = size.Width / 2;

          //  R = ;


            g.DrawEllipse(pen, point.X , point.Y, size.Width, R);
            g.DrawEllipse(pen, point.X, point.Y+size.Height, size.Width , R);
            g.DrawLine(pen, point.X, point.Y+ R / 2, point.X, point.Y+size.Height + R / 2);
            g.DrawLine(pen, point.X+size.Width, point.Y+ R / 2, point.X + size.Width, point.Y + size.Height + R / 2);

        }
    }
      
    class Circle : Figure
    {
        public Circle()
        {
            type = "cr";
        }
        public Circle(Figure f):base(f)
        {
            type = "cr";
        }
        public override double area()
        {
            return Math.PI * ((size.Width / 2)* (size.Width / 2));
        }
        protected override void draw(Color cl)
        {
            g.DrawEllipse(new Pen(cl), point.X, point.Y, size.Width, size.Width);
        }
    }
    class Ellipse : Figure
    {
        public Ellipse()
        {
            type = "el";
        }
        public Ellipse(Figure f) : base(f)
        {
            type = "el";
        }
        public override double area()
        {
           return Math.PI * (size.Width / 2) * (size.Height / 2);
        }
        protected override void draw(Color cl)
        {
            g.DrawEllipse(new Pen(cl), point.X, point.Y, size.Width, size.Height);
        }
    }
    class EditingRectangle : Figure
    {
        public override double area()
        {
            return 0;
        }
        protected override void draw(Color cl)
        {
            Pen pen = new Pen(cl);
            // Верхняя горизонтальная линия
            g.DrawLine(pen, 0, 0, size.Width, 0);

            // Правая вертикальная линия
            g.DrawLine(pen, size.Width, 0, size.Width, size.Height);

            // Нижняя горизонтальная линия
            g.DrawLine(pen, 0, size.Height, size.Width, size.Height);

            // Левая вертикальная линия
            g.DrawLine(pen, 0, 0, 0, size.Height);
        }
    }
        public class Figures : Figure
    {
        List<Figure> figures = new List<Figure>();
        public void show()
        {
            foreach (Figure f in figures)
            {
                f.show();
            }
        }

        public void add(Figure f) {
            figures.Add(f);
        }
        public Figure selected(int x, int y) {
            foreach (Figure f in figures)
            {

                if (f.point.X < x && f.size.Width + f.point.X > x && f.point.Y < y && f.size.Height + f.point.Y > y)
                {
                    return f;
                }

            }
            return null;
        }
        public void save(string filename){
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(filename))
            {
                //try
               // {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {

                        serializer.Serialize(writer, figures);
                        sw.Close();
                        writer.Close();
                    }
              //  }
               // catch
               // {
               //     sw.Close();
               // }
            }              
        }
        void set_type(){
            for (int i=0; i<figures.Count;i++) { 
                // if (f.type == "rect") { }
                switch (figures[i].type)
                {
                    case "rect": figures[i] = new Rectangle_(figures[i]);
                    figures[i].show();    
                    break;
                    case "cr":
                    figures[i] = new Circle(figures[i]);
                    figures[i].show();
                    break;
                    case "el":
                        figures[i] = new Ellipse(figures[i]);
                        figures[i].show();
                        break;
                    case "triangle":
                        figures[i] = new Triangle(figures[i]);
                        figures[i].show();
                        break;
                    case "cube":
                        figures[i] = new Cube(figures[i]);
                        figures[i].show();
                        break;
                    case "cilindr":
                        figures[i] = new Cilindr(figures[i]);
                        figures[i].show();
                        break;
                }
            }
        }
        public Figure[] open(string filename, Figure[] fig)
        {
           
            StreamReader sr = new StreamReader(filename);
            string output = sr.ReadLine();
            figures = JsonConvert.DeserializeObject<List<Figure>>(output);
            set_type();
            show();
            // MessageBox.Show(figures.Count.ToString());
            sr.Close();
            figures.AddRange(fig);
            return figures.ToArray();
        }
        public override double area()
        {
            throw new NotImplementedException();
        }

        protected override void draw(Color cl)
        {
            throw new NotImplementedException();
        }
    }
}
