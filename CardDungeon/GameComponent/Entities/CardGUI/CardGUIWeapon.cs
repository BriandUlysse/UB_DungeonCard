using CardDungeon.GameComponent.Entities.Items;
using CardDungeon.GameComponent.GUI;
using CardDungeon.GameComponent.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CardDungeon.GameComponent.Entities.CardGUI
{
    public class CardGUIWeapon : CardGuiBase
    {
        private Weapon weapon;
        private SpriteText spriteFontAttackPower;
        private List<SmallBarSprite> listBars;
        private AttackIconSprite attackIcon;

        public CardGUIWeapon(Entity entity, int x, int y) : base(x, y)
        {
            this.weapon = (Weapon)entity;
            spriteFontAttackPower = new SpriteText(x+24, y+1, this.weapon.AttackPower.ToString(), Color.Black);

            this.listBars = new List<SmallBarSprite>();
            for (int i = 0; i < weapon.Durability; i++)
            {
                listBars.Add(new SmallBarSprite(x + 3, (i * 3) + 5));
            }

            this.attackIcon = new AttackIconSprite(x + 18, y + 3);
        }

        public override void DrawGUI(SpriteBatch spriteBatch)
        {
            spriteFontAttackPower.Draw(spriteBatch);

            for (int i = 0; i < weapon.Durability; i++)
            {
                listBars[i].Draw(spriteBatch);
            }
            this.attackIcon.Draw(spriteBatch);
            for (int i = 0; i < this.weapon.Effects.Count; i++)
            {
                this.weapon.Effects[i].Draw(spriteBatch);
            }
        }

        public override void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;

            this.spriteFontAttackPower.setPosition(x + 24, y + 1);

            for (int i = 0; i < weapon.Durability; i++)
            {
                listBars[i].setPosition(x + 3, y + (i * 3) + 5);
            }
            this.attackIcon.setPosition(x + 18, y + 3);
            for (int i = 0; i < this.weapon.Effects.Count; i++)
            {
                this.weapon.Effects[i].setPosition(this.x +(((32 / 2) + (5 * i)) - (5 * this.weapon.Effects.Count / 2)+i), this.y + 25);
            }
        }

        public override void UpdateGUI(GameTime gameTime)
        {
            this.spriteFontAttackPower.Text = this.weapon.AttackPower.ToString();
        }
    }
}