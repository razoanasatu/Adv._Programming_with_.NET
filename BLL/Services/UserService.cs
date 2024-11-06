using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
       
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read(); 

            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<UserDTO>>(data);

            return mapped; 
        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Read(id); 

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<UserDTO>(data);

            return mapped; 
        }

        public static bool Register(UserDTO obj)
        {
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<User>(obj);

          
            return DataAccessFactory.UserData().Create(data) != null; 
        }

        public static bool VerifyCredentials(string uname, string password)
        {
            var user = DataAccessFactory.UserData().Read().SingleOrDefault(u => u.Username == uname && u.Password == password);
            return user != null; 
        }

        public static bool Update(UserDTO obj)
        {
           
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<User>(obj);

            
            return DataAccessFactory.UserData().Update(data) != null; 
        }

        
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }
    }
}
