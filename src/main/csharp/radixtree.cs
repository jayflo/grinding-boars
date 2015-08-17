using System;

namespace Trees
{
	public class RadixTree<T>
	{
		Node<T> Root;

		public RadixTree()
		{
			Root = new Node<T>(String.Empty);
		}

		public void Add(string key, T value)
		{
			Node<T> tmp = root;

			RecursiveAdd(root, string key, T value);
		}

		private void RecursiveAdd(Node<T> curr, string key, T value)
		{
			if(curr.key == key)
			{
				curr.value = value;
				return;
			}

			if(curr.key.StartsWith(key))
			{
				string tail = curr.key.Substring(key.length);
				Node<T> tmp = new Node<T>(tail, curr.value, curr, curr.Children);
				curr.key = key;
				curr.value = value;
				curr.Children = new Node<T>[] { tmp };				
			}
			else
			{

			}
		}
	}

	public class Node<T>
	{
		public string key;
		public T value;
		public Node<T> parent;

		public Node<T>[] Children;

		public Node(string key)
		{
			this.key = key;
			parent = null;
			Children = null;
		}

		public Node(string key, T value, Node<T> parent)
		{
			this.key = key;
			this.value = value;
			this.parent = parent;
		}

		public Node(string key, Node<T> parent) : this(key)
		{
			this.parent = parent;
		}

		public Node(string key, Node<T> parent, params Node<T>[] nodes) : this(key, parent)
		{
			Children = nodes;
		}

		public void Add(Node<T> node)
		{
			node.parent = this;
			Node<T> tmp = new Node<T>[Children.length + 1];

			Array.Copy(Children, tmp, Children.length);

			Children = tmp;
		}

		public static int DiffIndex(string key, string fkey)
		{
			int i = 0;
			while(key[i] == fkey[i])
			{
				i++;
			}

			return i;
		}
	}
}