using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public float delay { private set; get; } = 1f;
    public int cage = 10;    
    public WeaponShootSO weaponShoot;
    
    
    public GameObject prefab;
    public Sprite icon;


#if UNITY_EDITOR
    [ContextMenu("Save To JSON")]
    public void SaveToJson()
    {
        WeaponData weaponData = new WeaponData()
        {
            delay = delay,
            cage = cage,
            prefab = AssetDatabase.GetAssetPath(prefab),
            icon = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(icon)),
        };

        string json = JsonUtility.ToJson(weaponData);
        File.WriteAllText(Path.Combine(Application.dataPath, "weapon_data.json"), json);
    }

    [ContextMenu("Load From JSON")]
    public void LoadFromJson()
    {
        string filePath = Path.Combine(Application.dataPath,"weapon_data.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(Path.Combine(Application.dataPath,"weapon_data.json"));
            WeaponData data = JsonUtility.FromJson<WeaponData>(json);

            this.delay = data.delay;
            this.cage = data.cage;
            var iconPath = AssetDatabase.GUIDToAssetPath(data.icon);
            this.icon = AssetDatabase.LoadAssetAtPath<Sprite>(iconPath);
            this.prefab = AssetDatabase.LoadAssetAtPath<GameObject>(data.prefab);            
        }
    }
#endif

    [System.Serializable]
    public class Bullet
    {
        public string prefab;
    }

    public class WeaponData
    {
        public float delay;
        public int cage;
        public string prefab;
        public string icon;

        public List<Bullet> bullet = new List<Bullet>(new []{new Bullet()});
    }
}
