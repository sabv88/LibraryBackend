
using System.Xml.Linq;

namespace LibraryApplication.Common.Exceptions
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException(string name, object key)
            : base($"Entity \"{name}\" ({key}) out of stock.") { }
    }
}
