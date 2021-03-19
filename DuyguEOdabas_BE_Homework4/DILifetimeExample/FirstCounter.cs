namespace DILifetimeExample
{
    public class FirstCounter : IFirstCounter
    {
        private readonly ICounter counter;

        public FirstCounter(ICounter counter)
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
