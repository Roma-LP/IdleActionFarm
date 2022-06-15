using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class WheatBlock : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Spawn()
    {
        rb.AddForce(new Vector3(1, 5, 1));
    }
}
