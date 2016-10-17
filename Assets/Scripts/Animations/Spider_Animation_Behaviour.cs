using UnityEngine;
using System.Collections;

public class Spider_Animation_Behaviour : StateMachineBehaviour {

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        switch (animator.gameObject.GetComponent<Unit>().CurrentState)
        {
            case Unit.state.moving_to_Place:
            case Unit.state.moving_to_Start_Action:
                animator.SetBool(AnimationNames.Unit_Walk, true);
                animator.SetBool(AnimationNames.Unit_Attack, false);
                break;
            case Unit.state.making_Action:
            case Unit.state.wait_for_CD:
                animator.SetBool(AnimationNames.Unit_Walk, false);
                animator.SetBool(AnimationNames.Unit_Attack, true);
                break;
            case Unit.state.idle:
                animator.SetBool(AnimationNames.Unit_Walk, false);
                animator.SetBool(AnimationNames.Unit_Attack, false);
                break;
        }

    }
    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
    //
    //}

    // OnStateMachineExit is called when exiting a statemachine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
    //
    //}
}
