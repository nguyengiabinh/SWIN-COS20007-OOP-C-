using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class BoughtStatus : PropertyState
    {
        public BoughtStatus(Property property, Player player) : base(property, player) 
        {
            this.fee = property.market_price / 5;
            this.status = Property_Status.Bought;
        }

    }
}
