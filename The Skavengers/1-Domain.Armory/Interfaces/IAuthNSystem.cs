
namespace _1_Domain.Armory.Interfaces
{
    public interface IAuthNSystem
    {
        public string InvalidAuthNMessage { get; }
        bool Authorize(string password);
    }
}
