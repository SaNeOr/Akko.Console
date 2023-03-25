using MagicOnion;
using System.Threading.Tasks;
using Akko.Framework.API.Logger;
using MagicOnion.Server;

namespace Akko.Framework.Impl.Logger
{
    public class Logger: ServiceBase<ILogger>, ILogger
    {

        public async UnaryResult Info(string message)
        {
            await Log(LogLevel.Information, message);
        }

        public async UnaryResult Warn(string message)
        {
            await Log(LogLevel.Warning, message);
        }

        public async UnaryResult Error(string message)
        {
            await Log(LogLevel.Error, message);
        }


        public async Task Log(LogLevel level, string message)
        {
            if(level == LogLevel.Information)
            {
                ILogger.onRecLog?.Invoke(message);
            }
        }
    }
}
