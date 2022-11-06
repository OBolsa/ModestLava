using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/UI Channel", fileName = "Ui Channel")]
public class UiChannel : ScriptableObject
{
    public delegate void InventoryCallback(CharacterInventory inventory);
    public InventoryCallback OnChangeInventory;

    public void RaiseInventory(CharacterInventory inventory)
    {
        OnChangeInventory?.Invoke(inventory);
    }
}