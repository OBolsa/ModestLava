using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private DialogueChannel m_Channel;
    public TMP_Text m_DialogueText;
    private Dialogue m_Dialogue;

    public IEnumerator StartDialogue(Dialogue setDialogue)
    {
        m_Dialogue = setDialogue;

        int lineIndex = 0;
        int index = 0;

        while(lineIndex < m_Dialogue.Line.Length)
        {
            m_DialogueText.text = m_Dialogue.Line[lineIndex].Text[index].Text;

            index++;

            if(index >= m_Dialogue.Line[lineIndex].Text.Length)
            {
                index = 0;
                lineIndex++;
            }

            if (lineIndex >= m_Dialogue.Line.Length)
                yield break;
            else
                yield return new WaitForSeconds(m_Dialogue.Line[lineIndex].Text[index].TimeInThisText);
        }

        m_Channel.RaiseCloseDialogue(m_Dialogue);
    }
}