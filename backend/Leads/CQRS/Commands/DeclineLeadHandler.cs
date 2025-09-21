using MediatR;
using LeadsAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LeadsAPI.CQRS.Commands
{
    public class DeclineLeadHandler : IRequestHandler<DeclineLeadCommand>
    {
        private readonly LeadsDbContext _ctx;
        public DeclineLeadHandler(LeadsDbContext ctx) { _ctx = ctx; }

        public async Task<Unit> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _ctx.Leads.FindAsync(new object[] { request.Id }, cancellationToken);
            if (lead == null) return Unit.Value;

            lead.Decline();
            await _ctx.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        Task IRequestHandler<DeclineLeadCommand>.Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
