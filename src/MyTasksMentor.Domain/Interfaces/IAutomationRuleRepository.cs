using MyTasksMentor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTasksMentor.Domain.Interfaces
{
    public interface IAutomationRuleRepository
    {
        Task<List<AutomationRule>> GetByUserIdAsync(Guid userId);

        Task AddAsync(AutomationRule rule);

        Task UpdateAsync(AutomationRule rule);
    }
}
