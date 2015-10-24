using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWinOnEqualStrategy
    {
        bool dealerWins(Player player, Player dealer, int maxScore);
    }
}
