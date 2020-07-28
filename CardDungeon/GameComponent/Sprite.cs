using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent
{
    public class Sprite
    {
        private String nameTexture;
        private Texture2D texture;
        private int xSource;
        private int ySource;
        private int xTarget;
        private int yTarget;
        private int width;
        private int height;
        private Color color;


        public int XSource { get => xSource; set => xSource = value; }
        public int YSource { get => ySource; set => ySource = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Color Color { get => color; set => color = value; }


        public Sprite(String nameTexture, int xSource, int ySource, int xTarget, int yTarget, int width, int height, Color color)
        {
            this.nameTexture = nameTexture;
            this.texture = ContentLoader.getTexture(nameTexture);
            this.xSource = xSource;
            this.ySource = ySource;
            this.xTarget = xTarget;
            this.yTarget = yTarget;
            this.width = width;
            this.height = height;
            this.Color = color;
        }
        
        public void setPosition(int x, int y)
        {
            this.xTarget = x;
            this.yTarget = y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Rectangle(this.xTarget, this.yTarget, this.width, this.height),
                new Rectangle(this.xSource, this.ySource, this.width, this.height), this.Color);
        }
    }
}
