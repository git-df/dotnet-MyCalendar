using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AccesRequestSendModel
    {
        public string ToUserEmail { get; set; }
    }

    public class AccesRequestOnListModel
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
    }

    public class AccesRequestsListModel
    {
        public List<AccesRequestOnListModel> Accepted { get; set; }
        public List<AccesRequestOnListModel> NoAccepted { get; set; }
    }
}
