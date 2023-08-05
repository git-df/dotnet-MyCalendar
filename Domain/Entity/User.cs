using Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User : AuditableEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();

        public List<AccesRequest> accesRequestsToUser { get; set; } = new List<AccesRequest>();
        public List<AccesRequest> accesRequestsFromUser { get; set; } = new List<AccesRequest>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
