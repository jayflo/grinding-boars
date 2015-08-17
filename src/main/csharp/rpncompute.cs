using System;

namespace RPNComputer
{
	private static class Computer
	{
		private static Stack<Double> stack;
		private static Dictionary<string, Func<double, double, double>> ops = new Dictionary<string, Func<double, double, double>>()
		{
			{ "+", (x, y) => x + y },
			{ "-", (x, y) => x - y },
			{ "*", (x, y) => x * y },
			{ "/", (x, y) => {
				if(y == 0)
					throw new ArithmeticException();

				return x / y; } }
		};

		public static FromRPN(string[] tokens)
		{
			int len = tokens.length;
			int i = -1;
			double tmp;
			string token;

			while(i++ < len)
			{
				token = tokens[i];

				if(Double.TryParse(token, tmp))
				{
					stack.Push(tmp);
				}
				else
				{
					if(!ops.ContainsKey(token) || stack.Count < 2)
						throw new IllegalArgumentException()

					tmp = stack.Pop();
					stack.Push(ops[token](stack.Pop(), tmp));
				}
			}

			return stack.Pop();
		}
	}
}