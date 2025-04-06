using UnityEngine;

public class MoveAviablilityChecker : MonoBehaviour
{
    [SerializeField] private LayerContactChecker _groundChecker;
    [SerializeField] private LayerContactChecker _wallChecker;

    public bool IsAbleToMoveForward { get; private set; }

    private void OnEnable()
    {
        _groundChecker.GroundedStateChanged += UpdateMoveAviablility;
        _wallChecker.GroundedStateChanged += UpdateMoveAviablility;
    }

    private void OnDisable()
    {
        _groundChecker.GroundedStateChanged -= UpdateMoveAviablility;
        _wallChecker.GroundedStateChanged -= UpdateMoveAviablility;

    }

    private void UpdateMoveAviablility()
    {
        IsAbleToMoveForward = _groundChecker.IsGrounded && (_wallChecker.IsGrounded == false);
    }
}
