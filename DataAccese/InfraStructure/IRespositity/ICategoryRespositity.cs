using AppModel;
using AppModel.ViewModel;
using DataAccese.IRespositity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccese.InfraStructure.IRespositity
{
    public interface ICategoryRespositity : IRespositity<Category>
    {
        
        void Update(Category category);

    }
}
