using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class RSVP
    {
        [Key] 
        public int RSVPId { get; set; }

       
        [ForeignKey("Event")]
        public int EventId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
