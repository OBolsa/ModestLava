using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private string m_CharacterName;
    [SerializeField] private float m_Speed = 5f;
    [SerializeField] private AnimNames m_AnimNames = new AnimNames();
    [SerializeField] private CharacterInventory m_Inventory = new CharacterInventory();
    public CharacterInventory Inventory => m_Inventory;
    public string CharacterName => m_CharacterName;

    [Header("Atributtes")]
    [SerializeField] private Rigidbody2D m_Rigidbody;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private ActionChannel m_ActionChannel;
    [SerializeField] private InteractionInstigator m_Instigator;

    [Header("Events")]
    [SerializeField] private UnityEvent m_OnSelect;

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = new Vector2(h, v);

        if (moveDir.magnitude > 0.1f)
            m_Rigidbody.velocity = moveDir.normalized * m_Speed;
        else
            m_Rigidbody.velocity = Vector2.zero;
    }

    public void InstigatorOff() => m_Instigator.enabled = false;

    public IEnumerator DelayInstigator()
    {
        yield return new WaitForSeconds(0.3f);

        m_Instigator.enabled = true;
    }
}

[System.Serializable]
public struct AnimNames
{
    public IdleAnims m_IdleAnims;
    public WalkAnims m_WalkAnims;
}

[System.Serializable]
public struct IdleAnims
{
    public string Clip_Norte;
    public string Clip_Leste;
    public string Clip_Oeste;
    public string Clip_Sul;
}

[System.Serializable]
public struct WalkAnims
{
    public string Clip_Norte;
    public string Clip_Leste;
    public string Clip_Oeste;
    public string Clip_Sul;
}

[System.Serializable]
public struct CharacterInventory
{
    public string[] Item;

    public string Items()
    {
        string inventory = "";

        for (int i = 0; i < Item.Length; i++)
        {
            inventory += Item[i] + "\n";
        }

        return inventory;
    }
}