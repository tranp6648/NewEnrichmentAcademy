
using EnrichmentAcademy.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Services
{
    public class AccountServiceImpl : AccoutService
    {
        private DatabaseContext dbContext;
        public AccountServiceImpl(DatabaseContext databaseContext) { 
        this.dbContext = databaseContext;
        }
        public string GenerateRandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+[]{}|;:,.<>?";
            Random random = new Random();
            char[] StringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(chars.Length);
                StringChars[i] = chars[randomIndex];
            }
            return new string(StringChars);
        }
        private void SendEmail(string to, string subject, string body)
        {
            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential("tranp6648@gmail.com", "czvy qzyc vpes whkj");
                client.EnableSsl = true;
                var message = new MailMessage
                {
                    From = new MailAddress("tranp6648@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };
                message.To.Add(to);
                client.Send(message);
            }
        }

        public async Task<bool> AddAccountTeacher(AddAccountTeacher accountTeacher)
        {
            using (var traction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    string Password = GenerateRandomString(8);
                    var sql = "EXEC CreateAccountTeacher @Name,@Email,@Birthday,@Phone,@AccountType,@Password";
                    var paremeters = new[]
                    {
                        new SqlParameter("@Name",accountTeacher.Name),
                        new SqlParameter("@Email",accountTeacher.Email),
                        new SqlParameter("@Birthday",accountTeacher.Birthday),
                        new SqlParameter("@Phone",accountTeacher.Phone),
                        new SqlParameter("@AccountType", 1),
                        new SqlParameter("@Password",BCrypt.Net.BCrypt.HashPassword(Password))
                    };
                    await dbContext.Database.ExecuteSqlRawAsync(sql, paremeters);
                    SendEmail(accountTeacher.Email, "Create Account", $"FullName :{accountTeacher.Name}\n Password:{Password}");
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

        public async Task<dynamic> ShowAccountTeacher()
        {
            var accounts = await dbContext.Accounts
              .FromSqlRaw("EXEC ShowAccountTeacher")
              .AsNoTracking()
              .ToListAsync();

            return accounts.Select(d => new
            {
                id = d.Id,
                name = d.Name,
                email = d.Email,
                birthday = d.Birthday,
                phone = d.Phone,
            });
        }
    }
}
