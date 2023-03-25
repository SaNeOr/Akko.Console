using System;
using MagicOnion;

namespace Akko.Framework.API.Logger
{
    public interface ILogger : IService<ILogger>
    {
        public static Action<string> onRecLog;

        UnaryResult Info(string message);
        UnaryResult Warn(string message);
        UnaryResult Error(string message);
    }
}
