using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    [SerializeField]
    private string _key;

    private TMP_Text _text;

    void Start()
    {
        _text = GetComponent<TMP_Text>();
        UpdateText();
    }

    public void UpdateText()
    {
        _text.text = LocalizationManager.Instance.GetText(_key);
    }
}