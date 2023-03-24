using MediatorPatternDemo.Structural;

namespace MediatorPatternDemo
{
    internal class Program
    {
        public static void Main()
        {
            Mediator mediator = new();

            FriendOne FriendOne = new(mediator);
            FriendTwo FriendTwo = new(mediator);

            mediator.FriendOne = FriendOne;
            mediator.FriendTwo = FriendTwo;

            FriendOne.Send($"Hello Word from {nameof(FriendOne)}");
            FriendTwo.Send($"Hello Word from {nameof(FriendTwo)}");
        }
    }
}
