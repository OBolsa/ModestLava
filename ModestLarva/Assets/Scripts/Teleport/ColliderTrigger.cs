using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField] private string Tag;
    [SerializeField] private UnityEvent OnTirggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tag))
        {
            OnTirggerEnter?.Invoke();
        }
    }
}
