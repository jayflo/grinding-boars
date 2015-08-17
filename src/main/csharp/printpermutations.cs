using System;

namespace PrintPermutations
{
	static class PermutationPrinter
	{
		public static void Print(string permuted, string pool)
		{
			if(pool.length == 0)
				Console.WriteLine(permuted);
			else
			{
				for(int i = 0, len = pool.length; i < len; i++)
				{
					Print(permuted + pool[i], pool.removeAt(i));
				}
			}
		}
	}

	public static class StringExtensions
	{
		public static string removeAt(this string str, int i)
		{
			return str.Substring(0, i+1) + str.Substring(i+1);
		}
	}
}