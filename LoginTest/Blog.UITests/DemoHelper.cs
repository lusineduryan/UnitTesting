using System.Threading;

namespace Blog.UITests
{
    internal static class DemoHelper
    {
        public static void Pause(int secondsToPause = 5000)
        {
            Thread.Sleep(secondsToPause);
        }
    }
}
