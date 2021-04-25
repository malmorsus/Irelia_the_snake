using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsTail : MonoBehaviour
{
    public int length = 2;
    public Vector3[] segmentPoses;
    public Vector3[] segmentPoses1;
    private Vector3[] segmentV;
    public List<GameObject> Swords = new List<GameObject>();

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    void Start()
    {
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }


    void Update()
    {
        segmentPoses[0] = transform.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
            Swords[i - 1].transform.position = segmentPoses[i];
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            if(Swords.Count - 1 >= 0)
                ThrowSword(Swords[Swords.Count - 1]);
        }
        */
    }

    
    public void CollectSword(GameObject sword)
    {
        Swords.Add(sword);
        length += 1;
        segmentPoses1 = new Vector3[length];
        for (int i = 0; i < segmentPoses1.Length - 1; i++)
        {
            segmentPoses1[i] = segmentPoses[i];
        }
        segmentPoses1[segmentPoses1.Length - 1] = transform.position;
        segmentPoses = segmentPoses1;
        segmentV = new Vector3[length];
    }

    public void CanIThrowSword()
    {
        if (Swords.Count - 1 >= 0)
            ThrowSword(Swords[Swords.Count - 1]);
    }


    public void ThrowSword(GameObject sword)
    {
        Swords.Remove(sword);
        Destroy(sword.gameObject);
        length -= 1;
        segmentPoses1 = new Vector3[length];
        for (int i = 0; i < segmentPoses1.Length; i++)
        {
            segmentPoses1[i] = segmentPoses[i];
        }
        segmentPoses = segmentPoses1;
        segmentV = new Vector3[length];
    }
    
}
