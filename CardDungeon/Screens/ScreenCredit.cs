using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeon.GameComponent;
using CardDungeon.GameComponent.Entities;
using CardDungeon.GameComponent.Entities.Items;
using CardDungeon.GameComponent.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.Screens
{
    public class ScreenCredit : ScreenBase, ICardContext
    {
        private Button btnMainMenu;
        private Panel panel;
        private Card exampleCardEnemy;
        private Card exampleCardObject;
        private SpriteText sprTxtCreator;
        private SpriteText sprTxtFont;
        private SpriteText sprTxtEnemy;
        private SpriteText sprTxtObject;

        public ScreenCredit(Game1 game) : base(game)
        {
        }

        public override void initialize()
        {
            this.btnMainMenu = new Button(64, 20, (Settings.WIDTH_SOURCE / 2) - 32, 270, "Back");
            this.panel = new Panel(Settings.WIDTH_SOURCE - 40, 230, 20, 20);

            this.sprTxtCreator = new SpriteText(70, 30, "Game made by Ulysse Briand");

            this.sprTxtFont = new SpriteText(70, 45, "Font made by Andrew Tyler");

            this.exampleCardEnemy = new Card(new Enemy(EnemyType.SMALL_ZOMBIE), this, true);
            this.exampleCardEnemy.setPosition(30, 60);
            this.sprTxtEnemy = new SpriteText(70, 71, "Enemies sprites made by 0x72");

            this.exampleCardObject = new Card(new Weapon(WeaponType.SWORD), this, true);
            this.exampleCardObject.setPosition(30, 95);
            this.sprTxtObject = new SpriteText(70, 105, "items sprites made by Alex's");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.btnMainMenu.Draw(spriteBatch);
            this.panel.Draw(spriteBatch);

            this.sprTxtCreator.Draw(spriteBatch);
            this.sprTxtFont.Draw(spriteBatch);

            this.exampleCardEnemy.Draw(spriteBatch);
            this.sprTxtEnemy.Draw(spriteBatch);

            this.exampleCardObject.Draw(spriteBatch);
            this.sprTxtObject.Draw(spriteBatch);
        }


        public override void Update(GameTime gameTime)
        {
            this.btnMainMenu.Update(gameTime);

            if (this.btnMainMenu.IsClicked)
            {
                this.game.changeScreen(new ScreenGameMenu(this.game));
            }
        }

        public void clickOnCard(Card clickedCard)
        {
            
        }

        public void hoverCard(Card hoveredCard)
        {
            
        }

        public void onEntityDeleted(Card cardEntity)
        {
            
        }

        public void deleteCardFromList(Card cardToDelete)
        {
            
        }
    }
}
