using FluentValidation;
using ECommerceSite.Models.DTOs;

namespace ECommerceSite.API.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .Length(6, 100).WithMessage("Password must be at least 6 characters");
        }
    }

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email must be valid");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .Length(6, 100).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required")
                .Length(2, 100).WithMessage("Full name must be between 2 and 100 characters");
        }
    }

    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .Length(3, 200).WithMessage("Product name must be between 3 and 200 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(10, 1000).WithMessage("Description must be between 10 and 1000 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative");
        }
    }

    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required")
                .Length(3, 100).WithMessage("Category name must be between 3 and 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(5, 500).WithMessage("Description must be between 5 and 500 characters");
        }
    }

    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.Items)
                .NotNull().WithMessage("Order items are required")
                .NotEmpty().WithMessage("Order must contain at least one item");

            RuleForEach(x => x.Items)
                .SetValidator(new OrderItemRequestDtoValidator());
        }
    }

    public class OrderItemRequestDtoValidator : AbstractValidator<OrderItemRequestDto>
    {
        public OrderItemRequestDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Product ID must be valid");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0")
                .LessThanOrEqualTo(1000).WithMessage("Quantity cannot exceed 1000");
        }
    }
}
