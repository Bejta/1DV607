using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class BoatListItem
    {
        Boat _boat;
        private int _memberID;
        private int _boatID;

        public int MemberID
        {
            get
            {
                return _memberID;
            }
            set
            {
                _memberID = value;
            }
        }
        public int BoatID { get; set; }
        public Boat Boat { get; set; }

        public BoatListItem(int memberID, int boatID, Boat boat)
        {
            BoatID = boatID;
            MemberID = memberID;
            Boat = boat;
        }
       
    }
}
