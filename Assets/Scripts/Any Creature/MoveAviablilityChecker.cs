using UnityEngine;

public class MoveAviablilityChecker : MonoBehaviour
{
    [SerializeField] private LayerContactChecker _groundChecker;
    [SerializeField] private LayerContactChecker _wallChecker;

    public bool IsAbleToMoveForward { get; private set; }

    private void OnEnable()
    {
        _groundChecker.ConcatStateChanged += UpdateMoveAviablility;
        _wallChecker.ConcatStateChanged += UpdateMoveAviablility;
    }

    private void OnDisable()
    {
        _groundChecker.ConcatStateChanged -= UpdateMoveAviablility;
        _wallChecker.ConcatStateChanged -= UpdateMoveAviablility;

    }

    private void UpdateMoveAviablility()
    {
        IsAbleToMoveForward = _groundChecker.IsConcatWithLayer && (_wallChecker.IsConcatWithLayer == false);
    }
}
