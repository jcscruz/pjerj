using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Types.Queries.GetTypeById
{
    public sealed class GetTypeByIdHandler : IRequestHandler<GetTypeByIdQuery, GetTypeByIdResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public GetTypeByIdHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<GetTypeByIdResponse> Handle(GetTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _typeRepository.GetByIdAsync(request.TypeId);
            return new GetTypeByIdResponse(result);
        }
    }
}