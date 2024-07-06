
using EnrichmentAcademy.Data;
using EnrichmentAcademy.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Services
{
    public class PackageServiceImpl : PackageService
    {
        private readonly DatabaseContext databaseContext;
        public PackageServiceImpl(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<bool> CreatePackage(Data.CreatePackage createPackage)
        {
            using (var traction = await databaseContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var Package = new Package
                    {
                        Name = createPackage.Name,
                        PricePackage = createPackage.PricePackage,
                    };
                    databaseContext.Packages.Add(Package);  
                    databaseContext.SaveChanges();
                    foreach(var idsubject in createPackage.IdSubject)
                    {
                        var PackageSubject = new SubjectPackage
                        {
                            IdPackage = Package.Id,
                            IdSubject = idsubject
                        };
                        databaseContext.SubjectPackages.Add(PackageSubject);
                    }
                    await traction.CommitAsync();
                    return databaseContext.SaveChanges() > 0;
                }
                catch
                {
                    await traction.RollbackAsync();
                    return false;
                }
            }
        }

        public async Task<dynamic> ShowSubject()
        {
            var Subjects = await databaseContext.SubjectDbs
               .FromSqlRaw("EXEC GetSubject")
               .AsNoTracking()
               .ToListAsync();
            return Subjects.Select(d => new
            {
                Id = d.Id,
                Name = d.Name,
            });
        }
    }
}
