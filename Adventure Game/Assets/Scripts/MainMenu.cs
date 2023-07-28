using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Mainlevel;

    public void StartGame()
    {
        SceneManager.LoadScene(Mainlevel);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }


}
