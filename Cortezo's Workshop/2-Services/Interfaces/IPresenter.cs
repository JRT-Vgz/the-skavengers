
namespace _2___Servicios.Interfaces
{
    public interface IPresenter<TInput, TOutput>
    {
        TOutput Present(TInput input);
    }
}
