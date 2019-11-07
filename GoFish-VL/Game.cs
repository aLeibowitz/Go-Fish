﻿using System;
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
        public string currentPlayer;
        ArrayList alreadyRequested = new ArrayList(); //to help computer be a little "smarter" and not ask for the same card twice in one turn.



        public Game(Deck deck)
        {
            this.deck = deck;
        }

        public string AskForCard()
        {
            string cardRequested = null;

            if (currentPlayer == "Human")
            {
                Console.WriteLine("Type in the rank of the card you want to ask me for: ");
                cardRequested = Console.ReadLine();
                return cardRequested;
            }
            else 
            {
                Random random = new Random();
                int ixCompCards = random.Next(0, deck.compCards.Count);

                Cards cardRequested1 = (Cards)deck.compCards[ixCompCards];
                cardRequested = cardRequested1._rank; //turns it into a string

                if (alreadyRequested.Contains(cardRequested))
                    AskForCard();

                else alreadyRequested.Add(cardRequested);
                
                return cardRequested;
            }
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



        public void CheckForBooks(ArrayList deck, ArrayList booksPile)
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

                    if (currentPlayer == "Human")
                    {
                        Console.WriteLine($"Great job! You completed the book of {rank}'s!");
                        pl1NumOfBooks++;
                    }

                    else if (currentPlayer == "Computer")
                    {
                        Console.WriteLine($"Good for me! I completed the book of {rank}'s!");
                        compNumOfBooks++;
                    }

                    foreach (Cards card in cardsOfSameRank)
                    {
                        booksPile.Add(card);  //did this first here and below: cardsOfSameRank
                        deck.Remove(card);
                    }

                    if (currentPlayer == "Human")
                        Console.WriteLine($"You have {pl1NumOfBooks} books so far! Keep it up!!!");

                    else if (currentPlayer == "Computer")
                        Console.WriteLine($"I have {compNumOfBooks} so far.");

                }
            }
            currentPlayer = null;

        }

        public void HumanPlayerTurn()
        {
            

            //first see if he made a match -- instead of writing it after picking and after getting a card, can do it here, cuz it makes them go again, anyways.
            

            //show the player his cards
            Console.WriteLine("Here are your cards: ");
            deck.PrintDeck(deck.pl1Cards);

            //show the player how many books he won
            //Console.WriteLine("Number of books you already won: {0}", pl1NumOfBooks);
            //Console.WriteLine();
            currentPlayer = "Human";
            string cardRequested = AskForCard();
            bool validRequest = CheckIfHas(deck.pl1Cards, cardRequested);
            Console.WriteLine();
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
                    Console.WriteLine("I have it! Here you go.");
                    Console.WriteLine();

                    RemoveCards(deck.compCards, cardRequested); //1st parameter is the one giving up the cards.
                    AddThemIn(deck.pl1Cards); //this parameter is the one who asked for them.

                    CheckForBooks(deck.pl1Cards, pl1Books); //1st parameter:whose turn it is. 2nd parameter: his book pile. 3rd: his amount of books.

                    Console.WriteLine("You get to go again!");
                    HumanPlayerTurn();
                }
                else
                {
                    Console.WriteLine("Sorry, go fish!");
                    
                    deck.pl1Cards.Add(deck.centerPile[0]);
                    Cards cardPicked = (Cards)deck.centerPile[0];

                    deck.centerPile.Remove(deck.centerPile[0]);

                    if (cardPicked._rank == cardRequested)
                        {
                            Console.WriteLine("You picked the card you asked for!");
                        CheckForBooks(deck.pl1Cards, pl1Books);
                        Console.WriteLine("Go again!");
                        HumanPlayerTurn();
                        }
                else 
                    {
                            Console.WriteLine("You picked the card: ");
                            CheckForBooks(deck.pl1Cards, pl1Books);
                            cardPicked.PrintCard();

                    //Console.WriteLine("These are your cards now: ");
                    //deck.PrintDeck(deck.pl1Cards);
                    //////Cards cardPicked = deck.centerPile[0];
                    ////Console.Write("You picked the card: ");
                    //cardPicked.PrintCard();
                    
                    //printDeck(cardPicked); //might not work b/c the parameter is an arraylist.
                    //if (cardPicked._rank == cardRequested)
                    }
                }
                Console.WriteLine();
            }

        }

        public void ComputerPlayerTurn()
        {
            currentPlayer = "Computer";

            CheckForBooks(deck.compCards, compBooks);

            string cardRequested = AskForCard();

            Console.WriteLine($"Do you have any {cardRequested}'s?");

            bool success = CheckIfHas(deck.pl1Cards, cardRequested);
            if (success)
            {
                Console.WriteLine("Thanks! I get to go again!");
                RemoveCards(deck.pl1Cards, cardRequested); //1st parameter is the one giving up the cards.
                AddThemIn(deck.compCards); //this parameter is the one who asked for them.

                CheckForBooks(deck.compCards, compBooks); //1st parameter:whose turn it is. 2nd parameter: his book pile. 3rd: his amount of books.

                ComputerPlayerTurn();
            }
            else
            {
                Console.WriteLine("No? Ok, I'll go fish.");

                deck.compCards.Add(deck.centerPile[0]);
                Cards cardPicked = (Cards)deck.centerPile[0];

                deck.centerPile.Remove(deck.centerPile[0]);

                if (cardPicked._rank == cardRequested)
                {
                    Console.WriteLine("I picked the card I asked for!");
                    CheckForBooks(deck.compCards, compBooks);
                    Console.WriteLine("I get to go again!");
                    ComputerPlayerTurn();
                }

                alreadyRequested.Clear();
                CheckForBooks(deck.compCards, compBooks);
            }
            Console.WriteLine();
            




        }
    }
}
