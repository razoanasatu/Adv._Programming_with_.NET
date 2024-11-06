using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EventRepo : Repo, IRepo<Event, int, bool>
    {
        public bool Create(Event obj)
        {
            db.Events.Add(obj); 
            return db.SaveChanges() > 0; 
        }

        
        public List<Event> Read()
        {
            return db.Events.ToList(); 
        }

        public Event Read(int id)
        {
            return db.Events.Find(id); 
        }

        public bool Update(Event obj)
        {
            var ex = Read(obj.EventId); 
            if (ex != null) 
            {
                db.Entry(ex).CurrentValues.SetValues(obj); 
                return db.SaveChanges() > 0; 
            }
            return false; 
        }

        public bool Delete(int id)
        {
            var ex = Read(id); 
            if (ex != null) 
            {
                db.Events.Remove(ex); 
                return db.SaveChanges() > 0; 
            }
            return false; 
        }
    }
}
