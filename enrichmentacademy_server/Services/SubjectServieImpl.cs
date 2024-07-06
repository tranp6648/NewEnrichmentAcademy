using EnrichmentAcademy.Data;
using EnrichmentAcademy.Helper;
using EnrichmentAcademy.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Services
{
    public class SubjectServieImpl : SubjectService
    {
        private IConfiguration configuration;
        private IWebHostEnvironment webHostEnvironment;
        private DatabaseContext databaseContext;
        public SubjectServieImpl(IConfiguration configuration, IWebHostEnvironment webHostEnvironment, DatabaseContext databaseContext)
        {
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
            this.databaseContext = databaseContext;
        }

        public async Task<bool> CreateSubject(AddSubject addSubject)
        {
            using (var traction = await databaseContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var filename = FileHelper.GenerateFilename(addSubject.LinkSubject.FileName);
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "images", filename);
                    using (var filleStream=new FileStream(path,FileMode.Create))
                    {
                        addSubject.LinkSubject.CopyTo(filleStream);
                    }
                    var sql = "EXEC CreateSubject @Name,@IdFaculty,@Price,@Link";
                    var parameters = new[]
                    {
                        new SqlParameter("@Name",addSubject.Name),
                        new SqlParameter("@IdFaculty",addSubject.IdFaculty),
                        new SqlParameter("@Price",addSubject.Price),
                        new SqlParameter("@Link",filename),
                    };
                    await databaseContext.Database.ExecuteSqlRawAsync(sql, parameters);
                    await traction.CommitAsync();
                    return true;
                }
                catch
                {
                    await traction.RollbackAsync();
                    return false;
                }
            }
        }
        public void DeletePhoto(string photo)
        {
            try
            {
                string path = Path.Combine(webHostEnvironment.WebRootPath, "images", photo);
                if (File.Exists(path))
                {
                    File.Delete(path);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file '{photo}': {ex.Message}");
            }
        }
        public async Task<bool> DeleteSubject(int id)
        {
            using (var traction = await databaseContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var Subject=await databaseContext.SubjectDbs.FindAsync(id);
                    if (Subject!=null){
                        DeletePhoto(Subject.IdPhotoNavigation.Link);
                    }
                    var sql = "EXEC DeleteSubject @Id";
                    var Parameter = new SqlParameter("@Id", id);

                    await databaseContext.Database.ExecuteSqlRawAsync(sql, Parameter);
                    await traction.CommitAsync();
                    return true;
                }
                catch
                {
                    await traction.RollbackAsync();
                    return false;
                }
            }

            }

        public async Task<dynamic> ShowFaculty()
        {
            var Faculties = await databaseContext.Faculties
               .FromSqlRaw("EXEC ShowFaculty")
               .AsNoTracking()
               .ToListAsync();

            return Faculties.Select(d => new
            {
                Id = d.Id,
                Name = d.Name,
            });
        }

        public async Task<dynamic> ShowSubject()
        {
            return databaseContext.SubjectDbs.Select(d => new
            {
                Id = d.Id,
                Name=d.Name,
                Faculty=d.IdFacultityNavigation.Name,
                idFaculty=d.IdFacultity,
                Photo=configuration["ImageUrl"]+ d.IdPhotoNavigation.Link,
                Price=d.Price,
            }).ToList();

        }

        public async Task<bool> UpdateSubject(int id, UpdateSubject updateSubject)
        {
            using (var traction = await databaseContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var sql = "EXEC UpdateSubject @Id,@Name,@Price,@IdFaculty";
                    var parameters = new[]
                    {
                        new SqlParameter("@Id",id),
                        new SqlParameter("@Name",updateSubject.Name),
                        new SqlParameter("@Price",updateSubject.Price),
                        new SqlParameter("@IdFaculty",updateSubject.IdFaculty),
                    };
                    await databaseContext.Database.ExecuteSqlRawAsync(sql, parameters);
                    await traction.CommitAsync();
                    return true;    
                }
                catch
                {
                    await traction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
