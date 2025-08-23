using Artifacts.Api;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Services.Contracts.Services;
using MindFactory.Noticias.Backend.Services.DTOs.Categoria;

namespace MindFactory.Noticias.Backend.Api.Controllers;

/// <summary>
/// Controlador para gestionar categorías de noticias.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CategoriasController : BaseController
{
    private readonly ICategoriaService _categoriaService;
    private readonly IMapper _mapper;

    public CategoriasController(ICategoriaService categoriaService, IMapper mapper)
    {
        _categoriaService = categoriaService;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtiene todas las categorías.
    /// </summary>
    /// <returns>Lista de categorías</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _categoriaService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(categorias));
    }

    /// <summary>
    /// Obtiene una categoría por su ID.
    /// </summary>
    /// <param name="id">ID de la categoría</param>
    /// <returns>Categoría encontrada</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);
        if (categoria == null) return NotFound();
        return Ok(_mapper.Map<CategoriaDto>(categoria));
    }

    /// <summary>
    /// Crea una nueva categoría. Requiere rol de administrador.
    /// </summary>
    /// <param name="createCategoriaDto">Datos de la categoría</param>
    /// <returns>Categoría creada</returns>
    [HttpPost]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    /// <summary>
    /// Actualiza una categoría existente. Requiere rol de administrador.
    /// </summary>
    /// <param name="id">ID de la categoría</param>
    /// <param name="updateCategoriaDto">Datos actualizados</param>
    /// <returns>Categoría actualizada</returns>
    [HttpPut("{id:int}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(int id, [FromBody] CategoriaDto updateCategoriaDto)
    {
        if (id != updateCategoriaDto.Id)
            return BadRequest("El ID de la ruta no coincide con el ID del objeto.");

        var entity = _mapper.Map<Categoria>(updateCategoriaDto);
        var actualizada = await _categoriaService.UpdateAsync(entity);

        if (actualizada == null) return NotFound();

        return Ok(_mapper.Map<CategoriaDto>(actualizada));
    }

    /// <summary>
    /// Elimina una categoría. Requiere rol de administrador.
    /// </summary>
    /// <param name="id">ID de la categoría</param>
    /// <returns>NoContent si se eliminó correctamente</returns>
    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoriaService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
