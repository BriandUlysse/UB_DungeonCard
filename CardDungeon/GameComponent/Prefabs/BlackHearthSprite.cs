using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CardDungeon.GameComponent.Prefabs
{
    public class BlackHearthSprite : Sprite
    {
        public BlackHearthSprite(int xTarget, int yTarget) : 
            base("GUI", 15, 2, xTarget, yTarget, 5, 4, Color.White)
        {
        }
    }
}
