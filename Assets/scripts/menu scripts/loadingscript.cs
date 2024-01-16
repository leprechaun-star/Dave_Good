using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingscript : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    public GameObject Menus;
    public GameObject everythingelse;


    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        Menus.SetActive(false);
        everythingelse.SetActive(false);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);


        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress/0.9f);

            LoadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }
}
