using Firebase.Database; // �̰� �־�� ���� ����
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseExample : MonoBehaviour
{
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        // �����ͺ��̽����� �����͸� �д� ���
        // DatabaseReference�� ���� �ν��Ͻ��� �䱸��

        /*WriteUserDatatoDatabase("0", "Mcdonald's");
        WriteUserDatatoDatabase("1", "Lotteria");
        WriteUserDatatoDatabase("2", "BurgerKing");
        WriteUserDatatoDatabase("3", "FrankBurger");
        WriteUserDatatoDatabase("4", "SubWay");*/

        ReadUserDatatoDatabase();
    }

    void WriteUserDatatoDatabase(string _userID, string _userName)
    {
        // �����ͺ��̽� �ʿ� ���� ������ �ִ� ���
        reference.Child("users").Child(_userID).Child("_userName").SetValueAsync(_userName);

        // ����� �����ͺ��̽��� ������ ���� �����
        // database �̸�
        // users
        // -> _userID
        //      -> userName : _userName
        Debug.Log($"{_userID} {_userName}�� �����ͺ��̽��� ��ϵ�");
    }

    void ReadUserDatatoDatabase()
    {
        // �����ͺ��̽��� ����Ǿ� �ִ� ���� �о�� ���
        // 1. ���̾�̽��κ��� �ν��Ͻ��� ���� ���� ���� (���ν����忡�� ��� �۾� ����)

        // �� �ڵ忡 ���� �� ��Ȯ�� ���ظ� ���� �˾Ƶ� ����
        // 1. ������(Thread) : ���μ��� ������ ����Ǵ� �帧�� ����, �� �̻� ������ ��� ��Ƽ ������ ��� ��
        // 2. �½�ũ(Task) : �����带 ���� �񵿱� �۾��� ���Ǵ� ������
        // 3. ���� �޼ҵ�(annoymous method) : �ַ� delegate ��� ���� ���ǰ� �� �� ���� �ٽ� ���� ���� ��ɿ� ���� ǥ������ �����
        // 4. ���ٽ�(Lamda Expression) : �ڵ忡 ���� �ܼ�ȭ, �ַ� ���� �Լ��� ǥ���� �� ���� ���
        //                               => �����ڸ� ���� �ش� ���� ���������� ���� ó��
        //                               �����Ϸ��� �ڵ� ������ ���� �ڿ��� ���� �Ǽ� ���� ���� ����
        //                               ������ �۾��� ���� ǥ��θ� ����ϴ°��� �ٶ�����
        FirebaseDatabase.DefaultInstance.GetReference("users").
            GetValueAsync().ContinueWithOnMainThread(task =>
            {
                // �½�ũ�� ������ ���
                if (task.IsFaulted)
                {
                    // ������ ���� �ڵ鸵 �۾� ����
                }
                // �½�ũ�� �Ϸ�� ���
                else if (task.IsCompleted)
                {
                    // ���̾�̽����� �����ϴ� ������ �� ���ſ� ��ü(Ŭ����)
                    DataSnapshot dataSnapshot = task.Result;

                    for (int i = 0; i < dataSnapshot.ChildrenCount; i++)
                    {
                        Debug.Log(dataSnapshot.Child(i.ToString()).Child("_userName").Value);
                    }
                }
            }
            );
    }
}
