using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.GameComponent.Entities.Items
{
    public class Weapon : Item
    {
        private int durability;
        private int attackPower;
        private WeaponType weaponType;

        public int Durability { get => durability; set => durability = value; }
        public int AttackPower { get => attackPower; set => attackPower = value; }

        public Weapon(WeaponType weaponType, bool quick = false, bool lifeSteal = false) : base()
        {
            this.weaponType = weaponType;
            switch (weaponType)
            {
                case WeaponType.DAGGER:
                    this.sprite = new Sprite("sheet", 3 * 16, 0, 0, 0, 16, 16, Color.White);
                    this.attackPower = 4;
                    this.durability = 1;
                    this.addEffet(EffectType.LIFESTEAL);
                    this.addEffet(EffectType.QUICK);
                    break;
                case WeaponType.SWORD:
                    this.sprite = new Sprite("sheet", 0, 0, 0, 0, 16, 16, Color.White);
                    this.attackPower = 3;
                    this.durability = 4;
                    break;
                case WeaponType.SPEAR:
                    this.sprite = new Sprite("sheet", 0, 16, 0, 0, 16, 16, Color.White);
                    this.attackPower = 4;
                    this.durability = 2;
                    break;
                case WeaponType.STAFF:
                    this.sprite = new Sprite("sheet", 64, 32, 0, 0, 16, 16, Color.White);
                    this.attackPower = 2;
                    this.durability = 3;
                    this.addEffet(EffectType.LIFESTEAL);
                    break;
                case WeaponType.KNIFE:
                    this.sprite = new Sprite("sheet", 3 * 16, 16, 0, 0, 16, 16, Color.White);
                    this.attackPower = 2;
                    this.durability = 1;
                    this.addEffet(EffectType.QUICK);
                    break;
                case WeaponType.BIG_SWORD:
                    this.sprite = new Sprite("sheet", 6 * 16, 0, 0, 0, 16, 16, Color.White);
                    this.attackPower = 6;
                    this.durability = 3;
                    break;
                case WeaponType.AXE:
                    this.sprite = new Sprite("sheet", 7 * 16, 16, 0, 0, 16, 16, Color.White);
                    this.attackPower = 9;
                    this.durability = 1;
                    break;
                case WeaponType.RAPIER:
                    this.sprite = new Sprite("sheet", 2 * 16, 0, 0, 0, 16, 16, Color.White);
                    this.attackPower = 4;
                    this.durability = 1;
                    this.addEffet(EffectType.LIFESTEAL);
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public bool attack(Enemy enemy, CharacterStats characterStats)
        {
            int pvBefore = enemy.CurrentHP;
            enemy.CurrentHP -= this.attackPower;
            if (this.possessEffect(EffectType.LIFESTEAL))
            {
                characterStats.addCurrentHP(pvBefore - enemy.CurrentHP);
            }
            this.durability--;
            if (this.durability<=0)
            {
                this.Deleted = true;
            }
            return !this.possessEffect(EffectType.QUICK);
        }

        public override bool interact(CharacterStats characterStats, Inventory inventory)
        {
            inventory.addToInventory(new Weapon(this.weaponType));
            this.Deleted = true;
            return false;
        }
    }

    public enum WeaponType
    {
        SWORD,
        DAGGER,
        SPEAR,
        STAFF,
        KNIFE,
        BIG_SWORD,
        AXE,
        RAPIER
    }
}
