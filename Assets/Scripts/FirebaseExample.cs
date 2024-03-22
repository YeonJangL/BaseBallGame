using Firebase.Database; // 이게 있어야 연동 가능
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
        // 데이터베이스에서 데이터를 읽는 방법
        // DatabaseReference에 대한 인스턴스가 요구됨

        /*WriteUserDatatoDatabase("0", "Mcdonald's");
        WriteUserDatatoDatabase("1", "Lotteria");
        WriteUserDatatoDatabase("2", "BurgerKing");
        WriteUserDatatoDatabase("3", "FrankBurger");
        WriteUserDatatoDatabase("4", "SubWay");*/

        ReadUserDatatoDatabase();
    }

    void WriteUserDatatoDatabase(string _userID, string _userName)
    {
        // 데이터베이스 쪽에 값을 전달해 주는 기능
        reference.Child("users").Child(_userID).Child("_userName").SetValueAsync(_userName);

        // 실행시 데이터베이스에 다음과 같이 저장됨
        // database 이름
        // users
        // -> _userID
        //      -> userName : _userName
        Debug.Log($"{_userID} {_userName}이 데이터베이스에 등록됨");
    }

    void ReadUserDatatoDatabase()
    {
        // 데이터베이스에 저장되어 있는 값을 읽어내는 기능
        // 1. 파이어베이스로부터 인스턴스를 통해 값을 얻어옴 (메인스레드에서 계속 작업 진행)

        // 이 코드에 대한 더 정확한 이해를 위해 알아둘 개념
        // 1. 스레드(Thread) : 프로세스 내에서 실행되는 흐름의 단위, 둘 이상 실행일 경우 멀티 쓰레드 라고 함
        // 2. 태스크(Task) : 스레드를 통한 비동기 작업에 사용되는 데이터
        // 3. 무명 메소드(annoymous method) : 주로 delegate 등에서 많이 사용되고 한 번 쓰고 다시 쓸일 없는 기능에 대한 표현으로 사용함
        // 4. 람다식(Lamda Expression) : 코드에 대한 단순화, 주로 무명 함수를 표현할 때 많이 사용
        //                               => 연산자를 통해 해당 값이 무엇인지에 대한 처리
        //                               컴파일러가 코드 생성시 많은 자원을 쓰게 되서 성능 저하 유발
        //                               간단한 작업에 대한 표기로만 사용하는것이 바람직함
        FirebaseDatabase.DefaultInstance.GetReference("users").
            GetValueAsync().ContinueWithOnMainThread(task =>
            {
                // 태스크가 오류인 경우
                if (task.IsFaulted)
                {
                    // 오류에 대한 핸들링 작업 진행
                }
                // 태스크가 완료된 경우
                else if (task.IsCompleted)
                {
                    // 파이어베이스에서 지원하는 데이터 송 수신용 객체(클래스)
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
