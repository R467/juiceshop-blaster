using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tests
{
    /// <summary>
    /// Model for response from Juice Shop API
    /// /api/Challenges
    /// </summary>
    public class JsonChallengeResponse
    {
        [JsonPropertyName("data")]
        public List<JsonChallenge> Data { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

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
        public bool Solved { get; set; }

        [JsonPropertyName("disabledEnv")]
        public string DisabledEnv { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}