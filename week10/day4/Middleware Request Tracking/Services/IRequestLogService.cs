using Middleware_Request_Tracking.Models;
using System.Collections.Generic;


namespace Middleware_Request_Tracking.Services
{
    public interface IRequestLogService
    {
        void AddLog(RequestLog log);
        List<RequestLog> GetLogs();
    }
}
