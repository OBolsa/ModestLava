using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlowUpFoice : MonoBehaviour
{
    public float GrowthRate;
    private Volume m_Volume;
    private Bloom m_Bloom;

    private void Start()
    {
        m_Volume = GetComponent<Volume>();
        m_Volume.profile.TryGet(out m_Bloom);
    }

    private void Update()
    {
        m_Bloom.dirtIntensity.value += Time.deltaTime * GrowthRate;
    }
}
