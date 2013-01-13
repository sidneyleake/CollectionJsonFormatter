namespace CollectionJsonFormatter.SampleApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using CollectionJsonFormatter.Models;
    using CollectionJsonFormatter.SampleApi.Models;

    public class ManualFriendsController : ApiController
    {
        public CollectionJsonDocument Get()
        {
            var collectionJsonDocument = new CollectionJsonDocument(typeof(FluidFriend), "/friends");
            collectionJsonDocument.Initialize();
            collectionJsonDocument.Collection.Href = "/manualfriends";
            collectionJsonDocument.Collection.Links = new List<LinkProperty>
            {
                new LinkProperty { Href = "/friends/rss", Rel = "feed" }
            };

            var items = new List<ItemProperty>();
            foreach (var friend in SampleData.FluidFriends)
            {
                var data = new List<DataProperty>()
                {
                    new DataProperty{Name = "email", Value = friend.Email, Prompt = "Email"},
                    new DataProperty{Name = "full-name", Value = friend.FullName, Prompt = "Full Name"},
                    new DataProperty{Name = "short-name", Value = friend.ShortName, Prompt = "Short Name"}
                };

                var links = new List<LinkProperty>
                {
                    new LinkProperty{Href = string.Format("/friends/blogs/{0}", friend.ShortName), Rel = "blog", Prompt = "Blog"},
                    new LinkProperty{Href = string.Format("/friends/images/{0}", friend.ShortName), Rel = "avatar", Prompt = "Avatar"}
                };

                items.Add(new ItemProperty
                {
                    Href = string.Format("/friends/{0}", friend.ShortName),
                    Data = data,
                    Links = links
                });
            }

            collectionJsonDocument.Collection.Items = items;

            collectionJsonDocument.Collection.Queries = new List<QueryProperty>
            {
                new QueryProperty { Href = "/friends/search", Rel = "search" }
            };

            collectionJsonDocument.Collection.Template = new TemplateProperty
            {
                Data = new List<DataProperty>
                {
                    new DataProperty { Name = "email", Prompt = "Email", Value = string.Empty },
                    new DataProperty { Name = "full-name", Prompt = "Full Name", Value = string.Empty }
                }
            };

            return collectionJsonDocument;
        }
    }
}
