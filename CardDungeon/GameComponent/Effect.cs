using CardDungeon.GameComponent.Prefabs;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent
{
    public class Effect
    {
        private Sprite sprite;
        private EffectType effectType;

        public Effect(EffectType effectType)
        {
            switch (effectType)
            {
                case EffectType.LIFESTEAL:
                    this.effectType = effectType;
                    this.sprite = new BlackFangSprite(0, 0);
                    break;
                case EffectType.QUICK:
                    this.effectType = effectType;
                    this.sprite = new BlackFeatherSprite(0, 0);
                    break;
                default:
                    break;
            }
            
        }

        public EffectType EffectType { get => effectType; }

        public void setPosition(int x, int y)
        {
            this.sprite.setPosition(x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }

    public enum EffectType
    {
        LIFESTEAL,
        QUICK
    }
}
