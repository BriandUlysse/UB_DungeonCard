using CardDungeon.GameComponent;
using CardDungeon.GameComponent.Entities.Items;
using CardDungeon.GameComponent.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon
{
    public class CharacterStats
    {
        private int maxHP;
        private int currentHP;
        private int money;
        private int level;

        private Panel panel;
        private Sprite spriteHearth;
        private Sprite spriteMoney;

        private SpriteText maxHpSprite;
        private SpriteText slashHp;
        private SpriteText currentHpSprite;
        private SpriteText moneySprite;
        private SpriteText levelSprite;
        private Armor armor;
        private ILevelGame levelGame;

        public int Level { get => level; }
        public int CurrentHP { get => currentHP; }

        public CharacterStats(ILevelGame levelGame)
        {
            this.setMaxHP(10);
            this.setCurrentHp(10);
            this.setMoney(0);
            this.setLevel(1);

            this.panel = new Panel(320, 16, 0, 0);
            this.spriteHearth = new Sprite("GUI", 0, 15, 8, 5, 7, 6, Color.White);
            this.spriteMoney = new Sprite("GUI", 7, 15, 50, 5, 8, 6, Color.White);
            this.slashHp = new SpriteText(28, 3, "/");

            this.armor = null;
            this.levelGame = levelGame;
        }

        public void setCurrentHp(int currentHp)
        {
            this.currentHP = currentHp;
            this.currentHpSprite = new SpriteText(18, 3, this.currentHP.ToString());
        }

        public void removeCurrentHp(int nbToRemove)
        {
            this.setCurrentHp(this.currentHP - nbToRemove);
        }

        public void addCurrentHP(int nbToAdd)
        {
            this.setCurrentHp(this.currentHP + nbToAdd);
            if (this.currentHP>this.maxHP)
            {
                this.setCurrentHp(this.maxHP);
            }
        }

        public void setMaxHP(int maxHP)
        {
            this.maxHP = maxHP;
            this.maxHpSprite = new SpriteText(34, 3, this.maxHP.ToString());
        }

        public void setMoney(int money)
        {
            this.money = money;
            this.moneySprite = new SpriteText(60, 3, this.money.ToString());
        }

        public void setLevel(int level)
        {
            this.level = level;
            this.levelSprite = new SpriteText(100, 3, "Level:"+this.level.ToString());
        }

        public void setArmor(Armor newArmor)
        {
            if (!(this.armor !=null && this.armor.LevelArmor>newArmor.LevelArmor))
            {
                int diff = 0;
                if (this.armor!= null)
                {
                    diff = (newArmor.LevelArmor - this.armor.LevelArmor) *5;
                }
                else
                {
                    diff = newArmor.LevelArmor * 5;
                }
                this.setMaxHP(this.maxHP + diff);
                this.setCurrentHp(this.currentHP + diff);
                this.armor = newArmor;
                this.armor.setPosition(200, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.panel.Draw(spriteBatch);
            this.spriteHearth.Draw(spriteBatch);

            this.currentHpSprite.Draw(spriteBatch);
            this.slashHp.Draw(spriteBatch);
            this.maxHpSprite.Draw(spriteBatch);

            this.spriteMoney.Draw(spriteBatch);

            this.moneySprite.Draw(spriteBatch);
            
            this.levelSprite.Draw(spriteBatch);
            this.armor?.Draw(spriteBatch);
        }

        public void goToNextLevel()
        {
            this.setLevel(this.level + 1);
            this.levelGame.changeLevel(this.level);
        }
    }
}
