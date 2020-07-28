using CardDungeon.GameComponent.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent.Entities.CardGUI
{
    public class CardGUIFactory
    {
        public static CardGuiBase getGui(Card card)
        {
            CardGuiBase res = null;

            if (card.Entity is Weapon)
            {
                res = new CardGUIWeapon(card.Entity, card.X, card.Y);
            }

            if (card.Entity is Enemy)
            {
                res = new CardGUIEnemy(card.Entity, card.X, card.Y);
            }

            if (card.Entity is Armor)
            {
                res = new CardGUIArmor(card.Entity, card.X, card.Y);
            }

            if (card.Entity is Potion)
            {
                res = new CardGUIPotion(card.Entity, card.X, card.Y);
            }
            return res;
        }
    }
}
