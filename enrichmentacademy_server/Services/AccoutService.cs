using EnrichmentAcademy.Data;
using EnrichmentAcademy.Models;

namespace EnrichmentAcademy.Services
{
    public interface AccoutService
    {
        Task<bool>AddAccountTeacher(AddAccountTeacher accountTeacher);
        Task<dynamic> ShowAccountTeacher();
        Task<bool>ResetPassword(string Email,string Password);
        Task<Account>Login(string Email,string Password,HttpResponse response);
        Task<bool> ApproveActive(int id,string Email);
        Task<bool>ForgotPassword(string Email);
        Task<bool>CheckOTP(string Email,string OTP);
        Task UpdateOTP();
    }
}
