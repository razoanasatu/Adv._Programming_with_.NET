using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RSVPRepo : Repo, IRepo<RSVP, int, bool>
    {
        public bool Create(RSVP obj)
        {
            db.RSVPs.Add(obj); 
            return db.SaveChanges() > 0; 
        }

        public List<RSVP> Read() 
        {
            return db.RSVPs.ToList(); 
        }

        public RSVP Read(int id)
        {
            return db.RSVPs.Find(id); 
        }

        public bool Update(RSVP obj)
        {
            var existingRSVP = Read(obj.RSVPId);
            if (existingRSVP != null) 
            {
                db.Entry(existingRSVP).CurrentValues.SetValues(obj); 
                return db.SaveChanges() > 0; 
            }
            return false; 
        }

        public bool Delete(int id)
        {
            var ex = Read(id); 
            if (ex != null) 
            {
                db.RSVPs.Remove(ex); 
                return db.SaveChanges() > 0; 
            }
            return false; 
        }
    }
}
