using MediatorPatternDemo.Structural;

namespace MediatorPatternDemo
{
    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            Mediator mediator = new();
            Colleague1 colleague1 = new(mediator);
            Colleague2 colleague2 = new(mediator);

            mediator.Colleague1 = colleague1;
            mediator.Colleague2 = colleague2;

            colleague1.Send($"Hello Word from colleague 1");
            colleague2.Send($"Hello Word from colleague 2");
        }
    }
}
