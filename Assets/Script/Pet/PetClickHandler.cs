using UnityEngine;

public class PetInteractionManager : MonoBehaviour
{
    [SerializeField] private LayerMask _petLayer;
    [SerializeField] private GameObject _petUI;
    private WindowTransparent _windowTransparent;
    private Camera _mainCamera;

    void Start()
    {
        _windowTransparent = FindObjectOfType<WindowTransparent>();
        _mainCamera = Camera.main;
    }

    void Update()
    {
        Vector2 mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos, _petLayer);

        if (hit != null)
        {
            // 鼠标在宠物上  可交互
            _windowTransparent?.SetClickthrough(false);
            _petUI.SetActive(true);
        }
        else
        {
            // 鼠标不在宠物上  穿透
            _windowTransparent?.SetClickthrough(true);
            _petUI.SetActive(false);
        }
    }
}
