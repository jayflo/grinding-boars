using System;
using System.Collection.Generic;

namespace LinkedIn
{
	class Graph
	{
		List<Vertex> Vertices;
		int time;

		public void DFS()
		{
			time = 0;

			for(int i = 0, len = Vertices.length; i < len; i++)
			{
				if(Vertices[i].status == Status.None)
					Visit(Vertices[i]);
			}
		}

		private void Visit(Vertex v)
		{
			v.status = status.Visiting;

			for(int i = 0, len = v.adjacent.length; i < len; i++)
			{
				if(v.adjacent[i].status == Status.None)
					Visit(v.adjacent[i]);
			}

			v.Status = Status.Visited;
			v.finished = ++time;
		}
	}

	class Vertex
	{
		string key;
		string value;
		int finished;
		Status status;
		List<Vertex> adjacent;

		public Vertex()
		{
			status = Status.None;
			adjacent = new List<Vertex>();
		}
	}

	enum Status
	{
		None,
		Visiting,
		Visited
	}
}