using System;

namespace Intervals
{
	public interface IIntervals
	{
		void addInterval(int a, int b);
		int getTotalCoveredLength();
	}

	public class Intervals : IIntervals
	{
		public void addInterval(int a, int b)
		{

		}

	}

	

	class OrderedPair
	{
		int left;
		int right;
		public int length;

		public OrderedPair(int left, int right)
		{
			this.left = left;
			this.right = right;
			length = right - left;
		}

		public bool Contains(int x)
		{
			return x >= left && x <= right;
		}

		public bool Intersect(int x, int y)
		{
			return left <= y && x <= right;
		}

		public int Merge(int x, int y)
		{
			if(!Intersect(x,y))
				return -1;

			if(Contains(x))
			{
				if(Contains(y))
					return 0;

				right = y;
			}
			else if(Contains(y))
				left = x;
	
			int tmp = length;
			length = right - left;

			return length - tmp;
		}
	}
}