using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processia.Prose.Application.Domain.Entities;

namespace Processia.Prose.Application.Interfaces;

public interface IPostRepository
{
    Task AddAsync(Post post, CancellationToken cancellationToken);
}
