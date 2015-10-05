using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtClub.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YachtClub.view
{
    class Display
    {
        public void DisplayMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            string title = "    Yacht Club - Proper Geezers    ";
            Console.WriteLine("={0}=", PartOfMenu(1));
            Console.WriteLine("={0}=", PartOfMenu(2));
            Console.WriteLine("={0}=", title);
            Console.WriteLine("={0}=", PartOfMenu(2));
            Console.WriteLine("={0}=", PartOfMenu(1));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n0. Quit");
            Console.WriteLine("1. Add member");
            Console.WriteLine("2. Show detailed list");
            Console.WriteLine("3. Simple list");
            Console.WriteLine("4. Add boat");
            Console.WriteLine("5. Delete member");
            Console.WriteLine("6. Update member");
            Console.WriteLine("7. Update boat");
            Console.WriteLine("8. Delete boat");
            Console.WriteLine("={0}=", PartOfMenu(1));
            Console.Write("\nEnter menu choice [0-8]:");
        }
        public int getUserInput()
        {
            
            int index = int.Parse(Console.ReadLine());
            if (index < 0 || index > 9)
            {
                Console.Clear();
                return 50;
            }
            else
            {
                return index;
            }
        }

        private static string PartOfMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    return "===================================";
                case 2:
                    return "                                   ";
                case 3:
                    return "___________________________________________";
                case 4:
                    return "___________________________________________________________________";
                case 5:
                    return "-------------------------------------------------------------------";
                default:
                    return "-------------------------------------------";
            }
        }

        public void ShowList(List<Member> registry)
        {
            Console.Clear();
            Console.WriteLine("----SIMPLE LIST----");
            int i;
            foreach (var member in registry)
            {
                i = member.CountBoats();
                Console.WriteLine("Member ID:{0}, Name: {1}, Number of boats: {2}", member.UniqueID, member.Name,i);
            }
        }
        public void ShowBoats(List<BoatListItem> boats)
        {
            foreach (var boat in boats)
            {
                Console.WriteLine("Boat ID:{0}, Boat type: {1}, Length: {2}", boat.BoatID, boat.Boat.Boat_Type,boat.Boat.Length);
            }
        }
        public void ShowDetailedList(List<Member> registry)
        {
            Console.Clear();
            Console.WriteLine("----Verbose List----");
            int i;
            foreach (var member in registry)
            {
                i = member.CountBoats();
                Console.WriteLine("Member ID:{0}, Name: {1}, Personal number: {2}", member.UniqueID, member.Name, member.PersonalNumber);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Boats:");
                ShowBoats(filterBoats(member.UniqueID));
                Console.WriteLine();
            }
        }
        public int RemoveBoat()
        {
            
            Console.WriteLine("Enter ID of member you want to delete boat for:");
            
            int id = 0;
            try
            {
                id = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            ShowBoats(filterBoats(id));
            Console.WriteLine("Enter ID of boat you want to delete:");
            int idboat = 0;
            try
            {
                idboat = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return idboat;
        }
        public List<BoatListItem> filterBoats(int memberID)
        {
            model.Member m = new model.Member("", "", 0);
            List<BoatListItem> filteredList= new List<BoatListItem>();
            List<BoatListItem> fullList = new List<BoatListItem>();
            fullList = m.ReadFile();

            for (int i = 0; i < fullList.Count; i++)
            {
                if (fullList[i].MemberID == memberID)
                {
                    filteredList.Add(fullList[i]);
                }
            }
            return filteredList;
        }

        public int RemoveMember()
        {
            Console.WriteLine("Enter ID of member you want to delete:");
            int id = 0;
            try
            {
                id = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);              
            }
            return id;
           
        }
        public Member UpdateMember()
        {
            int id = 0;
            string name="";
            string personalNumber="";
            try
            {
                Console.WriteLine("Enter ID of member you want to Update:");
                id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter name of member you want to Update:");
                name = Console.ReadLine();
                Console.WriteLine("Enter personal number of member you want to Update:");
                personalNumber=Console.ReadLine();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Member member = new Member("","",0);
            member.UniqueID = id;
            member.Name = name;
            member.PersonalNumber = personalNumber;
            return member;
        }

        internal Member NewMemberInput(int uniqueID)
        {
            System.Console.Clear();
            string name;
            string personalNumber;
            Console.Write("Enter Name:");
            name=Console.ReadLine();
            Console.WriteLine("Enter Personal number:");
            personalNumber = Console.ReadLine();
            Member member = new Member(name, personalNumber, uniqueID+1);
            return member;
        }
        internal BoatListItem NewBoatInput(int boatID)
        {
            
            //System.Console.Clear();
            int length;
            int MemberID;
            string boatType = "Other";
            Console.Write("Enter member ID (from the list):");
            MemberID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter boatType (1-4)");
            Console.WriteLine("1 for Sailboat");
            Console.WriteLine("2 for Motorsailer");
            Console.WriteLine("3 for Kayak/Canoe");
            Console.WriteLine("4 for Other");
            int input;
            do 
            {
                input=Int32.Parse(Console.ReadLine());
                
            } while (input>4 && input<1);

            switch(input)
                {
                    case 1:
                        boatType = "Sailboat";
                            break;
                    case 2:
                         boatType = "Motorsailer";
                            break;
                    case 3:
                            boatType = "KayakCanoe";
                            break;
                    case 4:
                         boatType = "Other";
                            break;
                }
            Boat.BoatType type = (Boat.BoatType)Enum.Parse(typeof(Boat.BoatType), boatType);
            Console.Write("Enter boat length:");
            length = Int32.Parse(Console.ReadLine());
            Boat newBoat = new Boat(type, length);

            return new BoatListItem(MemberID, boatID + 1, newBoat);
        }
    }
}
