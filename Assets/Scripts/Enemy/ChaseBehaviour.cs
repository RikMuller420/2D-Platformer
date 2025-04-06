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
        float moveDirection = Mathf.Sign(_target.position.x - creature.position.x);

        if (_moveAviablilityChecker.IsAbleToMoveForward == false)
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
