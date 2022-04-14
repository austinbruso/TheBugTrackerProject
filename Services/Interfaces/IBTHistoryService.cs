using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBugTrackerProject.Models;

namespace TheBugTrackerProject.Services.Interfaces
{
    public interface IBTHistoryService
    {
        Task AddHistoryAsync(Ticket oldTicket, Ticket newTicket, string userId);

        Task<List<TicketHistory>> GetProjectTicketHistoryAsync(int projectId, int companyId);

        Task<List<TicketHistory>> GetCompanyTicketHistories(int companyId);

    }
}
