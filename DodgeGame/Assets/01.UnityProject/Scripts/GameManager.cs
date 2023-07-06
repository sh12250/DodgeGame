using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUi = default;
    public GameObject timeText = default;
    public GameObject recordText = default;

    private float surviveTime = default;
    private bool isGameOver = default;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            surviveTime += Time.deltaTime;
            timeText.SetText(string.Format("Time : {0}", (int)surviveTime));
            // == timeText.text = string.Format("Time : {0}", (int)surviveTime);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GFunc.LoadScene("PlayScene");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        // BestTime �� ��������� 0�� �����´�

        if (bestTime < surviveTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.SetText(string.Format("Best Time : {0}", (int)bestTime));
        // == recordText.text = string.Format("Best Time : {0}", (int)bestTime);
    }
}
