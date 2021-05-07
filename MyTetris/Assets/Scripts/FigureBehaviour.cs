using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureBehaviour : MonoBehaviour
{
    private bool _canFall = true;
    private float _fallSpeed = 1f;
    private SpawnFigures _spawnFigures;
    public bool _canMoveRight = true;
    public bool _canMoveLeft = true;
    private void Start()
    {
        StartCoroutine("Falling");
        _spawnFigures = GetComponentInParent<SpawnFigures>();
    }

    IEnumerator Falling()
    {
        while (_canFall)
        {
            transform.Translate(Vector3.down, Space.World);
            yield return new WaitForSeconds(_fallSpeed);
        }
    }

    public void SetPassive()
    {
        ChangeFallingState(false);
        foreach (Transform child in transform)
        {
            child.transform.tag = "MadeFloor";
        }
        transform.SetParent(null);
        _spawnFigures.SpawnFigure();
    }

    public void ChangeFallSpeed(float speed)
    {
        _fallSpeed = speed;
    }

    public void ChangeFallingState(bool canFall)
    {
        _canFall = canFall;
    }
    public bool GetFallingState()
    {
        return _canFall;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
            if (other.transform.position.x - transform.position.x < 0)
                _canMoveLeft = false;
            else
                _canMoveRight = false;
        if (other.CompareTag("MadeFloor"))
        {
            if (other.transform.position.x - transform.position.x > 0)
                _canMoveRight = false;
            else
                _canMoveLeft = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _canMoveLeft = true;
        _canMoveRight = true;
    }
}
