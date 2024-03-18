using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Core.Domain;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}