namespace Processia.Prose.Application.Domain.ValueObjects;

public record PostMetadata(DateTime? PublishDate, string LeadMagnet, PostLength Length);

public enum PostLength
{
    Short,
    Medium,
    Long
}
