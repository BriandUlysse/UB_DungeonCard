using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent.GUI
{
    public class SpriteText
    {
        protected SpriteFont spriteFont;
        protected int x, y;
        protected String text;
        protected Color color;

        public string Text { get => text; set => text = value; }

        public SpriteText(int x, int y, String text)
        {
            this.x = x;
            this.y = y;
            this.text = text;
            this.spriteFont = ContentLoader.getFont("pixelmix");
            this.color = Color.White;
        }

        public SpriteText(int x, int y, String text, Color color)
        {
            this.x = x;
            this.y = y;
            this.text = text;
            this.spriteFont = ContentLoader.getFont("pixelmix");
            this.color = color;
        }

        public void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.spriteFont, this.text, new Vector2(x, y), color, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
        }

        public Vector2 getSizeString()
        {
            return spriteFont.MeasureString(this.text);
        }
    }
}
