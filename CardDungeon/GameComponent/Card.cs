using CardDungeon.GameComponent.Entities.CardGUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent
{
    public class Card
    {
        private Sprite spriteCard;
        private bool isEnable;
        private bool isRevealed;
        private Entity entity;
        private int x;
        private int y;
        private Rectangle hitbox;
        private bool isHovered;
        private Sprite hovering;
        private ICardContext cardContext;
        private CardGuiBase cardGui;
        private bool deleted = false;

        public Entity Entity { get => entity; set => entity = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool IsRevealed { get => isRevealed; set => isRevealed = value; }
        public bool Deleted { get => deleted; set => deleted = value; }

        public Card(Entity entity, ICardContext cardContext, bool isRevealed = false)
        {
            this.entity = entity;
            this.spriteCard = new Sprite("Tile", 32, 0, 0, 0, 32, 32, Color.White);
            this.isEnable = true;
            this.isRevealed = isRevealed;
            if (this.isRevealed)
            {
                turnCard();
            }
            this.cardContext = cardContext;

            this.updateHitbox();

            this.cardGui = CardGUIFactory.getGui(this);
        }

        public void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.spriteCard.setPosition(x, y);

            this.entity?.setPosition(x + 8, y + 8);
            this.updateHitbox();
            this.updateHovering();

            this.cardGui?.setPosition(x, y);
        }

        public void Update(GameTime gameTime)
        {
            if (this.hitbox.Contains(Input.CurrentMoussePosition().X, Input.CurrentMoussePosition().Y))
            {
                this.isHovered = true;

                if (Input.isLeftClicked())
                {
                    cardContext.clickOnCard(this);
                }
            }
            else
            {
                this.isHovered = false;
            }

            if (this.isHovered)
            {
                cardContext.hoverCard(this);
            }

            if (this.isRevealed)
            {
                this.cardGui?.UpdateGUI(gameTime);
            }

            if (this.entity !=null)
            {
                if (this.entity.Deleted)
                {
                    cardContext.onEntityDeleted(this);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.spriteCard.Draw(spriteBatch);
            if (this.entity != null && this.isRevealed)
            {
                this.entity.Draw(spriteBatch);
                this.cardGui?.DrawGUI(spriteBatch);
            }
            if (this.isHovered && this.hovering != null)
            {
                this.hovering.Draw(spriteBatch);
            }
        }

        public void turnCard()
        {
            this.spriteCard.XSource = 0;
            this.isRevealed = true;
        }

        private void updateHitbox()
        {
            this.hitbox = new Rectangle(this.x, this.y, 32, 32);
        }

        private void updateHovering()
        {
            if (this.hovering != null)
            {
                this.hovering = new Sprite("Tile", 64, 0, x - 1, y - 1, 34, 34, Color.White);
            }
        }

        public void createHovering()
        {
            if (this.hovering == null)
            {
                this.hovering = new Sprite("Tile", 64, 0, x - 1, y - 1, 34, 34, Color.White);
            }
        }

        public void deleteEntity()
        {
            this.entity = null;
            this.cardGui = null;
        }
    }
}
