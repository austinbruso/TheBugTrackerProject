using BugTrackerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBugTrackerProject.Models;

namespace TheBugTrackerProject.Services.Interfaces
{
    public interface IBTNotificationService
    {
        public Task AddNotificationAsync(Notification notification);

        public Task <List<Notification>> GetRecievedNotificationsAsync(string userId);

        public Task <List<Notification>> GetSentNotificationsAsync(string userId);

        public Task SendEmailNotificationByRoleAsync(Notification notification, int companyId, string role);

        public Task SendMembersEmailNotificationAsync(Notification notification, List<BTUser> members);

        public Task<bool> SendEmailNotificationAsync(Notification notification, string emailSubject);

    }
}
