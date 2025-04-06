using UnityEngine;

public class ChaseBehaviour : IMoveBehaviour
{
    private MoveAviablilityChecker _moveAviablilityChecker;
    private Transform _target;

    public ChaseBehaviour(MoveAviablilityChecker moveAviablilityChecker)
    {
        _moveAviablilityChecker = moveAviablilityChecker;
    }

    public float GetMoveDirection(Transform creature)
    {
        float moveDirection;

        if (_target.position.x - creature.position.x > 0)
        {
            moveDirection = 1;
        }
        else
        {
            moveDirection = -1;
        }

        if (_moveAviablilityChecker.IsAbleToMoveForward(moveDirection) == false)
        {
            moveDirection = 0;
        }

        return moveDirection;
    }

    public void SetTargetToChase(Transform target)
    {
        _target = target;
    }
}
