using System;
using System.Collections.Generic;

namespace MathStuff
{
	public interface PointsOnAPlane
	{
		void addPoint(Point p);
		Collection<Point> findNearest(Point center, int count);
	}

	public class PointCache : PointsOnAPlane
	{
		private List<Point> points;

		public PointCache()
		{
			points = new List<Point>();
		}

		public void addPoint(Point p)
		{
			points.Add(p);
		}

		public Collection<Point> findNearest(Point center, int count)
		{
			List<double> dist = new List<double>();

			for(int i = 0, len = points.length; i < len; i++)
			{
				dist.Add(center.DistanceTo(points[i]));
			}

			Sort(dist);

			return new Collection(new)
		}
	}

	public class Point
	{
		public int x;
		public int y;

		public Point() {}
		public Point(int a, int b)
		{
			x = a;
			y = b;
		}

		public double DistanceTo(Point p)
		{
			return Math.Sqrt(Math.Pow(x - p.x, 2) + Math.Pow(y - p.y, 2));
		}

		public int this[int i]
		{
			get
			{
				return i < 1 ? x : y;
			}
			set
			{
				if(i < 1)
					x = value;
				else
					y = value;
			}
		}
	}
}