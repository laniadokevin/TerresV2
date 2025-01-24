using System;
using System.Collections.Generic;
using System.Text;
using Terres.Core.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Azure.Core.HttpHeader;
using System.Net.Http;
using Terres.Data.Services;
using Terres.Core.Entities.Database;

namespace Terres.Data.OLD.Repositories
{
    public class UserRepository : GenericService<JojmaUser>, IUserRepository
    {
        private readonly JojmaDbContext _context;

        public UserRepository(JojmaDbContext context):base(context)
        {
            _context = context;
        }

        public bool emailExist(string username)
        {
            var user = _context.Users
                .Where(x => x.Email.ToLower() == username.ToLower())
                .FirstOrDefault();

            if (user != null)
                return true;
            else
                return false;
        }


    }
}

