namespace CollectionJsonFormatter.SampleApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using CollectionJsonFormatter.SampleApi.Models;
    using CollectionJsonFormatter.Extensions;
    using CollectionJsonFormatter.Attributes;

    public class CollectionJsonAttributeConfig
    {
        public static void RegisterAttributes()
        {
            var friendType = typeof(FluidFriend);
            friendType
                .RegisterAttribute<AddCollectionLink>(new AddCollectionLink("/friends/rss", "feed"))
                .RegisterAttribute<AddHref>(new AddHref("/friends/{short-name}"))
                .RegisterAttribute<AddItemLink>(new AddItemLink("/friends/blog/{short-name}", "blog") { Prompt = "Blog" })
                .RegisterAttribute<AddItemLink>(new AddItemLink("/friends/images/{short-name}", "avatar") { Prompt = "Avatar" })
                .RegisterAttribute<AddQuery>(new AddQuery("search"))
                .RegisterAttribute<AddTemplate>(new AddTemplate());
        }
    }
}