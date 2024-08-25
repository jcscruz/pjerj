using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Types.Queries.GetTypeByOrigin
{
    public sealed class GetTypeByOriginHandler : IRequestHandler<GetTypeByOriginQuery, GetTypeByOriginResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public GetTypeByOriginHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<GetTypeByOriginResponse> Handle(GetTypeByOriginQuery request, CancellationToken cancellationToken)
        {
            var result = await _typeRepository.GetByOriginAsync(request.Origin);
            return new GetTypeByOriginResponse(result);
        }
    }
}