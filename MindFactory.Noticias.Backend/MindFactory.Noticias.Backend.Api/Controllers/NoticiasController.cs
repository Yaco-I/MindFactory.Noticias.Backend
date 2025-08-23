using Microsoft.AspNetCore.Mvc;
using MindFactory.Noticias.Backend.Services.DTOs.Noticia;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using AutoMapper;
using MindFactory.Noticias.Backend.Services.Contracts.Services;
using MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;
using Artifacts.Api;
using Artifacts.EntityFramework;

namespace MindFactory.Noticias.Backend.Api.Controllers;
/// <summary>
/// Controller de Noticias
/// </summary>
public class NoticiasController : BaseController
{
    private readonly INoticiaService _noticiaService;
    private readonly IMapper _mapper;
    public NoticiasController(INoticiaService noticiaService, IMapper mapper)
    {
        _noticiaService = noticiaService;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtiene una lista de todas las noticias.
    /// </summary>
    /// <returns>Una lista de objetos NoticiaDto.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll(int pageSize, int pageIndex)
    {
        var noticias = await _noticiaService.GetAllAsync(pageIndex, pageSize);

        var result = new PagedResult<NoticiaDto>
        {
            PageIndex = noticias.PageIndex,
            PageSize = noticias.PageSize,
            TotalRecords = noticias.TotalRecords,
            TotalPages = noticias.TotalPages,
            Items = _mapper.Map<List<NoticiaDto>>(noticias.Items)
        };

        return Ok(result);
    }

    /// <summary>
    /// Obtiene una noticia por su ID.
    /// </summary>
    /// <param name="id">El ID de la noticia a buscar.</param>
    /// <returns>La noticia encontrada o un código 404 si no existe.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(int id)
    {
        var noticia = await _noticiaService.GetByIdAsync(id);
        if (noticia == null)
            return NotFound();

        return Ok(_mapper.Map<NoticiaDto>(noticia));
    }


    /// <summary>
    /// Busca noticias utilizando un filtro de búsqueda.
    /// </summary>
    /// <param name="noticiaSearchFilter">Filtros de búsqueda para las noticias.</param>
    /// <returns>Una lista de noticias que coinciden con los filtros.</returns>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SearchNoticias([FromQuery]NoticiaSearchFilter noticiaSearchFilter)
    {
        var noticias = await _noticiaService.SearchNoticias(noticiaSearchFilter);
        if (noticias == null)
            return NotFound();

        return Ok(noticias);
    }

    /// <summary>
    /// Crea una nueva noticia.
    /// </summary>
    /// <param name="createNoticiaDto">El objeto NoticiaDto con los datos de la noticia a crear.</param>
    /// <returns>La noticia recién creada.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] NoticiaDto createNoticiaDto)
    {
        var entity = _mapper.Map<Noticia>(createNoticiaDto);
        var creada = await _noticiaService.CreateAsync(entity);

        return CreatedAtAction(nameof(GetById), new { id = creada.Id }, _mapper.Map<NoticiaDto>(creada));
    }

    /// <summary>
    /// Actualiza una noticia existente.
    /// </summary>
    /// <param name="id">El ID de la noticia a actualizar.</param>
    /// <param name="updateNoticiaDto">El objeto NoticiaDto con los datos actualizados.</param>
    /// <returns>La noticia actualizada.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(int id, [FromBody] NoticiaDto updateNoticiaDto)
    {
        if (id != updateNoticiaDto.Id)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del objeto.");
        }

        var entity = _mapper.Map<Noticia>(updateNoticiaDto);
        var actualizada = await _noticiaService.UpdateAsync(entity);

        if (actualizada == null)
            return NotFound();

        return Ok(_mapper.Map<NoticiaDto>(actualizada));
    }


    /// <summary>
    /// Elimina una noticia por su ID.
    /// </summary>
    /// <param name="id">El ID de la noticia a eliminar.</param>
    /// <returns>Un código 204 si la eliminación fue exitosa o 404 si la noticia no se encontró.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _noticiaService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
