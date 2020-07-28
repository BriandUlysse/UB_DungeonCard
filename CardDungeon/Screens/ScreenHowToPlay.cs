using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeon.GameComponent;
using CardDungeon.GameComponent.Entities;
using CardDungeon.GameComponent.Entities.Items;
using CardDungeon.GameComponent.GUI;
using CardDungeon.GameComponent.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CardDungeon.Screens
{
    public class ScreenHowToPlay : ScreenBase, ICardContext
    {
        private Button btnMainMenu;
        private Panel panel;
        private Card exampleCardEnemy;
        private Card exampleCardObject;
        private Card exampleCardEmpty;
        private Card exitCard;
        private SpriteText sprTxtCard;
        private SpriteText sprTxtEnemy;
        private SpriteText sprTxtObject;
        private SpriteText sprTxtArmor;
        private SpriteText sprTxtHeal;
        private SpriteText sprTxtLifeSteal;
        private SpriteText sprTxtQuick;
        private SpriteText sprTxtAttack;
        private SpriteText sprTxtLadder;

        private BlackFangSprite fangSprite;
        private BlackFeatherSprite featherSprite;
        private BlackCrossSprite blackCrossSprite;
        private BlackShieldSprite shieldSprite;
        private AttackIconSprite attackIcon;

        public ScreenHowToPlay(Game1 game) : base(game)
        {
        }

        public override void initialize()
        {
            this.btnMainMenu = new Button(64, 20, (Settings.WIDTH_SOURCE / 2) - 32, 270, "Back");
            this.panel = new Panel(Settings.WIDTH_SOURCE-40, 230, 20, 20);
            this.exampleCardEmpty = new Card(null, this);
            this.exampleCardEmpty.setPosition(30, 25);

            this.exampleCardEnemy = new Card(new Enemy(EnemyType.SMALL_ZOMBIE), this, true);
            this.exampleCardEnemy.setPosition(30, 60);

            this.exampleCardObject = new Card(new Weapon(WeaponType.SWORD), this, true);
            this.exampleCardObject.setPosition(30, 95);

            this.sprTxtCard = new SpriteText(70, 30, "Turn cards to progress, turning card take a turn.");
            this.sprTxtEnemy = new SpriteText(70, 60, "Enemy will attack you every turn. \nAttacking them take a turn.");
            this.sprTxtObject = new SpriteText(70, 95, "You can pick weapon and add them to you inventory. \nSelect them to attack enemy with it, but they \nhave a limited durability.\nPicking item don't take a turn.");
            this.sprTxtAttack = new SpriteText(70, 135, "Attack power of the enemy/weapon");
            this.attackIcon = new AttackIconSprite(45, 138);
            this.sprTxtArmor = new SpriteText(70, 150, "Number of extre HP the armor give you");
            this.shieldSprite = new BlackShieldSprite(45, 153);
            this.sprTxtHeal = new SpriteText(70, 165, "Number of HP the item restore you");
            this.blackCrossSprite = new BlackCrossSprite(45, 168);
            this.sprTxtQuick = new SpriteText(70, 180, "Attacking with this weapon don't take a turn");
            this.featherSprite = new BlackFeatherSprite(45, 183);
            this.sprTxtLifeSteal = new SpriteText(70, 195, "The enemy/weapon steal HP when attacking");
            this.fangSprite = new BlackFangSprite(45,198);

            this.exitCard = new Card(new Ladder(), this, true);
            this.exitCard.setPosition(30, 205);
            this.sprTxtLadder = new SpriteText(70, 215, "This card take you to the next level.");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.btnMainMenu.Draw(spriteBatch);
            this.panel.Draw(spriteBatch);

            this.exampleCardEmpty.Draw(spriteBatch);
            this.exampleCardEnemy.Draw(spriteBatch);
            this.exampleCardObject.Draw(spriteBatch);

            this.sprTxtCard.Draw(spriteBatch);
            this.sprTxtEnemy.Draw(spriteBatch);
            this.sprTxtObject.Draw(spriteBatch);
            this.sprTxtArmor.Draw(spriteBatch);

            this.sprTxtCard.Draw(spriteBatch);
            this.sprTxtEnemy.Draw(spriteBatch);
            this.sprTxtObject.Draw(spriteBatch);
            this.sprTxtAttack.Draw(spriteBatch);
            this.attackIcon.Draw(spriteBatch);
            this.sprTxtArmor.Draw(spriteBatch);
            this.shieldSprite.Draw(spriteBatch);
            this.sprTxtHeal.Draw(spriteBatch);
            this.blackCrossSprite.Draw(spriteBatch);
            this.sprTxtQuick.Draw(spriteBatch);
            this.featherSprite.Draw(spriteBatch);
            this.sprTxtLifeSteal.Draw(spriteBatch);
            this.fangSprite.Draw(spriteBatch);

            this.exitCard.Draw(spriteBatch);
            this.sprTxtLadder.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            this.btnMainMenu.Update(gameTime);
            
            if (this.btnMainMenu.IsClicked)
            {
                this.game.changeScreen(new ScreenGameMenu(this.game));
            }
        }

        public void clickOnCard(Card clickedCard)
        {
            
        }

        public void hoverCard(Card hoveredCard)
        {
            
        }

        public void onEntityDeleted(Card cardEntity)
        {
            
        }

        public void deleteCardFromList(Card cardToDelete)
        {
            
        }
    }
}
