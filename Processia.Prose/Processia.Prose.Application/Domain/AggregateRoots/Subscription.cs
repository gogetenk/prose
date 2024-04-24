using Processia.Prose.Application.Domain.ValueObjects;

namespace Processia.Prose.Application.Domain.AggregateRoots;

public class Subscription
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public SubscriptionPlan Plan { get; private set; }
    public DateTime StartedOn { get; }
    public DateTime? EndsOn { get; private set; }

    public Subscription(Guid id, Guid userId, SubscriptionPlan plan, DateTime startedOn, DateTime? endsOn)
    {
        Id = id;
        UserId = userId;
        Plan = plan;
        StartedOn = startedOn;
        EndsOn = endsOn;
    }

    public void UpgradePlan(SubscriptionPlan newPlan)
    {
        // Business logic to handle upgrading the subscription plan
        Plan = newPlan;
    }

    public void Cancel()
    {
        // Business logic to handle subscription cancellation
        EndsOn = DateTime.UtcNow;
    }
}
