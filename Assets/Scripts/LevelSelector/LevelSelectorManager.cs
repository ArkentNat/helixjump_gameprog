using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Tutorial - https://www.youtube.com/watch?v=LAILBzuBqVY

public class LevelSelectorManager : MonoBehaviour
{
    public void LoadToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
