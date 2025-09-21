using LeadsAPI.Dtos;
using MediatR;

namespace LeadsAPI.CQRS.Commands
{
    public class AcceptLeadCommand : IRequest<AcceptedLeadDto>
    {
        public int Id { get; }
        public AcceptLeadCommand(int id) { Id = id; }
    }
}
