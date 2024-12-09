
namespace _2___Servicios.Exceptions
{
    public class NotEnoughFundsException : Exception
    {
        public NotEnoughFundsException() : base("No hay suficientes fondos en la caja fuerte.") { }
    }
}
