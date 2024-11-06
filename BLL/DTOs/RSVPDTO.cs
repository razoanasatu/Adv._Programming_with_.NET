using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RSVPDTO
    {
        public int RSVPId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }

    }
}
