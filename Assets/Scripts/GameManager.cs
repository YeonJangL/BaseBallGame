/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text result_text;
    public InputField[] input_pads = new InputField[3];
    public Button selectButton;
    int[] checks;
    int[] result;
    int[] sbo;
    int cnt;
    bool gamestart;

    // Start is called before the first frame update
    void Start()
    {
        checks = new int[3];
        result = new int[3];
        sbo = new int[3] { 0, 0, 0 };
        result_text.text = "GameStart";
    }

    public void GameStart()
    {
        gamestart = true;
        RandomNumber(result);
    }

    public void GameReset()
    {
        if(gamestart == true)
        {
            selectButton
        }
        SceneManager.LoadScene("SampleScene");
        RandomNumber(result);
    }

    public void Check()
    {
        #region NULL CHECK
        bool null_check = false;
        for(int i = 0; i < 3; i++)
        {
            if (input_pads[i].text.Equals(""))
            {
                null_check
            }
        }
        #endregion

        cnt++;

        checkStrike();
        checkBall();
        sbo[2] = 3 - (sbo[0] + sbo[1]);
        checkPrintResult();
    }

    void check..()
    {
        
    }

    void checkPrintResult()
    {

    }

    void checkStrike()
    {
        for (int i = 0;i < 3;i++)
        {
            if (checks[i] == result[i])
            {
                sbo[0]++;
            }
        }
    }


    void checkBall()
    {

    }

    public void RandomNumber(int[] array)
    {
        for (int i = 0; i < 3; i++)
        {
            array[i] = Random.Range(1, 9);

            for (int j = 0; j < i; j++)
            {
                if (array[i] == array[j] && i != j)
                {
                    i--;
                }
            }
            Debug.Log(array[i]);
        }
        Debug.Log("¼ýÀÚ »ý¼º µÊ");
    }


    public void IsAnswer()
    {
        for (int i = 0; i < 3;i++)
        {
            if (input_pads[i] == null)
            {

            }

        }
    }
}
*/