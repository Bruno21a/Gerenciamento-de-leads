using MediatR;

namespace LeadsAPI.CQRS.Commands
{
    public class DeleteLeadCommand : IRequest
    {
        public int Id { get; }
        public DeleteLeadCommand(int id) { Id = id; }
    }
}
