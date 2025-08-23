using FluentValidation;
using MindFactory.Noticias.Backend.Services.DTOs.Categoria;
using MindFactory.Noticias.Backend.Services.DTOs.Noticia;

namespace MindFactory.Noticias.Backend.Api.Validators;

public class CategoriaValidator : AbstractValidator<CategoriaDto>
{
    public CategoriaValidator()
    {
        RuleFor(n => n.Nombre)
         .NotEmpty().WithMessage("El nombre es obligatorio.")
         .MaximumLength(100).WithMessage("El nombre no puede superar 100 caracteres.");

        RuleFor(n => n.Slug)
            .NotEmpty().WithMessage("El slug es obligatorio.")
            .MaximumLength(100).WithMessage("El slug no puede superar 100 caracteres.");

        RuleFor(n => n.Descripcion)
            .MaximumLength(255).WithMessage("El slug no puede superar 100 caracteres.");

    }
}