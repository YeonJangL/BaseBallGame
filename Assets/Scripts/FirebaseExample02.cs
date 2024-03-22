using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student
{
    public string s_name;
    public string email;

    public Student(string name, string email)
    {
        s_name = name;
        this.email = email;
    }

    public Dictionary<string, object> ToDictionary()
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        result["s_name"] = s_name;
        result["email"] = email;
        return result;
    }
}

// SetValueAsync()를 통해 지정한 참조에 데이터를 저장하고 해당 경로의 기존 데이터로 변경하는 작업
// string, long, double, bool Dictionary<string, Object>, List<Object>

public class FirebaseExample02 : MonoBehaviour
{
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        StudentRegister("211325", "Yeon Jang", "yeonjang@gwnu.ac.kr");
        StudentUpdate("211325", "Jang");
    }

    /// <summary>
    /// 데이터베이스에 학생 클래스에 대한 정보를 추가하는 코드
    /// </summary>
    /// <param name="_sid">학생 고유 식별 코드(학번)</param>
    /// <param name="_sname">학생 이름</param>
    /// <param name="_email">학생 이메일</param>
    private void StudentRegister(string _sid, string _sname, string _email)
    {
        // 1. 클래스에 대한 생성
        Student student = new Student(_sname, _email);

        // 2. 해당 클래스를 Json 형태로 바꿔줌(string)
        var Student_json = JsonUtility.ToJson(student);

        // 3. 레퍼런스에 값 설정
        reference.Child("students").Child(_sid).SetRawJsonValueAsync(Student_json);

        Debug.Log($"{_sid} / {_sname} / {_email}");
    }

    private void StudentUpdate(string _sid, string _sname)
    {
        reference.Child("students").Child(_sid).Child("s_name").SetValueAsync(_sname);

        Debug.Log("이름이 변경 됨");
    }

    // 사용 방식
    void sample()
    {
        Student s = new Student("a", "abc@naver.com");
        var sjson = JsonUtility.ToJson(s);
        Dictionary<string, object> update = s.ToDictionary();

        var key = reference.Child("students").Push().Key;

        reference.Child("students").Child("2113252").SetRawJsonValueAsync(sjson);
    }
}
