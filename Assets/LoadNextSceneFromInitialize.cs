using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextSceneFromInitialize : MonoBehaviour {

    public void SelectDanish()
    {
        setLanguage(GameManager.Language.Danish);
        Debug.Log(GameManager.Language.Danish);
    }

    public void SelectEnglish()
    {
        setLanguage(GameManager.Language.English);
    }

    private void setLanguage(GameManager.Language language)
    {
        GameManager.language = language;
        SceneManager.LoadScene("StartScene");
    }
}
