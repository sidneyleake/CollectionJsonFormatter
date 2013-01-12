using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CollectionJsonFormatter.SampleApi.Models;

namespace CollectionJsonFormatter.SampleApi.Controllers
{
    public class FriendsController : ApiController
    {
        public IQueryable<Friend> Get()
        {
            return SampleData.Friends.AsQueryable();
        }

        public Friend Get(string id)
        {
            return SampleData.Friends.Single(f => f.ShortName == id);
        }
    }
}
