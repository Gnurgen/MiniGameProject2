using UnityEditor;
using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;

public class Builder{

	static void AndroidBuild(){

		string basePath = "C:/Users/dadiu/Google Drive/MGP2/Builds";
		string buildFolder = System.DateTime.Now.ToString ("dd-MM-yy HH.mm.ss");

		try{

			PlayerSettings.bundleIdentifier = "com.highfiveproductions.doedetoner";
			PlayerSettings.bundleVersion = "2.2";

			// All of this is to find every scene in the build folder, put the StartScene
			// as the first scene, and add the rest.
			string[] scenes = Directory.GetFiles("C:/workspace/Assets/Scenes/Building/"); // find all the scenes for building

			for(int i = 0; i < scenes.Length; i++){
				scenes[i] = extractFile(scenes[i]); // Remove the path up to the file, so only the file name remains
			}

			List<string> tempScenes = new List<string>(); // Make a list holding all the scenes
			for(int i = 0; i < scenes.Length; i++){
				tempScenes.Add(scenes[i]);
			}
			tempScenes.Remove("StartScene.unity"); // Remove the start scene
			string[] buildScenes = new string[scenes.Length]; // Make the array holding all the scenes to be build
			buildScenes[0] = "StartScene.unity"; // Set the StartScene as the first one
			int n = 1;
			foreach(string s in tempScenes){ // Add the rest of the scenes
				buildScenes[n] = s;
				n++;
			}
			for(int i = 0; i < buildScenes.Length; i++){
				buildScenes[i] = "Assets/Scenes/Building/" + scenes[i]; // Add the required path to each file name
			}


			FileUtil.DeleteFileOrDirectory ("C:/Users/dadiu/AppData/LocalUnity/Editor/Editor.log");

			Directory.CreateDirectory (basePath + "/" + buildFolder);

			BuildPipeline.BuildPlayer (buildScenes, basePath + "/" + buildFolder + "/" + "build.apk" , BuildTarget.Android, BuildOptions.None);

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

	static string extractFile(string path){
		char[] delim = { '\\', '/' };
		string[] temp = path.Split (delim);
		string file = temp [temp.Length - 1];
		return file;
	}
}