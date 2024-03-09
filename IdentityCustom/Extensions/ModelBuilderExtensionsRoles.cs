using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityCustom.Extensions;

static class ModelBuilderExtensionsRoles
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "47EF3A46-9883-466A-969F-0C00975435D3",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "AA6452D8-71F6-4E0D-B4E2-ED95438B57DC"
            },
            new IdentityRole
            {
                Id = "65440C38-984A-4145-BCE1-4142A3722487",
                Name = "Klient",
                NormalizedName = "KLIENT",
                ConcurrencyStamp = "A9B1C55C-B3E0-4AF0-AB41-CD9018B327F4"
            },
            new IdentityRole
            {
                Id = "DFA9AFA8-B475-451E-A77A-ACC97C647820",
                Name = "Pracownik",
                NormalizedName = "PRACOWNIK",
                ConcurrencyStamp = "B4AC058E-CAE2-4BD4-A236-9D3AA7B9BA37"
            });
    }
}
