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
            return new InternationalNewGameStrategy();
        }

        public IHitStrategy GetHitRule()
        {
            return new SoftSeventeenHitStrategy();
        }

        public IWinOnEqualStrategy GetWinOnEqualStrategy()
        {
            return new DealerWinsOnEqual();
        }

    }
}
