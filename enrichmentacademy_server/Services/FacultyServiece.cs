using EnrichmentAcademy.Data;

namespace EnrichmentAcademy.Services
{
    public interface FacultyServiece
    {
        Task<bool> CreateFaculty(CreateFaculty createFaculty);
        Task<dynamic> ShowFaculty();
        Task<bool>UpdateFaculty(int id,CreateFaculty updateFaculty);
        Task<bool> DeleteFaculty(int id);
    }
}
