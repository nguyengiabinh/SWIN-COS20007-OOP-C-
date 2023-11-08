using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class LandStatus : BoughtStatus
    {
        public LandStatus(BoughtStatus prop, Player play) : base(prop,play)
        {
            this.fee = prop.fee * 4;
            this.status = Property_Status.Land;
        }
    }
}
