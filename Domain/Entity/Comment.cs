using Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Comment : AuditableEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
