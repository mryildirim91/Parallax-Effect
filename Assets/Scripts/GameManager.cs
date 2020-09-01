using StarterKit.Base;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BaseObject[] baseObjects;

    private void Awake()
    {
        CallBaseObjectAwakes();
    }

    private void FixedUpdate()
    {
        CallBaseObjectFixedUpdates();
    }

    private void LateUpdate()
    {
        CallBaseObjectLateUpdate();
    }

    private void CallBaseObjectAwakes()
    {
        for (int i = 0; i < baseObjects.Length; i++)
        {
            baseObjects[i].BaseObjectAwake();
        }
    }

    private void CallBaseObjectFixedUpdates()
    {
        for (int i = 0; i < baseObjects.Length; i++)
        {
            baseObjects[i].BaseObjectFixedUpdate();
        }
    }

    private void CallBaseObjectLateUpdate()
    {
        for (int i = 0; i < baseObjects.Length; i++)
        {
            baseObjects[i].BaseObjectLateUpdate();
        }
    }
}
