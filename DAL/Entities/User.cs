using Microsoft.AspNetCore.Identity;

namespace DAL
{
    using System;
    using System.Collections.Generic;
    public class User : IdentityUser
    {
        public User()
        {
            Order = new HashSet<Order>();
        }
        public virtual ICollection<Order> Order { get; set; }
    }
}
