using UnityEngine;

public class Collects : MonoBehaviour
{
    [SerializeField] private Animator animator;

    WheatUnit wheatUnit;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out wheatUnit))
        {
            if (wheatUnit.WheatState == eWheatState.Ready)
            {
                animator.SetTrigger("Collect");
                print("kek");
            }
        }
    }

    public void puck()
    {
        wheatUnit.StartCollect();
    }
}
