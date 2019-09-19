using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish_VL
{
	public class Game
	{
        public ArrayList cardsWon = new ArrayList { };
        public ArrayList cardsOfSameRank = new ArrayList { };
        public ArrayList pl1Books = new ArrayList { };
        public ArrayList compBooks = new ArrayList { };
        public int pl1NumOfBooks = 0;
        public int compNumOfBooks = 0;

		public string AskForCard()
		{
			Console.WriteLine("Type in the card you want to ask me for: ");
			string cardWanted = Console.ReadLine();
			return cardWanted;
		}

		public bool CheckIfHas(ArrayList deck, string cardWanted)
		{
			bool containsIt = false;
			foreach (Cards card in deck)
			{
				if (cardWanted == card._rank)
					return containsIt = true;
			}
			return containsIt;
		}

        public void RemoveCards(ArrayList deck, string cardWanted) //the first parameter is the deck of the one giving up the cards.
        {
            foreach (Cards card in deck) //adding all the cards he has to a new ArrayList, called cardsWon.
            {
                if (cardWanted == card._rank)
                    cardsWon.Add(card);
            }
            /*
            for (int j = 0; j < cardsWon.Count; j++) //removing all cards in cardsWon from his deck. (can't remove from an ArrayList in a foreach loop, 
            {                                           // but need a foreach loop when accessing only the ._rank of the card.
                for (int i = 0; i < deck.Count; i++)            //This way, the entire card, with both suit and rank, (which was added to cardsWon),
                {                                                   // is removed from the deck. And this works!!!
                    if (deck[i] == cardsWon[j])
                        deck.RemoveAt(i);
                }
            }
            */
            foreach (Cards card in cardsWon)  //just realized to do this, instead of above. Much shorter.
            {
                if (deck.Contains(card))
                    deck.Remove(card);
            }
        }



        public void AddThemIn(ArrayList deck) //this parameter is the one who asked for the cards.
        {
            foreach (Cards card in cardsWon)
                deck.Add(card);
        }



        public void CheckForBooks(ArrayList deck, ArrayList booksPile, int numOfBooks)
        {
            ArrayList ranks = new ArrayList { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "JACK", "QUEEN", "KING" };

            foreach (string rank in ranks)
            {
                cardsOfSameRank.Clear();
                int numOfRank = 0;
                foreach (Cards card in deck)
                {
                    if (rank == card._rank)
                    {
                        numOfRank++;
                        cardsOfSameRank.Add(card);
                    }
                }

                if (numOfRank == 4)
                {
                    foreach (Cards card in cardsOfSameRank)
                    {
                        booksPile.Add(cardsOfSameRank);
                        deck.Remove(cardsOfSameRank);
                    }
                    numOfBooks++;
                }
            }

        }
	}
}
