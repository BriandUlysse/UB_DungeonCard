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
    public class ScreenGameMenu : ScreenBase
    {
        private Button btnPlayGame;
        private Button btnHowToPlay;
        private Button btnCredit;
        private Button btnQuit;

        public ScreenGameMenu(Game1 game) : base(game)
        {

        }

        public override void initialize()
        {
            this.btnPlayGame = new Button(64, 20, (Settings.WIDTH_SOURCE / 2) - 32, 20, "Play");
            this.btnHowToPlay = new Button(64, 20, (Settings.WIDTH_SOURCE / 2) - 32, 50, "How to play");
            this.btnCredit = new Button(64, 20, (Settings.WIDTH_SOURCE / 2) - 32, 80, "Credit");
            this.btnQuit = new Button(64, 20, (Settings.WIDTH_SOURCE / 2) - 32, 110, "Quit");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.btnPlayGame.Draw(spriteBatch);
            this.btnHowToPlay.Draw(spriteBatch);
            this.btnCredit.Draw(spriteBatch);
            this.btnQuit.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            this.btnPlayGame.Update(gameTime);
            this.btnHowToPlay.Update(gameTime);
            this.btnCredit.Update(gameTime);
            this.btnQuit.Update(gameTime);

            if (this.btnPlayGame.IsClicked)
            {
                this.game.changeScreen(new ScreenTest(this.game));
            }
            if (this.btnHowToPlay.IsClicked)
            {
                this.game.changeScreen(new ScreenHowToPlay(this.game));
            }
            if (this.btnCredit.IsClicked)
            {
                this.game.changeScreen(new ScreenCredit(this.game));
            }
            if (this.btnQuit.IsClicked)
            {
                this.game.Exit();
            }
        }
    }
}
