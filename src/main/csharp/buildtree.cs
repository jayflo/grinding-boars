using System;
using System.Collections.Generic;

namespace BuildTree
{
	class BuildTreeProgram
	{
		static void Main()
		{

		}
	}

	public class Relation
	{
		public int? Parent;
		public int Child;
		public bool IsLeft;

		public Relation(int? p, int c, bool l)
		{
			Parent = p;
			Child = c;
			IsLeft = l;
		}
	}

	public class Node
	{
		public int Key;
		public Node Left;
		public Node Right;

		public Node(int k)
		{
			Key = k;
			Left = null;
			Right = null;
		}

		public static Node BuildTree(List<Relation> relations)
		{
			Dictionary<int, Node> lookup = new Dictionary<int, Node>();
			Node tmpChild, tmpParent, root;

			foreach(Relation rel in relations)
			{
				tmpChild = GetOrCreateNode(rel.Child, lookup);

				if(rel.Parent != null)
				{
					tmpParent = GetOrCreateNode(rel.Parent, lookup);

					if(rel.IsLeft)
						tmpParent.Left = tmpChild;
					else
						tmpParent.Right = tmpChild;
				}
				else 
				{
					root = tmpChild;
				}
			}

			return root;
		}

		private static Node GetOrCreateNode(int key, Dictionary<int, Node> lookup)
		{
			if(!lookup.ContainsKey(key))
				lookup.Add(key, new Node(key));

			return lookup[key];
		}
	}
}