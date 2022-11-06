using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public string CurrentCharacterName;
    [SerializeField] private ActionChannel m_ActionChannel;
    [SerializeField] private UiChannel m_UiChannel;
    private List<CharacterController> _Characters = new List<CharacterController>();

    private void Awake()
    {
        m_ActionChannel.OnAction += SelectCharacter;
    }

    private void OnDestroy()
    {
        m_ActionChannel.OnAction -= SelectCharacter;
    }

    private void Start()
    {
        FillCharacters();
        SelectCharacter("Billionaire01");
    }

    public void SelectCharacter(string characterName)
    {
        foreach (CharacterController item in _Characters)
        {
            if(item.CharacterName != characterName)
            {
                item.enabled = false;
                item.InstigatorOff();
                continue;
            }

            CurrentCharacterName = characterName;
            StartCoroutine(item.DelayInstigator());
            m_UiChannel.RaiseInventory(item.Inventory);
            item.enabled = true;
        }
    }

    public CharacterController CharacterByName(string characterName)
    {
        CharacterController character = null;

        foreach (CharacterController item in _Characters)
        {
            if(item.name == characterName)
            {
                character = item; 
                break;
            }
        }

        return character;
    }

    private void FillCharacters()
    {
        CharacterController[] controller = FindObjectsOfType<CharacterController>();

        foreach (CharacterController character in controller)
        {
            _Characters.Add(character);
        }
    }
}