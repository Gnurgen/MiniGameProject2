using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextSceneFromInitialize : MonoBehaviour {

    public void SelectDanish()
    {
        GameManager.instance.StartButton();
        setLanguage(GameManager.Language.Danish);
    }

    public void SelectEnglish()
    {
        GameManager.instance.StartButton();
        setLanguage(GameManager.Language.English);
    }

    private void setLanguage(GameManager.Language language)
    {
        GameManager.language = language;
        SceneManager.LoadScene("StartScene");
    }
}
