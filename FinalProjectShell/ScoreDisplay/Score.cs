using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FinalProjectShell
{

    class Score : ScoreString
    {
        int score = 0;

        public Score(Game game, string fontName) : base(game, fontName)
        {
            if (Game.Services.GetService<Score>() == null)
            {
                Game.Services.AddService<Score>(this);
            }
        }

        public override void Update(GameTime gameTime)
        {
            displayString = $"Score: {score}";
            base.Update(gameTime);
        }

        /// <summary>
        /// Add score
        /// </summary>
        /// <param name="value">value</param>
        public void AddScore(int value)
        {
            score += value;
        }


        /// <summary>
        /// Make score to zero
        /// </summary>
        public void SetScoreToZero()
        {
            score = 0;
        }
        
        /// <summary>
        /// Return final score
        /// </summary>
        /// <returns></returns>
        public int ReturnFinalScore()
        {
            return score;
        }
    }
}
