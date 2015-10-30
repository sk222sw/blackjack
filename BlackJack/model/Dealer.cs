using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player, Subject
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinOnEqualStrategy m_winRule;
        private List<BlackJackObserver> m_observer = new List<BlackJackObserver>();

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRule = a_rulesFactory.GetWinOnEqualStrategy();      
      
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                GetCard(a_player, true);

                return true;
            }
            return false;
        }
        public bool Stand()
        {
            if (m_deck != null)
            {
                ShowHand();

                while (m_hitRule.DoHit(this))
                {
                    GetCard(this, true);
                }
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return this.m_winRule.dealerWins(a_player, this, g_maxScore);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public void Subscribe(BlackJackObserver observer)
        {
            m_observer.Add(observer);
        }

        public void Unsubscribe(BlackJackObserver observer)
        {
            m_observer.Remove(observer);
        }

        public void NotifySubscriber()
        {
            m_observer.ForEach(x => x.ObserverDealCard());
        }

        public void GetCard(Player player, bool doShow)
        {
            Card card = m_deck.GetCard();
            card.Show(doShow);
            player.DealCard(card);
            NotifySubscriber();
        }

    }
}
