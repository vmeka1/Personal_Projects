using System;
using System.collections.Generic;

namespace rackTestStuff
{
    class Computer : Deck
    {
        List<int> computerDeck = new List<int>();
        
        public Computer()
        {
            for (int i = 0; i < 10; i++)
            {
                rnd = rand.Next(0, max);
                computerDeck.Add(deck[rnd]);
                deck.Remove(deck[rnd]);
                max--;
            }
        }
        
        public void computerDraw()
        {
            if (drawDeck.Count == 0)
            {
                changeDeck();
            }
            
            int newCard = drawDeck.Pop();
            
            for (int i = 1; i < computerDeck.Count; i++)
            {
                if (computerDeck[i - 1] < computerDeck[i])
                {
                    continue;
                }
                else if (computerdEck[i - 1] > computerDeck[i] && newCard < computerDeck[i - 1])
                {
                    discardPile.Push(computerDeck[i - 1]);
                    computerDeck[i - 1] = newCard;
                    break;
                }
            }
            Console.WriteLine("COMPUTER'S CARDS BELOW!");
            
            computerDeck.ForEach(Console.WriteLine);
        }
        
        //checks to see if computer won
        public bool checkComputer(ref string win)
        {
            for (int i = 1; i < computerDeck.count; i++)
            {
                if (computerDeck[i - 1].CompareTo(computerDeck[i]) > 0)
                {
                    return false;
                }
            }
            win = "Computer";
            return true;
        }
    }
}
