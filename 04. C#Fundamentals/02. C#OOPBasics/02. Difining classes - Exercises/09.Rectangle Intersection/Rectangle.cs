using System;

namespace _09.Rectangle_Intersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double x;
        private double y;
        private double bottomX;
        private double bottomY;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.bottomX = this.x + this.width;
            this.bottomY = this.y + this.height;
        }

        public string Id { get { return this.id; } set { this.id = value; } }
        public double Width { get { return this.width; } set { this.width = value; } }
        public double Height { get { return this.height; } set { this.height = value; } }
        public double X { get { return this.x; } set { this.x = value; } }
        public double Y { get { return this.y; } set { this.y = value; } }


        public bool Intersects(Rectangle rec2)
        {
            if (this.x > rec2.bottomX || rec2.x > this.bottomX)
            {
                return false;
            }

            if (this.y < rec2.bottomY || rec2.y < this.bottomY)
            {
                return false;
            }

            return true;
        }
    }
}
