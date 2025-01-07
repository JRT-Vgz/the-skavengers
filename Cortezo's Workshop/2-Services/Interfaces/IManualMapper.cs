
namespace _2___Servicios.Interfaces
{
    public interface IManualMapper<TInput, TOutput>
    {
        TOutput Map(TInput input);
    }
}
