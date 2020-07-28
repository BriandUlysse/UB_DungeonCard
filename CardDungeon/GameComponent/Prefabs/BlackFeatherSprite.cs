using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CardDungeon.GameComponent.Prefabs
{
    public class BlackFeatherSprite : Sprite
    {
        public BlackFeatherSprite(int xTarget, int yTarget)
            : base("GUI", 21, 0, xTarget, yTarget, 5, 5, Color.White)
        {
        }
    }
}
