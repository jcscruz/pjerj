using Domain.Repositories;
using MediatR;

namespace Application.UseCases.UserOrigin.Queries.GetUserOriginById
{
    public sealed class GetUserOriginByIdHandler(IUserOriginRepository UserOriginRepository) : IRequestHandler<GetUserOriginByIdQuery, GetUserOriginByIdResponse>
    {
        Task<GetUserOriginByIdResponse> IRequestHandler<GetUserOriginByIdQuery, GetUserOriginByIdResponse>.Handle(GetUserOriginByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}