using Marketplace.Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain.Contexts.UserProfile.Events;
public class UserDisplayNameUpdated(Guid userId, string displayName) : DomainEvent(userId)
{
    public string DisplayName { get; set; } = displayName;
}
