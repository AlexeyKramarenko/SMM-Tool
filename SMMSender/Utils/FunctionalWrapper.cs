namespace SMMSender.Utils
{
    internal class FunctionalWrapper
    {
        public static void For(int times, Action action)
        {
            for (int i = 0; i < times; i++)
            {
                action();
            }
        }
    }
}
