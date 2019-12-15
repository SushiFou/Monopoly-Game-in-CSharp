using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_FINAL_KERVELLA_LAGRANGE_DP
{
    abstract class PropertyDecorator : Property
    {
        public PropertyDecorator(Property prop, Player play)
        {
            this.name = prop.name;
            this.buying_cost = prop.buying_cost;
            this.type = prop.type;
            this.owner = play;
            this.position = prop.position;
        }

        public string toStringOwner()
        {
            return "\tName: " + name + "\n\tType: " + type.ToString() + "\n\tBuying cost: $" + buying_cost + "\n\tTaxes: $" + taxes +
                "\n\tSituation: " + situation.ToString() + "\n\tOwner: " + owner.name;
        }
    }

    class BoughtProperty : PropertyDecorator
    {

        public BoughtProperty(Property prop, Player play):base(prop, play)
        {            
            this.taxes = prop.buying_cost / 2;
            this.situation = Property_Situation.Bought;
        }
    }

    class HouseProperty : BoughtProperty
    {
        public HouseProperty(BoughtProperty prop, Player play) : base(prop, play)
        {
            this.taxes = prop.taxes * 2;
            this.situation = Property_Situation.House;
        }
    }

    class HotelProperty : HouseProperty
    {
        public HotelProperty(HouseProperty prop, Player play) : base(prop, play)
        {
            this.taxes = prop.taxes * 2;
            this.situation = Property_Situation.Hotel;
        }
    }
}
