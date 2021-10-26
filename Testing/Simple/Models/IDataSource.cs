using System.Collections.Generic;

namespace Simple.Models
{
    public interface IDataSource
    {
        IEnumerable<Product> Products { get; }
    }
}