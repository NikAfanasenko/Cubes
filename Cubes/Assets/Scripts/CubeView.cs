using System.Collections.Generic;
using UnityEngine;

public class CubeView : MonoBehaviour
{
    private const int Half = 2; 

    [SerializeField]
    private Cube _cube;

    private GeneratorCubes _generator;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();          
    }

    private void OnMouseDown()
    {
        if (RandomUtils.IsFallOut(_cube.AppearChance))
        {
            List<CubeView> cubeViews = _generator.InstantiateCubes(_cube.AppearChance / Half
                                                     , new Vector3(_cube.Scale.x / Half, _cube.Scale.y / Half, _cube.Scale.z / Half));
            
            Explosion explosion = new Explosion();
            explosion.Explode(this, cubeViews); 
        }

        Destroy(gameObject);
    }

    // test commit

    public void Init(Cube cube, GeneratorCubes generator, Material material)
    {
        _cube = cube;
        _generator = generator;
        _meshRenderer.material = material;
        gameObject.transform.localScale = cube.Scale;
    }

}
