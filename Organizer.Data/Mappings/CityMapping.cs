using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizer.Domain.Models;

namespace Organizer.Data.Mappings
{
    public class CityMapping: EntityMapping<CityModel>
    {
        public override void Configure(EntityTypeBuilder<CityModel> builder)
        {
            builder.Property(p => p.Name).HasColumnName("Name");
        }
    }
}