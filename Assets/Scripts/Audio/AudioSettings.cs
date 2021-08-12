using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = Tag, menuName = "Audio/AudioSettings")]
public class AudioSettings : ScriptableObject
{
    private const string Tag = nameof(AudioSettings);

    [SerializeField] private SfxInfo[] sfx;

    private readonly Dictionary<SfxType, SfxInfo> sfxMap = new Dictionary<SfxType, SfxInfo>();

    private void OnEnable()
    {
        FillMap();
    }

    private void OnValidate()
    {
        if (sfx == null)
            return;

        foreach (var sfxInfo in sfx)
        {
            sfxInfo.OnValidate();
        }
    }

    public AudioClip GetAudioClip(SfxType sfxType)
    {
        return sfxMap.ContainsKey(sfxType) ? sfxMap[sfxType].Clip : null;
    }
    
    public SfxInfo GetSfxInfo(SfxType sfxType)
    {
        return sfxMap.ContainsKey(sfxType) ? sfxMap[sfxType] : null;
    }

    private void FillMap()
    {
        sfxMap.Clear();
        
        if (sfx == null)
            return;

        foreach (var sfxInfo in sfx)
        {
            var type = sfxInfo.SfxType;

            if (!sfxMap.ContainsKey(type))
            {
                sfxMap.Add(type, sfxInfo);
            }
            else
            {
                Debug.LogError($"{Tag}, {nameof(FillMap)}: You can try add more than one clip for type '{type}'!");
            }
        }
    }
}