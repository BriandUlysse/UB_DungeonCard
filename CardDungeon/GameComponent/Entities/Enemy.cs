using CardDungeon.GameComponent.Entities.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent.Entities
{
    public class Enemy : Entity
    {
        private int HP;
        private int currentHP;
        private int attackPower;

        public Enemy(EnemyType enemyType) : base()
        {
            int x = 0;
            int y = 0;
            int HP = 3;
            int attack = 2;

            switch (enemyType)
            {
                case EnemyType.SMALL_CRIER:
                    break;
                case EnemyType.SMALL_ZOMBIE:
                    HP = 5;
                    x = 16;
                    break;
                case EnemyType.SMALL_DEMON:
                    attack = 4;
                    x = 32;
                    break;
                case EnemyType.SKELETON:
                    HP = 5;
                    attack = 3;
                    x = 48;
                    break;
                case EnemyType.CRIER:
                    HP = 5;
                    attack = 2;
                    y = 16;
                    this.addEffet(EffectType.LIFESTEAL);
                    break;
                case EnemyType.ZOMBIE:
                    HP = 8;
                    attack = 4;
                    y = 16;
                    x = 16;
                    break;
                case EnemyType.DEMON:
                    HP = 5;
                    attack = 7;
                    x = 32;
                    y = 16;
                    break;
                case EnemyType.MASKED_ZOMBIE:
                    HP = 12;
                    attack = 4;
                    x = 48;
                    y = 16;
                    this.addEffet(EffectType.LIFESTEAL);
                    break;
                case EnemyType.GARGABAGE:
                    HP = 12;
                    attack = 8;
                    y = 32;
                    break;
                default:
                    break;
            }

            this.sprite = new Sprite("enemies", x, y, 0, 0, 16, 16, Color.White);
            this.HP = HP;
            this.currentHP = HP;
            this.attackPower = attack;
        }

        public int AttackPower { get => attackPower; set => attackPower = value; }
        public int CurrentHP { get => currentHP; set => currentHP = value; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public override bool interact(CharacterStats characterStats, Inventory inventory)
        {
            bool res = false;
            if (inventory.SelectedCard != null)
            {
                if (inventory.SelectedCard.Entity is Weapon)
                {
                    Weapon weapon = (Weapon)inventory.SelectedCard.Entity;
                    res = weapon.attack(this, characterStats);
                }
            }
            else
            {
                this.currentHP -= 1;
                res = true;
            }

            if (this.currentHP > 0)
            {
                
            }
            else
            {
                this.Deleted = true;
            }

            return res;
        }

        public void attack(CharacterStats characterStats)
        {
            characterStats.removeCurrentHp(this.AttackPower);
            if (this.possessEffect(EffectType.LIFESTEAL))
            {
                this.CurrentHP += this.attackPower;
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }

    public enum EnemyType
    {
        SMALL_CRIER,
        SMALL_ZOMBIE,
        SMALL_DEMON,
        SKELETON,
        CRIER,
        ZOMBIE,
        DEMON,
        MASKED_ZOMBIE,
        GARGABAGE
    }
}
