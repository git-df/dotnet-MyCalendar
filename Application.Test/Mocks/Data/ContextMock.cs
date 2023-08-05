using Domain.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Test.Mocks.Data
{
    public class ContextMock
    {
        public List<Domain.Entity.User> Users { get; set; }
        public List<Domain.Entity.Event> Events { get; set; }
        public List<Domain.Entity.AccesRequest> AccesRequests { get; set; }
        public List<Domain.Entity.Comment> Comments { get; set; }

        public ContextMock()
        {
            Users = new List<Domain.Entity.User>()
            {
                new Domain.Entity.User()
                {
                    Id = Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"),
                    Email = "test1@test.test",
                    FirstName = "test1first",
                    LastName = "test1last",
                    Password = "631502BC927D8265FAACD1D32299BBCA705BEBF1FD79250E054F77398F5C6B54",
                    Salt = "49DF6A0F9C34A50A9178470E0CE3E1EB841C5F3BEEE2C18B36E77F702CC57A2A",
                    Events = new List<Domain.Entity.Event>(),
                    Comments = new List<Domain.Entity.Comment>(),
                    accesRequestsFromUser = new List<Domain.Entity.AccesRequest>(),
                    accesRequestsToUser = new List<Domain.Entity.AccesRequest>()
                },
                new Domain.Entity.User()
                {
                    Id = Guid.Parse("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf"),
                    Email = "test2@test.test",
                    FirstName = "test2first",
                    LastName = "test2last",
                    Password = "D22D6E8BCCCD20674DC25D98AA2DAEDCE9BD1D88F7ED6BA16DFFCBB9F0944606",
                    Salt = "B3F4EF86908A730D7243DF0752A1A3A405B1BDDC8B2AE54CEA1F16550F433576",
                    Events = new List<Domain.Entity.Event>(),
                    Comments = new List<Domain.Entity.Comment>(),
                    accesRequestsFromUser = new List<Domain.Entity.AccesRequest>(),
                    accesRequestsToUser = new List<Domain.Entity.AccesRequest>()
                },
                new Domain.Entity.User()
                {
                    Id = Guid.Parse("3715e326-6e29-43d7-bb77-af4440508186"),
                    Email = "test3@test.test",
                    FirstName = "test3first",
                    LastName = "test3last",
                    Password = "EF44C1BAE114AECB845C356DCBC23AA510518214487BE43CECD658F100CF4FA4",
                    Salt = "315419C3F8AB3B7C21A55D9E573DC0F7B40CCF0174CB8874CDC40CF78F7F7E9D",
                    Events = new List<Domain.Entity.Event>(),
                    Comments = new List<Domain.Entity.Comment>(),
                    accesRequestsFromUser = new List<Domain.Entity.AccesRequest>(),
                    accesRequestsToUser = new List<Domain.Entity.AccesRequest>()
                }
            };

            AccesRequests = new List<Domain.Entity.AccesRequest>()
            {
                new Domain.Entity.AccesRequest()
                {
                    Id = 1,
                    IsAccepted = true,
                    FromUserId = Users[0].Id,
                    FromUser = Users[0],
                    ToUserId = Users[1].Id,
                    ToUser = Users[1]
                },
                new Domain.Entity.AccesRequest()
                {
                    Id = 2,
                    IsAccepted = true,
                    FromUserId = Users[1].Id,
                    FromUser = Users[1],
                    ToUserId = Users[0].Id,
                    ToUser = Users[0]
                },new Domain.Entity.AccesRequest()
                {
                    Id = 3,
                    IsAccepted = true,
                    FromUserId = Users[0].Id,
                    FromUser = Users[0],
                    ToUserId = Users[2].Id,
                    ToUser = Users[2]
                },
                new Domain.Entity.AccesRequest()
                {
                    Id = 4,
                    IsAccepted = false,
                    FromUserId = Users[2].Id,
                    FromUser = Users[2],
                    ToUserId = Users[1].Id,
                    ToUser = Users[1]
                }
            };

            foreach (var item in AccesRequests)
            {
                Users.Find(u => u.Id == item.FromUserId).accesRequestsFromUser.Add(item);
                Users.Find(u => u.Id == item.ToUserId).accesRequestsToUser.Add(item);
            }

            Events = new List<Domain.Entity.Event>()
            {
                new Domain.Entity.Event()
                {
                    Id = 1,
                    Title = "Test1",
                    Description = "Test1Desc",
                    Label = "Test1Label",
                    EventDate = DateTime.Now.AddDays(5),
                    EndEventDate = DateTime.Now.AddDays(5).AddHours(1),
                    UserId = Users[0].Id,
                    User = Users[0],
                    Comments = new List<Domain.Entity.Comment>()
                },
                new Domain.Entity.Event()
                {
                    Id = 2,
                    Title = "Test2",
                    Description = "Test2Desc",
                    Label = "Test2Label",
                    EventDate = DateTime.Now.AddDays(10),
                    EndEventDate = DateTime.Now.AddDays(10).AddHours(2),
                    UserId = Users[0].Id,
                    User = Users[0],
                    Comments = new List<Domain.Entity.Comment>()
                },
                new Domain.Entity.Event()
                {
                    Id = 3,
                    Title = "Test3",
                    Description = "Test3Desc",
                    Label = "Test3Label",
                    EventDate = DateTime.Now.AddDays(15),
                    EndEventDate = DateTime.Now.AddDays(15).AddHours(3),
                    UserId = Users[0].Id,
                    User = Users[0],
                    Comments = new List<Domain.Entity.Comment>()
                },
                new Domain.Entity.Event()
                {
                    Id = 4,
                    Title = "Test4",
                    Description = "Test4Desc",
                    Label = "Test4Label",
                    EventDate = DateTime.Now.AddDays(6),
                    EndEventDate = DateTime.Now.AddDays(6).AddHours(1),
                    UserId = Users[1].Id,
                    User = Users[1],
                    Comments = new List<Domain.Entity.Comment>()
                },
                new Domain.Entity.Event()
                {
                    Id = 5,
                    Title = "Test5",
                    Description = "Test5Desc",
                    Label = "Test5Label",
                    EventDate = DateTime.Now.AddDays(11),
                    EndEventDate = DateTime.Now.AddDays(11).AddHours(2),
                    UserId = Users[1].Id,
                    User = Users[1],
                    Comments = new List<Domain.Entity.Comment>()
                },
                new Domain.Entity.Event()
                {
                    Id = 6,
                    Title = "Test6",
                    Description = "Test6Desc",
                    Label = "Test6Label",
                    EventDate = DateTime.Now.AddDays(16),
                    EndEventDate = DateTime.Now.AddDays(16).AddHours(3),
                    UserId = Users[1].Id,
                    User = Users[1],
                    Comments = new List<Domain.Entity.Comment>()
                },
                new Domain.Entity.Event()
                {
                    Id = 7,
                    Title = "Test7",
                    Description = "Test7Desc",
                    Label = "Test7Label",
                    EventDate = DateTime.Now.AddDays(7),
                    EndEventDate = DateTime.Now.AddDays(7).AddHours(1),
                    UserId = Users[2].Id,
                    User = Users[2],
                    Comments = new List<Domain.Entity.Comment>()
                },
                new Domain.Entity.Event()
                {
                    Id = 8,
                    Title = "Test8",
                    Description = "Test8Desc",
                    Label = "Test8Label",
                    EventDate = DateTime.Now.AddDays(12),
                    EndEventDate = DateTime.Now.AddDays(12).AddHours(2),
                    UserId = Users[2].Id,
                    User = Users[2],
                    Comments = new List<Domain.Entity.Comment>()
                },
                new Domain.Entity.Event()
                {
                    Id = 9,
                    Title = "Test9",
                    Description = "Test9Desc",
                    Label = "Test9Label",
                    EventDate = DateTime.Now.AddDays(17),
                    EndEventDate = DateTime.Now.AddDays(17).AddHours(3),
                    UserId = Users[2].Id,
                    User = Users[2],
                    Comments = new List<Domain.Entity.Comment>()
                }
            };

            foreach (var item in Events)
            {
                Users.Find(u => u.Id == item.UserId).Events.Add(item);
            }

            Comments = new List<Domain.Entity.Comment>()
            {
                new Domain.Entity.Comment()
                {
                    Id = 1,
                    Message = "Test1Message",
                    EventId = Events[0].Id,
                    Event = Events[0],
                    UserId = Users[0].Id,
                    User = Users[0]
                },
                new Domain.Entity.Comment()
                {
                    Id = 2,
                    Message = "Test2Message",
                    EventId = Events[0].Id,
                    Event = Events[0],
                    UserId = Users[0].Id,
                    User = Users[0]
                },
                new Domain.Entity.Comment()
                {
                    Id = 3,
                    Message = "Test3Message",
                    EventId = Events[0].Id,
                    Event = Events[0],
                    UserId = Users[1].Id,
                    User = Users[1]
                },
                new Domain.Entity.Comment()
                {
                    Id = 4,
                    Message = "Test4Message",
                    EventId = Events[0].Id,
                    Event = Events[0],
                    UserId = Users[1].Id,
                    User = Users[1]
                }
            };

            foreach (var item in Comments)
            {
                Events.Find(e => e.Id == item.EventId).Comments.Add(item);
                Users.Find(u => u.Id == item.UserId).Comments.Add(item);
            }
        }
    }
}
