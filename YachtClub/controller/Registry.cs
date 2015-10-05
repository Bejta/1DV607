using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtClub.model;

namespace YachtClub.controller
{
    class Registry
    {
        model.Registry r = new model.Registry();
        model.Member m = new model.Member("","",0);
        view.Display v = new view.Display();
        public void Run()
        {   
            DoControl(); 
        }
        public void DoControl()
        {
            v.DisplayMenu();
            int i = v.getUserInput();
            switch (i)
            {
                case 0 :
                    return;
                case 1:
                    AddMember();
                    break;
                case 2:
                    v.ShowDetailedList(r.ReadFile());
                    break;
                case 3:
                    v.ShowList(r.ReadFile());
                    break;
                case 4:
                    AddBoat();
                    break;
                case 5 :
                    RemoveMember();
                    break;
                case 6:
                    UpdateMember();
                    break;
                case 7:
                    UpdateBoat();
                    break;
                case 8:
                    RemoveBoat();
                    break;
                default:
                    DoControl();
                    break;
            }
            DoControl();
        }
        public void AddBoat()
        {
            v.ShowList(r.ReadFile());
            BoatListItem newBoat = v.NewBoatInput(m.CalculateMaxBoatID());
            m.AddBoat(newBoat);
            DoControl();
        }
        public void AddMember()
        {
            model.Member newMember = v.NewMemberInput(r.CalculateMaxID());
            r.AddMember(newMember);
            DoControl();
        }
        public void UpdateMember()
        {
            v.ShowList(r.ReadFile());
            List<Member> members = new List<Member>();
            members = r.ReadFile();
            Member memberNew = v.UpdateMember();
            Member memberOld = members.Find(i => i.UniqueID == memberNew.UniqueID);
            r.UpdateMember(memberOld,memberNew);
            DoControl();
        }
        public void UpdateBoat()
        {
            //v.ShowList(r.ReadFile());
            //List<Member> members = new List<Member>();
            //members = r.ReadFile();
            //Member memberNew = v.UpdateMember();
            //Member memberOld = members.Find(i => i.UniqueID == memberNew.UniqueID);
            //r.UpdateMember(memberOld, memberNew);
            //DoControl();
        }
        public void RemoveMember()
        {
            v.ShowList(r.ReadFile());
            List<Member> members = new List<Member>();
            members = r.ReadFile();
            int id = v.RemoveMember();
            r.RemoveMember(id);
            DoControl();
        }
        public void RemoveBoat()
        {
            v.ShowList(r.ReadFile());
            int id = v.RemoveBoat();
            m.RemoveBoat(id);
            DoControl();
        }
    }
    
}
