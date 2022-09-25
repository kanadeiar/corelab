using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleConsole.ViewModels.Configuration;

public class SampleViewModelConfiguration : IEntityTypeConfiguration<SampleViewModel>
{
    public void Configure(EntityTypeBuilder<SampleViewModel> builder)
    {
        builder.HasNoKey().ToView("SampleMakeView", "dbo");
        // builder.HasNoKey().ToSqlQuery(@" // запрос SQL
        // SELECT s.Name Name, m.Name MakeName
        // FROM dbo.Samples s
        // INNER JOIN dbo.Make m ON s.MakeId = m.Id").ToView("SampleMakeView");        
        builder.ToTable(x => x.ExcludeFromMigrations());
    }
}