using System.Text.Json.Serialization;
using api.Models.Common;

namespace api.Models;

public class Comment : Base
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int? StockId { get; set; }
    // Navigation Property
    [JsonIgnore]
    public Stock? Stock { get; set; }
}
