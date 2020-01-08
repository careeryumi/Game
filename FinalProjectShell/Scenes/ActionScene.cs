using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

/* Name: Yumi Lee
Assignment: Final Assignment 
This program is a game for catching pumpkins
Course Code: PROG-2370-4 Game Programming with Data Structures
Professor: Aneta Canhoto
Date: December 7, 2019 */

namespace FinalProjectShell
{
    public class ActionScene : GameScene
    {
        double gameStartTime = 0;
        double gameRunningTime = 20;

        SoundEffect gameEndFx;

        bool gameEnd = false;

        string fileName = "highScore.txt";

        int scoreFromFile;

        public ActionScene (Game game): base(game)
        {

        }
         
        public override void Initialize()
        {
            gameStartTime = 0;

            // create and add any components that belong to this scene
            this.SceneComponents.Add(new Background(Game));

            this.SceneComponents.Add(new Basket(Game));

            this.SceneComponents.Add(new PumpkinManager(Game));

            this.SceneComponents.Add(new Score(Game, "fonts\\regularFont"));
            this.SceneComponents.Add(new DisplayControl(Game, "fonts\\regularFont"));

            base.Initialize();
        }

        public void AddComponent(GameComponent component)
        {
            this.SceneComponents.Add(component);
            Game.Components.Add(component);
        }

        public override void Update(GameTime gameTime)
        {
            gameEnd = false;
            gameStartTime += gameTime.ElapsedGameTime.TotalSeconds;

            //check if game time passed, end game
            if (gameStartTime > gameRunningTime)
            {

                gameEndFx = Game.Content.Load<SoundEffect>("Sounds/gameOverSound");
                gameEndFx.Play();

                ((Game1)Game).HideAllScenes();

                Game.Services.GetService<GameEndScene>().Show();

                if (File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        scoreFromFile = int.Parse(reader.ReadLine());

                    }

                    if (scoreFromFile < Game.Services.GetService<Score>().ReturnFinalScore())
                    {
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            writer.WriteLine(Game.Services.GetService<Score>().ReturnFinalScore().ToString());
                        }
                    }
                }

                gameStartTime = 0;

                Game.Services.GetService<Score>().SetScoreToZero();

                gameEnd = true;

                SetGameEndFlag(gameEnd);
                
            }


            if (Enabled)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    gameStartTime = 0;

                    ((Game1)Game).HideAllScenes();

                    Game.Services.GetService<StartScene>().Show();

                }

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// store if the game ended or not
        /// </summary>
        /// <param name="gameEnd">gameEnd</param>
        public void SetGameEndFlag(bool gameEnd)
        {
            this.gameEnd = gameEnd;
        }


        /// <summary>
        /// return gameEnd value
        /// </summary>
        /// <returns></returns>
        public bool GetGameEndFlag()
        {
            return gameEnd;
        }
    }
}
