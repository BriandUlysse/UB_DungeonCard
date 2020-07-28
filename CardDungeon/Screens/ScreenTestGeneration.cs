using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeon.GameComponent;
using CardDungeon.GameComponent.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.Screens
{
    public class ScreenTestGeneration : ScreenBase, ICardContext
    {
        private Map map;
        private Button regenerateButton;

        public ScreenTestGeneration(Game1 game) : base(game)
        {
        }

        public override void initialize()
        {
            this.map = new Map(0, 50, this,6,6);
            regenerateAndTurn();
            this.regenerateButton = new Button(75, 50, 0, 0, "regenerate");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.regenerateButton.Draw(spriteBatch);
            this.map.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            this.regenerateButton.Update(gameTime);
            this.map.Update(gameTime);
            if (this.regenerateButton.IsClicked)
            {
                regenerateAndTurn();
            }
        }

        public void clickOnCard(Card clickedCard)
        {
            
        }

        public void hoverCard(Card hoveredCard)
        {
            
        }

        private void regenerateAndTurn()
        {
            this.map.generateMap(20, this,0.2f);
            this.map.turnAll();
        }

        public void onEntityDeleted(Card cardEntity)
        {
            
        }

        public void deleteCardFromList(Card cardToDelete)
        {
            
        }
    }
}
