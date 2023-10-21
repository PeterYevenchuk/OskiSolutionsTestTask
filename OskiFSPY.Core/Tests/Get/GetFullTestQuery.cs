using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OskiFSPY.Core.Tests.Get;

public class GetFullTestQuery : IRequest<FullTest>
{
    public int TestId { get; set; }
}
