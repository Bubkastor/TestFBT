using FluentMigrator;

namespace PersistanceMigrations.Migrations;
[Migration(20250404)]
internal class _20250404_Initial : DbMigration
{
    public override void Up()
    {
        Create.Table("Data")
            .WithInt32Id("Data_Id")
            .WithColumn("Code").AsInt32().NotNullable()
            .WithColumn("Value").AsString(100).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Data");
    }
}
