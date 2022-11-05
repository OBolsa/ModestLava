using UnityEngine;
using UnityEngine.Events;

public class ActionListener : MonoBehaviour
{
    [SerializeField] private ActionsListennerConfigs m_Configs;
    [SerializeField] private UnityEvent m_OnAction;

    private void Awake()
    {
        m_Configs.Channel.OnAction += DoAction;
    }

    private void OnDestroy()
    {
        m_Configs.Channel.OnAction -= DoAction;
    }

    public void DoAction(string actionName)
    {
        if (actionName != m_Configs.ActionName)
            return;

        m_OnAction?.Invoke();
    }

    [System.Serializable]
    public struct ActionsListennerConfigs
    {
        public string ActionName;
        public ActionChannel Channel;
    }
}