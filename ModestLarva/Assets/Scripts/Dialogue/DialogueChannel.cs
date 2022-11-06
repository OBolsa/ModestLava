using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialogue Channel", fileName = "Dialogue Channel")]
public class DialogueChannel : ScriptableObject
{
    public delegate void DialogueCallback(Dialogue dialogue);
    public DialogueCallback OnOpenDialogue;
    public DialogueCallback OnCloseDialogue;

    public void RaiseOpenDialogue(Dialogue dialogue)
    {
        OnOpenDialogue?.Invoke(dialogue);
    }

    public void RaiseCloseDialogue(Dialogue dialogue)
    {
        OnCloseDialogue?.Invoke(dialogue);
    }
}