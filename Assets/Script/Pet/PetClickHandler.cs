using UnityEngine;
using UnityEngine.EventSystems;

public class PetClickHandler : MonoBehaviour, IPointerClickHandler
{
    public GameObject interactionPanel;
    public GameObject interactionBackground;
    private WindowTransparent windowTransparent;
    private bool isActive = false;

    void Start()
    {
        windowTransparent = FindObjectOfType<WindowTransparent>();
        interactionPanel?.SetActive(false);
        interactionBackground?.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("🐶 点击了宠物");

        if (isActive) return; 

        isActive = true;

        interactionPanel?.SetActive(true);
        interactionBackground?.SetActive(true);

        windowTransparent?.DisableColorKey();
    }

    public void CloseInteraction()
    {
        Debug.Log("🚪 关闭交互");

        isActive = false;

        interactionPanel?.SetActive(false);
        interactionBackground?.SetActive(false);

        windowTransparent?.EnableColorKey();

    }
}