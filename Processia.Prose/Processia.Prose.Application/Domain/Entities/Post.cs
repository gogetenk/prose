using Processia.Prose.Application.Domain.ValueObjects;

namespace Processia.Prose.Application.Domain.Entities;

public class Post
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public PostMetadata Metadata { get; private set; }

    public Post(Guid id, string title, string content, PostMetadata metadata)
    {
        Id = id;
        Title = title;
        Content = content;
        Metadata = metadata;
    }

    public void UpdateContent(string newContent)
    {
        // Business logic for content validation and update
        Content = newContent;
    }

    public void Schedule(DateTime publishDate)
    {
        // Business logic to schedule a post
        Metadata = Metadata with { PublishDate = publishDate };
    }
}
