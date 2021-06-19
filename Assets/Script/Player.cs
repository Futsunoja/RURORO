using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject c1, c2, c3, c4;
    bool i0, i1, i2, i3, i4, i5, i6, i7, i8, i9, ispr0, ispr1, ispr2, ispr3;
    Vector3 c = new Vector3(-2.4f, 0, 0);
    Vector3 o = new Vector3(0.4f, 0, 0);
    public Sprite spr11, spr12, spr13, spr14, spr21, spr22, spr23, spr24, spr31, spr32, spr33, spr34, spr0;

    private void Start()
    {
        c1.transform.localPosition = c;
        c2.transform.localPosition = c;
        c3.transform.localPosition = c;
        c4.transform.localPosition = c;

        i0 = false;     //選項(收)階段一是否開始
        i1 = true;      //i1是否介於(0,0,0)與(0.4,0,0)之間
        i2 = false;     //i2是否介於(0,0,0)與(0.4,0,0)之間
        i3 = false;     //i3是否介於(0,0,0)與(0.4,0,0)之間
        i4 = false;     //i4是否介於(0,0,0)與(0.4,0,0)之間
        i5 = false;     //選項(收)階段二是否開始

        i6 = false;     //是否選擇攻擊或逃跑
        i7 = false;     //戰鬥開始
        i8 = false;     //是否最終選擇
        i9 = false;     //是否在執行中

        ispr1 = true;   //是否為主選項
        ispr2 = false;  //是否為技能選項
        ispr3 = false;  //是否為道具選項
        ispr0 = false;  //是否為行動中

        SpriteRenderer c1spr = c1.GetComponent<SpriteRenderer>();
        SpriteRenderer c2spr = c2.GetComponent<SpriteRenderer>();
        SpriteRenderer c3spr = c3.GetComponent<SpriteRenderer>();
        SpriteRenderer c4spr = c4.GetComponent<SpriteRenderer>();
        c1spr.sprite = spr11;
        c2spr.sprite = spr12;
        c3spr.sprite = spr13;
        c4spr.sprite = spr14;

    }

    private void Update()
    {
        if (i7 == false)
        {
            BS();
        }
        else
        {
            CT();
            CAD();
        }
    }

    private void CT()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (i1 == true)
            {
                c1.transform.localPosition = Vector3.zero;
                c2.transform.localPosition = o;
                i1 = false;
                i2 = true;
            }
            else if (i2 == true)
            {
                c2.transform.localPosition = Vector3.zero;
                c3.transform.localPosition = o;
                i2 = false;
                i3 = true;
            }
            else if (i3 == true)
            {
                c3.transform.localPosition = Vector3.zero;
                c4.transform.localPosition = o;
                i3 = false;
                i4 = true;
            }
            else if (i4 == true)
            {
                c4.transform.localPosition = Vector3.zero;
                c1.transform.localPosition = o;
                i4 = false;
                i1 = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (i1 == true)
            {
                c1.transform.localPosition = Vector3.zero;
                c4.transform.localPosition = o;
                i1 = false;
                i4 = true;
            }
            else if (i2 == true)
            {
                c2.transform.localPosition = Vector3.zero;
                c1.transform.localPosition = o;
                i2 = false;
                i1 = true;
            }
            else if (i3 == true)
            {
                c3.transform.localPosition = Vector3.zero;
                c2.transform.localPosition = o;
                i3 = false;
                i2 = true;
            }
            else if (i4 == true)
            {
                c4.transform.localPosition = Vector3.zero;
                c3.transform.localPosition = o;
                i4 = false;
                i3 = true;
            }
        }
    }

    private void BS()
    {
        SpriteRenderer c1spr = c1.GetComponent<SpriteRenderer>();
        SpriteRenderer c2spr = c2.GetComponent<SpriteRenderer>();
        SpriteRenderer c3spr = c3.GetComponent<SpriteRenderer>();
        SpriteRenderer c4spr = c4.GetComponent<SpriteRenderer>();
        float step = 6 * Time.deltaTime;
        if (i7 == false)
        {
            c1spr.sprite = spr11;
            c2spr.sprite = spr12;
            c3spr.sprite = spr13;
            c4spr.sprite = spr14;
            if (c4.transform.localPosition != Vector3.zero)
            {
                c4.transform.localPosition = Vector3.MoveTowards(c4.transform.localPosition, Vector3.zero, step);
            }
            if (c4.transform.localPosition.x >= -2 && c3.transform.localPosition != Vector3.zero)
            {
                c3.transform.localPosition = Vector3.MoveTowards(c3.transform.localPosition, Vector3.zero, step);
            }
            if (c3.transform.localPosition.x >= -2 && c2.transform.localPosition != Vector3.zero)
            {
                c2.transform.localPosition = Vector3.MoveTowards(c2.transform.localPosition, Vector3.zero, step);
            }
            if (c2.transform.localPosition.x >= -2 && c1.transform.localPosition != Vector3.zero)
            {
                c1.transform.localPosition = Vector3.MoveTowards(c1.transform.localPosition, o, step);
                if (c1.transform.localPosition == o)
                {
                    i7 = true;
                }
            }
        }
    }

    private void CAD()
    {
        SpriteRenderer c1spr = c1.GetComponent<SpriteRenderer>();
        SpriteRenderer c2spr = c2.GetComponent<SpriteRenderer>();
        SpriteRenderer c3spr = c3.GetComponent<SpriteRenderer>();
        SpriteRenderer c4spr = c4.GetComponent<SpriteRenderer>();
        float step = 6 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J) && i9 == false)
        {
            i9 = true;
            if (ispr1 == true)
            {
                if (c1.transform.localPosition == o || c4.transform.localPosition == o)
                {
                    ispr0 = true;
                    ispr1 = false;
                }
                if (c2.transform.localPosition == o)
                {
                    ispr1 = false;
                    ispr2 = true;
                }
                if (c3.transform.localPosition == o)
                {
                    ispr1 = false;
                    ispr3 = true;
                }
            }
            else if (ispr2 == true)
            {
                ispr0 = true;
                ispr2 = false;
            }
            else if (ispr3 == true)
            {
                ispr0 = true;
                ispr3 = false;
            }
            i0 = true;
        }
        if (Input.GetKeyDown(KeyCode.K) && i9==false)
        {
            i9 = true;
            if (ispr2 == true || ispr3 == true)
            {
                ispr0 = false;
                ispr1 = true;
                ispr2 = false;
                ispr3 = false;
                i0 = true;
            }
        }

        if (i0 == true)
        {
            if (i1 == true)
            {
                c1.transform.localPosition = Vector3.MoveTowards(c1.transform.localPosition, Vector3.zero, step);
                if (c1.transform.transform.localPosition == Vector3.zero)
                {
                    i1 = false;
                    if (i1 == false && i2 == false && i3 == false && i4 == false)
                    {
                        i5 = true;
                    }
                }
            }
            if (i2 == true)
            {
                c2.transform.localPosition = Vector3.MoveTowards(c2.transform.localPosition, Vector3.zero, step);
                if (c2.transform.transform.localPosition == Vector3.zero)
                {
                    i2 = false;
                    if (i1 == false && i2 == false && i3 == false && i4 == false)
                    {
                        i5 = true;
                    }
                }
            }
            if (i3 == true)
            {
                c3.transform.localPosition = Vector3.MoveTowards(c3.transform.localPosition, Vector3.zero, step);
                if (c3.transform.transform.localPosition == Vector3.zero)
                {
                    i3 = false;
                    if (i1 == false && i2 == false && i3 == false && i4 == false)
                    {
                        i5 = true;
                    }
                }
            }
            if (i4 == true)
            {
                c4.transform.localPosition = Vector3.MoveTowards(c4.transform.localPosition, Vector3.zero, step);
                if (c4.transform.transform.localPosition == Vector3.zero)
                {
                    i4 = false;
                    if (i1 == false && i2 == false && i3 == false && i4 == false)
                    {
                        i5 = true;
                    }
                }
            }

            if (i1 == false && i2 == false && i3 == false && i4 == false && i5 == true)
            {
                if (c1.transform.localPosition != c)
                {
                    c1.transform.localPosition = Vector3.MoveTowards(c1.transform.localPosition, c, step);
                }
                if (c1.transform.localPosition.x <= -0.4 && c2.transform.localPosition != c)
                {
                    c2.transform.localPosition = Vector3.MoveTowards(c2.transform.localPosition, c, step);
                }
                if (c2.transform.localPosition.x <= -0.4 && c3.transform.localPosition != c)
                {
                    c3.transform.localPosition = Vector3.MoveTowards(c3.transform.localPosition, c, step);
                }
                if (c3.transform.localPosition.x <= -0.4 && c4.transform.localPosition != c)
                {
                    c4.transform.localPosition = Vector3.MoveTowards(c4.transform.localPosition, c, step);
                    if (c4.transform.localPosition == c)
                    {
                        if (ispr0 == true)
                        {
                            c1spr.sprite = spr0;
                            c2spr.sprite = spr0;
                            c3spr.sprite = spr0;
                            c4spr.sprite = spr0;
                            i5 = false;
                        }
                        if (ispr1 == true)
                        {
                            c1spr.sprite = spr11;
                            c2spr.sprite = spr12;
                            c3spr.sprite = spr13;
                            c4spr.sprite = spr14;
                            i5 = false;
                        }
                        if (ispr2 == true)
                        {
                            c1spr.sprite = spr21;
                            c2spr.sprite = spr22;
                            c3spr.sprite = spr23;
                            c4spr.sprite = spr24;
                            i5 = false;
                        }
                        if (ispr3 == true)
                        {
                            c1spr.sprite = spr31;
                            c2spr.sprite = spr32;
                            c3spr.sprite = spr33;
                            c4spr.sprite = spr34;
                            i5 = false;
                        }
                    }
                }
            }
            if (i1 == false &&i2 == false && i3 == false && i4 == false && i5 == false && i6 == false)
            {
                if (c4.transform.localPosition != Vector3.zero)
                {
                    c4.transform.localPosition = Vector3.MoveTowards(c4.transform.localPosition, Vector3.zero, step);
                }
                if (c4.transform.localPosition.x >= -2 && c3.transform.localPosition != Vector3.zero)
                {
                    c3.transform.localPosition = Vector3.MoveTowards(c3.transform.localPosition, Vector3.zero, step);
                }
                if (c3.transform.localPosition.x >= -2 && c2.transform.localPosition != Vector3.zero)
                {
                    c2.transform.localPosition = Vector3.MoveTowards(c2.transform.localPosition, Vector3.zero, step);
                }
                if (c2.transform.localPosition.x >= -2 && c1.transform.localPosition != Vector3.zero)
                {
                    c1.transform.localPosition = Vector3.MoveTowards(c1.transform.localPosition, o, step);
                    if (c1.transform.localPosition == o)
                    {
                        i1 = true;
                        i5 = true;
                        i0 = false;
                        i9 = false;
                    }
                }
            }
        }
    }
}
