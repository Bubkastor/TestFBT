using FluentMigrator;

namespace PersistanceMigrations;

internal class DbMigration : Migration
{
    /// <inheritdoc />
    public override void Up()
    {
        throw new NotImplementedException($"The {GetType().Name}.{nameof(Up)}() migration method is not implemented.");
    }

    /// <inheritdoc />
    public override void Down()
    {
        throw new NotImplementedException($"The {GetType().Name}.{nameof(Down)}() migration method is not implemented.");
    }
}
