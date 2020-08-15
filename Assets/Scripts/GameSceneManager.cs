using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : SingletonClass<GameSceneManager>
{
    [SerializeField] private string sceneName;
    [SerializeField] private FadeScript fadeScript;

    public void ChangeScene()
    {
        StartCoroutine(fadeScript.Fade());
        SceneManager.LoadScene(sceneName);
    }

    public void ResetGame()
    {
        StartCoroutine(fadeScript.Fade());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinGame()
    {
        StartCoroutine(fadeScript.Fade());
        SceneManager.LoadScene(sceneName);
    }

}
