using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantMove : MonoBehaviour
{
    [SerializeField, Range(0.01f, 1.0f), TooltipAttribute("プレイヤーの速度を設定します")]
    private float moveSpeed = 0.01f;     //移動速度

    [SerializeField]
    private Camera mainCam;

    private Vector3 Rota;              //回転方向
    private Vector3 velo;              //速度方向
    private float applySpeed = 0.2f;   //振り向き速度
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
        //＊＊＊＊＊キャラの回転＊＊＊＊＊

        Rota = Vector3.zero; //移動方向を初期化

        if (Input.GetKey(KeyCode.W)) { Rota.z = +1.0f; }    //奥
        if (Input.GetKey(KeyCode.S)) { Rota.z = -1.0f; }    //手前
        if (Input.GetKey(KeyCode.A)) { Rota.x = -1.0f; }    //左
        if (Input.GetKey(KeyCode.D)) { Rota.x = +1.0f; }    //右

        //移動ベクトルを正規化(1の長さ)にして、Spee分だけ進む
        Rota = Rota.normalized * moveSpeed * Time.deltaTime;

        //移動しているとき(magnitude：ベクトルの長さを返す)
        if (Rota.magnitude > 0)
        {
            //プレイヤーの回転(transform.rotation)の更新
            //無回転状態のプレイヤーのZ+方向(後頭部)を、移動の反対方向(-velocity)に回す回転に段々近づける
            this.transform.rotation
                = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(Rota),
                    applySpeed);
        }

        //＊＊＊＊＊キャラの速度方向＊＊＊＊＊
        velo = new Vector3(0.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.W)) { velo.z = +moveSpeed; }    //奥
        if (Input.GetKey(KeyCode.S)) { velo.z = -moveSpeed; }    //手前
        if (Input.GetKey(KeyCode.A)) { velo.x = -moveSpeed; }    //左
        if (Input.GetKey(KeyCode.D)) { velo.x = +moveSpeed; }    //右

        //移動しているとき(magnitude：ベクトルの長さを返す)
        if (velo.magnitude > 0)
        {
            //速度を加える
            rb.velocity = velo;
        }
    }
}
