using System.Collections.Generic;

[System.Serializable]
public class LanguageData
{
    public List<ItemText> items;

    public Dictionary<string, string> ToDictionary()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (var item in items)
        {
            dict[item.key] = item.value;
        }
        return dict;
    }
}

[System.Serializable]
public class ItemText
{
    public string key;
    public string value;
}
