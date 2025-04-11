
namespace _1_Domain.TheSkavengers.Interfaces
{
    public interface IPresenter<TInput, TOutput>
    {
        TOutput Present(TInput input);
    }
}
