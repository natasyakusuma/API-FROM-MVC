using FluentValidation;

namespace APISolution.BLL.DTOs.Validator
{
	public class CategoryUpdateDTOValidator : AbstractValidator<CategoryUpdateDTO>
	{
		public CategoryUpdateDTOValidator()
		{
			RuleFor(x => x.CategoryID).NotEmpty().WithMessage("CategoryID is required");
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("CategoryName is required");

		}
	}
}
