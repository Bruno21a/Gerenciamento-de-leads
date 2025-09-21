using MediatR;
using LeadsAPI.Data;
using LeadsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LeadsAPI.CQRS.Commands
{
    public class UpdateLeadHandler : IRequestHandler<UpdateLeadCommand>
    {
        private readonly LeadsDbContext _ctx;

        public UpdateLeadHandler(LeadsDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _ctx.Leads.FindAsync(new object[] { request.Id }, cancellationToken);
            if (lead == null) throw new KeyNotFoundException("Lead not found");

            var dto = request.UpdateDto;
            lead.Update(dto.ContactFirstName, dto.ContactLastName, dto.Suburb, dto.Category,
                        dto.Description, dto.Price, dto.ContactEmail, dto.ContactPhone, lead.Status);

            await _ctx.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        Task IRequestHandler<UpdateLeadCommand>.Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
