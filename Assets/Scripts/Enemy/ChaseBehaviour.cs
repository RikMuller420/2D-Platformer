using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyGroundChecker _groundChecker;

    private Transform _target;

    public Direction GetDirection()
    {
        Direction moveDirection;

        if (_target.position.x - transform.position.x > 0)
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
