using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent
{
    public class Inventory : ICardContext
    {
        private List<Card> listEntity;
        private List<Card> listToDelete;
        private int maxSize;
        private Card selectedCard;

        public Inventory(int maxSize)
        {
            this.listEntity = new List<Card>();
            this.listToDelete = new List<Card>();
            this.maxSize = maxSize;
            this.updatePositionCard();
        }

        public int MaxSize { get => maxSize; set => maxSize = value; }
        public Card SelectedCard { get => selectedCard; set => selectedCard = value; }

        public void Update(GameTime gameTime)
        {
            foreach (Card entity in listEntity)
            {
                entity.Update(gameTime);
                if (entity.Deleted)
                {
                    listToDelete.Add(entity);
                }
            }

            foreach (Card entity in listToDelete)
            {
                listEntity.Remove(entity);
            }
            if (listToDelete.Count>0)
            {
                listToDelete.Clear();
                updatePositionCard();
                if (this.selectedCard != null)
                {
                    if (this.selectedCard.Deleted)
                    {
                        this.selectedCard = null;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Card entity in listEntity)
            {
                entity.Draw(spriteBatch);
            }
        }

        public bool addToInventory(Entity entityToAdd)
        {
            bool res = false;
            if (maxSize > listEntity.Count)
            {
                this.listEntity.Add(new Card(entityToAdd, this, true));
                updatePositionCard();
                res = true;
            }

            return res;
        }

        private void updatePositionCard()
        {
            int y = 280;
            int nbCard = this.listEntity.Count;
            int cpt = 0;
            foreach (Card entity in listEntity)
            {
                int entityY = entity == this.selectedCard ? y - 5 : y;
                
                int x = ((Settings.WIDTH_SOURCE / 2) + (32 * cpt)) - (32 * nbCard / 2);
                cpt++;
                entity.setPosition(x, entityY);
            }
        }

        public void clickOnCard(Card clickedCard)
        {
            if (selectedCard != clickedCard)
            {
                selectedCard = clickedCard;
            }
            else
            {
                this.selectedCard = null;
            }
            updatePositionCard();
        }

        public void hoverCard(Card hoveredCard)
        {
            hoveredCard.createHovering();
        }

        public void onEntityDeleted(Card cardEntity)
        {
            deleteCardFromList(cardEntity);
            this.selectedCard = null;
        }

        public void deleteCardFromList(Card cardToDelete)
        {
            this.listToDelete.Add(cardToDelete);
        }
    }
}
