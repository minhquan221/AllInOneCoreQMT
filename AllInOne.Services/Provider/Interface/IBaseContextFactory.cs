using AllInOne.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Services.Provider.Interface
{
    public interface IBaseContextFactory
    {
        BaseContext GetInstance();
    }
}
