namespace CollectionJsonFormatter.SampleApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using CollectionJsonFormatter.SampleApi.Models;

    public class AttributedFriendsController : ApiController
    {
        public IQueryable<AttributedFriend> Get()
        {
            return SampleData.AttributedFriends.AsQueryable();
        }

        public AttributedFriend Get(string id)
        {
            return SampleData.AttributedFriends.Single(f => f.ShortName == id);
        }
    }
}