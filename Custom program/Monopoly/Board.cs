using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Monopoly.Property;

namespace Monopoly
{
    public class Board
    {
        public Square[] square = new Square[16];

        public Board()
        {
            Board_Creation();
        }

        public void Board_Creation()
        {
            square[0] = new Square(); // start square: give $200 as you pass or land on            
            square[1] = new Square(); //prison
            square[2] = new Property("Ha Noi Static", property_Type.Mansion, 300, 0, Property_Status.Sale, null, 2);
            square[3] = new Property("Tay Ho Rift", property_Type.Mansion, 120, 0, Property_Status.Sale, null, 3);
            square[4] = new Property("card", property_Type.Mansion, 60, 0, Property_Status.Sale, null, 4);//
            square[5] = new Property("Tay Ho WaterPark", property_Type.Service, 250, 0, Property_Status.Sale, null, 5);
            square[6] = new Property("Tay Ho Arena", property_Type.Service, 180, 0, Property_Status.Sale, null, 6);
            square[7] = new Property("Ba Dinh Eleve", property_Type.Mansion, 160, 0, Property_Status.Sale, null, 7);
            square[8] = new Property("card", property_Type.Mansion, 60, 0, Property_Status.Sale, null, 8);//
            square[9] = new Property("Ba Dinh Vapore", property_Type.Mansion, 200, 0, Property_Status.Sale, null, 9);
            square[10] = new Property("Ba Dinh Trajure", property_Type.Special, 550, 0, Property_Status.Sale, null, 10);
            square[11] = new Property("Cau Giay supermarket", property_Type.Special, 500, 0, Property_Status.Sale, null, 11);
            square[12] = new Property("card", property_Type.Mansion, 60, 0, Property_Status.Sale, null, 12);//
            square[13] = new Property("Cau Giay Cuanfloa", property_Type.Mansion, 250, 0, Property_Status.Sale, null, 13);
            square[14] = new Property("Ho Guom Barlara", property_Type.Service, 100, 0, Property_Status.Sale, null, 14);
            square[15] = new Square(); //got lock up in prison
        }
            
    }
}
