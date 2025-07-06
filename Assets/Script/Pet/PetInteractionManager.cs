using UnityEngine;

public class PetInteractionManager : MonoBehaviour
{
    [SerializeField] private LayerMask _petLayer;
    [SerializeField] private LayerMask _uiLayer;
    [SerializeField] private GameObject _petUI;

    private WindowTransparent _windowTransparent;
    private Camera _mainCamera;

    void Start()
    {
        _windowTransparent = FindObjectOfType<WindowTransparent>();
        _mainCamera = Camera.main;
        _petUI.SetActive(false);
    }

    void Update()
    {
        Vector2 mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        bool onPet = Physics2D.OverlapPoint(mouseWorldPos, _petLayer) != null;
        bool onUI = Physics2D.OverlapPoint(mouseWorldPos, _uiLayer) != null;

        if (onPet || onUI)
        {
            _windowTransparent?.SetClickthrough(false);

            if (!UIManager.Instance.STATSPANELACTIVE)
            {
                _petUI.SetActive(true);
            }
        }
        else
        {
            _windowTransparent?.SetClickthrough(true);
            _petUI.SetActive(false);
        }
    }
}
