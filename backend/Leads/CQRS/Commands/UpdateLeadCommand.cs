using MediatR;
using LeadsAPI.Dtos;

namespace LeadsAPI.CQRS.Commands
{
    public class UpdateLeadCommand : IRequest
    {
        public int Id { get; }
        public LeadCreateDto UpdateDto { get; } 
        public UpdateLeadCommand(int id, LeadCreateDto dto) { Id = id; UpdateDto = dto; }
    }
}
