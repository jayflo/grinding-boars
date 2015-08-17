using System;

namespace IsANumber
{
	class Program
	{
		const int NUM_LOW = (int)'0';
		const int NUM_HIGH =  (int)'9';
		const int COMMA = (int)',';
		const int DECIMAL = (int)'.';

		static void Main()
		{

		}

		// not culture invariant
		// incorrect...
		public bool isNumber(string s)
		{
			int ascii;
			int lastComma = -1;
			bool decimalOccurred = false;

			for(int i = 0, len = s.length; i < len; i++)
			{
				ascii = (int)s[i];

				if(ascii >= NUM_LOW && ascii <= NUM_HIGH)
				{
					if(lastComma > -1 && digitcount > 3)
						return false;

					digitcount++;
				}
				else if(ascii == COMMA)
				{
					if((lastComma > -1 && i - lastComma != 4) 
						|| (decimalOccurred == false && digitcount > 3))
						return false;

					lastComma = i;
					digitcount = 0;
				}
				else if(ascii == DECIMAL)
				{
					if(lastComma > -1 || decimalOccurred)
						return false;

					decimalOccurred = true;
					digitcount = 0;
				}
				else
					return false;
			}

			return true;
		}
	}
}