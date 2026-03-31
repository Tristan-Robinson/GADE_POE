using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Pickup : MonoBehaviour
{
    private IPickup pickupEffect;

    private void Awake()
    {
        pickupEffect = GetComponent<IPickup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null && pickupEffect != null)
        {
            pickupEffect.OnPickup(player);
            gameObject.SetActive(false);
        }
    }
}
