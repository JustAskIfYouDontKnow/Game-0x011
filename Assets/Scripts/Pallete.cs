using UnityEngine;
using UnityEngine.Serialization;

public class Pallete : MonoBehaviour
{
    [SerializeField]
    private PalletePoint[] _points;

    [SerializeField]
    private Transform _spawnPoints;

    [SerializeField]
    public Transform loadUnloadZoneTransform;

    public GameObject testPrefab;

    private void Start()
    {
        _points = new PalletePoint[_spawnPoints.childCount];
        for (var i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i).GetComponent<PalletePoint>();
        }
        LoadObject(testPrefab);
    }

    private void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadObject(testPrefab);
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            LoadObject(testPrefab);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Has item " + PalleteHasItem());
        }
    }

    public void LoadObject(GameObject obj)
    {
        for (var i = 0; i < _points.Length; i++)
        {
            if (_points[i].isEmpty)
            {
                Debug.Log("load");
                obj.transform.position = Vector3.zero;
                obj.transform.localScale = Vector3.one;
                Instantiate(obj, _points[i].transform);
                _points[i].isEmpty = false;
            }
        }
    }

    public GameObject UnloadObject()
    {
        for (var i = 0; i < _points.Length; i++)
        {
            if (!_points[i].isEmpty)
            {
                Debug.Log("unload");
                _points[i].isEmpty = true;
                return _points[i].gameObject;
            }
        }

        return null;
    }


    //Проверяем, есть ли хотя-бы одна полная ячейка на паллете
    public bool PalleteHasItem()
    {
        foreach (var item in _points)
        {
            if (!item.isEmpty)
            {
                return true;
            }
        }
        return false;
    }
}