using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MutantCamera : MonoBehaviour
{
    [SerializeField, Range(0, 90), TooltipAttribute("カメラの角度を設定します")]
    private int CameraAngle = 0; //カメラの角度

    private Quaternion vRotation;       //カメラの垂直方向
    private Quaternion hRotation;       //カメラの水平方向
    private float turnSpeed = 10.0f;    // 回転速度

    // Start is called before the first frame update
    void Start()
    {
        //回転の初期化
        vRotation = Quaternion.identity;
        hRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton((int)MouseButton.LeftMouse))
        {
            //水平回転の更新
            float mouseX = Input.GetAxis("Mouse X");

            //垂直回転の更新
            float mouseY = Input.GetAxis("Mouse Y");

            float limit = 90.0f;
            float maxLimit = limit;
            float minLimit = 360.0f;

            //現在のオイラー角を取得
            Vector3 localAngle = transform.localEulerAngles;
            //マウスの移動量を加算
            localAngle.x += mouseY;

            //上向きの加算
            if (localAngle.x > maxLimit && localAngle.x < 180)
                localAngle.x = maxLimit;
            
            //下向きの加算
            if (localAngle.x < minLimit && localAngle.x > 180)
                localAngle.x = minLimit;

            //回転処理
            transform.localEulerAngles = localAngle;
            
            //Y軸回転
            var angle = transform.eulerAngles;
            angle.y += mouseX;
            transform.eulerAngles = angle;
        }
    }

}
