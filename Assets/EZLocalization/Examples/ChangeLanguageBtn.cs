using UnityEngine;

public class ChangeLanguageBtn : MonoBehaviour
{
    public SystemLanguage language = SystemLanguage.English;
    
    public void ChangeLanguage()
    {
        LanguageController.ChangeLanguage(language);
    }
}
