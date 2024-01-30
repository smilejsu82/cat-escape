using UnityEngine;

public class App : MonoBehaviour
{
    [SerializeField] private Transform b;   //child

    private void Start()
    {
        Debug.LogFormat("b.position: {0}", b.position); //world space 
        Debug.LogFormat("b.localPosition: {0}", b.localPosition); //local space 
    }

}
