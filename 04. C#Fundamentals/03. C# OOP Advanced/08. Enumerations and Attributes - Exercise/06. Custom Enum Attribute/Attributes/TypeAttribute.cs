using System;

namespace _06.Custom_Enum_Attribute.Attributes
{
    public class TypeAttribute : Attribute
    {
        public TypeAttribute(string category, string description)
        {
            this.Type = "Enumeration";
            this.Category = category;
            this.Description = description;
        }

        public string Type { get; private set; }

        public string Category { get; private set; }

        public string Description { get; private set; }

        public override string ToString()
        {
            return $"Type = {this.Type}, Description = {this.Description}";
        }
    }
}
