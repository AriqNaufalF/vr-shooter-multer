using UnityEngine;

public class SpawnArea : MonoBehaviour
{
  public Transform minLocation;
  public Transform maxLocation;
  private float xMin;
  private float zMin;
  private float xMax;
  private float zMax;

  void Start()
  {
    xMin = minLocation.position.x;
    xMax = maxLocation.position.x;
    zMin = minLocation.position.z;
    zMax = maxLocation.position.z;
  }

  // Get random position inside spawn area
  public Vector3 GetRandomPosition()
  {
    float xPosition = Random.Range(xMin, xMax);
    float zPosition = Random.Range(zMin, zMax);
    Debug.Log(new Vector3(xPosition, 0, zPosition).ToString());
    return new Vector3(xPosition, 0, zPosition);
  }
}