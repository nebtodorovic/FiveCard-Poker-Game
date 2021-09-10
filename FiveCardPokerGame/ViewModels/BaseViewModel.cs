﻿using FiveCardPokerGame.Commands;
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
        private BaseViewModel selectedViewModel;
        
        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; }
        }

        public ICommand UpdateViewCommand { get; set; }

        public BaseViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }


    }
}
