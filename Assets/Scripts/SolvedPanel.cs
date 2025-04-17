using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SolvedPanel : MonoBehaviour
{
    public Text TimeTxt;
    public Text MoveCountTxt;

    public void Initialize()
    {
        TimeTxt.text = "Time: " + InGameStatistics.Time.ToString("0.00") + " s";
        MoveCountTxt.text = "Move Count: " + InGameStatistics.MoveCount;
        gameObject.SetActive(true);
    }

    public void RestartBtn()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
