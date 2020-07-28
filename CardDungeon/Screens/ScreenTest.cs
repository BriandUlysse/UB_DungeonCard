using CardDungeon.GameComponent;
using CardDungeon.GameComponent.Entities;
using CardDungeon.GameComponent.Entities.Items;
using CardDungeon.GameComponent.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.Screens
{
    public class ScreenTest : ScreenBase, ICardContext, ILevelGame
    {
        private Panel panelTest;
        private CharacterStats characterStats;
        private Inventory inventory;
        private Map map;
        private bool finished = false;
        private bool hasWin;
        private PanelEnd panelEnd;

        public ScreenTest(Game1 game) : base(game)
        {
        }

        public override void initialize()
        {
            this.panelTest = new Panel(320, 48, 0, 272);
            characterStats = new CharacterStats(this);
            this.inventory = new Inventory(10);

            this.map = new Map(64, 48, this,6,6);
            this.map.generateMap(1, this, 0.2f);

            this.inventory.addToInventory(new Weapon(WeaponType.SWORD));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.panelTest.Draw(spriteBatch);
            this.characterStats.Draw(spriteBatch);
            this.inventory.Draw(spriteBatch);

            this.map.Draw(spriteBatch);

            if (this.finished)
            {
                this.panelEnd.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!(finished))
            {
                this.inventory.Update(gameTime);

                this.map.Update(gameTime);

                if (this.characterStats.CurrentHP <= 0 || this.characterStats.Level >= 11)
                {
                    this.finished = true;
                    this.hasWin = this.characterStats.Level >= 11;
                    this.panelEnd = new PanelEnd(this.game, this.hasWin);
                }
            }
            else
            {
                this.panelEnd.Update(gameTime);
            }
            

            if (this.finished)
            {
                this.panelEnd.Update(gameTime);
            }
        }

        public void clickOnCard(Card clickedCard)
        {
            if (clickedCard.IsRevealed)
            {
                if (clickedCard.Entity != null)
                {
                    if (clickedCard.Entity.interact(this.characterStats, this.inventory))
                    {
                        passTurn();
                    }
                }
            }
            else
            {
                passTurn();
                clickedCard.turnCard();
            }
            
        }

        public void hoverCard(Card hoveredCard)
        {
            hoveredCard.createHovering();
        }

        private void passTurn()
        {
            this.map.allEnemyAttack(this.characterStats);
        }

        public void onEntityDeleted(Card cardEntity)
        {
            cardEntity.deleteEntity();
        }

        public void deleteCardFromList(Card cardToDelete)
        {
            this.map.deleteCard(cardToDelete);
        }

        public void changeLevel(int level)
        {
            this.map.generateMap(level, this, 0.2f);
        }
    }
}
