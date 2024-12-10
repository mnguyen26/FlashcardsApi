using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace FlashcardsApi.Models
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        public required string Front { get; set; }
        [Required]
        public required string Back { get; set; }
        [Required]
        public required string Deck { get; set; }
        public List<string>? Categories { get; set; }

        public string GetJsonFromCategories(List<string> Categories)
        {
            return JsonSerializer.Serialize(Categories);
        }

        public List<string> GetCategoriesFromJson (string jsonString)
        {
            return string.IsNullOrEmpty(jsonString) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(jsonString);
        }
    }
}
