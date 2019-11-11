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
			deck.ShuffleDeck(); //for debugging purposes, to make the game go quicker, can comment this out
			deck.Deal();
		

            Game game = new Game(deck);

            Console.WriteLine();
            Console.WriteLine($"\t\t\t\t\tWelcome to the game of GO FISH!!!");
            Console.WriteLine();
            Console.WriteLine($"\t\t\t\t\t\t © A.Leibowitz");
            Console.WriteLine();
            Console.WriteLine("It's easy to play -- just follow the prompts, and see if you can win!");
            Console.WriteLine();
            Console.WriteLine("NOTE: The game is case-sensitive; please type all card rank names as shown on the screen.");
            Console.WriteLine();
            Console.WriteLine();

            do
            {
                //can uncomment the below for debugging purposes
                //Console.WriteLine("My cards: ");
                //deck.PrintDeck(deck.compCards);

                game.HumanPlayerTurn();
                
                game.ComputerPlayerTurn();

                if (deck.centerPile.Count == 0)
                    game.EndGame();
                Console.WriteLine("Your turn now!");
                Console.WriteLine();
            }
            while (deck.centerPile.Count > 0);
            //while (game.pl1NumOfBooks + game.compNumOfBooks < 13); //this would be that the players keep on playing even after the deck is finished.

            game.EndGame();
            
		}
	}
}
