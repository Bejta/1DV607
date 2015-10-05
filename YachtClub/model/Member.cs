using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class Member
    {
        /// <summary>
        /// Fields
        /// </summary>
        private string _name;
        private int _uniqueID;
        private string _personalNumber;
        private string _path;
        List<BoatListItem> _boats;

        /// <summary>
        /// Properties
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string PersonalNumber
        {
            get
            {
                return _personalNumber;
            }
            set
            {
                _personalNumber = value;
            }
        }
        public int UniqueID
        {
            get
            {
                return _uniqueID;
            }
            set
            {
                _uniqueID = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="personalNumber"></param>
        /// <param name="uniqueID"></param>
        public Member(string name, string personalNumber, int uniqueID)
        {
            Name = name;
            PersonalNumber = personalNumber;
            UniqueID = uniqueID;
            _boats = new List<BoatListItem>();
            _path = Path.Combine(Environment.CurrentDirectory, "Boatregistry.json");
            _boats = ReadFile();
            
        }
        
        public void AddBoat(BoatListItem boat)
        {
            _boats.Add(boat);
            SaveBoat();
        }
        public int CalculateMaxBoatID()
        {
            return _boats.Max(b => b.BoatID);
        }
        public void RemoveBoat(int boatID)
        {
            _boats.RemoveAll(boat => boat.BoatID == boatID);
            SaveBoat();
        }
        public void UpdateBoat(BoatListItem oldBoat, BoatListItem newBoat)
        {
            int index = 0;
            for (int i = 0; i < _boats.Count; i++)
            {
                if (_boats[i].MemberID == oldBoat.MemberID && _boats[i].BoatID == oldBoat.BoatID)
                {
                    index = i;
                    break;
                }
            }
            _boats[index] = newBoat;
            SaveBoat();
        }
        
        public int CountBoats()
        {    
                return _boats.Count();
        }
        public List<BoatListItem> ReadFile()
        {
            //http://stackoverflow.com/questions/18538428/loading-a-json-file-into-c-sharp-program

            using (StreamReader file = File.OpenText(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<BoatListItem> BoatRegistry = (List<BoatListItem>)serializer.Deserialize(file, typeof(List<BoatListItem>));
                return BoatRegistry;
            }
        }
        public void SaveBoat()
        {
            File.WriteAllText(_path, JsonConvert.SerializeObject(_boats, Formatting.Indented));

            using (StreamWriter file = File.CreateText(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _boats);
            }
        }
    }
}
