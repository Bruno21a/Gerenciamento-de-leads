using AutoMapper;
using LeadsAPI.Data;
using LeadsAPI.Dtos;
using LeadsAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LeadsAPI.CQRS.Queries
{
    public class GetLeadByIdHandler : IRequestHandler<GetLeadByIdQuery, object>
    {
        private readonly LeadsDbContext _ctx;
        private readonly IMapper _mapper;

        public GetLeadByIdHandler(LeadsDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
        {
            var lead = await _ctx.Leads.FindAsync(new object[] { request.Id }, cancellationToken);
            if (lead == null) return null;

            if (lead.Status == LeadStatus.Accepted)
                return _mapper.Map<AcceptedLeadDto>(lead);

            return _mapper.Map<LeadListDto>(lead);
        }
    }
}