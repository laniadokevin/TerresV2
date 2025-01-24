using System;
using System.Collections.Generic;
using System.Text;
using Terres.Core.Entities.Database;
using Terres.Core.Services;

namespace Terres.Core.Interfaces
{
    public interface IUserRepository:IGenericService<JojmaUser>
	{
		bool emailExist(string username);

	}
}
