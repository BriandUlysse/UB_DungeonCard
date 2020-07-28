using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.GameComponent.Entities.Items
{
    public class Potion : Item
    {
        private int heal;
        private PotionType potionType;

        public Potion(PotionType potionType)
        {
            this.potionType = potionType;
            int x = 0;
            int y = 0;

            switch (potionType)
            {
                case PotionType.SMALL_POTION:
                    x = 64;
                    y = 48;
                    this.heal = 10;
                    break;
                case PotionType.BIG_POTION:
                    x = 80;
                    y = 48;
                    this.heal = 20;
                    break;
                case PotionType.APPLE:
                    x = 0;
                    y = 128;
                    this.heal = 5;
                    break;
                case PotionType.CAKE:
                    x = 48;
                    y = 128;
                    this.heal = 15;
                    break;
                default:
                    break;
            }

            this.sprite = new Sprite("Sheet", x, y, 0, 0, 16, 16, Color.White);
        }

        public int Heal { get => heal; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public override bool interact(CharacterStats characterStats, Inventory inventory)
        {
            characterStats.addCurrentHP(this.heal);
            this.Deleted = true;
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }

    public enum PotionType
    {
        SMALL_POTION,
        BIG_POTION,
        APPLE,
        CAKE
    }
}
