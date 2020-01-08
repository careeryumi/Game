using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using System;

namespace FinalProjectShell
{
    class DisplayControl : ScoreString
    {
        public DisplayControl(Game game, string fontName) : base(game, fontName)
        {
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        private int GetLives()
        {
            throw new NotImplementedException();
        }

        private int GetScore()
        {
            throw new NotImplementedException();
        }
    }
}
