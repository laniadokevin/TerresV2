using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Terres.Core.Entities.Database;
using Terres.Core.Services;

namespace Terres.Core.Interfaces
{
    public interface ILogRepository:IGenericService<Log>
    {
        void SaveLog(Log log);

    }
}
