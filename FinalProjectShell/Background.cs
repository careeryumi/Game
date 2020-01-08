using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace FinalProjectShell
{
    class Background : DrawableGameComponent
    {
        Texture2D bgdFull;
        


        public Background(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();

            sb.Begin();
            sb.Draw(bgdFull, new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width,
                Game.GraphicsDevice.Viewport.Height),
                Color.White);
            sb.End();

            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            bgdFull = Game.Content.Load<Texture2D>("Images/witchsBackground");




            base.LoadContent();
        }
    }
}
