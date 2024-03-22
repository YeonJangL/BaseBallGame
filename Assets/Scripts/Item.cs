using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// 스크립터블 오브젝트(Scriptable Object)
// 유니티에서 제공하는 대량의 데이터를 저장할 수 있는 데이터 컨테이너
// 값 사본 생성 방지

// 게임 오브젝트에 컴포넌트로 부착이 불가능하며, 프로젝트에서 에셋으로 저장됨

public enum ItemTYPE
{
    WEAPON, ARMOR, POTION
}

[CreateAssetMenu(fileName = "item", menuName = "SO/Item")]

public class Item : ScriptableObject
{
    [SerializeField] ItemTYPE type;
    [SerializeField] string description;

    public ItemTYPE Type { get => type; set => type = value; }
    public string Description { get => description; set => description = value; }

    /// <summary>
    /// 아이템 생성 함수
    /// </summary>
    /// <returns></returns>
    public static Item Create()
    {
        var asset = ScriptableObject.CreateInstance<Item>();
        // CreateInstance는 ScriptableObject 에서 인스턴스를 생성하는 기능

        AssetDatabase.CreateAsset(asset, "Assets/Resources/Item/item1.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }

    public static ItemList Load()
    {
        var itemlist = AssetDatabase.LoadAssetAtPath("Assets/REsources/Item/item1.asset", typeof(ItemList)) as ItemList;

        return itemlist;
    }
}
