using Firebase;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class User
{
    public string _ID;
    public string _PW;

    public User(string ID, string PW)
    {
        _ID = ID;
        _PW = PW;
    }
}

public class LoginManager : MonoBehaviour
{
    DatabaseReference reference;

    public GameObject LoginButton;
    public GameObject LoginPanel;
    public GameObject RegisterPanel;

    public InputField IDInput;
    public InputField PWInput;
    public InputField PW_Check;

    public InputField IDInput2;
    public InputField PWInput2;

    public Text errortext;
    public Text errortext2;

    public void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(false);
        errortext.gameObject.SetActive(false);
        errortext2.gameObject.SetActive(false);
    }

    public void LoginButtonClick()
    {
        LoginPanel.SetActive(true);
        LoginButton.SetActive(false);
    }

    public async void JoinButtonClick()
    {
        // 입력된 아이디, 비번 가져오기
        string id = IDInput.text;
        string pw = PWInput.text;

        var task = reference.Child("user").Child(id).GetValueAsync();
        await task;

        DataSnapshot snapshot = task.Result;

        if (snapshot.Exists)
        {
            errortext.gameObject.SetActive(true);
            errortext.text = "로그인 성공";
            StartCoroutine(HideText(errortext, 2f));
            // 로그인 성공 시 로비 또는 게임 씬으로 이동
        }
        else
        {
            errortext.gameObject.SetActive(true);
            errortext.text = "존재하지 않는 회원입니다. \n회원가입을 진행하세요";
            StartCoroutine(HideText(errortext, 2f));
        }
}

    public void RegisterButtonClick()
    {
        RegisterPanel.SetActive(true);
        LoginPanel.SetActive(false);
    }

    public async void SaveData() // 얘 왜 데베에 저장이 안되니;;;
    {
        string id = IDInput2.text;
        string pw = PWInput2.text;
        string pwc = PW_Check.text;

        var snapshot = await reference.Child("user").GetValueAsync();

        var task = await reference.Child("user").Child(id).GetValueAsync();

        if (task.Value != null)
    {
            // 이미 가입된 경우
            errortext2.gameObject.SetActive(true);
            errortext2.text = "이미 가입된 사용자 입니다.";
            StartCoroutine(HideText(errortext2, 2f));
        }

        else if (pw == pwc)
        {
            // 비밀번호와 비밀번호 확인이 일치할 때 회원가입 진행
            User user = new User(id, pw);
            var user_json = JsonUtility.ToJson(user);
            await reference.Child("user").Child(id).SetRawJsonValueAsync(user_json);
            // await addTask;

            errortext2.gameObject.SetActive(true);
            errortext2.text = "회원가입 성공";
            StartCoroutine(HideText(errortext2, 2f));
        }
        else
        {
            errortext2.gameObject.SetActive(true);
            errortext2.text = "비밀번호가 일치하지 않습니다";
            StartCoroutine(HideText(errortext2, 2f));
        }
    }

    IEnumerator HideText(Text text, float delay)
    {
        yield return new WaitForSeconds(delay);
        text.gameObject.SetActive(false);
    }

    public void backButtonClick1()
    {
        LoginPanel.SetActive(false);
        LoginButton.SetActive(true);
    }

    public void backButtonClick2()
    {
        RegisterPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }
}