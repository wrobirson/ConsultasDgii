using Octetus.ConsultasDgii.Core.Messages;
using System;

namespace Octetus.ConsultasDgii.Core.Interfaces
{
    public interface IDgiiQuery
    {
        DgiiQueryResponse Execute(DgiiQueryRequest request);
    }

}
