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

// SetValueAsync()�� ���� ������ ������ �����͸� �����ϰ� �ش� ����� ���� �����ͷ� �����ϴ� �۾�
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
    /// �����ͺ��̽��� �л� Ŭ������ ���� ������ �߰��ϴ� �ڵ�
    /// </summary>
    /// <param name="_sid">�л� ���� �ĺ� �ڵ�(�й�)</param>
    /// <param name="_sname">�л� �̸�</param>
    /// <param name="_email">�л� �̸���</param>
    private void StudentRegister(string _sid, string _sname, string _email)
    {
        // 1. Ŭ������ ���� ����
        Student student = new Student(_sname, _email);

        // 2. �ش� Ŭ������ Json ���·� �ٲ���(string)
        var Student_json = JsonUtility.ToJson(student);

        // 3. ���۷����� �� ����
        reference.Child("students").Child(_sid).SetRawJsonValueAsync(Student_json);

        Debug.Log($"{_sid} / {_sname} / {_email}");
    }

    private void StudentUpdate(string _sid, string _sname)
    {
        reference.Child("students").Child(_sid).Child("s_name").SetValueAsync(_sname);

        Debug.Log("�̸��� ���� ��");
    }

    // ��� ���
    void sample()
    {
        Student s = new Student("a", "abc@naver.com");
        var sjson = JsonUtility.ToJson(s);
        Dictionary<string, object> update = s.ToDictionary();

        var key = reference.Child("students").Push().Key;

        reference.Child("students").Child("2113252").SetRawJsonValueAsync(sjson);
    }
}
