using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

/* Name: Yumi Lee
Date: December 7, 2019 */

namespace FinalProjectShell
{
    class Pumpkin : DrawableGameComponent
    {
        
        private Texture2D randomPumpkin;

        private Vector2 randomPumpkinPosition;
        float scale = 1f;

        PumpkinType pumpkinType = PumpkinType.orangePumpkin;

        
        SoundEffect collisionFx;
        List<Texture2D> pumpkins;


        public Pumpkin(Game game) : base(game)
        {
        }

        public Pumpkin(Game game, PumpkinType pumpkinType, Vector2 location) : base(game)
        {
            this.pumpkinType = pumpkinType;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();

            sb.Begin();

                sb.Draw(randomPumpkin,
                randomPumpkinPosition,
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

        public override void Initialize()
        {
            pumpkins = new List<Texture2D>();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            randomPumpkinPosition.Y += 0.5f;

            CheckCollisionWithPumpkin();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ((Game1)Game).HideAllScenes();
                Game.Services.GetService<StartScene>().Show();
                Game.Components.Remove(this);
            }
            if (Game.Services.GetService<ActionScene>().GetGameEndFlag() == true)
            {
                Game.Components.Remove(this);
               
            }

           

            base.Update(gameTime);

        }

        /// <summary>
        /// check if pumpkin and basket has a collision,
        /// if true, make a sound
        /// </summary>
        private void CheckCollisionWithPumpkin()
        {
            Basket getbasket = Game.Services.GetService<Basket>();

            Rectangle pumpkinRect = randomPumpkin.Bounds;
            pumpkinRect.Location = randomPumpkinPosition.ToPoint();         

            if (pumpkinRect.Intersects(getbasket.GetBasketRectangle()))
            {
                if (GetPumpkinValue() == 10)
                {
                    collisionFx = Game.Content.Load<SoundEffect>("Sounds/OrangePumpkinSound");
                    collisionFx.Play();
                }
                else if (GetPumpkinValue() == 20)
                {
                    collisionFx = Game.Content.Load<SoundEffect>("Sounds/OrangePumpkinSound");
                    collisionFx.Play();
                }
                else if (GetPumpkinValue() == 30)
                {
                    collisionFx = Game.Content.Load<SoundEffect>("Sounds/whitePumpkinSound");
                    collisionFx.Play();
                }
                else if (GetPumpkinValue() == -50)
                {
                    collisionFx = Game.Content.Load<SoundEffect>("Sounds/ghostSound");
                    collisionFx.Play();
                }


                CollectPumpkin();
                Game.Components.Remove(this);
            }

        }

        /// <summary>
        /// Collect collided pumkin and add to the score
        /// </summary>
        private void CollectPumpkin()
        {
            Game.Services.GetService<Score>().AddScore(GetPumpkinValue());
        }

        /// <summary>
        /// get each pumpkins value to add to the score
        /// </summary>
        /// <returns></returns>
        private int GetPumpkinValue()
        {
            switch (pumpkinType)
            {
                case PumpkinType.doubleScorePumpkin:
                    return (int)PumpkinValue.doubleScorePumpkin;
                case PumpkinType.ghost:
                    return (int)PumpkinValue.ghost;
                case PumpkinType.orangePumpkin:
                    return (int)PumpkinValue.orangePumpkin;
                case PumpkinType.tripleCorePumpkin:
                    return (int)PumpkinValue.TripleScorePumpkin;
                default:
                    return 0;
            }
        }

        protected override void LoadContent()
        {
            
            randomPumpkin = Game.Content.Load<Texture2D>($"Images/{pumpkinType.ToString()}");

            Random random = new Random();
            randomPumpkinPosition = new Vector2(random.Next(0, GraphicsDevice.Viewport.Width), 0);

            base.LoadContent();
        }
    }
}
