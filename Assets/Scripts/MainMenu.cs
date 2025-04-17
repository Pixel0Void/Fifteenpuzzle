using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Dropdown SizeDropDown;

    public void PlayGame()
    {
        int size = 0;
        switch (SizeDropDown.value)
        {
            case 0: size = 3; break;
            case 1: size = 4; break;
            case 2: size = 5; break;
            case 3: size = 6; break;
            case 4: size = 7; break;
            case 5: size = 8; break;
            case 6: size = 9; break;
            default:goto case 0;
        }
        PlayerPrefs.SetInt("Size", size);
        SceneManager.LoadScene(1);
    }
}
