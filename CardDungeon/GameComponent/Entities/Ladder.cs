using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.GameComponent.Entities
{
    public class Ladder : Entity
    {
        public Ladder()
        {
            this.sprite = new Sprite("Sheet", 112, 64, 0, 0, 16, 16, Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public override bool interact(CharacterStats characterStats, Inventory inventory)
        {
            characterStats.goToNextLevel();
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
