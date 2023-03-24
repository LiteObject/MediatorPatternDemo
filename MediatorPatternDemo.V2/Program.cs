using MediatorPatternDemo.V2.Structural;

namespace MediatorPatternDemo.V2
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

            /* var colleague1 = new Colleague1();
            var colleague2 = new Colleague2();

            mediator.Register(colleague1);
            mediator.Register(colleague2); */

            Colleague1 colleague1 = mediator.CreateColleague<Colleague1>();
            Colleague2 colleague2 = mediator.CreateColleague<Colleague2>();

            colleague1.Send($"Hello Word from colleague 1");
            colleague2.Send($"Hello Word from colleague 2");
        }
    }
}
