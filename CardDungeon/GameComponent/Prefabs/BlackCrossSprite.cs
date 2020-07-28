using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CardDungeon.GameComponent.Prefabs
{
    public class BlackCrossSprite : Sprite
    {
        public BlackCrossSprite(int xTarget, int yTarget)
            : base("GUI", 15, 15, xTarget, yTarget, 6, 6, Color.White)
        {
        }
    }
}
