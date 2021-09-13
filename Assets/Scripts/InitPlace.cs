using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlace : MonoBehaviour
{
    public GameObject[] casillas;
    public GameObject gameObject; 
    //public int Count;
    [SerializeField] int maphight = 4;
    [SerializeField] int mapWidth = 4;
    private float tileXfloat = 20.0f; 
    private float tileZfloat = 17.0f;
    // Start is called before the first frame update
    void Start()
    {
		CreateHexTileMap();
	}

    void CreateHexTileMap() 
    {
        for (int x = 1; x<= maphight; x++)
        {
            for (int z = 1; z<= mapWidth; z++) 
            {
				int rand = Random.Range(0, casillas.Length);
				//Vector3 position = new Vector3(20 * k, 0, 20 * j);
				GameObject randObject = Instantiate(casillas[0]);
				randObject.transform.parent = gameObject.transform;
				randObject.name = casillas[0].name;
                if (z % 2 == 0)
                {
                    randObject.transform.position = new Vector3(x * tileXfloat, 0, z * tileZfloat);
                }
                else 
                {
                    randObject.transform.position = new Vector3(x * tileXfloat+ tileXfloat/2, 0, z * tileZfloat);
                }
            }
        }
    }
    
}
