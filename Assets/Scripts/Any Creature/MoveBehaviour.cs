public abstract class MoveBehaviour
{
    protected CreatureMover Mover;
    protected float Speed;

    public MoveBehaviour(CreatureMover mover, float speed)
    {
        Mover = mover;
        Speed = speed;
    }

    public abstract void Move();
}
