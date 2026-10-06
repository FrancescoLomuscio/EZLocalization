using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocalizedLine
{
    public SystemLanguage language;
    public string text;
}

[Serializable]
public class LocalizationTextEntry
{
    public string id;
    public List<LocalizedLine> lines = new();
}

[Serializable]
public class LocalizationTextDatabase
{
    public List<LocalizationTextEntry> entries = new();
}

[Serializable]
public class LocalizedAudio
{
    public SystemLanguage language;
    public string clip_path;
}

[Serializable]
public class LocalizationAudioEntry
{
    public string id;
    public List<LocalizedAudio> clips = new();
}

[Serializable]
public class LocalizationAudioDatabase
{
    public List<LocalizationAudioEntry> entries = new();
}

[Serializable]
public class LocalizedImage
{
    public SystemLanguage language;
    public string sprite_path;
}

[Serializable]
public class LocalizationImageEntry
{
    public string id;
    public List<LocalizedImage> imgs = new();
}

[Serializable]
public class LocalizationImageDatabase
{
    public List<LocalizationImageEntry> entries = new();
}