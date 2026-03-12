using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float sceneLoadDelay = 2f;
    public void LoadGame(){
        ScoreKeeper.instance.resetScore();
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver(){
        StartCoroutine(WaitAndLoad("Retry Menu", sceneLoadDelay));
    }

    public void QuitGame(){
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay){
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneName);
    }
}
