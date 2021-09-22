﻿using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.Commands
{
    class PlayAgainCommand : ICommand
    {
        private EndOfGameViewModel endOfGameViewModel;

        public PlayAgainCommand(EndOfGameViewModel endOfGameViewModel)
        {
            this.endOfGameViewModel = endOfGameViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            endOfGameViewModel.SelectedViewModel = new GameViewModel();
        }
    }
}