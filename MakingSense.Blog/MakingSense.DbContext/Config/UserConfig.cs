using MakingSense.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakingSense.DataContext.Config
{
    public class UserConfig
    {
        public UserConfig(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Posts).HasMaxLength(500);
        }
    }
}
