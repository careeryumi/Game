using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

/* Name: Yumi Lee
Date: December 7, 2019 */

namespace FinalProjectShell
{
    class Basket : DrawableGameComponent
    {
        float scale = 1f;
        private Vector2 basketPosition;
        private Vector2 speed;

        // animation state
        List<Texture2D> baskets;
        int currentFrame = 0;
        const double FRAME_DURATION = 1;
        double frameTimer = 0.0;
        bool forwardFrame = true;

        const int MAX_FRAME = 2;

        Song backgroundMusic;

        public Basket(Game game) : base(game)
        {
            speed = new Vector2(4, 0);

            backgroundMusic = Game.Content.Load<Song>("Sounds/gameBackgroundMusic");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
        }

        /// <summary>
        /// get basket's rectangle
        /// </summary>
        /// <returns></returns>
        public Rectangle GetBasketRectangle()
        {
            Rectangle basketRect = baskets[currentFrame].Bounds;
            basketRect.Location = basketPosition.ToPoint();

            return basketRect;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();

            sb.Begin();
            sb.Draw(baskets[currentFrame],
                basketPosition,
                null,
                Color.AntiqueWhite,
                0.0f,
                Vector2.Zero,
                scale,
                SpriteEffects.None,
                0f);
            sb.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                basketPosition += speed;
            }
            else if (ks.IsKeyDown(Keys.Left))
            {
                basketPosition -= speed;
            }
            // here we make sure that we are not off screen, we
            // clap the value to between 0 and width of screen - texture width
            //position.X = MathHelper.Clamp(position.X, 0, GraphicsDevice.Viewport.Width - texture.Width);
            basketPosition.X = MathHelper.Clamp(basketPosition.X, 0, GraphicsDevice.Viewport.Width - 70);

            UpdateFrameInfo(gameTime);
            base.Update(gameTime);

        }

        /// <summary>
        /// Update animation info
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateFrameInfo(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (frameTimer >= FRAME_DURATION)
            {
                if (forwardFrame)
                {
                    currentFrame++;
                    
                    if (currentFrame == MAX_FRAME - 1)
                    {
                        forwardFrame = !forwardFrame;
                    }
                }
                else //backwards
                {                  
                    currentFrame--;
                    if (currentFrame <= 0)
                    {
                        forwardFrame = !forwardFrame;
                    }
                }

                frameTimer = 0;
            }
        }

        protected override void LoadContent()
        {
            baskets.Add(Game.Content.Load<Texture2D>("Images/basket"));
            baskets.Add(Game.Content.Load<Texture2D>("Images/basket2"));
            basketPosition = new Vector2(GraphicsDevice.Viewport.Width / 2,
                                    GraphicsDevice.Viewport.Height - 60);

            base.LoadContent();
        }

        public override void Initialize()
        {
            baskets = new List<Texture2D>();
            base.Initialize();
        }
    }
}
