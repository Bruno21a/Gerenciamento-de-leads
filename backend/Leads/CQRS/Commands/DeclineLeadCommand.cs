using MediatR;

namespace LeadsAPI.CQRS.Commands
{
    public class DeclineLeadCommand : IRequest
    {
        public int Id { get; }
        public DeclineLeadCommand(int id) { Id = id; }
    }
}
