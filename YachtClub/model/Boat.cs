using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class Boat
    {
        public enum BoatType
        {
            Sailboat,
            Motorsailer,
            KayakCanoe,
            Other
        }

        //fields
        private int _length;
        private BoatType _boatType;

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }
        public BoatType Boat_Type
        {
            get
            {
                return _boatType;
            }
            set
            {
                _boatType = value;
            }
        }
        public Boat(BoatType boatType, int length)
        {
            Length = length;
            Boat_Type = boatType;
        }
    }
}
