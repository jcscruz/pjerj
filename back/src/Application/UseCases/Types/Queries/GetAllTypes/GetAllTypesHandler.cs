using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Types.Queries.GetAllTypes
{
    public sealed class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, GetAllTypesResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public GetAllTypesHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<GetAllTypesResponse> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _typeRepository.GetAllAsync();
            return new GetAllTypesResponse(result);
        }
    }
}