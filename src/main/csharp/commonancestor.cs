using System;
using System.Collections.Generic;

namespace CommonAncestor
{
	public interface FirstCommonAncestor 
	{ 
		Node commonAncestor(Node nodeOne, Node nodeTwo) {}
	} 

	class AncestorFinder : FirstCommonAncestor
	{
		public Node commonAncestor(Node nodeOne, Node nodeTwo)
		{
			if(nodeOne.isRoot())
				return nodeOne;

			if(nodeTwo.isRoot())
				return nodeTwo;

			if(nodeOne == nodeTwo)
				return nodeOne;

			List<Node> branchOne = GetBranch(nodeOne); // log(h)
			List<Node> branchTwo = GetBranch(nodeTwo); // log(h)
			int lenOne = branchOne.length;
			int lenTwo = branchTwo.length;

			while(branchOne[lenOne - 1] == branchTwo[lenTwo - 1])
			{
				lenOne--;
				lenTwo--;
			}

			return branchOne[lenOne];
		}

		public List<Node> GetBranch(Node node)
		{
			List<Node> tmp = new List<Node>();

			while(!node.isRoot())
				tmp.Add(node.parent)

			return tmp;
		}
	}

	class Node 
	{ 
		public Node parent; 
		public Node left; 
		public Node right; 

		public Node(Node parent, Node left, Node right, data) 
		{ 
			this.parent = parent; 
			this.left = left; 
			this.right = right; 
			this.data = data 
		} 

		public bool isRoot() 
		{ 
			return parent == null; 
		} 
	}
}
