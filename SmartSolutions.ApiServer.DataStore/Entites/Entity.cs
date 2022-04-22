using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSolutions.ApiServer.DataStore.Entites
{
    public abstract class Entity<T> : IEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IEntity.Id
        {
            get => Id; 
            set { this.Id = (T)Convert.ChangeType(value, typeof(T)); }
        }

        public string? Name { get; set; }

        private DateTime? createdAt;
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt
        {
            get { return createdAt ?? DateTime.UtcNow; }
            set { createdAt = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        [Timestamp]
        public byte[]? Version { get; set; }
    }
}
