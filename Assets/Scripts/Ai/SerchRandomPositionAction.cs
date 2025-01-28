using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System;
using UnityEngine.AI;

namespace Xlab
{
	[Serializable, GeneratePropertyBag]
	[NodeDescription(name: "SerchRandomPosition", story: "Serch Random position", category: "Action", id: "219f2ef0c9accd9963cacd009654b8c1")]
	public partial class SerchRandomPositionAction : Action
	{
		[SerializeReference] public BlackboardVariable<GameObject> ThisTransform;
		[SerializeReference] public BlackboardVariable<Vector3> Target;

		[SerializeReference] public BlackboardVariable<float> Radius;

		protected override Status OnStart()
		{

			return Status.Running;
		}

		protected override Status OnUpdate()
		{
			NavMeshPath navMeshPath = new NavMeshPath();
			Vector3 thisPosition = ThisTransform.Value.transform.position;
			Vector3 newPosition = new Vector3();

			bool result = false;
			for (int i = 0; i < 5; ++i)
			{
				newPosition = thisPosition;
				Vector2 r = UnityEngine.Random.insideUnitCircle * Radius.Value;
				newPosition.x += r.x;
				newPosition.z += r.y;

				result = NavMesh.CalculatePath(thisPosition, newPosition, -1, navMeshPath);
				if (result)
				{
					Target.Value = newPosition;
					return Status.Success;
				}
			}

			return Status.Failure;
		}

		protected override void OnEnd()
		{
		}
	}

}