using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Window : MonoBehaviour, IDropHandler
{
    private TextMeshProUGUI _windowText;

    [SerializeField]
    private CheckAnswer checkAnswer;

    private GameObject _oldCloud;
    private void Awake()
    {
        _windowText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var cloud = eventData.pointerDrag;

        // If old cloud exists, and it is different, change cloud  
        if (_windowText.text != "" && _windowText.text != cloud.GetComponentInChildren<TextMeshProUGUI>().text)
        {
            _oldCloud.GetComponent<CanvasGroup>().alpha = 1f;
            _oldCloud.GetComponent<CloudDragHandler>().Dragged = false;
            _windowText.text = cloud.GetComponentInChildren<TextMeshProUGUI>().text;
            cloud.GetComponent<CanvasGroup>().alpha = 0.6f;
            cloud.GetComponent<CloudDragHandler>().Dragged = true;
        }
        // if old cloud is not different
        else if (cloud != null && !cloud.GetComponent<CloudDragHandler>().Dragged)
        {
            _windowText.text = cloud.GetComponentInChildren<TextMeshProUGUI>().text;
            cloud.GetComponent<CanvasGroup>().alpha = 0.6f;
            cloud.GetComponent<CloudDragHandler>().Dragged = true;
            _oldCloud = cloud;
        }
        
        // Checks if the answered clouds are correct
        checkAnswer.CheckCorrect();
    }
    
}
