using System;

namespace Tries
{
	public class Trie<T> {
		Node<T> Root;

		public Trie(Node<T> root) {
			Root = root;
		}

		public this[char c] {
			get { return root[c]; }
			set { root[c] = value; }
		}

		public this[string s] {
			get { return root[s]; }
			set { root[s] = value; }
		}

		public Node<T> TryGet(string s) {
			Node<T> tmp = null;

			try
			{
				tmp = root[s[0]][s.Substring(1)];
			}
			catch(Exception /* e */) {}

			return tmp;
		}

		public bool Contains(string s) {
			return TryGet(s) != null;
		}

		public void Add(string key, T value) {
			RecursiveAdd(root, key, value);
		}

		private void RecursiveAdd(Node<T> curr, string key, T value) {
			Node<T> tmp = curr[key[0]];

			if(tmp == null)
				tmp == new Node<T>();

			if(key.length == 1)
				tmp.value = value;
			else
				RecursiveAdd(tmp, key.Substring(1), value);
		}
	}

	public class Node<T> {
		public T value;
		
		private Node<T>[] Children;
		private const int ASCII_a = (int)'a';
		private const int ALPHABET_SIZE = 26;

		public Node() {
			Children = new Node<T>[ALPHABET_SIZE];
		}

		public Node(T value) : this() {
			this.value = value;
		}

		public this[char c] {
			get { return Children[tryhash(c)]; }
			set { Children[tryhash(c)] = value }
		}

		public this[string s] {
			get {
				if(s.length == 1)
					return root[s[0]];

				return root[s[0]][s.Substring(1)]; 
			}
			set {
				if(s.length == 1)
					root[s[0]] = value;
					
				root[s[0]][s.Substring(1)] = value;
			}
		}

		private int tryhash(char c) {
			int t = (int)c - ASCII_a;

			if(t < 0 || t >= ALPHABET_SIZE)
				throw new ArgumentException();

			return t;
		}
	}
}