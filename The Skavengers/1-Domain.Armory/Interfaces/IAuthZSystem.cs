
namespace _1_Domain.Armory.Interfaces
{
    public interface IAuthZSystem
    {
        public string InvalidAuthZMessage { get; }
        bool Authorize(string password);
    }
}
