using System.ComponentModel.DataAnnotations;

namespace Liki.Data.Contracts.Abstractions
{
    public abstract class BaseIdEntity : IBaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}