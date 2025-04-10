using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApi.Domain.Entities
{
    [Table("Products")]
    public record Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("Id")]
        public int Id { get; init; }

        [Column("product_name")]
        [MaxLength(100)]
        public string? ProductName { get; init; } = string.Empty;

        [Column("product_code")]
        [MaxLength(10)]
        public string? ProductCode { get; init; } = string.Empty;
        //public string Description { get; init; } = string.Empty;

        [Column("price", TypeName = "decimal(7,2)")]
        public decimal Price { get; init; }

    }
}
