using Microsoft.AspNetCore.Mvc;
using MindFactory.Noticias.Backend.Services.DTOs.Noticia;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using AutoMapper;
using MindFactory.Noticias.Backend.Services.Contracts.Services;
using MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;
using Artifacts.Api;

namespace MindFactory.Noticias.Backend.Api.Controllers;

public class NoticiasController : BaseController
{
    private readonly INoticiaService _noticiaService;
    private readonly IMapper _mapper;
    public NoticiasController(INoticiaService noticiaService, IMapper mapper)
    {
        _noticiaService = noticiaService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var noticias = await _noticiaService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<NoticiaDto>>(noticias));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var noticia = await _noticiaService.GetByIdAsync(id);
        if (noticia == null)
            return NotFound();

        return Ok(_mapper.Map<NoticiaDto>(noticia));
    }

    [HttpGet("Search")]
    public async Task<IActionResult> SearchNoticias([FromQuery]NoticiaSearchFilter noticiaSearchFilter)
    {
        var noticias = await _noticiaService.SearchNoticias(noticiaSearchFilter);
        if (noticias == null)
            return NotFound();

        return Ok(noticias);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NoticiaDto createNoticiaDto)
    {
        var entity = _mapper.Map<Noticia>(createNoticiaDto);
        var creada = await _noticiaService.CreateAsync(entity);

        return CreatedAtAction(nameof(GetById), new { id = creada.Id }, _mapper.Map<NoticiaDto>(creada));
    }

    [HttpPut("{id}")]
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

        return Ok(_mapper.Map<Noticia>(actualizada));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _noticiaService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
