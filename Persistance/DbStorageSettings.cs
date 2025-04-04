using System.ComponentModel.DataAnnotations;

namespace Persistance;

public class DbStorageSettings
{
    [Required]
    public required string ConnectionString { get; set; }

    [Required]
    public bool IsUseSqlLite { get; set; }

}
