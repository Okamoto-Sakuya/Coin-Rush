using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController_UI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Header("移動範囲（座標指定）")]
    public float minX = -500f; // 左限界
    public float maxX = 500f;  // 右限界

    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 offset;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out offset
        );
        offset = rectTransform.anchoredPosition - offset;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint))
        {
            // X軸のみ動かす
            float x = Mathf.Clamp(localPoint.x, minX, maxX);
            rectTransform.anchoredPosition = new Vector2(x, rectTransform.anchoredPosition.y);
        }
    }

    public void OnEndDrag(PointerEventData eventData) { }
}
