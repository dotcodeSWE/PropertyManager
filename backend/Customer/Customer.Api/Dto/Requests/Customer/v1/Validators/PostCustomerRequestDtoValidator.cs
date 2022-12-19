using FluentValidation;

namespace Customer.Api.Dto.Requests.Customer.v1.Validators
{
    public class PostCustomerRequestDtoValidator : AbstractValidator<PostCustomerRequestDto>
    {
        public PostCustomerRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty();
        }
    }
}
