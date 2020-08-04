using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Window : MonoBehaviour, IDropHandler
{
    private TextMeshProUGUI _windowText;
    private void Awake()
    {
        _windowText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var cloud = eventData.pointerDrag;
        
        
        if (cloud != null && !cloud.GetComponent<CloudDragHandler>().Dragged)
        {
            _windowText.text = cloud.GetComponentInChildren<TextMeshProUGUI>().text;
            cloud.GetComponent<CanvasGroup>().alpha = 0.6f;
            cloud.GetComponent<CloudDragHandler>().Dragged = true;
        }
    }
}
