using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SOExample : MonoBehaviour
{
    public Item item_object;
    public ItemList item_list;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(item_object.Type);
        // Debug.Log(item_object.Description);

        item_list = ItemList.Create();
        var item_obj = Item.Create();

        item_list.iList.Add(item_obj);

        for(int i = 0; i < item_list.iList.Count; i++)
        {
            Debug.Log(item_list.iList[i].name);
        }

        var item_list2 = ItemList.Load();
        Debug.Log(AssetDatabase.GetAssetPath(item_list2));
        // AssetDatabase�� ���ο� ������ ������ ��ο� ������ �� ���
        // ��ο��� Ȯ���ڸ� �����ؾ���
        // ������ �̹� path ��ο� �����ϴ� ��� ���� ������
        // ��� ��δ� ������Ʈ�� ���� �������� ����

        // ��� ���� : ������ �ҽ� ���Ͽ��� ���� �Ǵ� �ǽð� �ʿ��� ����� �� �ִ� ���·� �����͸� ��ȯ �ؾ���
        // ����Ƽ�� ��ȯ�� ����, ��ȯ�� ���ϰ� ����� �����͸� ���� ������ ���̽��� ������
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}