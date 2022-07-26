namespace SMMSender.Utils
{
    public static class FunctionalExtensions
    {

        private static bool OnConditionExecute(Action doSomething)
        {
            doSomething();
            return true;
        }

        //This is executed when condition == true
        public static bool Then(this bool condition, Action doSomething) =>
             (condition) && OnConditionExecute(doSomething);


        //This is executed when condition == false
        public static bool Else(this bool condition, Action doSomething) =>
             (!condition) && OnConditionExecute(doSomething);


        public static void Use<T>(this T item, Action<T> action) where T : IDisposable
        {
            using (item)
            {
                action(item);
            }
        }

    }
}
