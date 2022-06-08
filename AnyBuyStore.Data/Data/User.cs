﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }    = string.Empty;
        
        [Column("email",TypeName = "varchar(200)")]
        public string Email { get; set; } = string.Empty;
        
        [Column("age")]
        public int Age { get; set; }
        
        [Column("gender",TypeName = "varchar(50)")]
        public string? Gender { get; set; }

        [Column("role", TypeName = "varchar(50)")]
        public string Role { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        public virtual ICollection<ProductWish> ProductWishes { get; set; } = new HashSet<ProductWish>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        

    }
}
