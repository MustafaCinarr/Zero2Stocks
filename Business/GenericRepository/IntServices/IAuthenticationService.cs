using Business.DTOs.Auth;

namespace Business.GenericRepository.IntServices;

public interface IAuthenticationService
{
    
        Task<MemberResponseDto> RegisterAsync(RegisterMemberDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    
}