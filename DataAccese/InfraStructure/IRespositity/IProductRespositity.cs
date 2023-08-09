using AppModel;
using DataAccese.IRespositity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccese.InfraStructure.IRespositity
{
    public interface IProductRespositity : IRespositity<Product>
    {
        void Update(Product product);
    }
}
