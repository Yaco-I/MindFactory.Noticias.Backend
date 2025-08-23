using FluentValidation;
using MindFactory.Noticias.Backend.Services.DTOs.Noticia;

namespace MindFactory.Noticias.Backend.Api.Validators;

public class NoticiaValidator : AbstractValidator<NoticiaDto>
{
    public NoticiaValidator()
    {
        RuleFor(n => n.Id)
            .GreaterThanOrEqualTo(0).WithMessage("Id inválido.");

        RuleFor(n => n.Titulo)
            .NotEmpty().WithMessage("El título es obligatorio.")
            .MaximumLength(200).WithMessage("El título no puede superar 200 caracteres.");

        RuleFor(n => n.URL)
            .MaximumLength(500).WithMessage("La URL no puede superar 500 caracteres.");

        RuleFor(n => n.Contenido)
            .NotEmpty().WithMessage("El contenido es obligatorio.");

        RuleFor(n => n.Resumen)
            .MaximumLength(500).WithMessage("El resumen no puede superar 500 caracteres.");

        RuleFor(n => n.CategoriaId)
            .GreaterThan(0).WithMessage("Debe seleccionar una categoría válida.");

    }
}
