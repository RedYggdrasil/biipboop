﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRad;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public bool checkingForTargets = true;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public float meshResolution;
    public MeshFilter viewMeshFilter;
    Mesh viewMesh;


    void Start() 
    {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }

    void LateUpdate() 
    {
        DrawFieldOfView();
    }

    IEnumerator FindTargetsWithDelay(float delay) 
    {
        while (checkingForTargets) {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets() 
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRad = Physics.OverlapSphere(transform.position, viewRad, targetMask);
        
        for (int i=0; i < targetsInViewRad.Length; i++) 
        {
            Transform target = targetsInViewRad[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle/2) {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }
        }
     }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) 
    {
        if (!angleIsGlobal) {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees*Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees*Mathf.Deg2Rad));
    }

    void DrawFieldOfView() 
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        for (int i=0; i <= stepCount; i++) 
        {
            float angle = transform.eulerAngles.y - viewAngle/2 + i*stepAngleSize;
            ViewCastInfo newViewCast = ViewCast(angle);
            viewPoints.Add(newViewCast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount-2)*3];

        vertices[0] = Vector3.zero;
        for (int i=0; i < vertexCount-1; i++) 
        {
            vertices[i+1] = transform.InverseTransformPoint(viewPoints[i]);
            if (i<vertexCount-2) 
            {
                triangles[i*3] = 0;
                triangles[i*3+1] = i+1;
                triangles[i*3+2] = i+2;
            }
        }
        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();

    }

    public struct ViewCastInfo 
    {
        public bool hit;
        public Vector3 point;
        public float dist;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dist, float _angle) 
        {
            hit = _hit;
            point = _point;
            dist = _dist;
            angle = _angle;
        }
    }

    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, dir, out hit, viewRad, obstacleMask)) 
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position+dir*viewRad, viewRad, globalAngle);
        }
    }
}
