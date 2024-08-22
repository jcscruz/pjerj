using MediatR;

namespace Application.UseCases.UserOrigin.Queries.GetAllUserOrigin
{
    public class GetAllUserOriginQueryHandler : IRequestHandler<GetAllUserOriginQuery, GetAllUserOriginResponse>
    {
        public Task<GetAllUserOriginResponse> Handle(GetAllUserOriginQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetAllUserOriginResponse());
        }
    }
}