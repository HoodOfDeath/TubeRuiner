using UnityEngine;
using UnityEngine.UI;

public class OnCrash : MonoBehaviour// класс переименовать. Так Onчтото именуются события
{
    public Collider Player; // вместо этого просто использутйте gameObject.CompareTag()
    public Text Message;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != Player.tag ) // Если таг коллайдера не равен тэгу плеера, то мы проигрываем??
        {
            Message.text = "You Lose";
        }
    }


}
