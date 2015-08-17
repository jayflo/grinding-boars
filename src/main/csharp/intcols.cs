using System;

namespace List
{
	public static class Printer
	{
		public static void Print(int[] arr, int numCols)
		{
			int len = arr.length;
			int numRows = len / numCols;
			int overflow = len % numCols;

			int i = -1, index = 0, col = 0, row = 0;

			string output = "";

			while(++i < len)
			{
				output += arr[index].ToString() + " ";
				index += numCols + (col++ < overflow ? 1 : 0);

				if(col >= numCols)
				{
					Console.WriteLine(output);
					output = "";
					col = 0;
					index = ++row;
				}
			}

			Console.WriteLine(output);

			return;
		}
	}
}