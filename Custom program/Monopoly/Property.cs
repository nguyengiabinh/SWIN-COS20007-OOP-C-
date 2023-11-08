using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Property : Square
    {
        public enum property_Type { Mansion, Service, Special}
        public enum Property_Status { Sale, Bought, Land, Rent }

        public string name;
        public int market_price; 
        public int fee; // pay an amount to the owner of the property
        public property_Type type;
        public Property_Status status;
        public Player owner;

        public string Name 
        { 
            get 
            { 
                return name; 
            } 
            set 
            { 
                name = value;
            } 
        }
       
        public int Market_Price
        { 
            get 
            { 
                return market_price; 
            } 
            set
            {
                market_price = value; 
            } 
        }
        public int Fee
        { 
            get 
            { 
                return fee; 
            } 
            set 
            {
                fee = value;
            } 
        }
        public Player Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }
        public property_Type Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public Property_Status Status
        {
            get 
            { 
                return status; 
            } 
            set 
            { 
                status = value;
            }
        }

        public Property(string Name, property_Type Type, int Market_price, int Fee, Property_Status Status, Player Owner, int position) : base(position)
        {
            name = Name;
            type = Type;
            market_price = Market_price;
            fee = Fee;
            status = Status;
            owner = Owner;
            this.position = position;
        }

        public Property() 
        { 
        }

        public string property_desc()
        {
            return "\nName: " + "\t" + name + "\nType: " + "\t" + type.ToString() + "\nPrice:" + "\t" + market_price + "\nFee:" + "\t" + fee + "\nStatus:" + "\t" + status.ToString();
        }
    }
}
