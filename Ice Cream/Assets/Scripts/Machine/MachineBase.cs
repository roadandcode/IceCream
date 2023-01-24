using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBase : MonoBehaviour
{
  /*  [SerializeField] Transform vanillaStick;
    [SerializeField] Transform chocolateStick;
    [SerializeField] Transform strawberryStick;

    #region Controllers

    private PlayerInputController _playerInputController;
    private CreamMachineMovementController _creamMachineMovementController;
 //   private CreamMachineCreamController _creamMachineCreamController;

    #endregion



    private void Awake()
    {
        _playerInputController = playerInputController;
        _creamMachineMovementController = GetComponent<CreamMachineMovementController>();
        _creamMachineCreamController = GetComponent<CreamMachineCreamController>();
    }

    public void Initialize()
    {
        _playerInputController.Initialize();
        _creamMachineMovementController.Initialize();
        _creamMachineCreamController.Initialize(_creamMachineMovementController);
        InputEventsSubscriptions();
    }

    private void InputEventsSubscriptions()
    {
        // Moving machine sticks

        _playerInputController.SubscribeHoldingEvent(CreamType.CHOCOLATE, () =>
            _chocolateStick.DORotate(Vector3.forward * 45f, 1f)
            );
        _playerInputController.SubscribeReleasingEvent(CreamType.CHOCOLATE, () =>
            _chocolateStick.DORotate(Vector3.zero, 1f)
        );

        _playerInputController.SubscribeHoldingEvent(CreamType.VANILLA, () =>
            _vanillaStick.DORotate(Vector3.forward * 45f, 1f)
        );
        _playerInputController.SubscribeReleasingEvent(CreamType.VANILLA, () =>
            _vanillaStick.DORotate(Vector3.zero, 1f)
        );
    }*/
}

