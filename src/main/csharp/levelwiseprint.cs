using System;

namespace LevelwisePrint
{
	class Tree
	{
		public Node Root;

		public Tree(Node root)
		{
			Root = root;
		}

		public void LevelwisePrint()
		{
			List<Node> levelOne = new List<Node>() { Root };

			RecursivePrint(levelOne);
		}

		public void RecursivePrint(List<Node> nodeList)
		{
			Console.WriteLine(String.Join<Node>(" ", nodeList));
			List<Node> nextLevel = new List<Node>();
			Node tmp;

			for(int i = 0, len = nodeList.Count; i < len; i++)
			{
				tmp = nodeList[i];

				if(tmp.Left != null)
					nextLevel.Add(tmp.Left);
				if(tmp.Right != null)
					nextLevel.Add(tmp.Right);
			}

			if(nextLevel.Count > 0)
				RecursivePrint(nextLevel);
		}
	}

	class Node
	{
		public Node Left;
		public Node Right;
		public int Key;

		public Node()
		{
			Left = null;
			Right = null;
		}

		public override ToString()
		{
			return Key.ToString();
		}
	}
}