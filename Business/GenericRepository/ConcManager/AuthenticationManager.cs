using System.Security.Cryptography;
using System.Text;
using Business.DTOs.Auth;
using Business.GenericRepository.IntServices;
using DataAccess;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcManager;

public class AuthenticationManager : IAuthenticationService
{
        private readonly Zero2StocksContext _context;
        
        public AuthenticationManager(Zero2StocksContext context)
        {
            _context = context;
        }

        public async Task<MemberResponseDto> RegisterAsync(RegisterMemberDto dto)
        {
            // Bu e-posta veya kullanıcı adı daha önce kullanılmış mı ? 
            var exists = await _context.Members
                .AnyAsync(m => m.Email == dto.Email || m.UserName == dto.UserName);

            if (exists)
            {
                throw new InvalidOperationException("Bu e-poste veya kullanıcı adı zaten kayıtlı.");
            }
            
            // Yeni Member oluştur

            var member = new Member
            {
                UserName = dto.UserName,
                Email = dto.Email,
                IsActive = true
            };
            
            // Şifre hashle
            
            member.PasswordHash = HashPassword(dto.Password);
            
            // Veritabnına ekle ve kaydet 
            
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            
            // Kullanıcıya dönülen DTO

            return new MemberResponseDto
            {
                Id = member.Id,
                UserName = member.UserName,
                Email = member.Email
            };
            
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            // Kullanıcıyı email veya kullanıcı adına göre bul
            
            var member = await _context.Members
                .FirstOrDefaultAsync(m=> 
                    m.Email == dto.EmailOrUserName ||
                    m.UserName == dto.EmailOrUserName);

            if (member == null)
            {
                // Böyle bir kullanıcı yok , giriş başarısız

                return null;
            }
            
            // Şifreyi kontrol et
            
            var isPasswordValid = VerifyPassword(dto.Password, member.PasswordHash);

            if (!isPasswordValid)
            {
                // Şifre yanlış -> giriş başarısız
                return null;
            }
            
            // Şimdilik GEÇİCİ TOKEN 

            var fakeToken = "TEMP_TOKEN_LOGIN_SUCCES";

            return fakeToken;
        }
        
        // Şifre Hash işlemleri 

        private static string HashPassword(string password)
        {
            using var sha = SHA3_256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hashedPassword;
        }
    
}