using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerPhysicsController physicsController;
    [SerializeField] private PlayerAnimationController animationController;

    #endregion

    #region Private Variables


    #endregion

    #endregion

    private void OnEnable()
    {
        AssignEvents();
    }

    private void AssignEvents()
    {
        EventManager.Instance.onInputTaken += OnInputTaken;
        EventManager.Instance.onInputDragged += OnInputDragged;
        EventManager.Instance.onInputReleased += OnInputReleased;
    }

    private void UnAssignEvents()
    {
        EventManager.Instance.onInputTaken -= OnInputTaken;
        EventManager.Instance.onInputDragged -= OnInputDragged;
        EventManager.Instance.onInputReleased -= OnInputReleased;
    }

    private void OnDisable()
    {
        UnAssignEvents();
    }


    private void OnInputTaken()
    {
        animationController.SetAnimationStateToWalk();
    }

    private void OnInputDragged(JoystickMovementParams inputParams)
    {
        movementController.SetMovementAvailable();
        movementController.UpdateInputData(inputParams);
    }

    private void OnInputReleased()
    {
        movementController.SetMovementUnavailable();
        animationController.SetAnimationStateToIdle();
    }

}