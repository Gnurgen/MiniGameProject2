using UnityEditor;
using System.IO;
using UnityEngine;
using System;

public class Builder{

	static void AndroidBuild(){

		string basePath = "C:/Builds/Android";
		string buildFolder = System.DateTime.Now.ToString ("dd-MM-yy HH.mm.ss");

		try{

			string[] scenes = { "Assets/Scenes/Main.unity" };

			FileUtil.DeleteFileOrDirectory ("C:/Users/Kenned/AppData/LocalUnity/Editor/Editor.log");

			Directory.CreateDirectory (basePath + "/" + buildFolder);

			BuildPipeline.BuildPlayer (scenes, basePath + "/" + buildFolder + "/" + "buildfile.apk" , BuildTarget.Android, BuildOptions.None);

			FileUtil.CopyFileOrDirectory ("C:/Users/Kenned/AppData/Local/Unity/Editor/Editor.log", basePath + "/" + buildFolder + "/log.txt");
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