using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LocalizedAudioClip : LocalizedItem
{
    [SerializeField] private AudioSource source;
    [SerializeField] private string localizationId;
    
    protected override void Awake()
    {
        base.Awake();
        source = GetComponent<AudioSource>();
    }

    protected override void OnChangeLanguage()
    {
        source.clip = LocalizationLoader.Instance.GetLocalizedAudio(localizationId, LanguageController.language);
    }

    private void OnEnable()
    {
        OnChangeLanguage();
    }

    public void UpdateAudio(string id = "")
    {
        if(string.IsNullOrEmpty(id))
            source.clip = LocalizationLoader.Instance.GetLocalizedAudio(localizationId, LanguageController.language);
        else
            source.clip = LocalizationLoader.Instance.GetLocalizedAudio(id, LanguageController.language);
    }
}

