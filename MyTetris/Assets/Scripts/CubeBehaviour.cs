using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    private FigureBehaviour _figureBehaviour;
    private void Start()
    {
        _figureBehaviour = GetComponentInParent<FigureBehaviour>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("MadeFloor")) && (gameObject.tag != "MadeFloor"))
        {
            _figureBehaviour.SetPassive();
        }
    }

}
