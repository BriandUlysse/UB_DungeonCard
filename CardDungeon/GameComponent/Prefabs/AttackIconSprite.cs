using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CardDungeon.GameComponent.Prefabs
{
    public class AttackIconSprite : Sprite
    {
        public AttackIconSprite(int xTarget, int yTarget)
            : base("GUI", 15, 11, xTarget, yTarget, 4, 4, Color.White)
        {
        }
    }
}
