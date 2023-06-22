using Microsoft.EntityFrameworkCore;

namespace DocSeeker.API.Shared.Extensions;

// We are manipulating the metadata of Microsoft.EntityFrameworkCore.
public static class ModelBuilderExtensions
{
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        // We have all the entities that are participating in mapping process
        // foreach (var entity in builder.Model.GetEntityTypes())
        // {
        //     entity.SetTableName(entity.GetTableName().ToSnakeCase());
        //
        //     foreach (var property in entity.GetProperties())
        //         property.SetColumnName(property.GetColumnName().ToSnakeCase());
        //
        //     foreach (var key in entity.GetKeys()) key.SetName(key.GetName().ToSnakeCase());
        //
        //     foreach (var foreignKey in entity.GetForeignKeys())
        //         foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
        //
        //     foreach (var index in entity.GetIndexes()) index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
        // }
    }
}