using System;
using System.Text.Json.Serialization;

namespace Tests
{
    public class JsonChallenge
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("difficulty")]
        public int Difficulty { get; set; }

        [JsonPropertyName("hint")]
        public string Hint { get; set; }

        [JsonPropertyName("hintUrl")]
        public string HintUrl { get; set; }

        [JsonPropertyName("solved")]
        public bool solved { get; set; }

        [JsonPropertyName("disabledEnv")]
        public string DisabledEnv { get; set; }

        [JsonPropertyName("tutorialOrder")]
        public string TutorialOrder { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}