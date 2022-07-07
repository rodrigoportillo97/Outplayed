using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Animator transition;

    public void FadeTo()
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

    public void FadeBack()
    {
        LoadPrevious();
    }

    public void LoadPrevious()
    {
        StartCoroutine(LoadBack(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadBack(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

    public void FadeAgain()
    {
        LoadCurrent();
    }

    public void LoadCurrent()
    {
        StartCoroutine(LoadAgain(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadAgain(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

}
