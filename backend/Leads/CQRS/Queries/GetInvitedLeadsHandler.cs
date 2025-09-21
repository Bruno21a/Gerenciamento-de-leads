using AutoMapper;
using MediatR;
using LeadsAPI.Data;
using LeadsAPI.Dtos;
using LeadsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeadsAPI.CQRS.Queries
{
    public class GetInvitedLeadsHandler : IRequestHandler<GetInvitedLeadsQuery, IEnumerable<LeadListDto>>
    {
        private readonly LeadsDbContext _ctx;
        private readonly IMapper _mapper;

        public GetInvitedLeadsHandler(LeadsDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeadListDto>> Handle(GetInvitedLeadsQuery request, CancellationToken cancellationToken)
        {
            var leads = await _ctx.Leads
                .Where(l => l.Status == LeadStatus.Invited)
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<LeadListDto>>(leads);
        }
    }
}