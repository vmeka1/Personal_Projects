using System;
using System.Collections.Generic;

namespace rackTestStuff
{
    class Deck
    {
        protected List<int> deck = new List<int>();
        protected Stack<int> drawDeck = new Stack<int>();
        protected Stack<int> discardPile = new Stack<int>();
        protected Random rand = new Random();
        protected int n = 10;
        const int cardAmount = 60;
        protected int max = 60;
        protected int rnd = 0;
        
        public Deck()
        {
            for (int i = 1; i <= cardAmount; i++)
            {
                deck.Add(i);
            }
            
            for (int i = 0; i < 40; i++)
            {
                rnd = rand.Next(0, max);
                drawDeck.Push(deck[rnd]);
                deck.Remove(deck[rnd]);
                max--;
            }
        }
        //turns the discard pile into the draw pile
        public void changeDeck()
        {
            int discCount = discardPile.Count;
            int[] swap = new int[discCount];
            int i = 0;
            
            //stores the cards from discard pile into a temporary array
            foreach(int value in discardPile)
            {
                swap[i] = value;
                i++;
            }
            //clears the discard pile
            discardPile.Clear();
            
            //transfers the cards into the empty draw deck
            for (i = 0; i < swap.Length; i++)
            {
                drawDeck.Push(swap[i]);
            }

        }
        //gives a peek at what is on top of the pile
        public void showDiscardPile()
        {
            if (discardPile.count == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("top of discard pile: " + discardPile.Peek() + " ]");
                Console.WriteLine();
            }
        }
        
    }
}
