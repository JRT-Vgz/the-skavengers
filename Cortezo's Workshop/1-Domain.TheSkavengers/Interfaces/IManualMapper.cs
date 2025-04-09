
namespace _1_Domain.TheSkavengers.Interfaces
{
    public interface IManualMapper<TInput, TOutput>
    {
        TOutput Map(TInput input);
    }
}
