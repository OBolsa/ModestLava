using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] private UnityEvent m_OnInteract;

    public void DoInteraction()
    {
        m_OnInteract?.Invoke();
    }
}
