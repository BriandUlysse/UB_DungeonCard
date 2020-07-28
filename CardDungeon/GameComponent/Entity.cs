using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent
{
    public abstract class Entity
    {
        protected Sprite sprite;
        protected int x;
        protected int y;
        private bool deleted = false;
        private List<Effect> effects;

        public Entity()
        {
            this.effects = new List<Effect>();
        }

        public bool Deleted { get => deleted; set => deleted = value; }
        public List<Effect> Effects { get => effects; }

        public void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.sprite.setPosition(x, y);
        }
        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        public abstract bool interact(CharacterStats characterStats, Inventory inventory);

        public void addEffet(EffectType effectType)
        {
            this.effects.Add(new Effect(effectType));
        }

        public bool possessEffect(EffectType effectType)
        {
            bool res = false;
            foreach(Effect effect in effects)
            {
                res = res || effect.EffectType == effectType;
            }
            return res;
        }
    }
}
