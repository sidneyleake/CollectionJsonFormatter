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
        public IQueryable<FluidFriend> Get()
        {
            return SampleData.FluidFriends.AsQueryable();
        }

        public AttributedFriend Get(string id)
        {
            return SampleData.AttributedFriends.Single(f => f.ShortName == id);
        }
    }
}
