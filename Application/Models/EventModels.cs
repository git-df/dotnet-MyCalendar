using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class EventOnListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? EndEventDate { get; set; }
        public string Author { get; set; } = string.Empty;
    }

    public class EventListModel
    {
        public List<EventOnListModel> Events { get; set; }
        public int EventsCount { get; set; } = 0;
        public int PagesCount { get; set; } = 1;
        public int FirstEventNumber { get; set; }
        public int LastEventNumber { get; set; }
        public string OrderTitleRoute { get; set; } = string.Empty;
        public string OrderLabeleRoute { get; set; } = string.Empty;
        public string OrderDateRoute { get; set; } = string.Empty;
        public string OrderEndDateRoute { get; set; } = string.Empty;
        public string OrderAuthorRoute { get; set; } = string.Empty;
        public int CurrentPage { get; set; } = 1;
        public int CurrentSize { get; set; } = 1;
        public string CurrentOrder { get; set; } = string.Empty;
    }


    public class EventDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public DateTime? EndEventDate { get; set; }

        public bool Editable { get; set; } = false;

        public string Author { get; set; } = string.Empty;

        public List<CommentOnEventModel> Comments { get; set; } = new List<CommentOnEventModel>();
    }


    public class EventAddModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public DateTime EventDate { get; set; } = DateTime.Now;
        public DateTime? EndEventDate { get; set; } = DateTime.Now.AddHours(1);
    }
}
