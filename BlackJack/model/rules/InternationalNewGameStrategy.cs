using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            a_player.GetCard(a_deck, true);
            a_dealer.GetCard(a_deck, true);
            a_player.GetCard(a_deck, true);


            return true;
        }
    }
}
