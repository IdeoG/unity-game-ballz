using UnityEngine;
using UnityEngine.SceneManagement;

public class BallzManager : MonoBehaviour
{
    public void ReloadGame()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
