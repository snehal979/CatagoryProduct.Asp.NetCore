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
    public class UbityOfWork : IUnityOfWork
    {
        private AppDbContext _context;
        public ICategoryRespositity CategoryRespositity { get; private set; }
        public IProductRespositity ProductRespositity { get; private set; }
        public UbityOfWork(AppDbContext context) 
        {
            _context = context;
            CategoryRespositity = new CategoryRespotity(context);
            ProductRespositity = new ProductRespositity(context);
        }
      

        public void Save()
        {
            _context.SaveChanges();
        }

       
    }
}
