using UnityEngine;

public class HouseSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] housePrefabs;
    [SerializeField] private GameObject[] targetHousePrefabs;
    [SerializeField] private GameObject[] targetPrefabs;
    [SerializeField] private string[] targetNames;
    [SerializeField] private string[] targetShadowNames;
    [SerializeField] private GameObject[] roadPrefabs;

    [SerializeField] private int width = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private int houseSize = 25;
    [SerializeField] private int roadOffset = 10;
    [SerializeField] private float targetChance = 35;
    [SerializeField] private int targetIndex = 0;

    private int cellsize;

    private void Awake() {

        cellsize = houseSize / 5;

        int houseSpawnIndex = Random.Range(0, housePrefabs.Length);
        int targetHouseSpawnIndex = Random.Range(0, targetHousePrefabs.Length);
        targetIndex = Random.Range(0, targetPrefabs.Length);

        int totalHouses = width * height;

        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                int rotationDir = Random.Range(0, 4);
                Quaternion spawnRotation = Quaternion.Euler(0, 90 * rotationDir, 0);
                float xRotationOffset = rotationDir >= 2 ? houseSize : 0;
                float yRotationOffset = rotationDir == 1 || rotationDir == 2 ? houseSize : 0;
                Vector3 spawnPosition = new Vector3(x * houseSize + xRotationOffset + x * roadOffset, 0, y * houseSize + yRotationOffset + y * roadOffset);


                int spawnTargetRandom = Random.Range(0, totalHouses);

                if(spawnTargetRandom <= targetChance / totalHouses) {

                    bool shouldDestroy = true; 
                    GameObject target = Instantiate(targetHousePrefabs[targetHouseSpawnIndex], spawnPosition, spawnRotation, transform);
                    target.GetComponent<TargetDestructable>().Setup(targetPrefabs[targetIndex], shouldDestroy);
                } else {
                    Instantiate(housePrefabs[houseSpawnIndex], spawnPosition, spawnRotation, transform);
                }


                SpawnRoadAfterHouse(x, y);
            }

            SpawnRoadRow(x);
        }

        UIHandler.Instance.SetTarget(targetNames[targetIndex], targetShadowNames[targetIndex]);
    }

    private void SpawnRoadAfterHouse(int x, int y) {
        if(y != width - 1) {
            for(int i = 0; i < cellsize; i++) {
                Vector3 roadSpawnPosition1 = new Vector3((i + 1) * cellsize + x * houseSize + x * roadOffset, 0, (y + 1) * houseSize + cellsize + y * roadOffset);
                Vector3 roadSpawnPosition2 = new Vector3((i + 1) * cellsize + x * houseSize + x * roadOffset, 0, (y + 1) * houseSize + 2 * cellsize + y * roadOffset);

                SpawnRoad(roadSpawnPosition1);
                SpawnRoad(roadSpawnPosition2);
            }
        }
    }

    private void SpawnRoadRow(int row) {
        if(row != width - 1) {
            for(int i = 0; i < width * houseSize / cellsize + (width - 1) * 2; i++) {
                Vector3 roadSpawnPosition1 = new Vector3((row + 1) * houseSize + cellsize + row * roadOffset, 0, (i + 1) * cellsize);
                Vector3 roadSpawnPosition2 = new Vector3((row + 1) * houseSize + 2 * cellsize + row * roadOffset, 0, (i + 1) * cellsize);

                SpawnRoad(roadSpawnPosition1);
                SpawnRoad(roadSpawnPosition2);
            }
        }
    }

    private void SpawnRoad(Vector3 spawnPosition) {
        int randomSpawnIndex = Random.Range(0, roadPrefabs.Length);
        Instantiate(roadPrefabs[randomSpawnIndex], spawnPosition, Quaternion.identity, transform);
    }
}
