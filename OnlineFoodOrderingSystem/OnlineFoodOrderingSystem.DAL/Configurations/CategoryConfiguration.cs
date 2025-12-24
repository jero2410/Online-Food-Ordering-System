using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineFoodOrderingSystem.Shared.Models;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(300);

        builder.HasMany(x => x.FoodItems)
               .WithOne(f => f.Category)
               .HasForeignKey(f => f.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        // Auditing + soft delete
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.DeletedAt).IsRequired(false);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}
