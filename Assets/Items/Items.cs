using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템은 클래스
// 아이템 데이터는 실제로 만들 스크립터블 오브젝트
public abstract class Items
{
    public ItemData Data { get; private set; }
    public Items(ItemData data)
    {
        Data = data;
    }
}
