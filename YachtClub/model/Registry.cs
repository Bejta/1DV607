using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class Registry
    {
        List<Member> _members;
        private string _path;

        public Registry()
        {
            _members = new List<Member>();
            _path = Path.Combine(Environment.CurrentDirectory, "registry.json");
            _members = ReadFile();
        }
        public void AddMember(Member member)
        {
            _members.Add(member);
            SaveMember();
        }
        public void SaveMember()
        {
           
            File.WriteAllText(_path, JsonConvert.SerializeObject(_members, Formatting.Indented));
            
            using (StreamWriter file = File.CreateText(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _members);
            }
        }
        public void RemoveMember(int id)
        {
            _members.RemoveAll(member => member.UniqueID == id);
            SaveMember();
        }
        public void UpdateMember(Member oldMember, Member newMember)
        {
            int index=0;
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].UniqueID == oldMember.UniqueID)
                {
                    index = i;
                    break;
                }
            }
            _members[index] = newMember;
            SaveMember();
        }
        public int CalculateMaxID()
        {
            return _members.Max(m => m.UniqueID);
        }
        public List<Member> ReadFile()
        {
            //http://stackoverflow.com/questions/18538428/loading-a-json-file-into-c-sharp-program

            using (StreamReader file = File.OpenText(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Member> registry = (List<Member>)serializer.Deserialize(file, typeof(List<Member>));
                return registry;
            }
        }
    }
}
