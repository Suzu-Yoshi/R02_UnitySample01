using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantMove : MonoBehaviour
{
    [SerializeField, Range(0.1f, 5.0f), TooltipAttribute("プレイヤーの速度を設定します")]
    private float moveSpeed = 1.0f;     //移動速度

    private Vector3 vec;    //移動方向
    private float applySpeed = 0.2f;  //振り向き速度
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //物理法則を取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vec = Vector3.zero; //移動方向を初期化

        if (Input.GetKey(KeyCode.W)) { vec.z += 1; }    //奥
        if (Input.GetKey(KeyCode.S)) { vec.z -= 1; }    //手前
        if (Input.GetKey(KeyCode.A)) { vec.x -= 1; }    //左
        if (Input.GetKey(KeyCode.D)) { vec.x += 1; }    //右

        //移動ベクトルを正規化(1の長さ)にして、Spee分だけ進む
        vec = vec.normalized * moveSpeed * Time.deltaTime;

        //移動しているとき(magnitude：ベクトルの長さを返す)
        if (vec.magnitude > 0)
        {
            //プレイヤーの回転(transform.rotation)の更新
            //無回転状態のプレイヤーのZ+方向(後頭部)を、移動の反対方向(-velocity)に回す回転に段々近づける
            this.transform.rotation
                = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(vec),
                    applySpeed);

            //プレイヤーの位置に足し込む
            transform.position += vec;
        }
    }
}
