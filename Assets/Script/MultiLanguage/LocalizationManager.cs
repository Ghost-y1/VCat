using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    English,
    Spanish,
    Chinese
}

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    private Dictionary<string, string> texts;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            int savedLang = PlayerPrefs.GetInt("language", 0);
            LoadLanguage((Language)savedLang);

        }
        else Destroy(gameObject);
    }

    void Start()
    {
 
    }

    public void LoadLanguage(Language language)
    {
        string fileName = GetFileName(language);

        TextAsset jsonFile = Resources.Load<TextAsset>("Languages/" + fileName);

        if (jsonFile != null)
        {
            texts = JsonUtility.FromJson<JsonReader>(jsonFile.text).ToDictionary();
        }
        else
        {
            Debug.LogError("Language file not found: " + fileName);
        }
    }


    private string GetFileName(Language language)
    {
        switch (language)
        {
            case Language.Spanish: return "SP";
            case Language.English: return "EN";
            case Language.Chinese: return "ZH";
            default: return "EN";
        }
    }

    public string GetText(string key)
    {
        if (texts == null)
        {
            Debug.LogWarning("Localization texts not loaded yet.");
            return $"[?{key}?]";
        }

        if (texts.ContainsKey(key))
            return texts[key];
        return $"[?{key}?]";
    }
}

