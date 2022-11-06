using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] private UnityEvent m_OnInteract;
    [SerializeField] private UnityEvent m_OnInteractReturnToKarl;

    public void DoInteraction()
    {
        m_OnInteract?.Invoke();
    }

    public void DoGhostInteraction()
    {
        m_OnInteractReturnToKarl?.Invoke();
    }
}