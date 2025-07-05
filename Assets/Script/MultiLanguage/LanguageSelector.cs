using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public void SetLanguage(int index)
    {
        Language selectedLanguage = (Language)index;

        LocalizationManager.Instance.LoadLanguage(selectedLanguage);

        foreach (var txt in FindObjectsOfType<LocalizedText>())
        {
            txt.UpdateText();
        }

        // Optional: Save preference
        PlayerPrefs.SetInt("language", index);
    }
}
