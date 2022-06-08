﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnyBuyStore.Data.Data
{
    public class ProductSubcategory
    {   [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Product_category_id")]
        [Display(Name = "ProductCategory")]
        public virtual int ProductCategoryId { get; set; }

        [Column("name")]
        public string Name { get; set; } = String.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;



        [ForeignKey("ProductCategoryId")]
        public  virtual ProductCategory ProductCategory { get; set; } = new ProductCategory();


    }
}
