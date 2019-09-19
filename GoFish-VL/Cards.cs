using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish_VL
{
	public class Cards
	{
		string _suit;
		public string _rank;

		public Cards(string suit, string rank)
		{
			this._suit = suit;
			this._rank = rank;
		}

		public void PrintCard()
		{
			Console.Write($"{this._rank} ({this._suit})");
		}

		
	}
}
