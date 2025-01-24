using System.Collections.Generic;
using UnityEngine;

namespace Xlab
{
	[CreateAssetMenu(fileName = "WeaponDB", menuName = "Xlab/WeaponDB")]
	public class WeaponDB : ScriptableObject
    {
		public List<WeaponDataSO> weapons;

		public WeaponDataSO GetWeapon(string id)
		{
			return weapons.Find(x => x.id == id);
		}
    }
}
