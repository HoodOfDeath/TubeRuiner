using UnityEngine;

public class OnCrash : MonoBehaviour
{
    public Collider trash;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != trash.tag )
        {
            Debug.Log("Oi fseo");
        }
    }
}
