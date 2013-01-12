using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollectionJsonFormatter.SampleApi.Models;

namespace CollectionJsonFormatter.SampleApi
{
    public static class SampleData
    {
        public static List<AttributedFriend> AttributedFriends = new List<AttributedFriend>
        {
            new AttributedFriend
            {
                Email = "sleake@email.com",
                FullName = "Sidney Leake"
            },
            new AttributedFriend
            {
                Email = "tnguyen@email.com",
                FullName = "Truong Nguyen"
            },
            new AttributedFriend
            {
                Email = "aaung@email.com",
                FullName = "Andrew Aung"
            }
        };

        public static List<FluidFriend> FluidFriends = new List<FluidFriend>
        {
            new FluidFriend
            {
                Email = "sleake@email.com",
                FullName = "Sidney Leake"
            },
            new FluidFriend
            {
                Email = "tnguyen@email.com",
                FullName = "Truong Nguyen"
            },
            new FluidFriend
            {
                Email = "aaung@email.com",
                FullName = "Andrew Aung"
            }
        };
    }
}