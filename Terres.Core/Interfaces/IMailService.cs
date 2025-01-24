using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Terres.Core.Entities.Generic;

namespace Terres.Core.Interfaces
{
    public interface IMailService
	{
		Task<bool> SendAsync(MailData mailData, CancellationToken ct);

	}

}