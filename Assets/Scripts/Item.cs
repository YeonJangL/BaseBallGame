using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// ��ũ���ͺ� ������Ʈ(Scriptable Object)
// ����Ƽ���� �����ϴ� �뷮�� �����͸� ������ �� �ִ� ������ �����̳�
// �� �纻 ���� ����

// ���� ������Ʈ�� ������Ʈ�� ������ �Ұ����ϸ�, ������Ʈ���� �������� �����

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
    /// ������ ���� �Լ�
    /// </summary>
    /// <returns></returns>
    public static Item Create()
    {
        var asset = ScriptableObject.CreateInstance<Item>();
        // CreateInstance�� ScriptableObject ���� �ν��Ͻ��� �����ϴ� ���

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
