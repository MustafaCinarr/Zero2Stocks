namespace Business.GenericRepository.IntServices.IBaseService;

public interface IBaseService<TGetDto, in TCreateDto, in TUpdateDto>
{
    Task<IEnumerable<TGetDto>> GetAllAsync();

    Task<TGetDto> GetByIdAsync(int id);

    Task<TGetDto> AddAsync(TCreateDto createDto);

    Task<bool> UpdateAsync(int id, TUpdateDto updateDto);

    Task<bool> DeleteAsync(int id);
}
