using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace slot_4.Models
{
    public partial class Category
    {
        public Category()
        {
        }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return CategoryId + "\t" + CategoryName;
        }
    }
}