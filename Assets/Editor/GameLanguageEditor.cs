using UnityEngine;
using UnityEditor;
using System.Collections;

public class GameLanguageEditor : EditorWindow {

    [MenuItem("Tools/Game Language/Danish",false,0)]
    public static void SetLanguage_Danish()
    {
        GameManager.language = GameManager.Language.Danish;
    }

    [MenuItem("Tools/Game Language/English", false, 1)]
    public static void SetLanguage_English()
    {
        GameManager.language = GameManager.Language.English;
    }
}
