using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
   public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }

        public virtual ICollection<Event> ManagedEvents { get; set; }
        public virtual ICollection<RSVP> RSVPs { get; set; }

        public User()
        {
            ManagedEvents = new List<Event>();
            RSVPs = new List<RSVP>();
        }
    }

 }
