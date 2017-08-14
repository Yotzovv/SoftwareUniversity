using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Models.DTOs
{
	public class GroupDto
	{
		[JsonProperty(PropertyName ="Name" )]
		public string Name { get; set; }
		[JsonProperty(PropertyName = "IsActive")]
		public bool IsActive { get; set; }
		[JsonProperty(PropertyName = "SubGroup")]
		public SubGroup SubGroups { get; set; }
		
		
	}

	[JsonArray]
	public class SubGroup
	{
		[JsonProperty(PropertyName = "Name")]
		public string Name { get; set; }
		[JsonProperty(PropertyName = "IsActive")]
		public bool IsActive { get; set; }

		public Element Elements { get; set; }

	}

	[JsonArray]
	public class Element
	{
		[JsonProperty(PropertyName = "Name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "Price")]
		public decimal Price { get; set; }
		[JsonProperty(PropertyName = "Date")]
		public DateTime Date { get; set; }
	}
}
