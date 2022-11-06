using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private string m_InteractorName;
    [SerializeField] private GameObject m_Door;
    [SerializeField] private UnityEvent m_OnEnterInArea;
    [SerializeField] private UnityEvent m_OnExitInArea;

    private CharacterController _Character;
    private bool canOpenDoor = true;

    public void SetDoor(bool open)
    {
        if (!canOpenDoor)
            return;

        Debug.Log("Tentando abrir a porta com... " + _Character.CharacterName);
        if(_Character != null && _Character.CharacterName == m_InteractorName)
        {
            m_Door.SetActive(open);
            Debug.Log("Abri a porta!");
            canOpenDoor = false;
            return;
        }
        Debug.Log("N consigo abrir a porta com ele...");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _Character = collision.GetComponent<CharacterController>();

        if (canOpenDoor)
        {
            m_OnEnterInArea?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _Character = null;

        if (canOpenDoor)
        {
            m_OnExitInArea?.Invoke();
        }
    }
}
