
using FluentValidation;

namespace APISolution.BLL.DTOs.Validator
{
	public class CategoryCreateDTOValidator : AbstractValidator<CategoryCreateDTO>
	{
		public CategoryCreateDTOValidator()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name is required");
			RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("Category Name cannot be more than 50 characters");
		}
	}
}
