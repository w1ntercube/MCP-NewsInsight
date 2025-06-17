using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsInsight.Shared.Models
{
    [Table("t_news")]
    public class News
    {
        [Key]
        [Column("news_id")]
        public int NewsId { get; set; }

        [Column("headline")]
        public string? Headline { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("topic")]
        public string Topic { get; set; }

        [Column("total_browse_num")]
        public uint TotalBrowseNum { get; set; }

        [Column("total_browse_duration")]
        public uint TotalBrowseDuration { get; set; }

        [Column("released_time")]
        public uint? ReleasedTime { get; set; } // 可为空
    }
}
