using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftSeventeenHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        // return true if score is 17 and dealer has an Ace,
        // else return true/false depending on if dealer has
        // a score lower than the hit limit.
        public bool DoHit(model.Player a_dealer)
        {
            IEnumerable<Card> cards = a_dealer.GetHand();
            
            if (a_dealer.CalcScore() == g_hitLimit)
            {
                foreach (var c in cards)
                {
                    if (c.GetValue() == Card.Value.Ace)
                    {
                        return false;
                    }
                }
            }

            return a_dealer.CalcScore() < g_hitLimit;

        }
    }
}
