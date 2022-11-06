using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrenghtUiDisplayer : MonoBehaviour
{
    [SerializeField] private Image m_Stars;
    [SerializeField] private CreatureStrenght m_Strenght;

    private void Start()
    {
        m_Stars.fillAmount = m_Strenght.Strenght / 3f;
    }
}