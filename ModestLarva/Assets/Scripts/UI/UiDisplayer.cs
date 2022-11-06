using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiDisplayer : MonoBehaviour
{
    [SerializeField] private UiChannel m_UiChannel;
    [SerializeField] private TMP_Text m_Inventory;

    private void Awake()
    {
        m_UiChannel.OnChangeInventory += UpdateInventory;
    }

    private void OnDestroy()
    {
        m_UiChannel.OnChangeInventory -= UpdateInventory;
    }

    public void UpdateInventory(CharacterInventory inventory)
    {
        m_Inventory.text = inventory.Items();
    }
}