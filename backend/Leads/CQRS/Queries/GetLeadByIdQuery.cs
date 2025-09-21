using MediatR;
using LeadsAPI.Dtos;

namespace LeadsAPI.CQRS.Queries
{
    public class GetLeadByIdQuery : IRequest<object>
    {
        public int Id { get; set; }
        public GetLeadByIdQuery(int id) { Id = id; }
    }
}