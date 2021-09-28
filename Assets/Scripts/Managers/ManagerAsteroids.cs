using UnityEngine;

public class ManagerAsteroids : MonoBehaviour
{
    public GameObject AsteroidPrefab;

    public int NumberOfAsteroidsOnAxisX = 10;
    public int NumberOfAsteroidsOnAxisY = 10;
    public int NumberOfAsteroidsOnAxisZ = 10;
    public int GridSpacing = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumberOfAsteroidsOnAxisX; i++)
        {
            for (int j = 0; j < NumberOfAsteroidsOnAxisY; j++)
            {
                for (int k = 0; k < NumberOfAsteroidsOnAxisZ; k++)
                {
                    InstantiateAsteroids(i, j, k);
                }
            }
        }
    }

    private void InstantiateAsteroids(int x, int y, int z)
    {
        Instantiate(AsteroidPrefab, new Vector3(
            transform.position.x + x * GridSpacing * OffsetAsteroid(),
            transform.position.y + y * GridSpacing * OffsetAsteroid(),
            transform.position.z + z * GridSpacing * OffsetAsteroid()
        ), Quaternion.identity, transform);
    }

    private float OffsetAsteroid()
    {
        return Random.Range(-GridSpacing / 4f, GridSpacing / 4f);
    }
}
