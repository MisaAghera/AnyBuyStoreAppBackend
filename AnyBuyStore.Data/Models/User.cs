﻿using AnyBuyStore.Data.Data;
using Microsoft.AspNetCore.Identity;


namespace AnyBuyStore.Data.Models
{
    public class User : IdentityUser<int>
    {


        public int? Age { get; set; }
        public string? Gender { get; set; } = string.Empty;


        public virtual Address? Address { get; set; }

        public virtual ICollection<ProductWish>? ProductWishes { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<ProductCart>? ProductCarts { get; set; }
    
    }
}