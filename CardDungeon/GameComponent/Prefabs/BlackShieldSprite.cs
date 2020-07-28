using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CardDungeon.GameComponent.Prefabs
{
    public class BlackShieldSprite : Sprite
    {
        public BlackShieldSprite(int xTarget, int yTarget)
            : base("GUI", 15, 6, xTarget, yTarget, 6, 5, Color.White)
        {
        }
    }
}
