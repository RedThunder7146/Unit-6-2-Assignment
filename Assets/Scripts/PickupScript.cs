using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PickupScript : MonoBehaviour
{
    InputAction pickupAction;
    [SerializeField] private Transform raycastSpawner;
    [SerializeField] private LayerMask objectLayerMask;
    private void Start()
    {
        pickupAction = InputSystem.actions.FindAction("Interact");
    }



    private void Update()
    {
        if (pickupAction.triggered)
        {
            float pickUpDistance = 2f;
            if (Physics.Raycast(raycastSpawner.position, raycastSpawner.forward, out RaycastHit raycasthit, pickUpDistance, objectLayerMask))
            {
                print("Hit");
            }
        }
    }
}
