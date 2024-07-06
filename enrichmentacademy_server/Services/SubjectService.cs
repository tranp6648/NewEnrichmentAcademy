using EnrichmentAcademy.Data;

namespace EnrichmentAcademy.Services
{
    public interface SubjectService
    {
        Task<bool> CreateSubject(AddSubject addSubject);
        Task<dynamic> ShowFaculty();
        Task<dynamic> ShowSubject();
        Task<bool>UpdateSubject(int id,UpdateSubject updateSubject);
        Task<bool>DeleteSubject(int id);    
    }
}
