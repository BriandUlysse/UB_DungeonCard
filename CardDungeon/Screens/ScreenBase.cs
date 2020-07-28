using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.Screens
{
    public abstract class ScreenBase
    {
        protected Game1 game;

        public ScreenBase(Game1 game)
        {
            this.game = game;
        }

        public abstract void initialize();

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
