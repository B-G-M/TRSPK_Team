using System;

namespace task_3_6
{
	class Point
	{
		public Point()
		{
		}
		public Point(int x,int y)
		{
			this.x = x;
			this.y = y;
		}
		public Point(Point point)
		{
			x = point.x;
			y = point.y;
		}
		private int x;
		public int X
		{
			get { return x; }
			set { x = value; }
		}

		private int y;
		public int Y
		{
			get { return y; }
			set { y = value; }
		}
	}

	class Quadrangle
	{
		public Quadrangle(Point a, Point b, Point c, Point d)
		{
			points = new Point[] { a, b, c, d };
		}
		Point[] points;

		double perimeter = 0;
		double area = 0;

		private bool IsItQuad(Point[] points)
		{
			Point temp,
				  temp1,
				  temp2;
			bool itQuad = true;

				for (int j = 0; j < 3; j++)
				{
					int k = j + 1;
					temp1 = points[j];
					temp2 = points[j + 1];
					for (int t = 0; t < 2; t++)
					{
						k = (k + 1) > 3 ? 0 : k + 1;
						temp = points[k];

						if ((double)(temp.X - temp1.X) / (temp2.X - temp1.X) == (double)(temp.Y - temp1.Y) / (temp2.Y - temp1.Y))
						{
							itQuad = false;
							return itQuad;
						}
					}
				}
			return itQuad;
		}

		public bool PerimeterAndArea(out double Perimeter, out double Area)
		{
			if(!IsItQuad(points))
			{
				Perimeter = -1;
				Area = -1;
				return false;
			}
			for (int i = 0; i < 3; i++)
			{
				area += (points[i].X - points[i + 1].X) * (points[i].Y + points[i + 1].Y);
				perimeter += Math.Sqrt(Math.Pow(points[i + 1].X - points[i].X, 2) + Math.Pow(points[i + 1].Y - points[i].Y, 2));
			}
			area += (points[3].X - points[0].X) * (points[3].Y + points[0].Y);
			area = 0.5 * Math.Abs(area);
			perimeter += Math.Sqrt(Math.Pow(points[3].X - points[0].X, 2) + Math.Pow(points[3].Y - points[0].Y, 2));

			Perimeter = perimeter;
			Area = area;
			return true;
		}
	}



	class Program
	{
		static void Main(string[] args)
		{
			double perimeter,
				   area;
			Point p1 = new(8, 4);
			Point p2 = new(7, 8);
			Point p3 = new(6, 8);
			Point p4 = new(2, 6);
			Quadrangle quadrangle = new(p1, p2, p3, p4);
			quadrangle.PerimeterAndArea(out perimeter,out area);
			Console.WriteLine("Периметр = " + perimeter);
			Console.WriteLine("Площадь = " + area);
		}
	}
}
