using MakingSense.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakingSense.DataContext.Config
{
    public class PostConfig
    {
        public PostConfig(EntityTypeBuilder<Post> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.UserId).IsRequired();
            entityBuilder.Property(x => x.User).IsRequired();
            entityBuilder.Property(x => x.Content).IsRequired().HasMaxLength(500);
        }
    }
}
