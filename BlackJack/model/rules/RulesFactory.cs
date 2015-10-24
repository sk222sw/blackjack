using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        public IHitStrategy GetHitRule()
        {
            return new BasicHitStrategy();
        }

        public IHitStrategy GetSoftSeventeen()
        {
            return new SoftSeventeenStrategy();
        }

        public IWinOnEqualStrategy GetWinOnEqualStrategy()
        {
            return new DealerWinsOnEqual();
        }

    }
}
