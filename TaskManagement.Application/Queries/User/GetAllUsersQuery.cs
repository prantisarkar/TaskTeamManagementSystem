using MediatR;


namespace TaskManagement.Application.Queries.User
{
    public class GetAllUsersQuery : IRequest<List<Domain.User>> { }
}