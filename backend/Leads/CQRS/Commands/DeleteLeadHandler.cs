using MediatR;
using LeadsAPI.Data;
using System.Threading;
using System.Threading.Tasks;

namespace LeadsAPI.CQRS.Commands
{
    public class DeleteLeadHandler : IRequestHandler<DeleteLeadCommand>
    {
        private readonly LeadsDbContext _ctx;
        public DeleteLeadHandler(LeadsDbContext ctx) { _ctx = ctx; }

        public async Task<Unit> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _ctx.Leads.FindAsync(new object[] { request.Id }, cancellationToken);
            if (lead == null) return Unit.Value;

            _ctx.Leads.Remove(lead);
            await _ctx.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteLeadCommand>.Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
