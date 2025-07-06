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
        Debug.Log("open menu");

        if (!isActive)
        {
            isActive = true;
            interactionPanel?.SetActive(true);
            interactionBackground?.SetActive(true);
        } 
    }

    public void CloseInteraction()
    {
        Debug.Log("close menu");

        isActive = false;

        interactionPanel?.SetActive(false);
        interactionBackground?.SetActive(false);
    }
}