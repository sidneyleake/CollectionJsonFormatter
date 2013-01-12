using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollectionJsonFormatter.SampleApi.Models;

namespace CollectionJsonFormatter.SampleApi
{
    public static class SampleData
    {
        public static List<Friend> Friends = new List<Friend>
        {
            new Friend
            {
                Email = "sleake@email.com",
                FullName = "Sidney Leake"
            },
            new Friend
            {
                Email = "tnguyen@email.com",
                FullName = "Truong Nguyen"
            },
            new Friend
            {
                Email = "aaung@email.com",
                FullName = "Andrew Aung"
            }
        };
    }
}