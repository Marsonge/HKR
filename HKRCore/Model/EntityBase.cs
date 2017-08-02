using System.ComponentModel.DataAnnotations;

namespace HKRCore.Model
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; protected set; }
    }
}