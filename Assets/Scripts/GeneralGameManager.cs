using UnityEngine;
using UnityEngine.SceneManagement;

public static class GeneralGameManager
{
    //Settings pause
    private static float previousTimeScale = 1f;
    public static bool isPaused { get; private set; } = false;
    public static void PauseGame()
    {
        if (!isPaused)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            isPaused = true;
        }
        else
        {
            Time.timeScale = previousTimeScale;
            isPaused = false;
        }
    }
    public static void ChangeScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }
    public static void ExitAplication()
    {
        Application.Quit();
    }
}
