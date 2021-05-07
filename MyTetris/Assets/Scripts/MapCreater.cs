using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreater : MonoBehaviour
{
    private int _mapSizeX = 14;
    private int _mapSizeY = 25;
    [SerializeField]
    private GameObject _cubeDeleter;
    [SerializeField]
    private GameObject _ordinaryCube;
    [SerializeField]
    private GameObject _wall;
    [SerializeField]
    private GameObject _floor;

    void Start()
    {
        Instantiate(_wall, new Vector3(-1, _mapSizeY/2, 10), _wall.transform.rotation);
        for (int i = 0; i < _mapSizeY; i++)
        {
            Instantiate(_cubeDeleter, new Vector3(0, -4 + i, 11), _cubeDeleter.transform.rotation);
            for (int j = 1; j < _mapSizeX; j++)
                Instantiate(_ordinaryCube, new Vector3(0 + j, -4 + i, 11), _ordinaryCube.transform.rotation);
            Instantiate(_wall, new Vector3(-1, -4 + i, 11), _wall.transform.rotation);
        }
        Instantiate(_wall, new Vector3(_mapSizeX, _mapSizeY / 2, 10), _wall.transform.rotation);
        Instantiate(_floor, new Vector3(_mapSizeX / 2, -5, 10), _floor.transform.rotation);
    }
}
