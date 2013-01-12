namespace CollectionJsonFormatter.SampleApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using CollectionJsonFormatter.SampleApi.Models;

    public class FluidFriendsController : ApiController
    {
        public IQueryable<FluidFriend> Get()
        {
            return SampleData.FluidFriends.AsQueryable();
        }

        public FluidFriend Get(string id)
        {
            return SampleData.FluidFriends.FirstOrDefault(ff => ff.ShortName == id);
        }
    }
}