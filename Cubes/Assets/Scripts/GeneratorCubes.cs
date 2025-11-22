using System.Collections.Generic;
using UnityEngine;

public class GeneratorCubes : MonoBehaviour
{
    [SerializeField]
    private GameObject _cubeInstance;

    [SerializeField]
    private Material _dafaultMaterial; 

    private void Awake()
    {        
        InstantiateCubes(RandomUtils.MaxChance, Vector3.one); 
    }

    public List<CubeView> InstantiateCubes(float chance, Vector3 scale)
    {       
        int count = RandomUtils.GetRandomCubeCount();

        List<CubeView> cubeViewList = new List<CubeView>(count);

        for (int i = 0; i < count; i++)
        {
            GameObject cubeInstance = Instantiate(_cubeInstance, RandomUtils.GetRandomPosition(), Quaternion.identity);
            CubeView cubeView = cubeInstance.GetComponent<CubeView>();
            cubeView.Init(new Cube(chance, scale), this, GetNewMaterial(_dafaultMaterial));
            cubeViewList.Add(cubeView);
        }  

        return cubeViewList;
    }

    public Material GetNewMaterial(Material material)
    {
        Material newMaterial = new Material(material);
        newMaterial.color = RandomUtils.GetRandomColor();
        return newMaterial;
    }

}
