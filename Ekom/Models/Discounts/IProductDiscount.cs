namespace Ekom.Core.Models
{
    public interface IProductDiscount : IDiscount
    {
        decimal StartOfRange { get; }
        decimal EndOfRange { get; }
        bool Disabled { get; }
    }
}
