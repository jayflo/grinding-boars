using System;

namespace MyMath
{
	public static class Math
	{
		public double Power(double a, int b)
		{
			if(b == 0)
				return 1.0;
			if(b == 1)
				return a;

			if(b < 0)
				return 1.0/pow(a, -1 * b);
			else 
				return pow(a, b);
		}

		private double pow(double a, int b)
		{
			if(b == 1)
				return a;
			else if(b % 2 == 0)
			{
				double tmp = pow(a, b/2);
				return tmp * tmp;
			}
			else
			{
				double tmp 
			}
		}
	}
}