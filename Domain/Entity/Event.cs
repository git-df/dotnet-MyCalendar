using Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Event : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? EndEventDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
