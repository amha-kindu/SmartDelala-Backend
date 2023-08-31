
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartDelala.Domain.Models;

namespace SmartDelala.Persistence.Configurations.Security;

public class ApplicationRoleEntityConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    private const string AdminRoleId = "acaa5c92-d9d8-4106-8150-91cb40139031";
    private const string PropertyBuyerRoleId = "6970d313-8ead-434b-a1ea-cacbc6b5c0e0";
    private const string PropertySellerRoleId = "8f4ca49c-f74f-4a97-b90c-b66f40eb9a5g";

    private const string Admin = "Admin";
    private const string PropertyBuyer = "PropertyBuyer";
    private const string PropertySeller = "PropertySeller";


    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        var admin = new ApplicationRole
        {
            Id = AdminRoleId,
            Name = Admin,
            NormalizedName = Admin.ToUpperInvariant()
        };
        builder.HasData(admin);

        var PropertyBuyerRole = new ApplicationRole
        {
            Id = PropertyBuyerRoleId,
            Name = PropertyBuyer,
            NormalizedName = PropertyBuyer.ToUpperInvariant()
        };
        builder.HasData(PropertyBuyerRole);


        var PropertySellerRole = new ApplicationRole
        {
            Id = PropertySellerRoleId,
            Name = PropertySeller,
            NormalizedName = PropertySeller.ToUpperInvariant()
        };
        builder.HasData(PropertySellerRole);
       }
}