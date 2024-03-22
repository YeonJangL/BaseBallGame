using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler // 드롭 이벤트에 대한 처리
{
    GameObject Icon()
    {
        // 슬롯(아이템 뷰어)에 아이템(자식 트랜스폼)이 있다면 아이템의 gameObject를 return
        if (transform.childCount > 0)
        {
            return transform.GetChild(0).gameObject;
        }
        else
        {
            // 없을 경우 null 값 처리
            return null;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        // 슬롯이 비어있는 경우
        if(Icon() == null)
        {
            // 아이콘을 자식으로 위치를 변경하는 코드(슬롯
        }
    }
}
