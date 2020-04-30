using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("怪物資料")]
    public MonsterData data;
    [Header("補血藥水")]
    public GameObject propHp;
    [Header("加速藥水")]
    public GameObject propCD;
    [Header("發射物件")]
    public GameObject bullet;

    // 補血藥水掉落機率 : 30% (0.3)
    // Random.Range(0, 1) - 小於 0.3
    // if (隨機 <= 0.3) 掉落補血藥水

    private Animator ani;
    private float hp;
    private float timer;          // 計時器

    private void Start()
    {
        hp = data.hp;
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收到的傷害值</param>
    public void Damage(float damage)
    {
        hp -= damage;

        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡開關", true);
        DropProp();
        Destroy(gameObject, 0.1f);
    }

    /// <summary>
    /// 掉落道具
    /// </summary>
    private void DropProp()
    {
        float rHP = Random.Range(0f, 1f);
        if (rHP <= data.propHP) Instantiate(propHp, transform.position + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
        float rCD = Random.Range(0f, 1f);
        if (rCD <= data.propCD) Instantiate(propCD, transform.position + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
    }

    /// <summary>
    /// 攻擊 : 發射物件
    /// </summary>
    private void Attack()
    {
        timer += Time.deltaTime;

        if (timer >= data.cd)
        {
            timer = 0;
            GameObject temp = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
            temp.AddComponent<Move>().speed = data.bulletSpeed;
            temp.AddComponent<Ball>().damage = data.attack;
            temp.GetComponent<Ball>().type = "怪物";
        }
    }
}
