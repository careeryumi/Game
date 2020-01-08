using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace FinalProjectShell
{
   public class HighScoreComponent : DrawableGameComponent
    {
        Texture2D texture;
        private Vector2 picturePosition;

        string fileName = "highScore.txt";
        string scoreFromFile;

        SpriteFont font;

        string comment = "High score is : ";
        string currentHighScoreToString = "";

        public HighScoreComponent(Game game) : base(game)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService<SpriteBatch>();

            spriteBatch.Begin();
            spriteBatch.DrawString(font, comment, new Vector2(400, 160), Color.White);
            spriteBatch.DrawString(font, currentHighScoreToString, new Vector2(400, 200), Color.White);
                
            spriteBatch.End();

            base.Draw(gameTime);

            currentHighScoreToString = "";
        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    scoreFromFile = reader.ReadLine();
                    currentHighScoreToString = currentHighScoreToString + scoreFromFile;


                }
            }

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            picturePosition = new Vector2(30, 20);

            font = Game.Content.Load<SpriteFont>("fonts\\regularFont");
            texture = Game.Content.Load<Texture2D>("Images/backgroundLargeSize");
            base.LoadContent();
        }
    }
}
