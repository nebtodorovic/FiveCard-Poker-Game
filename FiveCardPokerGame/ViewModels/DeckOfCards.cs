﻿using FiveCardPokerGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class DeckOfCards : BaseViewModel
    {
        private static readonly Random random = new();

        public ObservableCollection<Card> Deck { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<Card> Hand { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<CardView> CardViews { get; set; }
        public ObservableCollection<CardView> ThrownCards { get; set; } = new();
        
        public PokerHands PokerHands { get; set; } = new PokerHands();
        public List<Card> Cards { get; set; }
        

        public DeckOfCards()
        {
            SetUpDeck();
            DealCards();           
            CreateCardViews();
        }

        public void SetUpDeck()
        {
            foreach (Card.Suit s in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Value v in Enum.GetValues(typeof(Card.Value)))
                {
                    var newcard = new Card { Cardsuit = s, Cardvalue = v };
                    Deck.Add(newcard);
                }
            }           
        }

        public void DealCards()
        {           
            do
            {
                int randomNr = random.Next(Deck.Count);
                var newCard = Deck[randomNr];
                Hand.Add(newCard);
                Deck.RemoveAt(randomNr);
                
            } while (Hand.Count <= 4);        
            EvaluateHand.CheckPokerHand(Hand, PokerHands);
            IsHandFiveOrLess();
        }        

        public void CreateCardViews()
        {
            CardViews = new();
            foreach (Card card in Hand)
            {
                var cardView = new CardView();
                cardView.GetCard = card;

                CardViews.Add(cardView);
            }        
            
        }

        public void ThrowCard(int cardViewNumber)
        {
            Hand.RemoveAt(cardViewNumber);
            IsHandFiveOrLess();
            
        }

        public bool IsHandFiveOrLess()
        {
            
            if (Hand.Count < 5)
            {
                return true;
            }
            return false;
        }

    }
}

