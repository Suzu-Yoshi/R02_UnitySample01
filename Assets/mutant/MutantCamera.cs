using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantCamera : MonoBehaviour
{
    [SerializeField, Range(0, 90), TooltipAttribute("カメラの角度を設定します")]
    private int CameraAngle = 0; //カメラの角度

    [SerializeField,Range(0.1f,10.0f), TooltipAttribute("プレイヤーとカメラの距離を設定します")]
    private float distance = 3.5f; //プレイヤーとカメラの距離

    [SerializeField] private Transform player;  // 注視対象プレイヤー

    private Quaternion vRotation;       //カメラの垂直方向
    private Quaternion hRotation;       //カメラの水平方向
    private float turnSpeed = 10.0f;    // 回転速度

    // Start is called before the first frame update
    void Start()
    {
        //回転の初期化
        vRotation = Quaternion.Euler(CameraAngle, 0, 0);
        hRotation = Quaternion.identity;

        //カメラ位置の初期化(後ろに少し引く)
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }

    // Update is called once per frame
    void Update()
    {
        // 水平回転の更新
        if (Input.GetMouseButton(0))
            hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnSpeed, 0);

        //垂直方向の更新
        vRotation = Quaternion.Euler(CameraAngle, 0, 0);

        // カメラの回転(transform.rotation)の更新
        // 方法1 : 垂直回転してから水平回転する合成回転とします
        transform.rotation = hRotation * vRotation;

        // カメラの位置(transform.position)の更新
        // player位置から距離distanceだけ手前に引いた位置を設定します(位置補正版)
        transform.position = player.position + new Vector3(0.0f, 0.5f, 3.0f) - transform.rotation * Vector3.forward * distance;

    }
}
