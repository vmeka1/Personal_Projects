/*Created by Vincent Meka
 This program will allow a user to play racko agains a pseudo A.I*/

using System;

namespace rackTestStuff
{
    class main
    {
        static void Main(string[] args)
        {
            string win = " ";
            
            Console.WriteLine("Dealer will now shuffle the cards.");
            Player p = new Player();
            Computer c = new Computer();
            
            while (p.checkWinner(ref win) == false && c.checkComputer(ref win) == false)
            {
                p.showCards();
                p.showDescardPile();
                Console.WriteLine();
                p.checkWinner(ref win);
                c.checkComputer(ref win);
                
                Console.WriteLine("Please choose an option: ");
                Console.WriteLine("1) choose from draw pile.");
                Console.WriteLine("1) choose from discard pile.");
                
                int input = Conver.ToInt32(Console.ReadLine());
                
                if (input == 1)
                {
                    p.draw();
                    p.checkWinner(ref win);
                    c.checkComputer(ref win);
                }
                else if (input == 2)
                {
                    p.drawDiscardPile();
                    p.checkWinner(ref win);
                    c.checkComputer(ref win);
                }
                else
                {
                    Console.WriteLine("invalid option. Please choose again");
                    Console.ReadLine();
                    Console.Clear();
                }
                
                Console.WriteLine();
                Console.WriteLine("computer will now draw");
                
                Console.WriteLine();
                c.computerDraw();
                c.checkComputer(ref win);
            }
            
            if (p.checkWinner(ref win) == true || c.checkComputer(ref win) == true)
            {
                Console.WriteLine(win + " won!");
            }
        }
    }
}
