using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace slot_4.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        [JsonProperty("surprise")]
        public string? CategoryName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}