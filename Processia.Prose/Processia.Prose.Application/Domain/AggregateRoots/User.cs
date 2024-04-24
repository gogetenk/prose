using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Processia.Prose.Application.Domain.Entities;
using Processia.Prose.Application.Domain.ValueObjects;

namespace Processia.Prose.Application.Domain.AggregateRoots;

public class User : AggregateRoot
{
    public string Email { get; }
    public PersonalityTestResult PersonalityTestResult { get; private set; }
    public List<Post> Posts { get; }
    public Subscription Subscription { get; private set; }

    public User(Guid id, string email)
    {
        Id = id;
        Email = email;
        Posts = new List<Post>();
    }

    public void UpdatePersonalityTestResult(PersonalityTestResult newResult)
    {
        // Add business logic to validate the result before setting it
        PersonalityTestResult = newResult;
    }

    public void AddPost(Post post)
    {
        // Add business logic to ensure only valid posts are added
        Posts.Add(post);
    }

    public void Subscribe(SubscriptionPlan plan)
    {
        // Business logic to initialize a subscription
        Subscription = new Subscription(Guid.NewGuid(), Id, plan, DateTime.UtcNow, null);
    }
}
