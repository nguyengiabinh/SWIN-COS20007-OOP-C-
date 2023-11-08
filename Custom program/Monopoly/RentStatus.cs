using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class RentStatus : LandStatus
    {
        public RentStatus(LandStatus prop, Player play) : base(prop,play)
        {
            this.fee = prop.fee / 2;
            this.status = Property_Status.Rent;
        }
    }
}
