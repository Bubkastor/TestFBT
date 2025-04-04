using LinqToDB.Mapping;

namespace Persistance.Models
{
    [Table("Data")]
    public class DataEntite
    {
        [Column]
        [NotNull]
        [PrimaryKey]
        [Identity]
        [SkipValuesOnInsert]
        public required int Id { get; set; }

        [Column, NotNull]

        public required int Code { get; set; }

        [Column, NotNull]
        public required string Value { get; set; }
    }
}
