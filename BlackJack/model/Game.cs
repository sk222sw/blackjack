using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game : Subject, BlackJackObserver
    {
        private model.Dealer m_dealer;
        private model.Player m_player;

        public model.Dealer Dealer { get { return m_dealer; } }
        public model.Player Player { get { return m_player; } }

        List<BlackJackObserver> m_observers = new List<BlackJackObserver>();

        public Game()   
        {
            m_dealer = new Dealer(new rules.RulesFactory());
            m_player = new Player();
            m_dealer.Subscribe(this);
        }

        public bool IsGameOver()
        {
            return m_dealer.IsGameOver();
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            return m_dealer.NewGame(m_player);
        }

        public bool Hit()
        {
            return m_dealer.Hit(m_player);
        }

        public bool Stand()
        {
            return m_dealer.Stand();
        }

        public IEnumerable<Card> GetDealerHand()
        {
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }

        public void Subscribe(BlackJackObserver observer)
        {
            m_observers.Add(observer);
        }

        public void Unsubscribe(BlackJackObserver observer)
        {
            m_observers.Remove(observer);
        }
        public void NotifySubscriber()
        {
            m_observers.ForEach(x => x.ObserverDealCard());
        }

        public void ObserverDealCard()
        {
            NotifySubscriber();
        }

    }
}
