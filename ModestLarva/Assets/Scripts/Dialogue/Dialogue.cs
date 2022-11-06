using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialogue/Dialogue Node")]
public class Dialogue : ScriptableObject
{
    public DialogueLine[] Line;
}

[System.Serializable]
public struct DialogueLine
{
    public string DialogueTitle;
    public DialogueNode[] Text;
}

[System.Serializable]
public struct DialogueNode
{
    [TextArea(1, 5)] public string Text;
    public float TimeInThisText;
}