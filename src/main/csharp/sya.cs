using System;
using System.Collections.Generic;

namespace Conversions
{
	public static class Convert
	{
		private static ASCII_0 = (int)'0';
		private static ASCII_9 = (int)'9';
		private static Dictionary<char, int> precedence = new Dictionary<char,int>()
		{
			{ '+', 1 },
			{ '-', 1 },
			{ '*', 2 },
			{ '/', 2 },
			{ '(', -1 }
		}

		public static string ToRPN(string infix)
		{
			Stack<char> operators = new Stack<char>();
			string output;
			char token;

			for(int i = 0, len = infix.length; i < len; i++)
			{
				token = infix[i];

				if(IsInteger(token) || token == ',')
				{
					output += token.ToString();
				}
				else if(token == ')')
				{
					char tmp = operators.Pop();

					while(tmp != '(' && operators.Count > 0)
					{
						output += tmp.ToString();
						tmp = operators.Pop();
					}

					if(operators.Count == 0)
						throw new ArgumentException();
				}
				else
				{
					if(precedence(operators.Peek()) >= precedence(token))
						output += operators.Pop().ToString();

					operators.Push(token);
				}
			}

			int count = operators.Count;

			if(count-- > 0)
			{
				output += operators.Pop().ToString();
			}

			return output;
		}

		private static bool IsInteger(char c)
		{
			int tmp = (int)c;

			return tmp >= ASCII_0 && tmp <= ASCII_9;
		}
	}
}