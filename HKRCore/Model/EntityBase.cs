using System;
using System.ComponentModel.DataAnnotations;

namespace HKRCore.Model
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}