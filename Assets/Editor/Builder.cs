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
			string[] scenes = Directory.GetFiles("C:/workspace/Assets/Scenes/Building/");

			for(int i = 0; i < scenes.Length; i++){
				//scenes[i] = trimPath(scenes[i]);
				print ("TEST PATH: " + scenes[i]);
			}

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

	static string trimPath(string path){
		string temp = path.Split ('\\',1000);
		string file = temp [temp.Length - 1];
		return "Assets/Scenes/Building/" + file;
	}
}