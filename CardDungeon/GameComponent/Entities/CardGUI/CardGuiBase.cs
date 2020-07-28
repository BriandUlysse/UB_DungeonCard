using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent.Entities.CardGUI
{
    public abstract class CardGuiBase
    {
        protected int x;
        protected int y;

        public CardGuiBase(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract void DrawGUI(SpriteBatch spriteBatch);

        public abstract void UpdateGUI(GameTime gameTime);

        public abstract void setPosition(int x, int y);
    }
}
