using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineFoodOrderingSystem.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.DAL.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.CartItems)
                   .WithOne(ci => ci.Cart)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.OrderItems)
                   .WithOne(oi => oi.Cart)
                   .HasForeignKey(oi => oi.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();

            builder.Property(x => x.IsDeleted)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.Property<int>("CartItemsCount").HasDefaultValue(0);
            builder.Property<int>("OrderItemsCount").HasDefaultValue(0);

            builder.Property<decimal>("Subtotal").HasDefaultValue(0m);
            builder.Property<decimal>("TaxAmount").HasDefaultValue(0m);
            builder.Property<decimal>("DeliveryFee").HasDefaultValue(0m);
            builder.Property<decimal>("DiscountAmount").HasDefaultValue(0m);
            builder.Property<decimal>("GrandTotal").HasDefaultValue(0m);
        }

    }
}
