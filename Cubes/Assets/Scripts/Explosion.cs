using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion 
{
    public const int MaxRadius = 100;
    public const int MaxForce = 800; 

    public Explosion()
    {
        Radius = MaxRadius;
        Force = MaxForce; 
    }
    
    public int Radius { get; private set; }
    
    public int Force { get; private set; }


    public void Explode(CubeView sourceCube, List<CubeView> childrenCubes)
    {
        List<Collider> collidersInExplosion = Physics.OverlapSphere(sourceCube.transform.position, Radius).ToList();

        List<BoxCollider> childrenCollidersInExplosion = new List<BoxCollider>();

        foreach (CubeView childrenCube in childrenCubes)
        {
            BoxCollider childrenCollider = childrenCube.GetComponent<BoxCollider>(); 

            if (collidersInExplosion.Contains(childrenCollider))
            {
                childrenCollidersInExplosion.Add(childrenCollider); 
            }
        }        

        foreach (BoxCollider childrenCollider in childrenCollidersInExplosion)
        {
            childrenCollider.attachedRigidbody.AddExplosionForce(Force, sourceCube.transform.position, Radius); 
        }
    }
}