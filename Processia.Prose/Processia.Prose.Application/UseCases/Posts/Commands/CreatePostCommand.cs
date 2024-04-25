using MediatR;
using Processia.Prose.Application.Domain.Entities;
using Processia.Prose.Application.Domain.ValueObjects;
using Processia.Prose.Application.Interfaces;

namespace Processia.Prose.Application.UseCases.Posts.Commands;

public record CreatePostCommand(string Title, string Hook, DateTime PublishDate, string LeadMagnet, PostLength Length) : IRequest<Guid>
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post(
                Guid.NewGuid(),
                request.Title,
                string.Empty, // Initially, the content might be empty or generated elsewhere.
                new PostMetadata(request.PublishDate, request.LeadMagnet, request.Length)
            );

            await _postRepository.AddAsync(post, cancellationToken);

            return post.Id;
        }
    }
}
