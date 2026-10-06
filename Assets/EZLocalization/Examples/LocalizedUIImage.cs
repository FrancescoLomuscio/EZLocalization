using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LocalizedUIImage: LocalizedItem
{
    [SerializeField] private Image img;
    [SerializeField] private string localizationId;
    
    protected override void Awake()
    {
        base.Awake();
        img = GetComponent<Image>();
    }

    protected override void OnChangeLanguage()
    {
        img.sprite = LocalizationLoader.Instance.GetLocalizedImage(localizationId, LanguageController.language);
    }

    private void OnEnable()
    {
        OnChangeLanguage();
    }

    public void UpdateAudio(string id = "")
    {
        if(string.IsNullOrEmpty(id))
            img.sprite = LocalizationLoader.Instance.GetLocalizedImage(localizationId, LanguageController.language);
        else
            img.sprite = LocalizationLoader.Instance.GetLocalizedImage(id, LanguageController.language);
    }
}

