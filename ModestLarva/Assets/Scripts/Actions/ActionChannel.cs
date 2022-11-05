using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Action Channel")]
public class ActionChannel : ScriptableObject
{
    public delegate void ActionCallback(string actionName);
    public ActionCallback OnAction;

    public void RaiseAction(string actionName)
    {
        OnAction?.Invoke(actionName);
    }
}