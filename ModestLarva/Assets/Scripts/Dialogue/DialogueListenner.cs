using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueListenner : MonoBehaviour
{
    [SerializeField] private DialogueChannel m_DialogueChannel;
    [SerializeField] private Dialogue m_Dialogue;
    [SerializeField] private DialogueBox m_DialogueBox;

    private void Awake()
    {
        m_DialogueChannel.OnOpenDialogue += StartDialogue;
        m_DialogueChannel.OnCloseDialogue += CloseDialogue;
    }

    private void OnDestroy()
    {
        m_DialogueChannel.OnOpenDialogue -= StartDialogue;
        m_DialogueChannel.OnCloseDialogue -= CloseDialogue;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if(dialogue == m_Dialogue)
        {
            m_DialogueBox.gameObject.SetActive(true);
            StartCoroutine(m_DialogueBox.StartDialogue(m_Dialogue));
        }
    }

    public void CloseDialogue(Dialogue dialogue)
    {
        if (dialogue == m_Dialogue)
        {
            m_DialogueBox.gameObject.SetActive(false);
            StopAllCoroutines();
            m_DialogueChannel.RaiseCloseDialogue(dialogue);
        }
    }
}