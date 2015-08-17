using System;
using System.Collections.Generic;

namespace ArrayTriples
{
	class Program
	{
		static void Main()
		{

		}
	}

	class TripleBuilder
	{
		HashSet<int> complete;
		List<int> values;
		List<Tuple<int, int>> pairs;
		List<Tuple<int,int,int>> triples;

		public TripleBuilder()
		{
			complete = new HashSet<int>();
			values = new List<int>();
			pairs = new List<Tuple<int,int>>();
			triples = new List<Tuple<int,int,int>>();
		}

		public List<Tuple<int,int,int>> Build(int[] arr)
		{
			int i = arr.length;
			int tmp;

			while(i-- > 0)
			{
				if(complete.Contains(arr[i]))
					continue;

				tmp = arr[i];
				CreateTriples(tmp);
				CreatePairs(tmp);
				values.Add(tmp);
				complete.Add(tmp);
			}

			return triples;
		}

		private void Createtriples(int a)
		{
			int i = pairs.length;

			while(i-- > 0)
			{
				triples.Add(Tuple.Create(pairs[i].Item1, pairs[i].Item2, a));
			}
		}

		private void CreatePairs(int a)
		{
			int i = values.Count;

			while(i-- > 0)
			{
				pairs.Add(Tuple.Create(values[i], a))
			}
		}
	}
}