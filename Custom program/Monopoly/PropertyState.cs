using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class PropertyState : Property
    {
        public PropertyState(Property property, Player player)
        {
            this.name = property.name;
            this.market_price = property.market_price;
            this.type = property.type;
            this.owner = player;
            this.position = property.position;
        }

        public string Owner()
        {
            return "\nName: " + "\t" + name + "\nType: " + "\t" + type.ToString() + "\nPrice:" + "\t" + market_price + "\nFee:" + "\t" + fee + "\nStatus:" + "\t" + status.ToString() + "\nOwner" + "\t" + owner.name;
        }

    }
}
