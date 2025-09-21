using AutoMapper;
using MediatR;
using LeadsAPI.Data;
using LeadsAPI.Dtos;
using LeadsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LeadsAPI.CQRS.Commands
{
    public class CreateLeadHandler : IRequestHandler<CreateLeadCommand, LeadListDto>
    {
        private readonly LeadsDbContext _ctx;
        private readonly IMapper _mapper;
        public CreateLeadHandler(LeadsDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<LeadListDto> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var dto = request.CreateDto;
            var lead = Lead.Create(dto.ContactFirstName, dto.ContactLastName, dto.Suburb, dto.Category,
                dto.Description, dto.Price, dto.ContactEmail, dto.ContactPhone);

            _ctx.Leads.Add(lead);
            await _ctx.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LeadListDto>(lead);
        }
    }
}