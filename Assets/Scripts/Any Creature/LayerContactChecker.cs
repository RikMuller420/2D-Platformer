using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LayerContactChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private int _layerContacts = 0;

    public event Action ConcatStateChanged;

    public bool IsConcatWithLayer { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _layer) != 0)
        {
            _layerContacts++;
            SetConcatState(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _layer) != 0)
        {
            _layerContacts--;

            if (_layerContacts <= 0)
            {
                _layerContacts = 0;
                SetConcatState(false);
            }
        }
    }

    private void SetConcatState(bool isConcat)
    {
        bool isConcatBuffer = IsConcatWithLayer;
        IsConcatWithLayer = isConcat;

        if (IsConcatWithLayer != isConcatBuffer)
        {
            ConcatStateChanged?.Invoke();
        }
    }
}
