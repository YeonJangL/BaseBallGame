using System.Collections;
using System.Collections.Generic;
using System.IO; // File, Directory ����� ���� using
using UnityEngine;
using UnityEngine.UI;

class InfoManager : MonoBehaviour
{
    [SerializeField] Info player_info;

    public Text ID_Text;
    public Text Point_Text;
    public Text Gold_Text;
    public Text Board_Text;

    private void Awake()
    {
        player_info = new Info();

        var loadedJson = Resources.Load<TextAsset>("info");
        // ���ҽ� ������ �ִ� info�� �ε�
        // Text Asseet�� �ؽ�Ʈ ������ ������ �ǹ�

        player_info = JsonUtility.FromJson<Info>(loadedJson.text);
        // JsonUtility.FromJson<T>(string json);
        // json ���Ϸκ��� �о�� ������ �������� �����͸� �����ϴ� �ڵ�

        printText();
    }

    public string PLAYER_ID => ID_Text.text = player_info.name.ToString();

    public string PLAYER_POINT => Point_Text.text = $"{player_info.point:n0}";

    public string PLAYER_GOLD => Gold_Text.text = $"{player_info.gold:n0}";

    void printText()
    {
        ID_Text.text = PLAYER_ID;
        Point_Text.text = PLAYER_POINT;
        Gold_Text.text = PLAYER_GOLD;
    }

    /// <summary>
    /// ����Ʈ�� ����ؼ� ���� �����Ѵ� �ڵ�(100����Ʈ -> 10000���)
    /// </summary>
    public void GoldPlus()
    {
        if (player_info.point >= 100)
        {
            player_info.point -= 100;
            player_info.gold += 10000;

            // JsonUtility.ToJson(object obj);
            // ��ü�� ������ Json ���Ϸ� ������ ���
            // �÷��̾� ������ json ���Ͽ� ����
            SaveData(player_info);
            printText();
        }
        else
        {
            Debug.Log("��ȯ�� ����Ʈ ����");
        }
    }

    private string ResourcePath => Application.dataPath + "/Resources/";

    // [����Ƽ ������ ���]
    private string SavePath => Application.persistentDataPath;
    // ���� ������ ������ ��ġ, Ư�� �ü������ ���� ����� �� �ֵ��� ����ϴ� ���
    // C:\Users\[user name]\AppData\LocalLow\[company name]\[product name]

    private string DataPath => Application.dataPath;
    // �������� ���� ���(�б� ����)���� ������Ʈ ���� ����(Asset)�� �ǹ�

    private string StreamingPath => Application.streamingAssetsPath;
    // Application.dathPath + StreamingAssets = Application.streamingAssetsPath

    public void SaveData(Info info)
    {
        // ������ ���� ��쿡�� ���� ����
        if (!Directory.Exists(ResourcePath))
        {
            Directory.CreateDirectory(ResourcePath);
        }

        var sJson = JsonUtility.ToJson(info); // 1. json ������ ������ string ���·� ����

        var FilePath = ResourcePath + "info.json";

        File.WriteAllText(FilePath, sJson);
        printText();    
    }

    public void SaveData2()
    {
        if (!Directory.Exists(ResourcePath))
        {
            Directory.CreateDirectory(ResourcePath);
        }
        var sJson = JsonUtility.ToJson(player_info);
        var FilePath = Path.Combine(DataPath, "info.json");
        // DataPath/info.json
        // ���� ���ڿ��� �� ��η� �����ϴ� ���(System.IO)
        File.WriteAllText(FilePath, sJson);
    }

    public Info LoadData(string path)
    {
        player_info = null; // Ŭ���� ��ü ���� (���ص� ��� ����)
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path); // �ش� ��ηκ��� ���� �о��
            player_info = JsonUtility.FromJson<Info>(json); // �о�� ������ ���� Info�� �� ����
        }

        return player_info; // �ϼ��� ��ü�� return ��
    }

    public void LoadData2()
    {
        var data = File.ReadAllText(ResourcePath + "info.json");
        player_info = JsonUtility.FromJson<Info>(data);
    }
}
