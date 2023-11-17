using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class LandStatus : BoughtStatus
    {
        public LandStatus(BoughtStatus property, Player player) : base(property,player)
        {
            this.fee = property.fee + 200;
            this.status = Property_Status.Land;
        }
    }
}
