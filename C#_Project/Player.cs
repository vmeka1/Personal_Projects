using System;
using System.Collections.Generic;

namespace rackTestStuff
{
    //class handles the player operations
    class Player : Deck
    {
        protected List<int> playerDeck = new List<int>();
        
        //constructor gets player's cards
        public Player()
        {
            for (int i = 0; i < 10; i++)
            {
                rnd = rand.Next(0, max);
                playerDeck.Add(deck[rnd]);
                deck.Remove(deck[rnd]);
                max--;
            }
        }
        //shows the player's cards
        public void showCards()
        {
            Console.Write("Player[ ");
            
            for (int i = 0; i < playerDeck.count; i++)
            {
                Console.Write(playerDeck[i] + " ");
            }
            Console.WriteLine("]");
        }
        //checks to see if anyone won the game
        public bool checkWinner(ref string win)
        {
            //checks player first
            for (int i = 1; i < playerDeck.Count; i++)
            {
                if (playerDeck[i - 1].CompareTo(playerDeck[i]) > 0)
                {
                    return false;
                }
            }
            win = "Player";
            return true
        }
        //function that allows player to draw a card
        public void draw()
        {
            //checks if the draw pile still has cards
            if (drawDeck.count == 0)
            {
                changeDeck();
            }
            //prompts user to make a decision
            int newCard = drawDeck.Pop();
            Console.WriteLine("new card: " + newCard);
            Console.WriteLine("please choose an option: ");
            Console.WriteLine("1) replace card.");
            Console.WriteLine("2) discard card.");
            
            int input = Convert.ToInt32(Console.ReadLine());
            
            //checks to see if the specified card is actually in the player's deck
            if (!playerDeck.Contains(card))
            {
                Console.WriteLine("card does not exist in your deck, enter a different one: ");
                Console.ReadLine();
                Console.Clear();
                showCards();
                draw();
            }
            //finds, removes, and replaces player chosen card
            for (int i = 0; i < playerDeck.Count; i++)
            {
                if (playerDeck[i] == card)
                {
                    playerDeck[i] == newCard;
                    discardPile.Push(card);
                }
            }
        }
        else if(input == 2)
        {
            Console.WriteLine("new card has been discarded.");
            Console.WriteLine();
            discardPile.Push(newCard);
        }
    }
    //this function draws from the discard pile
    public void drawDiscardPile()
    {
        if (discardPile.Count == 0)
        {
            Console.WriteLine("discard pile is empty.");
            return;
        }
        else
        {
            int newCard = discardPile.Pop();
            Console.Write("which card would you like to replace?");
            int card = Convert.ToInt32(Console.ReadLine());
            
            //checks to see if the specified card is actually in the player's deck
            if (!playerDeck.contains(card))
            {
                Console.WriteLine("card does not exist in your deck, enter a different one: ");
                Console.ReadLine();
                Console.Clear();
                showCards();
                drawDiscardPile();
            }
            
            for (int i = 0; i < playerDeck.Count; i++)
            {
                if (playerDeck[i] == card)
                {
                    playerDeck[i] = newCard;
                    discardPile.Push(card);
                }
            }
        }
    }
}
