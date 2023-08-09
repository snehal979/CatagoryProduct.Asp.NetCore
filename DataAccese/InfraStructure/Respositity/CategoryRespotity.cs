using AppModel;
using DataAccese.Data;
using DataAccese.InfraStructure.IRespositity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccese.InfraStructure.Respositity
{
    public class CategoryRespotity : Respositity<Category> , ICategoryRespositity
    {
        private AppDbContext _context;
        public CategoryRespotity(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var data = _context.Categories.FirstOrDefault(x=>x.Id== category.Id);
            if (data != null)
            {
                data.Name = category.Name;
                data.Price =category.Price;
                data.CreatedDate=category.CreatedDate;
                
            }
           
        }
    }
}
