using MediatR;
using LeadsAPI.Dtos;
using System.Collections.Generic;

namespace LeadsAPI.CQRS.Queries
{
    public class GetAcceptedLeadsQuery : IRequest<IEnumerable<AcceptedLeadDto>> { }
}