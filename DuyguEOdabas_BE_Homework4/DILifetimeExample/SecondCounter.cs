namespace DILifetimeExample
{
    public class SecondCounter : ISecondCounter
    {
        private readonly ICounter counter;

        public SecondCounter(ICounter counter)
        {
            this.counter = counter;
        }
        public int IncrementAndGet()
        {
            counter.Increment();
            return counter.Get();
        }
    }
}
