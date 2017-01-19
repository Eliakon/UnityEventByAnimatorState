using System;
using UnityEngine;

public class OnEnterStateBehaviour : StateMachineBehaviour
{
    private EventByAnimatorStateManager eventManager;
    private bool getComponentDone;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!getComponentDone)
        {
            eventManager = animator.GetComponent<EventByAnimatorStateManager>();
            getComponentDone = true;
        }

        if (null == eventManager)
        {
            Debug.LogWarningFormat("No EventByAnimatorStateManager linked to animator {0}", name);
            return;
        }

        var eventByState = Array.Find(eventManager.EventsByState, ebs => stateInfo.IsName(ebs.StateName));

        if (null == eventByState.Action)
        {
            return;
        }

        eventByState.Action.Invoke();
    }
}
