

namespace Domain.Common.Abstractions;

public interface IAuditable
{
    [Required]
    public DateTimeOffset CreatedAt { get; set; }

    [Column(TypeName = "CHAR(36)")]//because guid has 32 characters with 4 hyphens -
    public string CreatedBy { get; set; }

    [Required]
    public DateTimeOffset LastModifiedAt { get; set; }

    [Column(TypeName = "CHAR(36)")]
    public string LastModifiedBy { get; set; }
}
