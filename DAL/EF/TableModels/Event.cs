using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Event
    {
        [Key] 
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }

        
        [ForeignKey("Admin")]
        public int AdminId { get; set; } 

        public virtual User Admin { get; set; }

        public virtual ICollection<RSVP> RSVPs { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }


    }
}
