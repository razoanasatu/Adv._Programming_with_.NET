using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReminderRepo : Repo, IRepo<Reminder, int, bool>
    {
        public bool Create(Reminder obj)
        {
            db.Reminders.Add(obj); 
            return db.SaveChanges() > 0; 
        }

        public List<Reminder> Read() 
        {
            return db.Reminders.ToList(); 
        }

        public Reminder Read(int id)
        {
            return db.Reminders.Find(id); 
        }

        public bool Update(Reminder obj)
        {
            var existingReminder = Read(obj.ReminderId); 
            if (existingReminder != null) 
            {
                db.Entry(existingReminder).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0; 
            }
            return false; 
        }

        public bool Delete(int id)
        {
            var ex = Read(id); 
            if (ex != null) 
            {
                db.Reminders.Remove(ex); 
                return db.SaveChanges() > 0; 
            }
            return false; 
        }
    }
}
