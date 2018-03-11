using UnityEngine;
using UnityEngine.UI;

public class OnCrash : MonoBehaviour
{
    public Collider trash;
    public Text Message;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != trash.tag )
        {
            Message.text = "You Lose";
        }
    }


}
