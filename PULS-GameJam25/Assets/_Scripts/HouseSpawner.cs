using UnityEngine;

public class HouseSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] housePrefabs;
    [SerializeField] private GameObject[] roadPrefabs;

    [SerializeField] private int width = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private int houseSize = 25;
    [SerializeField] private int roadOffset = 10;

    private int cellsize;

    private void Awake() {

        int spawnIndex = Random.Range(0, housePrefabs.Length);
        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                int rotationDir = Random.Range(0, 4);
                Quaternion spawnRotation = Quaternion.Euler(0, 90 * rotationDir, 0);
                float xRotationOffset = rotationDir >= 2 ? houseSize : 0;
                float yRotationOffset = rotationDir == 1 || rotationDir == 2 ? houseSize : 0;
                Vector3 spawnPosition = new Vector3(x * houseSize + xRotationOffset + x * roadOffset, 0, y * houseSize + yRotationOffset + y * roadOffset);

                Instantiate(housePrefabs[spawnIndex], spawnPosition, spawnRotation, transform);

                cellsize = houseSize / 5;

                if(y != width - 1) {
                    for(int i = 0; i < cellsize; i++) {
                        Vector3 roadSpawnPosition1 = new Vector3((i + 1) * cellsize + x * houseSize + x * roadOffset, 0, (y + 1) * houseSize + cellsize + y * roadOffset);
                        Vector3 roadSpawnPosition2 = new Vector3((i + 1) * cellsize + x * houseSize + x * roadOffset, 0, (y + 1) * houseSize + 2 * cellsize + y * roadOffset);

                        Instantiate(roadPrefabs[spawnIndex], roadSpawnPosition1, Quaternion.identity, transform);
                        Instantiate(roadPrefabs[spawnIndex], roadSpawnPosition2, Quaternion.identity, transform);
                    }
                }
            }

            if(x != width - 1) {
                for(int i = 0; i < width * houseSize / cellsize + (width - 1) * 2; i++) {
                    Vector3 roadSpawnPosition1 = new Vector3((x + 1) * houseSize + cellsize + x * roadOffset, 0, (i + 1) * cellsize);
                    Vector3 roadSpawnPosition2 = new Vector3((x + 1) * houseSize + 2 * cellsize + x * roadOffset, 0, (i + 1) * cellsize);

                    Instantiate(roadPrefabs[spawnIndex], roadSpawnPosition1, Quaternion.identity, transform);
                    Instantiate(roadPrefabs[spawnIndex], roadSpawnPosition2, Quaternion.identity, transform);
                }
            }

        }
    }
}
