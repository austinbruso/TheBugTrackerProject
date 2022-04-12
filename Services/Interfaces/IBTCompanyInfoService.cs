using BugTrackerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBugTrackerProject.Models;

namespace TheBugTrackerProject.Services.Interfaces
{
   public interface IBTCompanyInfoService
    {
        public Task<Company> GetCompanyInfoById(int? companyId);
        public Task<List<BTUser>> GetAllMembersAsync(int companyId);
        public Task<List<Project>> GetAllProjectsAsync(int companyId);
        public Task<List<Ticket>> GetAllTicketsAsync(int companyId);

    }
}
