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
    public class CardGUIArmor : CardGuiBase
    {
        private Armor armor;
        private BlackShieldSprite shieldSprite;
        private SpriteText spriteTxtShield;

        public CardGUIArmor(Entity entity, int x, int y) : base( x, y)
        {
            this.armor = (Armor)entity;

            this.spriteTxtShield = new SpriteText(this.x +16, this.y+24, (armor.LevelArmor * 5).ToString(), Color.Black);
            this.shieldSprite = new BlackShieldSprite(this.x + 10, this.y + 24);
        }

        public override void DrawGUI(SpriteBatch spriteBatch)
        {
            this.shieldSprite.Draw(spriteBatch);
            this.spriteTxtShield.Draw(spriteBatch);
        }

        public override void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;

            this.spriteTxtShield.setPosition(this.x + 17, this.y + 22);
            this.shieldSprite.setPosition(this.x + 10, this.y + 24);
        }

        public override void UpdateGUI(GameTime gameTime)
        {
            
        }
    }
}
