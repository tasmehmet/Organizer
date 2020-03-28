using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizer.Domain.Models;

namespace Organizer.Data.Mappings
{
    public class CountiesMapping:EntityMapping<CountiesModel>
    {
        public override void Configure(EntityTypeBuilder<CountiesModel> builder)
        {
            builder.Property(p => p.CityId).HasColumnName("CityId");
            builder.Property(p => p.Name).HasColumnName("Name");
        }
    }
}