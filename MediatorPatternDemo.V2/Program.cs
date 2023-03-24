using MediatorPatternDemo.V2.Structural;

namespace MediatorPatternDemo.V2
{
    internal class Program
    {
        public static void Main()
        {
            Mediator mediator = new();

            /* FriendOne friendOne = new();
            FriendTwo friendTwo = new();

            mediator.Register(friendOne);
            mediator.Register(friendTwo); */

            FriendOne Friend1 = mediator.CreateFriend<FriendOne>();
            FriendTwo Friend2 = mediator.CreateFriend<FriendTwo>();

            Friend1.Send($"Hello Word from {nameof(FriendOne)}");
            Friend2.Send($"Hello Word from {nameof(FriendTwo)}");
        }
    }
}
