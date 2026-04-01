using MyTasksMentor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTasksMentor.Domain.Interfaces
{
    public interface IReportRepository
    {
        Task<List<Report>> GetByUserIdAsync(Guid userId);

        Task AddAsync(Report report);
    }
}
