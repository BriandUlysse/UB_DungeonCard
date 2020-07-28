using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.GameComponent
{
    public interface ICardContext
    {
        void clickOnCard(Card clickedCard);

        void hoverCard(Card hoveredCard);

        void onEntityDeleted(Card cardEntity);

        void deleteCardFromList(Card cardToDelete);
    }
}
