using System.Linq;
using UnityEngine;

public class LocalizationLoader : MonoBehaviour
{
    private LocalizationTextDatabase textDatabase;
    private LocalizationAudioDatabase audioDatabase;
    private LocalizationImageDatabase imgDatabase;
    public static LocalizationLoader Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Load();
        DontDestroyOnLoad(gameObject);
    }

    public void Load()
    {
        textDatabase = LocalizationTextFile.Load();
        audioDatabase = LocalizationAudioFile.Load();
        imgDatabase = LocalizationImageFile.Load();
    }

    public string GetLocalizedLine(string id, SystemLanguage language)
    {
        var entry = textDatabase.entries.FirstOrDefault(e => e.id == id);

        if (entry == null)
            return id;

        var line = entry.lines.FirstOrDefault(l => l.language == language);

        if (line != null)
            return line.text;

        // fallback inglese
        var fallback = entry.lines.FirstOrDefault(l => l.language == SystemLanguage.English);

        return fallback != null ? fallback.text : $"[No text: {id}]";
    }

    public AudioClip GetLocalizedAudio(string id, SystemLanguage language)
    {
        var entry = audioDatabase.entries.FirstOrDefault(e => e.id == id);

        if (entry == null)
            return null;

        var line = entry.clips.FirstOrDefault(l => l.language == language);

        if (line != null)
            return Resources.Load<AudioClip>(line.clip_path);

        // fallback inglese
        var fallback = entry.clips.FirstOrDefault(l => l.language == SystemLanguage.English);

        return fallback != null ? Resources.Load<AudioClip>(fallback.clip_path) : null;
    }

    public Sprite GetLocalizedImage(string id, SystemLanguage language)
    {
        var entry = imgDatabase.entries.FirstOrDefault(e => e.id == id);

        if (entry == null)
            return null;

        var line = entry.imgs.FirstOrDefault(l => l.language == language);

        if (line != null)
            return Resources.Load<Sprite>(line.sprite_path);

        // fallback inglese
        var fallback = entry.imgs.FirstOrDefault(l => l.language == SystemLanguage.English);

        return fallback != null ? Resources.Load<Sprite>(fallback.sprite_path) : null;
    }
}
