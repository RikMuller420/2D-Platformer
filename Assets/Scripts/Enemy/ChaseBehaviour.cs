using UnityEngine;

public class ChaseBehaviour : IMoveBehaviour
{
    private MoveAviablilityChecker _groundChecker;
    private Transform _target;

    public ChaseBehaviour(MoveAviablilityChecker groundChecker)
    {
        _groundChecker = groundChecker;
    }

    public Direction GetMoveDirection(Transform creature)
    {
        Direction moveDirection;

        if (_target.position.x - creature.position.x > 0)
        {
            moveDirection = Direction.Right;
        }
        else
        {
            moveDirection = Direction.Left;
        }

        if (_groundChecker.IsAbleToMoveForward(moveDirection) == false)
        {
            moveDirection = Direction.None;
        }

        return moveDirection;
    }

    public void SetTargetToChase(Transform target)
    {
        _target = target;
    }
}
