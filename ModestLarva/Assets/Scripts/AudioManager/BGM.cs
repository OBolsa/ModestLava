using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] private AudioClip m_BMG;
    [SerializeField] private float m_Volume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterController character = collision.GetComponent<CharacterController>();

        if(character != null && AudioManager.instance.bgmSource.clip != m_BMG)
            AudioManager.instance.PlayBgm(m_BMG, m_Volume);
    }
}