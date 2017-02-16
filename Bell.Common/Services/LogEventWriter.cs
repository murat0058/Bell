using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bell.Common.Models;

namespace Bell.Common.Services
{
    public interface ILogEventWriter
    {
        /// <summary>
        /// Creates a log event
        /// </summary>
        /// <param name="logEventRequest">The log event request</param>
        /// <returns>The fully created log event</returns>
        Task<LogEvent> CreateAsync(ILogEventRequest logEventRequest);

        /// <summary>
        /// Creates a collection of log events
        /// </summary>
        /// <param name="logEventRequests">The log event requests</param>
        Task BatchCreateAsync(IList<ILogEventRequest> logEventRequests);
    }

    public class LogEventWriter : ILogEventWriter
    {
        public Task<LogEvent> CreateAsync(ILogEventRequest logEventRequest)
        {
            throw new NotImplementedException();
        }
    
        public Task BatchCreateAsync(IList<ILogEventRequest> logEventRequests)
        {
            throw new NotImplementedException();
        }
    }
}
