using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProjectShell
{
    class AboutComponent : DrawableGameComponent
    {

        Texture2D texture;
        private Vector2 picturePosition;

        public AboutComponent(Game game) : base(game)
        {
            
        }

        
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService<SpriteBatch>();

            spriteBatch.Begin();
            spriteBatch.Draw(texture, picturePosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            picturePosition = new Vector2(70, 40);
            texture = Game.Content.Load<Texture2D>("Images/aboutPagePicture");
            base.LoadContent();
        }
         
    }
}
