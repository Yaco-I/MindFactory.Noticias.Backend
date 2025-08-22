using Artifacts.Api;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Services.Contracts;
using MindFactory.Noticias.Backend.Services.DTOs.Categoria;

namespace MindFactory.Noticias.Backend.Api.Controllers;

public class CategoriasController : BaseController
{
    private readonly ICategoriaService _categoriaService;
    private readonly IMapper _mapper;

    public CategoriasController(ICategoriaService categoriaService, IMapper mapper)
    {
        _categoriaService = categoriaService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _categoriaService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(categorias));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);
        if (categoria == null)
            return NotFound();

        return Ok(_mapper.Map<CategoriaDto>(categoria));
    }

    [HttpPost]
    [Authorize(Policy = "RequireAdminRole")]
    public async Task<IActionResult> Create([FromBody] CategoriaDto createCategoriaDto)
    {
        var entity = _mapper.Map<Categoria>(createCategoriaDto);
        var creada = await _categoriaService.CreateAsync(entity);

        return CreatedAtAction(
            nameof(GetById),
            new { id = creada.Id },
            _mapper.Map<CategoriaDto>(creada)
        );
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    public async Task<IActionResult> Update(int id, [FromBody] CategoriaDto updateCategoriaDto) 
    {
        if (id != updateCategoriaDto.Id)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del objeto.");
        }

        var entity = _mapper.Map<Categoria>(updateCategoriaDto);
        var actualizada = await _categoriaService.UpdateAsync(entity);

        if (actualizada == null)
            return NotFound();

        return Ok(_mapper.Map<CategoriaDto>(actualizada));
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoriaService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
