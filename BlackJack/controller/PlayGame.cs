using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.BlackJackObserver
    {
        private model.Game a_game;
        private view.IView a_view;

        public PlayGame(model.Game g, view.IView v)
        {
            a_game = g;
            a_view = v;
            a_view.DisplayWelcomeMessage(); 
            a_game.Subscribe(this);
        }

        public bool Play()
        {


            view.PlayChoice input = a_view.GetInput();

            if (input == view.PlayChoice.Play)
            {
                a_game.NewGame();
            }
            else if (input == view.PlayChoice.Hit)
            {
                a_game.Hit();
            }
            else if (input == view.PlayChoice.Stand)
            {
                a_game.Stand();
                if (a_game.IsGameOver())
                {
                    a_view.DisplayGameOver(a_game.IsDealerWinner());
                }
            }

            return input != view.PlayChoice.Quit;
        }

        public void ObserverDealCard()
        {
            System.Threading.Thread.Sleep(900);
            a_view.DisplayWelcomeMessage(); 
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
        }
    }
}
