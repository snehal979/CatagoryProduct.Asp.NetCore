using AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccese.InfraStructure.IRespositity
{
    public interface IUnityOfWork
    {
        void Save();
       
        IProductRespositity ProductRespositity { get; }
        ICategoryRespositity CategoryRespositity { get; }
    }
}
