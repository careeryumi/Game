using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FinalProjectShell
{
    class PumpkinManager : GameComponent
    {
        double secondsSinceLast = 0.0;
        const double PUMPKIN_INTERVAL = 0.8;

        Random random;

        public PumpkinManager(Game game) : base(game)
        {
            random = new Random();
            //this.parent = parent;
        }

        public override void Update(GameTime gameTime)
        {

            secondsSinceLast += gameTime.ElapsedGameTime.TotalSeconds;


            if (secondsSinceLast > PUMPKIN_INTERVAL)
            {
                Vector2 location = new Vector2(random.Next(Game.GraphicsDevice.Viewport.Width),
                    random.Next(Game.GraphicsDevice.Viewport.Height));

                Game.Components.Add(new Pumpkin(Game, GetRandomPumpkinType(), location));

                secondsSinceLast = 0.0;
            }

            

            base.Update(gameTime);
        }

        /// <summary>
        /// Get random pumpkin's type
        /// </summary>
        /// <returns></returns>
        private PumpkinType GetRandomPumpkinType()
        {
            int pumpkinMax = Enum.GetNames(typeof(PumpkinType)).Length;
            int randomPumpkin = random.Next(0, pumpkinMax);
            return (PumpkinType)randomPumpkin;

        }
    }
}
