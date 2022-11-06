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
    [TextArea(1,5)] public string[] Text;
}