using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class PropertyState : Property
    {
        public PropertyState(Property prop, Player play)
        {
            this.name = prop.name;
            this.market_price = prop.market_price;
            this.type = prop.type;
            this.owner = play;
            this.position = prop.position;
        }

        public string Owner()
        {
            return "\nName: " + "\t" + name + "\nType: " + "\t" + type.ToString() + "\nPrice:" + "\t" + market_price + "\nFee:" + "\t" + fee + "\nStatus:" + "\t" + status.ToString() + "\nOwner" + "\t" + owner.name;
        }

    }
}
