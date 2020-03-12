using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGyro: MonoBehaviour
{

    public int speed;
    private Quaternion _origin = Quaternion.identity;


    private void getOrigin()
    {
        _origin = Input.gyro.attitude;
    }

    private void Start()
    {
        Input.gyro.enabled = true;
        getOrigin();
    }

    void Update()
    {
        float transX = Input.GetAxis("Horizontal") * speed;
        float transY = Input.GetAxis("Vertical") * speed;
        
        transform.Rotate(transY * Time.deltaTime,0, transX * Time.deltaTime);
        //this.transform.rotation = ConvertRightHandedToLeftHandedQuaternion(Input.gyro.attitude);
    }

    private Quaternion ConvertRightHandedToLeftHandedQuaternion(Quaternion rightHandedQuaternion)
    {
        return new Quaternion(-rightHandedQuaternion.x,
                               -rightHandedQuaternion.z,
                               -rightHandedQuaternion.y,
                                rightHandedQuaternion.w);
    }
}
