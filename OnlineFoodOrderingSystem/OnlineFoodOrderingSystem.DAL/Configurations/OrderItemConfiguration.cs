using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineFoodOrderingSystem.Shared.Models;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Quantity).IsRequired();

        builder.Property(x => x.UnitPrice)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Price)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(x => x.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Cart)
               .WithMany(c => c.OrderItems)
               .HasForeignKey(x => x.CartId)
               .OnDelete(DeleteBehavior.Restrict);

        // Auditing + soft delete
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);
        builder.Property(x => x.DeletedAt).IsRequired(false);

        builder.HasIndex(x => x.OrderId);
        builder.HasIndex(x => x.CartId);
    }
}
