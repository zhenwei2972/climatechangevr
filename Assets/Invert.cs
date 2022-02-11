using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Invert : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public MeshCollider meshCollider;

    private void Awake()
    {
        if (!meshCollider) meshCollider = GetComponent<MeshCollider>();

        var mesh = meshCollider.sharedMesh;

        // Reverse the triangles
        mesh.triangles = mesh.triangles.Reverse().ToArray();

        // also invert the normals
        mesh.normals = mesh.normals.Select(n => -n).ToArray();
    }
}
