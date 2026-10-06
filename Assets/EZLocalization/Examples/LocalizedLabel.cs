using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedLabel : LocalizedItem
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private string localizationId;
    
    protected override void Awake()
    {
        base.Awake();
        label = GetComponent<TextMeshProUGUI>();
    }

    protected override void OnChangeLanguage()
    {
        label.text = LocalizationLoader.Instance.GetLocalizedLine(localizationId, LanguageController.language);
    }
    
    private void Start()
    {
        OnChangeLanguage();
    }

    public void UpdateLabel(string id = "")
    {
        if(string.IsNullOrEmpty(id))
            label.text = LocalizationLoader.Instance.GetLocalizedLine(localizationId, LanguageController.language);
        else
            label.text = LocalizationLoader.Instance.GetLocalizedLine(id, LanguageController.language);
    }
}
