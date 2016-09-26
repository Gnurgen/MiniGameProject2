using UnityEditor;
using System.IO;
using UnityEngine;
using System;

public class Builder{

	static void AndroidBuild(){

		string basePath = "C:/Users/dadiu/Google Drive/MGP2/Builds";
		string buildFolder = System.DateTime.Now.ToString ("dd-MM-yy HH.mm.ss");

		try{

			PlayerSettings.bundleIdentifier = "com.highfiveproductions.doedetoner";
			PlayerSettings.bundleVersion = "2.2";
			// Change something to push again and again and again
			string[] scenes = { "Assets/Scenes/Tests/WwiseTestScene.unity" };

			FileUtil.DeleteFileOrDirectory ("C:/Users/dadiu/AppData/LocalUnity/Editor/Editor.log");

			Directory.CreateDirectory (basePath + "/" + buildFolder);

			BuildPipeline.BuildPlayer (scenes, basePath + "/" + buildFolder + "/" + "build.apk" , BuildTarget.Android, BuildOptions.None);

			FileUtil.CopyFileOrDirectory ("C:/Users/dadiu/AppData/Local/Unity/Editor/Editor.log", basePath + "/" + buildFolder + "/log.txt");
		} catch(UnityException e){
			StreamWriter fil = new StreamWriter(basePath + "/" + buildFolder + "/unity_errors.txt",true);
			fil.Write (e.Message);
			fil.Close ();
		} catch(Exception e){
			StreamWriter fil = new StreamWriter(basePath + "/" + buildFolder + "/general_errors.txt",true);
			fil.Write (e.Message);
			fil.Close ();
		}
	}
}