using Business.DTOs.Asset;
using Business.GenericRepository.IntServices;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetsController : ControllerBase
{
    private readonly IAssetService _assetService;

    public AssetsController(IAssetService assetService)
    {
        _assetService = assetService;
    }

    // Tüm assetleri getir
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var assets = await _assetService.GetAllAsync();
        return Ok(assets);
    }

    // Id'ye göre tek asset getir
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var asset = await _assetService.GetByIdAsync(id);
        if (asset == null)
            return NotFound();
        
        return Ok(asset);
    }
    
    // Yeni asset ekle 
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AssetCreateDto dto)
    {
        var created = await _assetService.AddAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }
    
    // Mevcut Asseti güncelle 

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] AssetUpdateDto dto)
    {
        var success = await _assetService.UpdateAsync(id,dto);
        if (!success)
            return NotFound();
        
        return NoContent();
    }
    
    // Asset sil

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _assetService.DeleteAsync(id);
        if (!success)
            return NotFound();
        
        return NoContent();
    }
    
}