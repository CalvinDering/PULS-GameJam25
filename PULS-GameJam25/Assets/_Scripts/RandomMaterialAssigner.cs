using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialAssigner : MonoBehaviour {

    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject wallsBasic;
    [SerializeField] private GameObject walls;
    [SerializeField] private GameObject roofwalls;
    [SerializeField] private GameObject roofs;
    [SerializeField] private GameObject floors;
    [SerializeField] private GameObject doors;
    [SerializeField] private GameObject windows;

    private Dictionary<GameObject, Material[]> dict;

    private void Start() {
        dict = new Dictionary<GameObject, Material[]>();

        AssignRandomMaterial(wallsBasic);
        AssignRandomMaterial(walls, dict[wallsBasic][1], dict[wallsBasic][0]);
        AssignRandomMaterial(roofs);
        AssignRandomMaterial(floors);
        AssignRandomMaterial(doors);
        AssignRandomMaterial(windows);

        AssignRandomMaterial(roofwalls, dict[roofs][0], dict[walls][0]);
    }

    private void AssignRandomMaterial(GameObject category, Material categoryMaterial1 = null, Material categoryMaterial2 = null) {
        Material randomMaterial1 = categoryMaterial1;
        Material randomMaterial2 = categoryMaterial2;
        if(randomMaterial1 == null || randomMaterial2 == null) {
            randomMaterial1 = materials[Random.Range(0, materials.Length)];
            randomMaterial2 = materials[Random.Range(0, materials.Length)];
        }

        Material[] mats = new Material[] { randomMaterial1, randomMaterial2 };

        dict.Add(category, mats);

        foreach(Transform child in category.transform) {
            Renderer renderer = child.GetComponent<Renderer>();
            if(renderer == null) {
                continue;
            }

            Material[] newMaterials = (Material[]) renderer.sharedMaterials.Clone();

            if(newMaterials.Length > 1) {
                newMaterials[0] = randomMaterial1;
                newMaterials[1] = randomMaterial2;
            } else {
                newMaterials[0] = randomMaterial1;
            }

            renderer.sharedMaterials = newMaterials;
        }
    }

}
