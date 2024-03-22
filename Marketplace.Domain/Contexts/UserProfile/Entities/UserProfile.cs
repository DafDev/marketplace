using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain.Contexts.UserProfile.Entities;
public class UserProfile : AggregateRoot, IAggregateRoot
{
    
    public string AggregateId => throw new NotImplementedException();

    protected override void EnsureValidState()
    {
        throw new NotImplementedException();
    }

    protected override void OnDomainEventRaised(DomainEvent domainEvent)
    {
        throw new NotImplementedException();
    }
}
