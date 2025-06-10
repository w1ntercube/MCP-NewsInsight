using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsInsight.Shared.Models
{
    [Table("news")]
    public class News
    {
    [Key]
    [Column("news_id")]
    public string NewsId { get; set; }

    [Column("category")]
    public string Category { get; set; }

    [Column("topic")]
    public string Topic { get; set; }

    [Column("headline")]
    public string Headline { get; set; }

    [Column("news_body")]
    public string NewsBody { get; set; }

    }
}
