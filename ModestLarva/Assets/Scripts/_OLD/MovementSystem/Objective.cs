using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType
{
    Enemy,
    Buff,
    Scene
}

public class Objective : MonoBehaviour
{
    [SerializeField] private ObjectiveType m_Type;
    public ObjectiveType Type => m_Type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
