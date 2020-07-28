using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CardDungeon.GameComponent.Prefabs
{
    public class SmallBarSprite : Sprite
    {
        public SmallBarSprite(int xTarget, int yTarget) 
            : base("GUI", 15, 0, xTarget, yTarget, 3, 2, Color.White)
        {
        }
    }
}
