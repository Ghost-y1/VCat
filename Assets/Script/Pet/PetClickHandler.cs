using UnityEngine;
using UnityEngine.EventSystems;

public class PetClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] 
    GameObject _interactionPanel;
    private bool _isActive = false;

    void Start()
    {
        _interactionPanel?.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isActive)
        {
            Debug.Log("open menu");
            _isActive = true;
            _interactionPanel?.SetActive(true);
        } 

        else
        {
            Debug.Log("close menu");
            _isActive = false;
            _interactionPanel?.SetActive(false);
        }
    }
}