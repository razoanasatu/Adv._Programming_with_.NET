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
    public class RSVPService
    {
      
        public static List<RSVPDTO> Get()
        {
            var data = DataAccessFactory.RSVPData().Read(); 

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RSVP, RSVPDTO>(); 
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<RSVPDTO>>(data);

            return mapped; 
        }

        public static RSVPDTO Get(int id)
        {
            var data = DataAccessFactory.RSVPData().Read(id); 

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RSVP, RSVPDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<RSVPDTO>(data);

            return mapped; 
        }

        public static bool Create(RSVPDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RSVPDTO, RSVP>(); 
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<RSVP>(obj);

            return DataAccessFactory.RSVPData().Create(data); 
        }

        public static bool Update(RSVPDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RSVPDTO, RSVP>(); 
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<RSVP>(obj);

            return DataAccessFactory.RSVPData().Update(data); 
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.RSVPData().Delete(id); 
        }
    }
}
