using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "itemlist", menuName = "SO/Item/ItemList")]

public class ItemList : ScriptableObject
{
    public List<Item> iList;

    /// <summary>
    /// 아이템 생성 함수
    /// </summary>
    /// <returns></returns>
    public static ItemList Create()
    {
        var asset = CreateInstance<ItemList>();
        // CreateInstance는 ScriptableObject에서 인스턴스를 생성하는 기능
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Item/itemExample01.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
    
    public static ItemList Load()
    {
        var itemlist = AssetDatabase.LoadAssetAtPath("Assets/REsources/Item/itemExample01.asset", typeof(ItemList)) as ItemList;

        return itemlist;
    }
}