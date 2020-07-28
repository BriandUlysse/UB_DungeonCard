using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeon.GameComponent.GUI;
using CardDungeon.GameComponent.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.GameComponent.Entities.CardGUI
{
    public class CardGUIEnemy : CardGuiBase
    {
        private Enemy enemy;
        private SpriteText spriteTxtAttack;
        private SpriteText spriteTxtHP;
        private BlackHearthSprite hearthSprite;
        private AttackIconSprite attackIcon;

        public CardGUIEnemy(Entity entity, int x, int y) : base(x, y)
        {
            this.enemy = (Enemy)entity;
            this.spriteTxtAttack = new SpriteText(x +24, y +3, this.enemy.AttackPower.ToString(), Color.Black);
            this.hearthSprite = new BlackHearthSprite(x + 3, y +3);
            this.spriteTxtHP = new SpriteText(x + 10, 3, this.enemy.CurrentHP.ToString(), Color.Black);
            this.attackIcon = new AttackIconSprite(x + 18, y + 3);
        }

        public override void DrawGUI(SpriteBatch spriteBatch)
        {
            this.spriteTxtAttack.Draw(spriteBatch);
            this.hearthSprite.Draw(spriteBatch);
            this.spriteTxtHP.Draw(spriteBatch);
            this.attackIcon.Draw(spriteBatch);
            for (int i = 0; i < this.enemy.Effects.Count; i++)
            {
                this.enemy.Effects[i].Draw(spriteBatch);
            }
        }

        public override void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;

            this.spriteTxtAttack.setPosition(this.x +24, this.y+1);
            this.hearthSprite.setPosition(this.x + 3, y + 3);
            this.spriteTxtHP.setPosition(this.x + 10, y +1);
            this.attackIcon.setPosition(this.x + 18, y + 3);

            for (int i = 0; i < this.enemy.Effects.Count; i++)
            {
                this.enemy.Effects[i].setPosition(this.x + (((32 / 2) + (5 * i)) - (5 * this.enemy.Effects.Count / 2)+i), this.y + 25);
            }
        }

        public override void UpdateGUI(GameTime gameTime)
        {
            this.spriteTxtAttack.Text = this.enemy.AttackPower.ToString();
            this.spriteTxtHP.Text = this.enemy.CurrentHP.ToString();
        }
    }
}
