using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent.GUI
{
    public class Panel
    {
        private Rectangle leftUpCorner;
        private Rectangle upSide;
        private Rectangle rightUpCorner;
        private Rectangle leftSide;
        private Rectangle content;
        private Rectangle RightSide;
        private Rectangle LeftDownCorner;
        private Rectangle DownSide;
        private Rectangle RightDownCorner;

        protected int width, height, x, y;
        private Texture2D texture;
        protected Color color;

        public Color Color { get => color; set => color = value; }

        public Panel(int _width, int _height, int x, int y)
        {
            this.texture = ContentLoader.getTexture("GUI");
            this.width = _width;
            this.height = _height;
            this.x = x;
            this.y = y;

            leftUpCorner = new Rectangle(0, 0, 5, 5);
            upSide = new Rectangle(5, 0, 5, 5);
            rightUpCorner = new Rectangle(10 , 0, 5, 5);
            leftSide = new Rectangle(0 , 5, 5, 5);
            content = new Rectangle(5 , 5, 5, 5);
            RightSide = new Rectangle(10 , 5, 5, 5);
            LeftDownCorner = new Rectangle(0, 10, 5, 5);
            DownSide = new Rectangle(5 , 10, 5, 5);
            RightDownCorner = new Rectangle(10, 10, 5, 5);

            color = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int blocSize = 5;

            for (int xBlock = 0; xBlock * blocSize < this.height; xBlock++)
            {
                for (int yBlock = 0; yBlock * blocSize < this.width; yBlock++)
                {
                    Rectangle rect = content;
                    int horizontalDecal = 0;
                    int verticalDecal = 0;

                    if (xBlock == 0 && yBlock == 0)
                    {
                        rect = leftUpCorner;
                    }
                    else if (xBlock == 0 && this.width - (yBlock * blocSize) - blocSize <= 0)
                    {
                        rect = rightUpCorner;
                        horizontalDecal = ((yBlock+1) * blocSize) - this.width;
                    }
                    else if (yBlock == 0 && this.height - (xBlock * blocSize) - blocSize <= 0)
                    {
                        rect = LeftDownCorner;
                        verticalDecal = ((xBlock + 1) * blocSize) - this.height;
                    }
                    else if (this.width - (yBlock * blocSize) - blocSize <= 0 && this.height - (xBlock * blocSize) - blocSize <= 0)
                    {
                        rect = RightDownCorner;
                        horizontalDecal = ((yBlock+1) * blocSize) - this.width;
                        verticalDecal = ((xBlock + 1) * blocSize) - this.height;
                    }
                    else if (xBlock == 0)
                    {
                        rect = upSide;
                    }
                    else if (yBlock == 0)
                    {
                        rect = leftSide;
                    }
                    else if (this.height - (xBlock * blocSize) - blocSize <= 0)
                    {
                        rect = DownSide;
                        verticalDecal = ((xBlock + 1) * blocSize) - this.height;
                    }
                    else if (this.width - (yBlock * blocSize) - blocSize <= 0)
                    {
                        rect = RightSide;
                        horizontalDecal = ((yBlock+1) * blocSize) - this.width;
                    }

                    spriteBatch.Draw(texture,
                        new Rectangle((this.x + yBlock * blocSize) - horizontalDecal, (this.y + xBlock * blocSize) - verticalDecal
                            , blocSize, blocSize), rect, color);
                }
            }

        }
    }
}
