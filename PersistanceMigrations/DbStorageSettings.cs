using System.ComponentModel.DataAnnotations;

namespace PersistanceMigrations
{
    internal class DbStorageSettings
    {
        [Required]
        public required string ConnectionString { get; set; }

        [Required]
        public bool IsUseSqlLite { get; set; }
    }
}
