
using System.IO;
using UnityEngine;
using Xlab;

public static class PlayerDataProc
{
	public static string pathFile => Path.Combine(Application.persistentDataPath, "playerSaveData.json");

	public static void SavePlayer(PlayerData playerData)
	{
		var json = playerData.ToJson();
		
		File.WriteAllText(pathFile, json);
	}

	public static void LoadPlayer(PlayerData playerData)
	{
		if (File.Exists(pathFile))
		{
			var json = File.ReadAllText(pathFile);

			playerData.FromJson(json);
		}
	}
}
