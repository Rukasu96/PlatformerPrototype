using UnityEngine;

public class SpreadRandomizer : MonoBehaviour
{
    public static Vector3 RandomSpreadPosition(float maxSpread, Transform objectTransform)
    {
        Vector3 objectPos = objectTransform.position;
        float randPosX = Random.Range(objectPos.x, objectPos.x + maxSpread);
        float randPosZ = Random.Range(objectPos.z, objectPos.z + maxSpread);

        return new Vector3(randPosX, objectPos.y, randPosZ);
    }
}
