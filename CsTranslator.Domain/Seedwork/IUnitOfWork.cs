using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsTranslator.Domain.Seedwork
{
	public interface IUnitOfWork : IDisposable
	{
		Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
