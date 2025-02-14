using UnityEngine;

namespace Xlab
{
	public class PickupDetecter : MonoBehaviour
	{
		public event System.Action<WeaponDataSO> onPickupObjectDetect;

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log($"[PickupDetecter]: OnTriggerEnter({other})", this);

			if (other.TryGetComponent<PickupObject>(out var pickupObject))
			{
				onPickupObjectDetect?.Invoke(pickupObject.weaponData);

				Destroy(other.gameObject);
			}
		}
	}
}