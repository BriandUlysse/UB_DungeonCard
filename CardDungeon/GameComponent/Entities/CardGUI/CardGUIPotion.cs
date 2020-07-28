using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeon.GameComponent.Entities.Items;
using CardDungeon.GameComponent.GUI;
using CardDungeon.GameComponent.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.GameComponent.Entities.CardGUI
{
    public class CardGUIPotion : CardGuiBase
    {
        private Potion potion;
        private BlackCrossSprite crossSprite;
        private SpriteText spriteTxtHeal;

        public CardGUIPotion(Entity entity, int x, int y) : base(x, y)
        {
            this.potion = (Potion)entity;
            this.spriteTxtHeal = new SpriteText(this.x + 16, this.y + 24, this.potion.Heal.ToString(), Color.Black);
            this.crossSprite = new BlackCrossSprite(this.x + 9, this.y + 23);
        }

        public override void DrawGUI(SpriteBatch spriteBatch)
        {
            this.crossSprite.Draw(spriteBatch);
            this.spriteTxtHeal.Draw(spriteBatch);
        }

        public override void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;

            this.spriteTxtHeal.setPosition(this.x + 17, this.y + 23);
            this.crossSprite.setPosition(this.x + 10, this.y + 24);
        }

        public override void UpdateGUI(GameTime gameTime)
        {
            
        }
    }
}
