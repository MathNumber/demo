namespace Bai1
{
    public delegate T SampleDelegate<T>(T a, T b);
    class Operations
    {
        public T Add<T>(T a, T b)
        {
            return (dynamic)a + (dynamic)b;
        }
        public T Sub<T>(T a, T b)
        {
            return (dynamic)a - (dynamic)b;
        }
        public T Mul<T>(T a, T b)
        {
            return (dynamic)a * (dynamic)b;
        }
        public T Div<T>(T a, T b)
        {
            return (dynamic)a / (dynamic)b;
        }

        public static void Main(string[] args)
        {
            Operations sample = new Operations();
            SampleDelegate<int> sampleDelegate = sample.Add;
            sampleDelegate += sample.Sub;
            sampleDelegate += sample.Mul;
            sampleDelegate += sample.Div;

            int result = 0;
            foreach (SampleDelegate<int> del in sampleDelegate.GetInvocationList())
            {
                result = del(10, 20);
                Console.WriteLine("Result: " + result);
            }
        }

    }
}