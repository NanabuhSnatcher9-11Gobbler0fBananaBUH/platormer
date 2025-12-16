using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscript : MonoBehaviour
{
    public string gameSceneName = "Numba1";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
