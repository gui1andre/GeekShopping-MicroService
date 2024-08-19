using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.ProductApi.Models.Base;

namespace GeekShopping.ProductApi.Models.Context;

[Table("product")]
public class Product : BaseEntity
{
    [Column("name")]
    [Required]
    [StringLength(150)]
    public required string Name { get; set; }

    [Column("price")]
    [Required]
    [Range(1, 10000)]
    public Decimal Price { get; set; }

    [Column("description")]
    [StringLength(500)]
    public required string Description { get; set; }

    [Column("category_name")]
    [StringLength(50)]
    public required string CategoryName { get; set; }

    [Column("image_url")]
    [StringLength(300)]
    public required string ImageUrl { get; set; }
}