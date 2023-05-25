using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;

    //Buat UI Text
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;

    //UI Win Screen
    [SerializeField] private GameObject RedWinUI;
    [SerializeField] private GameObject BlueWinUI;

    public static GameManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
    }

    public void Score(string wallID)
    {
        if (wallID == "Red")
        {
            PlayerScoreR = PlayerScoreR + 10; //Menambah score
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //Mengisikan nilai integer PlayerScore ke UI
            ScoreCheck();
        }
        else
        {
            PlayerScoreL = PlayerScoreL + 10;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            ScoreCheck();
        }
    }

    public void ScoreCheck()
    {
        if (PlayerScoreL == 20)
        {
            Time.timeScale = 0f;
            RedWinUI.SetActive(true);
            Debug.Log("playerL win");
        }
        else if (PlayerScoreR == 20)
        {
            Time.timeScale = 0f;
            BlueWinUI.SetActive(true);
            Debug.Log("playerR win");
        }
    }
}
