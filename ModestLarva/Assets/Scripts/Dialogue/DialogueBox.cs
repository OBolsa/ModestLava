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
        int textIndex = -1;

        while (lineIndex < m_Dialogue.Line.Length)
        {
            textIndex++;

            if (textIndex >= m_Dialogue.Line[lineIndex].Text.Length)
            {
                textIndex = 0;
                lineIndex++;

                if(lineIndex >= m_Dialogue.Line.Length)
                {
                    m_Channel.RaiseCloseDialogue(m_Dialogue);
                    yield break;
                }
            }

            m_DialogueText.text = m_Dialogue.Line[lineIndex].Text[textIndex].Text;

            yield return new WaitForSeconds(m_Dialogue.Line[lineIndex].Text[textIndex].TimeInThisText);
        }
    }
}