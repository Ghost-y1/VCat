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

    Language currentLanguage = Language.Spanish;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadLanguage(currentLanguage);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        int savedLang = PlayerPrefs.GetInt("language", 0);
        LoadLanguage((Language)savedLang);
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
        if (texts.ContainsKey(key))
            return texts[key];
        return $"[?{key}?]";
    }
}

