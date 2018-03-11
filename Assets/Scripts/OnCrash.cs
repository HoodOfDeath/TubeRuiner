using UnityEngine;
using UnityEngine.UI;

public class OnCrash : MonoBehaviour
{
    public Collider Player;
    public Text Message;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != Player.tag )
        {
            Message.text = "You Lose";
        }
    }


}
