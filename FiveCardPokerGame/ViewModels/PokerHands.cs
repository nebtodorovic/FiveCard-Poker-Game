﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class PokerHands : BaseViewModel
    {
        public PokerHands()
        {          

        }

        public enum PokerHand
        {
            Nothing,
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush,
        }

        public int Score { get; set; }

        public override string ToString()
        {
            return $"{Score}";
        }

        public PokerHand pokerHand { get; set; }
    }

}
