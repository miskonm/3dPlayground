using System;
using UnityEngine;

[Serializable]
public class SfxInfo
{
    [HideInInspector]
    [SerializeField] private string name;
    public SfxType SfxType;
    public AudioClip Clip;
    public float Volume = 1;
    public float Pitch = 1;

    public void OnValidate()
    {
        name = SfxType.ToString();
    }
}
