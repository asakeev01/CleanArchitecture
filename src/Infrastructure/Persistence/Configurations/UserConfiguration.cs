using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

//public class UserConfiguration : IEntityTypeConfiguration<User>
//{
//    public void Configure(EntityTypeBuilder<User> builder)
//    {
//        builder
//            .HasOne(x => x.Document)
//            .WithOne(x => x.User)
//            .OnDelete(DeleteBehavior.Cascade);
//    }
//}