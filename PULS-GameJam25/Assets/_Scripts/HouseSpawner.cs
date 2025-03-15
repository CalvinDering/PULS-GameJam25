using UnityEngine;

public class HouseSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] spawnPrefabs;

    [SerializeField] private int width = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private int cellSize = 25;
    [SerializeField] private int roadOffset = 10;

    private void Awake() {

        int spawnIndex = Random.Range(0, spawnPrefabs.Length);
        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                int rotationDir = Random.Range(0, 4);
                Debug.Log(rotationDir);
                Quaternion spawnRotation = Quaternion.Euler(0, 90 * rotationDir, 0);
                float xRotationOffset = rotationDir >= 2 ? cellSize : 0;
                float yRotationOffset = rotationDir == 1 || rotationDir == 2 ? cellSize : 0;
                Vector3 spawnPosition = new Vector3(x * cellSize - xRotationOffset + x * roadOffset, 0, y * cellSize - yRotationOffset + y * roadOffset);

                Instantiate(spawnPrefabs[spawnIndex], spawnPosition, spawnRotation, transform);
            }
        }
    }

}
