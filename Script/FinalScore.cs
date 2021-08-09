using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    public static FinalScore FS;
    public Text FinalScoreText = null;
    public static int FinalinisScore = 0;
    // Start is called before the first frame update
    void Start()
    {

        if (FinalScore.FS == null)
            FinalScore.FS = this;
        if (FinalScoreText != null)

        FinalScoreText.text = "Final Score: " + FinalinisScore;
        GameData.singleton.score = 0;

      //  Debug.Log(FinalinisScore);
    }

    // Update is called once per frame
    public void Result(int s)
    {
        FinalScoreText.text = "Final Score: " + s;
    }
    public void LoadGameMeniu()
    {
        SceneManager.LoadScene("Meniu", LoadSceneMode.Single);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("1lygis", LoadSceneMode.Single);
    }
}
