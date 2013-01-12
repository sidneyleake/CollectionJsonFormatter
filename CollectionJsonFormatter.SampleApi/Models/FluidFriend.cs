namespace CollectionJsonFormatter.SampleApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class FluidFriend
    {
        private string fullName;

        public string FullName
        {
            get { return this.fullName; }
            set
            {
                this.fullName = value;
                var tempName = this.fullName.ToLower();
                ShortName = tempName.Substring(0, 1) + tempName.Substring(tempName.IndexOf(" ") + 1);
            }
        }

        public string ShortName { get; private set; }

        public string Email { get; set; }
    }
}