using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent.GUI
{
    public class Button : Panel
    {
        private bool isLocked;
        private bool isHovered;
        private bool isClicked;
        private String text;
        private Rectangle hitbox;
        private SpriteText spriteText;

        public bool IsClicked { get => isClicked; }
        

        public Button(int _width, int _height, int x, int y, String _text) : base(_width, _height, x, y)
        {
            this.text = _text;
            this.hitbox = new Rectangle(this.x, this.y, this.width, this.height);

            spriteText = new SpriteText(this.x, this.y, this.text);

            int _x = this.x + (this.width / 2) - ((int)spriteText.getSizeString().X / 2);
            int _y = this.y + (this.height / 2) - ((int)spriteText.getSizeString().Y / 2);

            spriteText.setPosition(_x, _y);
        }

        public void Update(GameTime gameTime)
        {
            if (isLocked)
            {
                this.color = Color.DimGray;
            }
            else if (isClicked)
            {
                this.color = Color.Honeydew;
            }
            else if (isHovered)
            {
                this.color = Color.LightGray;
            }
            else
            {
                this.color = Color.White;
            }

            if (this.hitbox.Contains(Input.CurrentMoussePosition()))
            {
                this.isHovered = true;
            }
            else
            {
                this.isHovered = false;
            }

            if (isHovered && Input.isLeftClicked())
            {
                this.isClicked = true;
            }
            else
            {
                this.isClicked = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteText.Draw(spriteBatch);
        }
    }
}
