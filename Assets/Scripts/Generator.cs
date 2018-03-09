using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    public abstract GameObject Generate(Vector3 position, Quaternion rotation);
}
