using System;
using System.Collections.Generic;

namespace TwoSumSpace
{
	class TwoSumProgram
	{
		static void Main()
		{

		}
	}

	interface ITwoSum
	{
		void Store(int val);
		bool test(int val);
	}

	class TwoSum : ITwoSum
	{
		HashSet<int> Sums;
		List<int> Values;

		public void Store(int val)
		{
			int i = Values.length;
			int tmp;

			while(i-- > 0)
			{
				Sums.Add(Values[i] + val);
			}
		}

		public bool test(int val)
		{
			return Sums.Contains(val);
		}
	}
}