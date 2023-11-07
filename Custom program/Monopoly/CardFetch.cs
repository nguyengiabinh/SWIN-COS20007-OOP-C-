using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Monopoly.Card;

namespace Monopoly
{
    public class CardFetch : SquareFetch
    {
        public card_Type cardType;

        public CardFetch(card_Type cardType)
        {
            this.cardType = cardType;
        }

        public override Square FetchSquare(int position)
        {
            return new Card(cardType, position);
        }
    }
}
