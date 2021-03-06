using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class Highscore : BaseViewModel
    {
        public int HighscoreId { get; set; }
        public int Score { get; set; }
        public long ScoreRank { get; set; }
        public string Difficulty { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Returns this string when displaying this type of object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"#{ScoreRank} ⋆|⋆ {Name} ⋆|⋆ Score: {Score} ";
        }
    }
}
