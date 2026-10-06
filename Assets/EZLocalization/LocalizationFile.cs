using System.IO;
using UnityEngine;
public static class LocalizationTextFile
{
    public static string Path => Application.dataPath + "/Resources/Localization/" + Name + ".json";
    public static string Name => "localization_text";

    public static LocalizationTextDatabase Load()
    {
#if UNITY_EDITOR
        if (!File.Exists(Path))
            return new LocalizationTextDatabase();

        return JsonUtility.FromJson<LocalizationTextDatabase>(File.ReadAllText(Path));
#else
        TextAsset jsonFile = Resources.Load<TextAsset>("Localization/" + Name);
        if (jsonFile == null)
            return new LocalizationTextDatabase();
        return JsonUtility.FromJson<LocalizationTextDatabase>(jsonFile.text);
#endif
    }

    public static void Save(LocalizationTextDatabase db)
    {
        string directory = System.IO.Path.GetDirectoryName(Path); 
        if (!string.IsNullOrEmpty(directory)) 
        { 
            Directory.CreateDirectory(directory); 
        }
        File.WriteAllText(Path, JsonUtility.ToJson(db, true));

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}

public static class LocalizationAudioFile
{
    public static string Path => Application.dataPath + "/Resources/Localization/" + Name + ".json";
    public static string Name => "localization_audio";

    public static LocalizationAudioDatabase Load()
    {
#if UNITY_EDITOR
        if (!File.Exists(Path))
            return new LocalizationAudioDatabase();

        return JsonUtility.FromJson<LocalizationAudioDatabase>(File.ReadAllText(Path));
#else
        TextAsset jsonFile = Resources.Load<TextAsset>("Localization/" + Name);
        if (jsonFile == null)
            return new LocalizationAudioDatabase();
        return JsonUtility.FromJson<LocalizationAudioDatabase>(jsonFile.text);
#endif
    }

    public static void Save(LocalizationAudioDatabase db)
    {
        string directory = System.IO.Path.GetDirectoryName(Path); 
        if (!string.IsNullOrEmpty(directory)) 
        { 
            Directory.CreateDirectory(directory); 
        }
        File.WriteAllText(Path, JsonUtility.ToJson(db, true));

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}

public static class LocalizationImageFile
{
    public static string Path => Application.dataPath + "/Resources/Localization/" + Name + ".json";
    public static string Name => "localization_img";

    public static LocalizationImageDatabase Load()
    {
#if UNITY_EDITOR
        if (!File.Exists(Path))
            return new LocalizationImageDatabase();

        return JsonUtility.FromJson<LocalizationImageDatabase>(File.ReadAllText(Path));
#else
        TextAsset jsonFile = Resources.Load<TextAsset>("Localization/" + Name);
        if (jsonFile == null)
            return new LocalizationImageDatabase();
        return JsonUtility.FromJson<LocalizationImageDatabase>(jsonFile.text);
#endif
    }

    public static void Save(LocalizationImageDatabase db)
    {
        string directory = System.IO.Path.GetDirectoryName(Path); 
        if (!string.IsNullOrEmpty(directory)) 
        { 
            Directory.CreateDirectory(directory); 
        }
        File.WriteAllText(Path, JsonUtility.ToJson(db, true));

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}