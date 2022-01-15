using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject particlSystem;

    public void Activate()
    {
        particlSystem.SetActive(true);
    }
    public void Deactivate()
    {
        particlSystem.SetActive(false);
    }
}
