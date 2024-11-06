using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventDTO
    {
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
