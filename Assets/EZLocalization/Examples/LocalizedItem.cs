using System;
using UnityEngine;

public class LocalizedItem : MonoBehaviour
{
    [SerializeField] protected bool shouldUpdateOnLangChange = true;

    protected virtual void Awake()
    {
        if(shouldUpdateOnLangChange)
            LanguageController.OnChangeLanguage += OnChangeLanguage;
    }

    protected virtual void OnDestroy()
    {
        if(shouldUpdateOnLangChange)
            LanguageController.OnChangeLanguage -= OnChangeLanguage;
    }

    protected virtual void OnChangeLanguage(){

    }
}
