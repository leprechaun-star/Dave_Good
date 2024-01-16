using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

[ExecuteInEditMode]
public class SplineRoads : MonoBehaviour
{
    [SerializeField]
    private SplineContainer m_splineContainer;

    [SerializeField]
    private int m_splineIndex;
    [SerializeField]
    [Range(0f, 1f)]
    private float m_time;
    private float m_width;

    float3 position;
    float3 forward;
    float3 upVector;


    private void Update()
    {
        




    }

    private void OnDrawGizmos()
    {
        
    }
}
