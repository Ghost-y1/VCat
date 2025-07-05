using System.Collections.Generic;

[System.Serializable]
public class LanguageData
{
    List<ItemText> items;
    public Dictionary<string, string> ToDictionary()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (var item in items)
        {
            dict[item.KEY] = item.VALUE;
        }
        return dict;
    }
}

[System.Serializable]
public class ItemText
{
    public string KEY { get; private set; }
    public string VALUE { get; private set; }
}
