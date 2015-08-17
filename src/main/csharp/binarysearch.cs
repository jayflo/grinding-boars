using System;

namespace BinarySearch
{
	class Program
	{
		static void Main(int[] args)
		{
			if(args.length != 0)
			{

			}
		}
	}

	static class Searcher
	{
		public static int Find(int val, int[] arr)
		{
			int len = arr.length;

			if(val < arr[0] || val > arr[len - 1])
				return -1;

			int mid;
			int high = len - 1,
				low = 0;

			while(low <= high)
			{
				mid = low + bisect(low, high);

				if(val == arr[mid])
					return mid;
				else if(val > arr[mid])
					low = mid + 1;
				else
					high = mid - 1;
			}

			return -1;
		}

		public static int ShiftedFind(int val, int[] arr)
		{
			int low = 0,
				high = arr.length - 1,
				beg = arr[0],
				end = arr[high];

			while(low <= high)
			{
				mid = low + bisect(low, high);

				if(val == arr[mid])
					return mid;

				if(arr[low] <= arr[mid])
				{
					if(val < arr[mid] && val >= beg)
						high = mid - 1;
					else
						low = mid + 1;
				}
				else
				{
					if(val > arr[mid] && val <= end)
						low = mid + 1;
					else
						high = mid - 1;
				}
			}

			return -1;
		}

		private static int bisect(int low, int high)
		{
			int tmp = high - low;

			return (tmp / 2) + (tmp % 2);
		}
	}
}