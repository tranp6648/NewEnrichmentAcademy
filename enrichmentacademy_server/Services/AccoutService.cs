namespace EnrichmentAcademy.Services
{
    public interface AccoutService
    {
        Task<bool>AddAccountTeacher(AddAccountTeacher accountTeacher);
        Task<dynamic> ShowAccountTeacher();
    }
}
