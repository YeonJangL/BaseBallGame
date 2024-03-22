using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 핸들러 유형은 Event Trigger에서 조사 가능
class SlotItemDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static GameObject beginDraggedIcon;
    // 드래그 될때 이동되는 아이콘에 대한 static 변수

    Vector3 Starting_Position; // 슬롯이 아닌 위치에 혹시라도 드래그 했을 경우 원래의 위치로 돌아가기 위한 기본 설정   

    [SerializeField] Transform onDragParent_Position;
    // 아이콘 드래그 중에 변경될 부모에 대한 RectTransform 변수

    public Transform Starting_Parent_Position;
    // 부모 위치 기본 값

    public void OnBeginDrag(PointerEventData eventData)
    {
        beginDraggedIcon = gameObject;

        Starting_Parent_Position = transform.parent;
        Starting_Position = transform.position;

        GetComponent<CanvasGroup>().blocksRaycasts = false; // 아이콘에 대한 RectTransform을 무시

        transform.SetParent(onDragParent_Position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beginDraggedIcon = null; // 할당 해제
        GetComponent<CanvasGroup>().blocksRaycasts = true; // 이벤트 감지 활성화

        // 드랍 이벤트 했는데 부모가 변경되지 않은 상황 + 부모 transform이 같은 상황
        // -> 원래 위치 그래도 유지
        if (transform.parent == onDragParent_Position)
        {
            transform.position = Starting_Position;
            transform.SetParent(Starting_Parent_Position);
        }
    }
}