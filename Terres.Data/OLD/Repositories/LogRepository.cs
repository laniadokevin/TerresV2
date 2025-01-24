using System;
using System.Collections.Generic;
using System.Text;
using Terres.Core.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using Terres.Data.Services;
using Terres.Core.Entities.Database;

namespace Terres.Data.OLD.Repositories
{
    public class LogRepository : GenericService<Log>, ILogRepository
    {
        private readonly JojmaDbContext _context;

        public LogRepository(JojmaDbContext context) : base(context)
        {
            _context = context;

        }

        public void SaveLog(Log log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges();
        }

    }
}