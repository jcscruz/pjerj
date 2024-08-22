using MediatR;

namespace Application.UseCases.UserOrigin.Commands.UpdateUserOrigin;

public sealed record UpdateUserOriginCommand : IRequest<UpdateUserOriginResponse>;