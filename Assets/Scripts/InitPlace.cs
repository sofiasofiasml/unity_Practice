using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections; 

public class InitPlace : MonoBehaviour
{
    public GameObject[] casillas;
    public GameObject gameObject; 
    //public int Count;
    [SerializeField] int maphight = 24;
    [SerializeField] int mapWidth = 24;
    private float tileXfloat = 40.0f; 
    private float tileZfloat = 34.0f;
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


        for (float x = -3; x<= 3; x++)
        {
            for (float z = -3; z<= 3; z++) 
            {
                if ((x>=-2 && x<2) || (x == -3 && z>=-1 && z<=1 )|| (x==3 && z==0 ) ||(x==2 && (z>-3 && z<3)) ) { 
                int prob = Random.Range(0, 101);
                Vector3 pos; 

                if (prob < 70 || x==0 && z==0) 
                    rand = 0; 
                else
                    rand = Random.Range(1, casillas.Length);

                //Vector3 position = new Vector3(20 * k, 0, 20 * j);
                GameObject randObject = Instantiate(casillas[rand]);
				randObject.transform.parent = gameObject.transform;
				randObject.name = x+" "+z;
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
    }
    IEnumerator setTitleInfo(GameObject GO, Vector3 pos) 
    {
        yield return new WaitForSeconds(0.00001f); 
        GO.transform.position = pos; 
    }
	//void OnTriggerExit(Collider other)
	//{
 //       Destroy(other.gameObject); 
	//}

	
}
