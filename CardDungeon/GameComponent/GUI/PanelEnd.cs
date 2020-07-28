using CardDungeon.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent.GUI
{
    public class PanelEnd : Panel
    {
        private SpriteText spriteText;
        private Game1 game;
        private Button btnMainMenu;

        public PanelEnd(Game1 game, bool win) 
            : base(100, 70, (Settings.WIDTH_SOURCE/2) - (100/2), (Settings.HEIGHT_SOURCE/2)-50)
        {
            this.game = game;
            this.spriteText = new SpriteText(this.x + 10, this.y + 10, win?"You won!":"You lost...");
            this.btnMainMenu = new Button(75, 25, this.x + 12, this.y + 40, "Back to menu");
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.spriteText.Draw(spriteBatch);
            this.btnMainMenu.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            this.btnMainMenu.Update(gameTime);
            if (this.btnMainMenu.IsClicked)
            {
                this.game.changeScreen(new ScreenGameMenu(this.game));
            }
        }
    }
}
