using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Window : MonoBehaviour, IDropHandler
{
    private TextMeshProUGUI _windowText;
    private void Start()
    {
        _windowText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            _windowText.text = eventData.pointerDrag.GetComponentInChildren<TextMeshProUGUI>().text;
            eventData.pointerDrag.SetActive(false);
        }
    }
}
