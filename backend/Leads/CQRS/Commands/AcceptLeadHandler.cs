using AutoMapper;
using MediatR;
using LeadsAPI.Data;
using LeadsAPI.Dtos;
using LeadsAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LeadsAPI.CQRS.Commands
{
    public class AcceptLeadHandler : IRequestHandler<AcceptLeadCommand, AcceptedLeadDto>
    {
        private readonly LeadsDbContext _ctx;
        private readonly IEmailService _email;
        private readonly IMapper _mapper;
        private const string SalesEmail = "sales@test.com";

        public AcceptLeadHandler(LeadsDbContext ctx, IEmailService email, IMapper mapper)
        {
            _ctx = ctx;
            _email = email;
            _mapper = mapper;
        }

        public async Task<AcceptedLeadDto> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _ctx.Leads.FindAsync(new object[] { request.Id }, cancellationToken);
            if (lead == null) return null;

            lead.Accept();

            await _ctx.SaveChangesAsync(cancellationToken);

            await _email.SendAsync(SalesEmail, $"Lead {lead.Id} accepted", $"Lead {lead.Id} foi aceito. Preço final: {lead.Price}");

            return _mapper.Map<AcceptedLeadDto>(lead);
        }
    }
}
