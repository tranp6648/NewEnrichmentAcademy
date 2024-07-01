
using EnrichmentAcademy.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EnrichmentAcademy.Data;
using System.Data;
using Newtonsoft.Json;

namespace EnrichmentAcademy.Services
{
    public class AccountServiceImpl : AccoutService
    {
        private DatabaseContext dbContext;
        public AccountServiceImpl(DatabaseContext databaseContext) { 
        this.dbContext = databaseContext;
        }
        public string GenerateRandomFourDigitNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(1000, 10000);
            return  randomNumber.ToString();
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
                    var sql = "EXEC CreateAccountTeacher @Name,@Email,@Birthday,@Phone,@AccountType,@Password,@IsActive";
                    var paremeters = new[]
                    {
                        new SqlParameter("@Name",accountTeacher.Name),
                        new SqlParameter("@Email",accountTeacher.Email),
                        new SqlParameter("@Birthday",accountTeacher.Birthday),
                        new SqlParameter("@Phone",accountTeacher.Phone),
                        new SqlParameter("@AccountType", accountTeacher.AccountType),
                        new SqlParameter("@Password",BCrypt.Net.BCrypt.HashPassword(Password)),
                        new SqlParameter("@IsActive",false)
                    };
                    await dbContext.Database.ExecuteSqlRawAsync(sql, paremeters);
                    SendEmail(accountTeacher.Email, "Create Account", $"FullName :{accountTeacher.Name}\n Password:{Password}\n Your account creation request will be sent to admin for account activation.");
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
                Accountype=d.Accountype,
                IsActive = d.IsActive
            });
        }

        public async Task<Account> Login(string Email, string Password, HttpResponse response)
        {
            try
            {

                var AccountLogin=await dbContext.Accounts.FirstOrDefaultAsync(d=>d.Email == Email && d.IsActive==true);
                if(AccountLogin!=null && BCrypt.Net.BCrypt.Verify(Password, AccountLogin.Password))
                {
                    var Account = new Account
                    {
                        Id = AccountLogin.Id,
                        Name = AccountLogin.Name,
                        Email = AccountLogin.Email,
                        Birthday = AccountLogin.Birthday,
                        Phone = AccountLogin.Phone,
                        Accountype = AccountLogin.Accountype,
                        IsActive = AccountLogin.IsActive
                    };
                    var userData = JsonConvert.SerializeObject(Account);
                    response.Cookies.Append("UserSession", userData, new CookieOptions
                    {
                        Expires = DateTime.Now.AddMinutes(15),
                        HttpOnly = true,
                        Secure = true
                    });
                    return Account;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Login: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> ApproveActive(int id, string Email)
        {
            using (var traction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var idParameter = new SqlParameter("@Id", id);
                    await dbContext.Database.ExecuteSqlRawAsync("EXEC ApproveAccount @Id", idParameter);
                    SendEmail(Email, "Successful activationt", $"Your account has been activated");
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

        public async Task<bool> ForgotPassword(string Email)
        {
            using (var traction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var Otp = GenerateRandomFourDigitNumber();
                    var EmailParameter = new SqlParameter("@Email", Email);
                    var OtpParameter = new SqlParameter("@OTP", Otp);
                    await dbContext.Database.ExecuteSqlRawAsync("EXEC ForgetPassword @Email,@OTP", EmailParameter, OtpParameter);

                    await traction.CommitAsync();
                    SendEmail(Email, "Password Reset Request ", $"Code OTP:{Otp}");
                    return true;
                }
                catch
                {
                    await traction.RollbackAsync();
                    return false;
                }
               
            }
            }

        public async Task<bool> CheckOTP(string Email, string OTP)
        {
            using (var traction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                
                    var OTPCheck = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == Email && x.Otp == OTP);
                    if (OTPCheck != null)
                    {
                        OTPCheck.Otp = null;
                        OTPCheck.Otptime = null;
                        await dbContext.SaveChangesAsync();

                        await traction.CommitAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    await traction.RollbackAsync();
                    return false;
                }
                
            }
            }

        public async Task UpdateOTP()
        {
            DateTime currenttime=DateTime.Now;
            var account = await dbContext.Accounts.ToListAsync();
            foreach(var accounts in account)
            {
                if(accounts.Otptime.HasValue && (currenttime - accounts.Otptime.Value).TotalMinutes > 2)
                {
                    accounts.Otp = null;
                    accounts.Otptime = null;
                }
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ResetPassword(string Email, string Password)
        {
            using(var traction=await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var EmailParameter = new SqlParameter("@Email", Email);
                    var PasswordParameter=new SqlParameter("@Password", BCrypt.Net.BCrypt.HashPassword(Password));
                    await dbContext.Database.ExecuteSqlRawAsync("EXEC ResetPassword @Email,@Password", EmailParameter, PasswordParameter);
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

