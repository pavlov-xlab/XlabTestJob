using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "AiTestAction", story: "Test action", category: "Action", id: "3d8297c3f2274542d5ef9121ffcf9acd")]
public partial class AiTestActionAction : Action
{
    public NavMeshAgent navMeshAgent;
    [SerializeReference] public BlackboardVariable<List<Vector3>> Waypoints;

    [SerializeReference] public BlackboardVariable<float> speed;

    protected override Status OnStart()
    {
        navMeshAgent.enabled = true;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (navMeshAgent)
        {
            navMeshAgent.SetDestination(Waypoints.Value[0]);
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

