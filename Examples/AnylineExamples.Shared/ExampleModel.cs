using System;
using System.Collections.Generic;
using System.Text;

namespace AnylineExamples.Shared
{
    public class ExampleModel : Java.Lang.Object
    {

        /// <summary>
        /// The type (header or item)
        /// </summary>
        public ItemType Type { get; set; }

        /// <summary>
        /// Name of the entry
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Category (constants defined in "Category" class)
        /// </summary>
        public string Category { get; set; }
        
        /// <summary>
        /// Path string to the json config file
        /// </summary>
        public string JsonPath { get; set; }

        public ExampleModel(ItemType type, string name, string category, string jsonPath)
        {
            Type = type;
            Name = name;
            Category = category;
            JsonPath = jsonPath;
        }

        private ExampleModel() { }

    }
}
