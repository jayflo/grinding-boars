using System;

namespace LinkedIn
{
	public class Finder
	{
		int RepeatedHalfLength(int[] arr)
		{
			int distanceToEnd = arr.length,
				halfLen = arr.length / 2 + 1,
				distanceFromMaxCountToHalf = halfLen;

			Dictionary<int,int> count = new Dictionary<int,int>();

			int tmp, i = 0, maxCount = 0;

			while(distanceToEnd >= distanceFromMaxCountToHalf)
			{
				tmp = arr[i];

				if(count.ContainsKey(tmp))
					count[tmp]++;
				else
					count.Add(tmp, 1);

				if(count[tmp] == halfLen)
					return tmp;

				if(count[tmp] > maxCount)
					maxCount = count[tmp];

				distanceFromMaxCountToHalf = halfLen - maxCount;
				distanceToEnd--;
			}

		}
	}
}