using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.GameComponent.Entities.Items
{
    public class Armor : Item
    {
        private int levelArmor;

        public Armor(int levelArmor)
        {
            this.levelArmor = levelArmor;
            this.sprite = new Sprite("Sheet", (levelArmor - 1) * 16, 112, 0, 0, 16, 16, Color.White);
        }

        public int LevelArmor { get => levelArmor; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public override bool interact(CharacterStats characterStats, Inventory inventory)
        {
            characterStats.setArmor(new Armor(this.levelArmor));
            this.Deleted = true;
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
