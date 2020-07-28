using CardDungeon.GameComponent.Entities;
using CardDungeon.GameComponent.Entities.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent
{
    public class Map
    {
        private int width = 8;
        private int height = 8;
        private int mapX;
        private int mapY;

        private Card[,] mapCard;

        public Map(int x, int y, ICardContext cardContext, int width, int height)
        {
            this.mapX = x;
            this.mapY = y;
            this.width = width;
            this.height = height;
            this.mapCard = new Card[this.width, this.height];
        }

        public void generateMap(int level, ICardContext cardContext, float ratioEmptyCard=1)
        {
            Random rnd = new Random();
            Entity[,] entities = MapGenerator.generateMapCard(this.width, this.height, level);

            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    if (entities[x, y] == null)
                    {
                        int value = rnd.Next(100);
                        if (value> (100* ratioEmptyCard))
                        {
                            this.setCard(x, y, null);
                        }
                        else
                        {
                            this.setCard(x, y, new Card(null, cardContext));
                        }
                    }
                    else
                    {
                        this.setCard(x, y, new Card(entities[x, y], cardContext));
                    }
                    
                    
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    Card currentCard = this.mapCard[x, y];

                    if (currentCard !=null)
                    {
                        currentCard.Draw(spriteBatch);
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    Card currentCard = this.mapCard[x, y];

                    if (currentCard != null)
                    {
                        currentCard.Update(gameTime);
                        if (currentCard.Deleted)
                        {
                            this.mapCard[x,y] = null;
                        }
                    }
                }
            }
        }

        public void setCard(int x, int y, Card card)
        {
            this.mapCard[x, y] = card;
            card?.setPosition((x * 32) + this.mapX, (y * 32)+this.mapY);
        }

        public void turnAll()
        {
            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    this.mapCard[x, y]?.turnCard();
                }
            }
        }

        public void allEnemyAttack(CharacterStats characterStats)
        {
            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    if (this.mapCard[x, y] != null && this.mapCard[x, y].Entity != null
                        && this.mapCard[x, y].Entity is Enemy
                        && this.mapCard[x, y].IsRevealed
                        && !this.mapCard[x, y].Entity.Deleted)
                    {
                        Enemy enemy = (Enemy)this.mapCard[x, y].Entity;
                        enemy.attack(characterStats);
                    }
                }
            }
        }

        public void deleteCard(Card card)
        {
            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    if (this.mapCard[x, y] == card)
                    {
                        this.mapCard[x, y].Deleted = true;
                    }
                }
            }
        }
    }
}
