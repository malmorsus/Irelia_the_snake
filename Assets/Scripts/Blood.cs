using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private int numberOfTrash;
    public int minNumberOfTrash;
    public int maxNumberOfTrash;
    public float flightDistance;
    public GameObject[] trash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BloodBoom()
    {
        numberOfTrash = Random.Range(minNumberOfTrash, maxNumberOfTrash);
        for (int i = 0; i < numberOfTrash; i++)
        {
            int rand = Random.Range(0, trash.Length);
            GameObject trashP = (GameObject)Instantiate(trash[rand], transform.position, Quaternion.identity);
            trashP.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) * flightDistance;
            trashP.transform.Rotate(0, 0, Random.Range(0f, 360f));
            trashP.transform.localScale = new Vector3(Random.Range(60f, 100f), Random.Range(60f, 100f), 0f);
        }
    }
}
