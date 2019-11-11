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
			//deck.ShuffleDeck(); //for debugging purposes
			deck.Deal();
		

            Game game = new Game(deck);

            do
            {
                Console.WriteLine("My cards: ");
                deck.PrintDeck(deck.compCards);

                game.HumanPlayerTurn();
                
                game.ComputerPlayerTurn();
                Console.WriteLine("Your turn now!");
                Console.WriteLine();
            }
            while (deck.centerPile.Count > 0);
            //while (game.pl1NumOfBooks + game.compNumOfBooks < 13); //this would be that the players keep on playing even after the deck is finished.

            game.EndGame();
		}
	}
}
