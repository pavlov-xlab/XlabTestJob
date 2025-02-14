
using System.IO;
using UnityEngine;
using Xlab;

public static class PlayerDataProc
{
	public static string filePath => Path.Combine(Application.persistentDataPath, "playerSaveData.json");
	public static string filePathInventory => Path.Combine(Application.persistentDataPath, "player_inventory.json");

	public static void SavePlayer(PlayerData playerData)
	{
		var json = playerData.ToJson();
		File.WriteAllText(filePath, json);

		json = playerData.inventory.ToJson();
		File.WriteAllText(filePathInventory, json);
	}

	public static void LoadPlayer(PlayerData playerData)
	{
		if (File.Exists(filePath))
		{
			var json = File.ReadAllText(filePath);
			playerData.FromJson(json);

			json = File.ReadAllText(filePathInventory);
			playerData.inventory.FromJson(json);
		}
	}
}
