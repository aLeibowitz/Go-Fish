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
        public Deck deck;
        

        public Game(Deck deck)
        {
            this.deck = deck;
        }

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
            cardsWon.Clear();
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
                    Console.WriteLine("Great job! You got 4 cards of the same rank!");
                    foreach (Cards card in cardsOfSameRank)
                    {
                        booksPile.Add(cardsOfSameRank);
                        deck.Remove(cardsOfSameRank);
                    }
                    numOfBooks++;
                }
            }

        }

        public void HumanPlayerTurn()
        {
            //show the player his cards
            Console.WriteLine("Here are your cards: ");
            deck.PrintDeck(deck.pl1Cards);

            //show the player how many books he won
            Console.WriteLine("Number of books you already won: {0}", pl1NumOfBooks);
            Console.WriteLine();

            string cardRequested = AskForCard();
            bool validRequest = CheckIfHas(deck.pl1Cards, cardRequested);
            if (!validRequest)
            {
                Console.WriteLine("You may only ask for a rank which you already have. Please try again.");
                Console.WriteLine();
                HumanPlayerTurn();
            }
            else
            {
                bool success = CheckIfHas(deck.compCards, cardRequested); //for computer's turn, jsut put in the player's deck as the 1st parameter.
                if (success)
                {
                    Console.WriteLine("Good for you! I have it!");
                    Console.WriteLine("You get to go again.");

                    RemoveCards(deck.compCards, cardRequested); //1st parameter is the one giving up the cards.
                    AddThemIn(deck.pl1Cards); //this parameter is the one who asked for them.

                    CheckForBooks(deck.pl1Cards, pl1Books, pl1NumOfBooks); //1st parameter:whose turn it is. 2nd parameter: his book pile. 3rd: his amount of books.

                    HumanPlayerTurn();
                }
                else
                {
                    Console.WriteLine("Sorry, go fish!");
                    
                    deck.pl1Cards.Add(deck.centerPile[0]);
                    
                    deck.centerPile.Remove(deck.centerPile[0]);

                    Console.WriteLine("You picked the card: ");
                    

                    //Console.WriteLine("These are your cards now: ");
                    //deck.PrintDeck(deck.pl1Cards);
                    //////Cards cardPicked = deck.centerPile[0];
                    ////Console.Write("You picked the card: ");
                    //cardPicked.PrintCard();
                    
                    //printDeck(cardPicked); //might not work b/c the parameter is an arraylist.
                    //if (cardPicked._rank == cardRequested)
                }
                
            }

        }
    }
}
