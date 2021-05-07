using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDeleter : MonoBehaviour
{
    public List<GameObject> _cubesInTrigger;
    [SerializeField]
    private int _amountOfCubes = 0;
    private GameObject _scoreCounterGameObject;
    private ScoreCounter _scoreCounter;

    private void Start()
    {
        _scoreCounterGameObject = GameObject.Find("ScoreCounter");
        _scoreCounter = _scoreCounterGameObject.GetComponent<ScoreCounter>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _cubesInTrigger.Add(other.gameObject);
        _amountOfCubes++;
        if (_amountOfCubes == 14)
        {
            foreach(GameObject cube in _cubesInTrigger)
            {
                if (cube != null)
                    GameObject.Destroy(cube);
            }
            _amountOfCubes = 0;
            _cubesInTrigger.Clear();
            GameObject[] otherCubes = GameObject.FindGameObjectsWithTag("MadeFloor");
            foreach (GameObject savedCube in otherCubes)
            {
                if (savedCube.transform.position.y > transform.position.y)
                    savedCube.transform.Translate(Vector3.down, Space.World);
            }
            GameObject[] flyingCubes = GameObject.FindGameObjectsWithTag("Block");
            foreach (GameObject savedCube in flyingCubes)
            {
                if (savedCube.transform.position.y > transform.position.y)
                    savedCube.transform.Translate(Vector3.down, Space.World);
            }
            _scoreCounter.UpdateScore(100);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _cubesInTrigger.Remove(other.gameObject);
        _amountOfCubes--;
    }
}
