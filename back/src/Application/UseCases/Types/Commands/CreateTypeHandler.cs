using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Types.Commands
{
    public sealed class CreateTypeHandler : IRequestHandler<CreateTypeCommand, CreateTypeResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public CreateTypeHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<CreateTypeResponse> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _typeRepository.AddAsync(request.ToTypeEntity());
            return new CreateTypeResponse(result);
        }
    }
}