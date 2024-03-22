using System.Collections;
using System.Collections.Generic;
using System.IO; // File, Directory 사용을 위한 using
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
        // 리소스 폴더에 있는 info를 로드
        // Text Asseet은 텍스트 형태의 에셋을 의미

        player_info = JsonUtility.FromJson<Info>(loadedJson.text);
        // JsonUtility.FromJson<T>(string json);
        // json 파일로부터 읽어온 파일을 기준으로 데이터를 적용하는 코드

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
    /// 포인트를 사용해서 골드로 변경한느 코드(100포인트 -> 10000골드)
    /// </summary>
    public void GoldPlus()
    {
        if (player_info.point >= 100)
        {
            player_info.point -= 100;
            player_info.gold += 10000;

            // JsonUtility.ToJson(object obj);
            // 객체의 정보를 Json 파일로 보내는 기능
            // 플레이어 정보를 json 파일에 전달
            SaveData(player_info);
            printText();
        }
        else
        {
            Debug.Log("교환할 포인트 부족");
        }
    }

    private string ResourcePath => Application.dataPath + "/Resources/";

    // [유니티 데이터 경로]
    private string SavePath => Application.persistentDataPath;
    // 쓰기 가능한 폴더의 위치, 특정 운영체제에서 앱이 사용할 수 있도록 허용하는 경로
    // C:\Users\[user name]\AppData\LocalLow\[company name]\[product name]

    private string DataPath => Application.dataPath;
    // 데이터의 저장 경로(읽기 전용)으로 프로젝트 폴더 내부(Asset)을 의미

    private string StreamingPath => Application.streamingAssetsPath;
    // Application.dathPath + StreamingAssets = Application.streamingAssetsPath

    public void SaveData(Info info)
    {
        // 폴더가 없을 경우에는 폴더 생성
        if (!Directory.Exists(ResourcePath))
        {
            Directory.CreateDirectory(ResourcePath);
        }

        var sJson = JsonUtility.ToJson(info); // 1. json 파일의 정보를 string 형태로 저장

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
        // 여러 문자열을 한 경로로 결합하는 기능(System.IO)
        File.WriteAllText(FilePath, sJson);
    }

    public Info LoadData(string path)
    {
        player_info = null; // 클래스 객체 비우기 (안해도 상관 없음)
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path); // 해당 경로로부터 파일 읽어옴
            player_info = JsonUtility.FromJson<Info>(json); // 읽어온 내용을 통해 Info에 값 전달
        }

        return player_info; // 완성된 객체를 return 함
    }

    public void LoadData2()
    {
        var data = File.ReadAllText(ResourcePath + "info.json");
        player_info = JsonUtility.FromJson<Info>(data);
    }
}
