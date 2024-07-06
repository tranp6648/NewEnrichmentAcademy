using EnrichmentAcademy.Data;

namespace EnrichmentAcademy.Services
{
    public interface PackageService
    {
        Task<dynamic> ShowSubject();
        Task<bool> CreatePackage(CreatePackage createPackage);
    }
}
