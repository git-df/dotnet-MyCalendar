using Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class AccesRequest : AuditableEntity
    {
        public int Id { get; set; }
        public bool IsAccepted { get; set; }

        public Guid FromUserId { get; set; }
        public User FromUser { get; set; }

        public Guid ToUserId { get; set; }
        public User ToUser { get; set; }
    }
}
