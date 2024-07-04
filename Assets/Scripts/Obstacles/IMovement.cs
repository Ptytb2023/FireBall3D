
namespace Obstacles
{
    public interface IMovement
    {
        public float Speed { get; }
        public void Move(float speed);
    }
}