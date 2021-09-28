﻿using FiveCardPokerGame.Commands;
using FiveCardPokerGame.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.ViewModels
{
   public class EndOfGameViewModel : BaseViewModel
    {
        public string EndScore { get; set; }
        public string EndHand { get; set; }
        public string ShowDifficulty { get { return HighScoreDb.dif; } set { HighScoreDb.dif = value; } }
        public HighScoreDb highScoreDb = new HighScoreDb();
        public DeckOfCards deckOfCards = new DeckOfCards();
        public static ObservableCollection<Highscore> HighscoreList { get; set; }
        public ICommand PlayAgainCommand { get; set; }        
        public ICommand GoToStartCommand { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }

        public EndOfGameViewModel()
        {        
            highScoreDb.SetHighscore();
            highScoreDb.GetHighscores();
            EndScore = Global.EndScore.ToString();
            EndHand = Global.EndHand.ToString();
            PlayAgainCommand = new PlayAgainCommand(this);
            GoToStartCommand = new GoToStartCommand(this);
        }

    }
}
