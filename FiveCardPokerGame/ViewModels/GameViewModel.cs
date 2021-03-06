using FiveCardPokerGame.Commands;
using FiveCardPokerGame.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace FiveCardPokerGame.ViewModels
{
    public partial class GameViewModel : BaseViewModel
    {
        
        public GameEngine DeckOfCards { get; set; } = new GameEngine();
        public HowToPlayViewModel HowToPlayViewModel { get; set; } = new(); 
        public bool IsButtonEnabled { get; set; }
        public ICommand RemoveCardCommand { get; set; }
        public ICommand DrawCardCommand { get; set; }
        public string IsCardEnabled { get; set; }
        public int NumberOfDraws { get; set; }
        public Player SetPlayer { get; set; }
        public ICommand EndViewCommand { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public HighScoreDb HighScoreDb { get; set; } = new();
        /// <summary>
        /// Method for changing the picture binded to the button where the player draws new cards.
        /// </summary>
        /// <returns>A string depending if the player can draw more cards or not</returns>
        public string CardEnabler()
        {
            if (DeckOfCards.IsHandFiveOrLess() == true)
            {
                return IsCardEnabled = "/Resources/ImagesCards/xCardBack.png";
            }
            else
            {
                return IsCardEnabled = "/Resources/ImagesCards/xCardBackDisabled.png";
            }
        }
        /// <summary>
        /// Constructor that enables the diffrent commands for the GameView. Also runs the method CardEnabler() when starting this class. Method is connected to a property that sets IsEnabled on a button, true or false.
        /// </summary>
        public GameViewModel()
        {
            RemoveCardCommand = new RemoveCardCommand(this);
            DrawCardCommand = new DrawCardCommand(this);
            IsCardEnabled = CardEnabler();
            EndViewCommand = new EndViewCommand(this);            
        }
        /// <summary>
        /// Checks if the players final score is equal or better than any score in the highscorelist.
        /// </summary>
        /// <returns></returns>
        public static bool CheckIfHighScore()
        {
            foreach (var item in HighScoreDb.GetHighscores())
            {
                if (Global.EndScore >= item.Score)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// If the player has no draws left it moves the player to the score screen after 2 seconds.
        /// </summary>
        public void ExecuteGameOver()
        {
            if (DeckOfCards.CanDrawNewCard()==false)
            {
                Global.FinalHand = DeckOfCards.CardViews;
                Task.Delay(2000).ContinueWith(t=>EndViewCommand.Execute(this));
            }
        }
        /// <summary>
        /// Checks if the player makes it to the high score list. Plays a sound if true
        /// Checks if players score is equal to or higher than five (lowest possible score). Plays sound if that is the case
        /// If player has no points it plays a sad trumpet(?) sound.
        /// </summary>
        public static void PlaySoundBasedOnScore()
        {
            if (CheckIfHighScore() == true)
            {
                Global.PlayHighScoreSound();
            }
            else if (Global.EndScore >= 5)
            {
                Global.PlayPointsSound();
            }
            else
            {
                Global.PlayNoPointsSound();
            }
        }
    }
}
