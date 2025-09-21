using AutoMapper;
using LeadsAPI.Data;
using LeadsAPI.Dtos;
using LeadsAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeadsAPI.CQRS.Queries
{
    public class GetAcceptedLeadsHandler : IRequestHandler<GetAcceptedLeadsQuery, IEnumerable<AcceptedLeadDto>>
    {
        private readonly LeadsDbContext _ctx;
        private readonly IMapper _mapper;

        public GetAcceptedLeadsHandler(LeadsDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AcceptedLeadDto>> Handle(GetAcceptedLeadsQuery request, CancellationToken cancellationToken)
        {
            var leads = await _ctx.Leads
                .Where(l => l.Status == LeadStatus.Accepted)
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<AcceptedLeadDto>>(leads);
        }
    }
}