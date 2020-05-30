using UnityEngine;
using Unity.Entities;

public class PlayerMove : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<UserInput>().ForEach<Rigidbody>((Rigidbody rigidbody) =>
        {
            Vector3 movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            rigidbody.MovePosition(rigidbody.position + movePos * 3 * Time.DeltaTime);
        });
    }
}
public class PlayerRotation : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<UserInput>().ForEach<UserInput, Transform>((ref UserInput userInput, Transform transform) =>
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 joyStickRightAnalog = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (mousePos.magnitude > 0)
            {
                Ray cameraRay = Camera.main.ScreenPointToRay(mousePos);
                if (Physics.Raycast(cameraRay, out var hit, userInput.CameraRayMaxLength, userInput.CameraRayHitLayer))
                {
                    var forward = hit.point - transform.position;
                    forward.y = 0;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward), .5f);
                }
                else
                {
                    var forward = cameraRay.GetPoint(userInput.CameraRayMaxLength);
                    forward.y = 0;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward), .5f);
                }

                // using 
                // Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y)); ;

                // transform.LookAt(mousePos + Vector3.up * transform.position.y);
            }
            else if(joyStickRightAnalog.magnitude>0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(joyStickRightAnalog), .1f);
            }


        });
    }
}
