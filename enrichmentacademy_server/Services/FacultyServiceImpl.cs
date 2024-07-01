using EnrichmentAcademy.Data;
using EnrichmentAcademy.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EnrichmentAcademy.Services
{
    public class FacultyServiceImpl : FacultyServiece
    {
        private readonly DatabaseContext _dbContext;
        public FacultyServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateFaculty(CreateFaculty createFaculty)
        {
           using(var traction=await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var Name = new SqlParameter("@Name", createFaculty.Name);
                    await _dbContext.Database.ExecuteSqlRawAsync("EXEC CreateFaculty @Name", Name);
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

        public async Task<bool> DeleteFaculty(int id)
        {
            using (var traction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var IdParameter = new SqlParameter("@Id", id);
                    await _dbContext.Database.ExecuteSqlRawAsync("EXEC DeleteFaculty @Id", IdParameter);
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
            var Faculties = await _dbContext.Faculties
              .FromSqlRaw("EXEC ShowFaculty")
              .AsNoTracking()
              .ToListAsync();

            return  Faculties.Select(d => new
            {
                Id=d.Id,
                Name=d.Name,
            });
        }

        public async Task<bool> UpdateFaculty(int id, CreateFaculty updateFaculty)
        {
           using(var traction=await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var NameParameter = new SqlParameter("@Name", updateFaculty.Name);
                    var IdParameter=new SqlParameter("@Id", id);
                    await _dbContext.Database.ExecuteSqlRawAsync("EXEC UpdateFaculty @Id,@Name", IdParameter, NameParameter);
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
