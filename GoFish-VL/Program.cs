using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish_VL
{
	class Program
	{
		static void Main(string[] args)
		{
			Player pl1 = new Player();
			Player comp = new Player();
			ArrayList players = new ArrayList();
			players.Add(pl1);
			players.Add(comp);


			Deck deck1 = new Deck();
			deck1.CreateDeck();
			//deck.PrintDeck();
			deck1.ShuffleDeck();
			//deck1.PrintDeck(deck1.deck);
			deck1.Deal();
			Console.WriteLine("Here are your cards: ");
			deck1.PrintDeck(deck1.pl1Cards);
			Console.WriteLine("These are my cards: ");
			deck1.PrintDeck(deck1.compCards);

            do
            {
                //show the player his cards
                Console.WriteLine("Here are your cards: ");
                deck1.PrintDeck(deck1.pl1Cards);

                Game game = new Game();
                string cardWanted = game.AskForCard();
                bool containsIt = game.CheckIfHas(deck1.compCards, cardWanted); //for computer's turn, jsut put in the player's deck as the 1st parameter.
                if (containsIt)
                {
                    Console.WriteLine("Good for you! I have it!");
                    Console.WriteLine();
                }
                else { Console.WriteLine("Sorry, go fish!");
                    Console.WriteLine();
                }

                if (containsIt == true)
                { game.RemoveCards(deck1.compCards, cardWanted); //1st parameter is the one giving up the cards.
                    game.AddThemIn(deck1.pl1Cards); } //this parameter is the one who asked for them.
                game.CheckForBooks(deck1.pl1Cards, game.pl1Books, game.pl1NumOfBooks); //1st parameter:whose turn it is. 2nd parameter: his book pile. 3rd: his amount of books.
                

                Console.WriteLine("Here are your cards: ");
                deck1.PrintDeck(deck1.pl1Cards);
                Console.WriteLine("These are my cards: ");
                deck1.PrintDeck(deck1.compCards);

            }
			while (deck1.centerPile.Count > 0);

			Console.ReadKey();
		}
	}
}
