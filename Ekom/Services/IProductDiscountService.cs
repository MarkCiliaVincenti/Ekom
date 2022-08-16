using Ekom.Models;

namespace Ekom.Interfaces
{
    public interface IProductDiscountService
    {
        IProductDiscount GetProductDiscount(string path, string storeAlias, string inputPrice, string[] categories = null);
    }
}
