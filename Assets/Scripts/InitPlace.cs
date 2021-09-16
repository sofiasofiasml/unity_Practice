using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections; 

public class InitPlace : MonoBehaviour
{
    public GameObject[] casillas;
    public GameObject gameObject; 
    //public int Count;
    [SerializeField] int maphight = 25;
    [SerializeField] int mapWidth = 12;
    private float tileXfloat = 20.0f; 
    private float tileZfloat = 17.0f;
    private int rand;
    SphereCollider myCollier; 
    // Start is called before the first frame update
    void Start()
    {
        //myCollier = GetComponent<SphereCollider>();
        //myCollier.radius = 200;
        CreateHexTileMap();

    }

    void CreateHexTileMap() 
    {
        float mapXmin = -mapWidth / 2;
        float mapXmax = mapWidth / 2;

        float mapZmin = -maphight / 2;
        float mapZmax = maphight / 2; 


        for (float x = mapXmin; x<= mapXmax; x++)
        {
            for (float z = mapZmin; z<= mapZmax; z++) 
            {
                int prob = Random.Range(0, 101);
                Vector3 pos; 

                if (prob < 70)
                    rand = 0; 
                else
                    rand = Random.Range(1, casillas.Length);

                //Vector3 position = new Vector3(20 * k, 0, 20 * j);
                GameObject randObject = Instantiate(casillas[rand]);
				//randObject.transform.parent = gameObject.transform;
				randObject.name = casillas[rand].name;
                if (z % 2 == 0)
                {
                   pos = new Vector3(x * tileXfloat, 0, z * tileZfloat);
                }
                else 
                {
                    pos = new Vector3(x * tileXfloat+ tileXfloat/2, 0, z * tileZfloat);
                }
                StartCoroutine(setTitleInfo(randObject, pos)); 
            }
        }
    }
    IEnumerator setTitleInfo(GameObject GO, Vector3 pos) 
    {
        yield return new WaitForSeconds(0.00001f); 
        GO.transform.position = pos; 
    }
	void OnTriggerExit(Collider other)
	{
        Destroy(other.gameObject); 
	}

	
}
