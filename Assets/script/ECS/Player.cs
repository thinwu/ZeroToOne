using UnityEngine;
using Unity.Entities;
public class Player : MonoBehaviour, IConvertGameObjectToEntity
{
    public float cameraRayMaxLength;
    public LayerMask cameraRayHitLayer;
    void IConvertGameObjectToEntity.Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        entityManager.AddComponentData(entity, new UserInput { CameraRayHitLayer = cameraRayHitLayer, CameraRayMaxLength = cameraRayMaxLength });
        //Debug.Log("IConvertGameObjectToEntity");
    }
}
