using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TDX.Api.Models
{
    [BsonDiscriminator(RootClass = true)]
	public class ModelBase : IModel
	{
		[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
		public string Id { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier, providing support for optional hierarchies.
        /// </summary>
        /// <value>The parent identifier.</value>
		[JsonProperty("parentId")]
		public string ParentId { get; set; }

        [JsonProperty("created")]
		public DateTime Created { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("updated")]
		public DateTime Updated { get; set; }

        [JsonProperty("updatedBy")]
        public string UpdatedBy { get; set; }

        [JsonProperty("softDeleted")]
        public DateTime SoftDeleted { get; set; }

        [JsonProperty("softDeletedBy")]
        public string SoftDeletedBy { get; set; }

        [JsonProperty("isSoftDeleted")]
        public bool IsSoftDeleted { get; set; } = false;

		[JsonProperty("isActive")]
		public bool IsActive { get; set; } = true;
	}
} 
