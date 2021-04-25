using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsTail : MonoBehaviour
{
    public int length = 2;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;
    public Transform[] Swords;

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
    }
}
