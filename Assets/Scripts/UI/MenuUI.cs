using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public void StartGame()
    {
        GeneralGameManager.ChangeScene(1);
    }
    public void ExitGame()
    {
        GeneralGameManager.ExitAplication();
    }
}
