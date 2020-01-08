using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProjectShell
{
    class ScoreString : DrawableGameComponent
    {
        protected string displayString;
        string fontName;

        SpriteFont font;


        public ScoreString(Game game, string fontName) : base(game)
        {
            this.fontName = fontName;
            displayString = "";
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            sb.DrawString(font, displayString, GetScoreStringPosition(), Color.White);
            sb.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Get score position that is located 
        /// </summary>
        /// <returns></returns>
        private Vector2 GetScoreStringPosition()
        {
            Vector2 location = Vector2.Zero;

            float stringWidth = font.MeasureString(displayString).X;
            int displayWidth = Game.GraphicsDevice.Viewport.Width;

            location.X = displayWidth - stringWidth;
            location.Y = 0;

            return location;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            font = Game.Content.Load<SpriteFont>(fontName);
            base.LoadContent();
        }
    }
}
