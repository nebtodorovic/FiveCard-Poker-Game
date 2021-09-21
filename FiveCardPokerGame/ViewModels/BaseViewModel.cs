﻿using FiveCardPokerGame.Commands;
using FiveCardPokerGame.Data;
using FiveCardPokerGame.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel
    {
        public BaseViewModel SelectedViewModel { get; set; }
        //public PlayerDb playerDb { get; set; } = new PlayerDb();
        public ICommand UpdateViewCommand { get; set; }

        public BaseViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            
        }


    }
}
