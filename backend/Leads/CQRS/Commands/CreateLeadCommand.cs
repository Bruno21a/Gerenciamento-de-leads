using MediatR;
using LeadsAPI.Dtos;

namespace LeadsAPI.CQRS.Commands
{
    public class CreateLeadCommand : IRequest<LeadListDto>
    {
        public LeadCreateDto CreateDto { get; }
        public CreateLeadCommand(LeadCreateDto dto) { CreateDto = dto; }
    }
}