using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinsOnEqual : IWinOnEqualStrategy
    {
        public bool dealerWins(Player a_player, Player a_dealer, int maxScore)
        {
            // if player or dealer exceeds the maxscore
            if (a_player.CalcScore() > maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > maxScore)
            {
                return false;
            }

            // else favor the dealer
            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
    }
}
