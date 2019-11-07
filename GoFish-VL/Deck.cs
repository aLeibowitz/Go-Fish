using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish_VL
{
	public class Deck
	{
		public ArrayList centerPile = new ArrayList { };
		public ArrayList pl1Cards = new ArrayList { };
		public ArrayList compCards = new ArrayList { };
		//public Queue centerPile = new Queue { };



		public void CreateDeck()
		{
			string[] suits = new string[] { "Hearts", "Diamonds", "Spades", "Clubs" };
			ArrayList ranks = new ArrayList { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "JACK", "QUEEN", "KING" };

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < ranks.Count; j++)
				{
					Cards card = new Cards(suits[i], ranks[j].ToString());  // This is a class constructor. Making new cards as objects in the Cards class, with 2 attributes: suit and rank.
					centerPile.Add(card);
				}
			}
		}

		public void PrintDeck(ArrayList deck)
		{
            SortDeck(deck);

			foreach( Cards card in deck) // "Cards" is the class, "card" is an instantiation of the Cards class. 
			{ card.PrintCard();				//that is why you can do card.PrintCard(); -- b/c card is ""!
				Console.WriteLine(" ");
			}
            Console.WriteLine();
		}

        //public void PrintPickedCard(ArrayList originalDeck, ArrayList updatedDeck)
        //{
        //    foreach (Cards card in updatedDeck)
        //    {
        //        if (!originalDeck.Contains(card))
        //            {
        //            card.PrintCard();
        //            Console.WriteLine(" ");
        //            }
        //    }
        //}
		

		public void ShuffleDeck()
		{
			Random r = new Random();

			for (int i = 0; i < 200; i++)   //mix up 2 cards with each other, 200 times, to hopefully shuffle it enough.
			{
				int randomIndex1 = r.Next(52);
				int randomIndex2 = r.Next(52);
				object temp = centerPile[randomIndex1];
				centerPile[randomIndex1] = centerPile[randomIndex2];
				centerPile[randomIndex2] = temp;
			}
		}

		public void Deal()
		{
			for (int i = 0; i < 7; i++) //giving the human player 7 cards, and removing those cards from the deck.
				{
				pl1Cards.Add(centerPile[i]);
				centerPile.Remove(centerPile[i]);
				}
			for (int j = 0; j < 7; j++) //giving the computer player 7 cards, and removing those cards from the deck.
			{
				compCards.Add(centerPile[j]);
				centerPile.Remove(centerPile[j]);
			}
		}

		//public void MakeCenterPile()
		//{
		//	for (int i = 0; i < deck.Count; i++)
		//	{
		//		centerPile.Enqueue(deck[i]);
		//		deck.Remove(deck[i]);
		//	}
		//}

        public void SortDeck(ArrayList deck)
        {
            deck.Sort(new MyComparer());
        }

	}
}
