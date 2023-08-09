using AppModel;
using DataAccese.Data;
using DataAccese.InfraStructure.IRespositity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccese.InfraStructure.Respositity
{
    public class ProductRespositity : Respositity<Product>, IProductRespositity
    {
        private AppDbContext _context;
        public ProductRespositity(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var data = _context.Products.FirstOrDefault(x => x.Id== product.Id);
            if (data != null)
            {
                data.Name = product.Name;
                data.Price =product.Price;
               data.Description=product.Description;
                if(product.ImageUrl!= null)
                {
                    data.ImageUrl=data.ImageUrl;
                }

            }

        }
    
    }
}
