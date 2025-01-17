﻿using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>
    {
        public User Create(User obj)
        {
            db.Users.Add(obj); 
            if (db.SaveChanges() > 0) return obj; 
            return null; 
        }

        public bool Delete(int id)
        {
            var ex = Read(id); 
            if (ex != null) 
            {
                db.Users.Remove(ex); 
                return db.SaveChanges() > 0; 
            }
            return false; 
        }

        public List<User> Read()
        {
            return db.Users.ToList(); 
        }

        public User Read(int id)
        {
            return db.Users.Find(id); 
        }

        public User Update(User obj)
        {
            var ex = Read(obj.UserId); 
            if (ex != null) 
            {
                db.Entry(ex).CurrentValues.SetValues(obj); 
                if (db.SaveChanges() > 0) return obj; 
            }
            return null; 
        }
    }
}
