using UnityEngine;
using UnityEngine.SceneManagement;
public class Menus : MonoBehaviour
{
    public  void OpenMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

   public void OpenGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

}
