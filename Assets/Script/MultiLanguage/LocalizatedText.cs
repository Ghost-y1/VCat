using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    [SerializeField]
    private string _key;

    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        UpdateText();
    }

    public void UpdateText()
    {
        _text.text = LocalizationManager.Instance.GetText(_key);
    }
}