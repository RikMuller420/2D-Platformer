using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class CreatureMover : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D Rigidbody;

    public Direction MoveDirection { get; private set; }

    public void MoveHorizontal(float velocityX)
    {
        Rigidbody.linearVelocityX = velocityX;
        MoveDirection = GetDirection(velocityX);
    }

    private Direction GetDirection(float velocityX)
    {
        if (velocityX == 0)
        {
            return Direction.None;
        }
        
        return (Direction)Mathf.Sign(velocityX); ;
    }
}
