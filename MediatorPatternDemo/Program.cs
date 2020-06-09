namespace MediatorPatternDemo
{
    using MediatorPatternDemo.Structural;
    using System;

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
            var mediator = new Mediator();
            var colleague1 = new Colleague1(mediator);
            var colleague2 = new Colleague2(mediator);

            mediator.Colleague1 = colleague1;
            mediator.Colleague2 = colleague2;

            colleague1.Send($"Hello Word from colleague 1");
            colleague2.Send($"Hello Word from colleague 2");
        }
    }
}
