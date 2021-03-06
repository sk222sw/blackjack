﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface Subject
    {
        void Subscribe(BlackJackObserver a_observer);
        void Unsubscribe(BlackJackObserver a_observer);
        void NotifySubscriber();
    }
}
