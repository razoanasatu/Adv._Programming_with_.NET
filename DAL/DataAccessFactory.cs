using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
       
        public static IRepo<User, int, User> UserData()
        {
            return new UserRepo(); 
        }

        public static IRepo<Event, int, bool> EventData()
        {
            return new EventRepo();
        }

        public static IRepo<RSVP, int, bool> RSVPData()
        {
            return new RSVPRepo();
        }

        public static IRepo<Reminder, int, bool> ReminderData()
        {
            return new ReminderRepo();
        }
    }

}
