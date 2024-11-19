using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMiniGame()
    {
        SceneManager.LoadScene("MiniGameSceneName");
    }
}
