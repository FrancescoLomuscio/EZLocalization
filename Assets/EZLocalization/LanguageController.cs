using System;
using UnityEngine;

public class LanguageController : MonoBehaviour
{
    public static SystemLanguage language = SystemLanguage.English;
    public static Action OnChangeLanguage;

    public static void ChangeLanguage(SystemLanguage lang)
    {
        language = lang;
        PlayerPrefs.SetInt("Language", (int)LanguageController.language);
        PlayerPrefs.Save();
        OnChangeLanguage?.Invoke();
    }

    void Awake()
    {
        LanguageController.language = (SystemLanguage)PlayerPrefs.GetInt("Language", (int)SystemLanguage.English);
    }
}
