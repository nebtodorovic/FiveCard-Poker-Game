using FiveCardPokerGame.Data;
using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.Commands
{
    class CreatePlayerCommand : ICommand
    {
        private readonly PlayerDbViewModel playerDb;

        public CreatePlayerCommand(PlayerDbViewModel playerDb)
        {
            this.playerDb = playerDb;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        /// <summary>
        /// Can always execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Creates a new player from UI input. Writes to the database.
        /// Gets a list of created players from the database.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            playerDb.CreatePlayer(playerDb.NewPlayer);
            playerDb.GetPlayers();
            Global.PlayClickSound();
        }
    }
}
