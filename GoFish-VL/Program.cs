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
            ArrayList players = new ArrayList
            {
                pl1,
                comp
            };


			Deck deck = new Deck();
			deck.CreateDeck();
			//deck.PrintDeck(deck.deck);
			deck.ShuffleDeck();
			//deck.PrintDeck(deck.deck);
			deck.Deal();
			Console.WriteLine("Here are your cards: ");
			deck.PrintDeck(deck.pl1Cards);
			Console.WriteLine("These are my cards: ");
			deck.PrintDeck(deck.compCards);

            Game game = new Game(deck);

            do
            {
                //show the player his cards
                //Console.WriteLine("Here are your cards: ");
                //deck.PrintDeck(deck.pl1Cards);
                //Console.WriteLine("Number of books you already won: {0}", game.pl1NumOfBooks);
                //Console.WriteLine();

                game.HumanPlayerTurn();

                //Game game = new Game();
                //string cardWanted = game.AskForCard();
                //bool validRequest = game.CheckIfHas(deck.pl1Cards, cardWanted);
                //if (!validRequest)
                //{
                //    Console.WriteLine("You may only ask for a rank which you already have. Please try again.");
                //    cardWanted = game.AskForCard();
                //}
                //else
                //{
                //    bool containsIt = game.CheckIfHas(deck.compCards, cardWanted); //for computer's turn, jsut put in the player's deck as the 1st parameter.
                //    if (containsIt)
                //    {
                //        Console.WriteLine("Good for you! I have it!");
                //        Console.WriteLine();
                //    }
                //    else
                //    {
                //        Console.WriteLine("Sorry, go fish!");
                //        Console.WriteLine();
                //    }

                //    if (containsIt == true)
                //    {
                //        game.RemoveCards(deck.compCards, cardWanted); //1st parameter is the one giving up the cards.
                //        game.AddThemIn(deck.pl1Cards);
                //    } //this parameter is the one who asked for them.
                //    game.CheckForBooks(deck.pl1Cards, game.pl1Books, game.pl1NumOfBooks); //1st parameter:whose turn it is. 2nd parameter: his book pile. 3rd: his amount of books.
                //}

                Console.WriteLine("Here are your cards: ");
                deck.PrintDeck(deck.pl1Cards);
                Console.WriteLine("These are my cards: ");
                deck.PrintDeck(deck.compCards);

            }
			while (deck.centerPile.Count > 0); //not correct. change it to when all 13 books have been won.

			Console.ReadKey();
		}
	}
}
