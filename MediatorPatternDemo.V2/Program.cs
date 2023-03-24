using MediatorPatternDemo.V2.Structural;

namespace MediatorPatternDemo.V2
{
    internal class Program
    {
        public static void Main()
        {
            Mediator mediator = new();

            /* var Friend1 = new Friend1();
            var Friend2 = new Friend2();

            mediator.Register(Friend1);
            mediator.Register(Friend2); */

            Friend1 Friend1 = mediator.CreateFriend<Friend1>();
            Friend2 Friend2 = mediator.CreateFriend<Friend2>();

            Friend1.Send($"Hello Word from Friend 1");
            Friend2.Send($"Hello Word from Friend 2");
        }
    }
}
