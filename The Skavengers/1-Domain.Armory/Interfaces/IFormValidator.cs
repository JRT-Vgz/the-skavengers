
namespace _1_Domain.Armory.Interfaces
{
    public interface IFormValidator<TDto>
    {
        public string Error { get; set; }
        bool Validate(TDto dto);
    }
}
