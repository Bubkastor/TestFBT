using FluentMigrator.Builders.Create.Table;

namespace PersistanceMigrations;

internal static class MigrationUtils
{
    public static ICreateTableColumnOptionOrWithColumnSyntax WithInt32Id(this ICreateTableWithColumnSyntax createTableSyntax, string primaryKeyName)
    {
        return createTableSyntax.WithColumn("Id").AsInt32().NotNullable().PrimaryKey(primaryKeyName).Identity();
    }

    public static ICreateTableColumnOptionOrWithColumnSyntax WithInt64Id(this ICreateTableWithColumnSyntax createTableSyntax, string primaryKeyName)
    {
        return createTableSyntax.WithColumn("Id").AsInt64().NotNullable().PrimaryKey(primaryKeyName).Identity();
    }

    public static ICreateTableColumnOptionOrWithColumnSyntax WithGuidId(this ICreateTableWithColumnOrSchemaSyntax createTableSyntax, string primaryKeyName)
    {
        return createTableSyntax.WithColumn("Id").AsGuid().NotNullable().PrimaryKey(primaryKeyName);
    }

    public static ICreateTableColumnOptionOrWithColumnSyntax AsMaxString(this ICreateTableColumnAsTypeSyntax createTableSyntax)
    {
        return createTableSyntax.AsString(int.MaxValue);
    }
}
