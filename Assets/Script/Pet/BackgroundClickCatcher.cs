using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class BackgroundClickCatcher : MonoBehaviour, IPointerClickHandler
{
    public PetClickHandler handler;
    public RectTransform interactionPanel;
    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;

    public void OnPointerClick(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(eventData, results);

        bool clickedInsidePanel = false;

        foreach (var result in results)
        {
            if (result.gameObject.transform.IsChildOf(interactionPanel))
            {
                clickedInsidePanel = true;
                break;
            }
        }

        if (!clickedInsidePanel)
        {
            handler?.CloseInteraction();
        }
    }
}
