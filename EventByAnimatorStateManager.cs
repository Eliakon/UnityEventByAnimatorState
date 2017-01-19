using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct EventByAnimatorState
{
    public string StateName;
    public UnityEvent Action;
}

public class EventByAnimatorStateManager : MonoBehaviour
{
    public EventByAnimatorState[] EventsByState;
}
