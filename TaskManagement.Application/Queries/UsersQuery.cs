using MediatR;


namespace TaskManagement.Application.Queries
{
    public class UsersQuery : IRequest<List<Domain.User>> { }
}