using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class CuefaLogika
    {
        Random rnd = new Random();

        public string BotChoice;
        public string Result;
       
        public void Igrat(string player)
        {
            string[] choices = { "rock", "scissors", "paper" };

            BotChoice = choices[rnd.Next(0, 3)];

            if (player == BotChoice)
            {
                Result = "It's a draw";
            }
            else if (
                (player == "rock" && BotChoice == "scissors") ||
                (player == "scissors" && BotChoice == "paper") ||
                (player == "paper" && BotChoice == "rock"))
            {
                Result = "You win";
            }
            else
            {
                Result = "You lost";
            }
        }
    }
}
