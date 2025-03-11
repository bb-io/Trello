using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbird.Applications.Sdk.Common.Exceptions;

namespace Apps.Trello.Utils
{
    public static class ExecuteWithWrapper
    {
        public static async Task ExecuteRefreshWithWrapper(Func<Task> refreshFunc)
        {
            try
            {
                await refreshFunc();
            }
            catch (Exception ex)
            {
                throw new PluginApplicationException(ex.Message);
            }
        }
    }
}
