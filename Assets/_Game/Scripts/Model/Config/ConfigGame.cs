using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newConfigGame",menuName = "Game/ConfigGame" )]
public class ConfigGame:ScriptableObject
{
       [field: SerializeField] public List<int> ExperienceRequiredForNextLevel { get; private set; }
       [field: SerializeField] public List<IconVolume> IconVolumes{get; private set;}
       [field: SerializeField] public List<AudioVolume> AudioVolumes{get; private set;}
       
       [field: SerializeField] public List<FX> FxPrefabs{get; private set;}
       [field: SerializeField] public GameObject FlyTextPrefab{get; private set;}
}
public enum IconType
{ 
       Off, 
       On
}
public enum FxType
{ 
       Click, 
       ChangeAnimal
}

public enum AudioType
{ 
       Background, 
       Click,
       Change
}

[Serializable]
public class IconVolume
{
       [field: SerializeField] public IconType Type { get;  set; }
       [field: SerializeField] public Sprite Icon { get; private set; }
}

[Serializable]
public class AudioVolume
{
       [field: SerializeField] public AudioType Type { get;  set; }
       [field: SerializeField] public AudioClip Sound { get; private set; }
}
[Serializable]
public class FX
{
       [field: SerializeField] public FxType Type { get;  set; }
       [field: SerializeField] public GameObject PrefabParticle { get; private set; }
}

 
