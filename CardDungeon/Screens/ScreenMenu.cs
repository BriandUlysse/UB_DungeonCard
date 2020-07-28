using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeon.GameComponent.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.Screens
{
    public class ScreenMenu : ScreenBase
    {
        private Button btnTest;
        private Button btnTestGeneration;
        private Button btnGameProd;

        public ScreenMenu(Game1 game) : base(game)
        {
        }

        public override void initialize()
        {
            this.btnTest = new Button(75, 20, 50, 30, "Test game");
            this.btnTestGeneration = new Button(75, 20, 50, 60, "Test generation");
            this.btnGameProd = new Button(75, 20, 50, 90, "Game mode");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.btnTest.Draw(spriteBatch);
            this.btnTestGeneration.Draw(spriteBatch);
            this.btnGameProd.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            this.btnTest.Update(gameTime);
            this.btnTestGeneration.Update(gameTime);
            this.btnGameProd.Update(gameTime);

            if (this.btnTest.IsClicked)
            {
                this.game.changeScreen(new ScreenTest(this.game));
            }

            if (this.btnTestGeneration.IsClicked)
            {
                this.game.changeScreen(new ScreenTestGeneration(this.game));
            }

            if (this.btnGameProd.IsClicked)
            {
                this.game.changeScreen(new ScreenGameMenu(this.game));
            }
        }
    }
}
