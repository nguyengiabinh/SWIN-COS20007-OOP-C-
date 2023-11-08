using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class BoughtStatus : PropertyState
    {
        public BoughtStatus(Property prop, Player play) : base(prop, play) 
        {
            this.fee = prop.market_price / 5;
            this.status = Property_Status.Bought;
        }

    }
}
