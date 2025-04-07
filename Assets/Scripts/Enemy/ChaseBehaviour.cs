using UnityEngine;

public class ChaseBehaviour : IMoveBehaviour
{
    private MoveAviablilityChecker _moveAviablilityChecker;
    private Transform _target;
    private float _chaseSpeed;

    public ChaseBehaviour(MoveAviablilityChecker moveAviablilityChecker, float chaseSpeed)
    {
        _moveAviablilityChecker = moveAviablilityChecker;
        _chaseSpeed = chaseSpeed;
    }

    public void Move(CreatureMover creature)
    {
        float moveDirection = Mathf.Sign(_target.position.x - creature.transform.position.x);

        if (_moveAviablilityChecker.IsAbleToMoveForward == false)
        {
            moveDirection = 0;
        }

        float velocityX = moveDirection * _chaseSpeed;
        creature.MoveHorizontal(velocityX);
    }

    public void SetTargetToChase(Transform target)
    {
        _target = target;
    }
}
