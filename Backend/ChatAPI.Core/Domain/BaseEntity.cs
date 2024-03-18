using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Core;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}