using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    public string CurrentCharacterName;
    [SerializeField] private ActionChannel m_ActionChannel;
    [SerializeField] private UiChannel m_UiChannel;
    private List<CharacterController> _Characters = new List<CharacterController>();

    private void Awake()
    {
        instance = this;
        m_ActionChannel.OnAction += SelectCharacter;
    }

    private void OnDestroy()
    {
        m_ActionChannel.OnAction -= SelectCharacter;
    }

    private void Start()
    {
        FillCharacters();
        SelectCharacter("Karl");
    }

    public void SelectCharacter(string characterName)
    {
        foreach (CharacterController item in _Characters)
        {
            if(item.CharacterName != characterName)
            {
                item.enabled = false;
                item.InstigatorOff();
                if (item.CharacterName == "Karl")
                    item.gameObject.SetActive(false);
                continue;
            }

            CurrentCharacterName = characterName;
            StartCoroutine(item.DelayInstigator());
            m_UiChannel.RaiseInventory(item.Inventory);
            if (item.CharacterName == "Karl")
                item.gameObject.SetActive(true);
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

    public void BackToGhost()
    {
        int activeIndex = 0;
        int karlIndex = 0;

        for (int i = 0; i < _Characters.Count; i++)
        {
            if (_Characters[i].enabled)
            {
                activeIndex = i;
            }

            if(_Characters[i].CharacterName == "Karl")
            {
                karlIndex = i;
            }
        }

        _Characters[karlIndex].transform.position = _Characters[activeIndex].transform.position;

        SelectCharacter("Karl");
    }
}