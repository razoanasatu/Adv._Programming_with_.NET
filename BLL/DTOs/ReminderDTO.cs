using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReminderDTO
    {
      
        public int ReminderId { get; set; }       
        public DateTime ReminderDate { get; set; } 
        public int EventId { get; set; }
    }
}
