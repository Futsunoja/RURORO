using UnityEngine;
using UnityEngine.UI;

public class MapMove : MonoBehaviour
{
    public GameObject[] map;
    public GameObject[] pla;
    public GameObject place, intro;
    public GameObject MapManu, Girl, go, tra, forg, sav, loa, backmenu;
    float i = 4;
    public int[] j;
    int k;
    bool l, m;

    private void Start()
    {
        k = 1;  //讀取地圖編號
        transform.position = map[k].transform.position;
        pla[0].SetActive(true);
        pla[1].SetActive(false);
        Place();
        m = true;
        go.GetComponent<Image>().color = Color.green;
    }

    private void Update()
    {
        mapManu();
        
        if (Input.GetKeyDown(KeyCode.K) && m == true)
        {
            m = false;
        }

        if (m == false)
        {
            if (Input.GetKeyDown(KeyCode.A) && l == false)
            {
                pla[0].SetActive(true);
                pla[1].SetActive(false);
                l = true;
            }
            if (Input.GetKeyDown(KeyCode.D) && l == false)
            {
                pla[0].SetActive(false);
                pla[1].SetActive(true);
                l = true;
            }
            m0();
            m1();
            m2();
            m3();
            m4();
            m5();
            m6();
            m7();
            m8();
            m9();
            m10();
            m11();
            m12();
            m13();
            m14();
        }

        if(j[0] == 0 && j[1] == 0 && j[2] == 0 && j[3] == 0 && j[4] == 0 && j[5] == 0 && j[6] == 0 && j[7] == 0 && j[8] == 0 && j[9] == 0 && j[10] == 0 && j[11] == 0 && j[12] == 0 && j[13] == 0 && j[14] == 0)
        {
            l = false;
        }
    }
        


    private void m0()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[0].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                j[0] = 1;
            }
        }
        if (j[0] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[1].transform.position, step);
            if (transform.position == map[1].transform.position)
            {
                j[0] = 0;
                l = false;
            }
        }
    }

    private void m1()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[1].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                j[1] = 1;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                j[1] = 2;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                j[1] = 3;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                j[1] = 4;
            }
        }

        if (j[1] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[0].transform.position, step);
            if (transform.position == map[0].transform.position)
            {
                j[1] = 0;
            }
        }
        if (j[1] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[2].transform.position, step);
            if (transform.position == map[2].transform.position)
            {
                j[1] = 0;
            }
        }
        if (j[1] == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[15].transform.position, step);
            if (transform.position == map[15].transform.position)
            {
                j[1] = 5;
            }
        }
        if (j[1] == 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[16].transform.position, step);
            if (transform.position == map[16].transform.position)
            {
                j[1] = 6;
            }
        }
        if (j[1] == 6)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[3].transform.position, step);
            if (transform.position == map[3].transform.position)
            {
                j[1] = 0;
            }
        }
        if (j[1] == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[4].transform.position, step);
            if (transform.position == map[4].transform.position)
            {
                j[1] = 0;
            }
        }
    }

    private void m2()
    {
        float speed = i * Time.deltaTime;
        if (transform.position == map[2].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                j[2] = 1;
            }
        }
        if (j[2] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[1].transform.position, speed);
            if (transform.position == map[1].transform.position)
            {
                j[2] = 0;
            }
        }
    }

    private void m3()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[3].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                j[3] = 1;
            }
        }
        if (j[3] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[16].transform.position, step);
            if (transform.position == map[16].transform.position)
            {
                j[3] = 2;
            }
        }
        if (j[3] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[15].transform.position, step);
            if (transform.position == map[15].transform.position)
            {
                j[3] = 3;
            }
        }
        if (j[3] == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[1].transform.position, step);
            if (transform.position == map[1].transform.position)
            {
                j[3] = 0;
            }
        }
    }

    private void m4()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[4].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                j[4] = 1;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                j[4] = 2;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                j[4] = 3;
            }
        }
        if (j[4] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[1].transform.position, step);
            if (transform.position == map[1].transform.position)
            {
                j[4] = 0;
            }
        }
        if (j[4] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[5].transform.position, step);
            if (transform.position == map[5].transform.position)
            {
                j[4] = 0;
            }
        }
        if (j[4] == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[7].transform.position, step);
            if (transform.position == map[7].transform.position)
            {
                j[4] = 0;
            }
        }
    }

    private void m5()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[5].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                j[5] = 1;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                j[5] = 2;
            }
        }
        if (j[5] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[4].transform.position, step);
            if (transform.position == map[4].transform.position)
            {
                j[5] = 0;
            }
        }
        if (j[5] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[6].transform.position, step);
            if (transform.position == map[6].transform.position)
            {
                j[5] = 0;
            }
        }
    }

    private void m6()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[6].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                j[6] = 1;
            }
        }
        if (j[6] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[5].transform.position, step);
            if (transform.position == map[5].transform.position)
            {
                j[6] = 0;
            }
        }
    }

    private void m7()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[7].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                j[7] = 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                j[7] = 2;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                j[7] = 3;
            }
        }
        if (j[7] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[4].transform.position, step);
            if (transform.position == map[4].transform.position)
            {
                j[7] = 0;
            }
        }
        if (j[7] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[8].transform.position, step);
            if (transform.position == map[8].transform.position)
            {
                j[7] = 0;
            }
        }
        if (j[7] == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[10].transform.position, step);
            if (transform.position == map[10].transform.position)
            {
                j[7] = 0;
            }
        }
    }

    private void m8()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[8].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                j[8] = 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                j[8] = 2;
            }
        }
        if (j[8] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[7].transform.position, step);
            if (transform.position == map[7].transform.position)
            {
                j[8] = 0;
            }
        }
        if (j[8] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[9].transform.position, step);
            if (transform.position == map[9].transform.position)
            {
                j[8] = 0;
            }
        }
    }

    private void m9()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[9].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                j[9] = 1;
            }
        }
        if (j[9] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[8].transform.position, step);
            if (transform.position == map[8].transform.position)
            {
                j[9] = 0;
            }
        }
    }

    private void m10()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[10].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                j[10] = 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                j[10] = 2;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                j[10] = 3;
            }
        }
        if (j[10] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[7].transform.position, step);
            if (transform.position == map[7].transform.position)
            {
                j[10] = 0;
            }
        }
        if (j[10] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[11].transform.position, step);
            if(transform.position== map[11].transform.position)
            {
                j[10] = 0;
            }
        }
        if (j[10] == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[13].transform.position, step);
            if (transform.position == map[13].transform.position)
            {
                j[10] = 0;
            }
        }
    }

    private void m11()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[11].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                j[11] = 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                j[11] = 2;
            }
        }
        if (j[11] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[10].transform.position, step);
            if (transform.position == map[10].transform.position)
            {
                j[11] = 0;
            }
        }
        if (j[11] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[17].transform.position, step);
            if (transform.position == map[17].transform.position)
            {
                j[11] = 3;
            }
        }
        if (j[11] == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[12].transform.position, step);
            if (transform.position == map[12].transform.position)
            {
                j[11] = 0;
            }
        }
    }

    private void m12()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[12].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                j[12] = 1;
            }
        }
        if (j[12] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[17].transform.position, step);
            if (transform.position == map[17].transform.position)
            {
                j[12] = 2;
            }
        }
        if (j[12] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[11].transform.position, step);
            if (transform.position == map[11].transform.position)
            {
                j[12] = 0;
            }
        }
    }

    private void m13()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[13].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                j[13] = 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                j[13] = 2;
            }
        }
        if (j[13] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[10].transform.position, step);
            if (transform.position == map[10].transform.position)
            {
                j[13] = 0;
            }
        }
        if (j[13] == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[14].transform.position, step);
            if (transform.position == map[14].transform.position)
            {
                j[13] = 0;
            }
        }
    }

    private void m14()
    {
        float step = i * Time.deltaTime;
        if (transform.position == map[14].transform.position)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                j[14] = 1;
            }
        }
        if (j[14] == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, map[13].transform.position, step);
            if (transform.position == map[13].transform.position)
            {
                j[14] = 0;
            }
        }
    }

    private void mapManu()
    {
        if (m == true)
        {
            MapManu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (go.GetComponent<Image>().color == Color.green)
                {
                    go.GetComponent<Image>().color = Color.white;
                    forg.GetComponent<Image>().color = Color.green;
                }
                else if (forg.GetComponent<Image>().color == Color.green)
                {
                    forg.GetComponent<Image>().color = Color.white;
                    tra.GetComponent<Image>().color = Color.green;
                }
                else if (tra.GetComponent<Image>().color == Color.green)
                {
                    tra.GetComponent<Image>().color = Color.white;
                    go.GetComponent<Image>().color = Color.green;
                }
                else if (sav.GetComponent<Image>().color == Color.green)
                {
                    sav.GetComponent<Image>().color = Color.white;
                    backmenu.GetComponent<Image>().color = Color.green;
                }
                else if (backmenu.GetComponent<Image>().color == Color.green)
                {
                    backmenu.GetComponent<Image>().color = Color.white;
                    loa.GetComponent<Image>().color = Color.green;
                }
                else if (loa.GetComponent<Image>().color == Color.green)
                {
                    loa.GetComponent<Image>().color = Color.white;
                    sav.GetComponent<Image>().color = Color.green;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (go.GetComponent<Image>().color == Color.green)
                {
                    go.GetComponent<Image>().color = Color.white;
                    tra.GetComponent<Image>().color = Color.green;
                }
                else if (forg.GetComponent<Image>().color == Color.green)
                {
                    forg.GetComponent<Image>().color = Color.white;
                    go.GetComponent<Image>().color = Color.green;
                }
                else if (tra.GetComponent<Image>().color == Color.green)
                {
                    tra.GetComponent<Image>().color = Color.white;
                    forg.GetComponent<Image>().color = Color.green;
                }
                else if (sav.GetComponent<Image>().color == Color.green)
                {
                    sav.GetComponent<Image>().color = Color.white;
                    loa.GetComponent<Image>().color = Color.green;
                }
                else if (backmenu.GetComponent<Image>().color == Color.green)
                {
                    backmenu.GetComponent<Image>().color = Color.white;
                    sav.GetComponent<Image>().color = Color.green;
                }
                else if (loa.GetComponent<Image>().color == Color.green)
                {
                    loa.GetComponent<Image>().color = Color.white;
                    backmenu.GetComponent<Image>().color = Color.green;
                }
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {
                if (go.GetComponent<Image>().color == Color.green)
                {
                    go.GetComponent<Image>().color = Color.white;
                    sav.GetComponent<Image>().color = Color.green;
                }
                else if (forg.GetComponent<Image>().color == Color.green)
                {
                    forg.GetComponent<Image>().color = Color.white;
                    backmenu.GetComponent<Image>().color = Color.green;
                }
                else if (tra.GetComponent<Image>().color == Color.green)
                {
                    tra.GetComponent<Image>().color = Color.white;
                    loa.GetComponent<Image>().color = Color.green;
                }
                else if (sav.GetComponent<Image>().color == Color.green)
                {
                    sav.GetComponent<Image>().color = Color.white;
                    go.GetComponent<Image>().color = Color.green;
                }
                else if (backmenu.GetComponent<Image>().color == Color.green)
                {
                    backmenu.GetComponent<Image>().color = Color.white;
                    forg.GetComponent<Image>().color = Color.green;
                }
                else if (loa.GetComponent<Image>().color == Color.green)
                {
                    loa.GetComponent<Image>().color = Color.white;
                    tra.GetComponent<Image>().color = Color.green;
                }
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (go.GetComponent<Image>().color == Color.green)
                {
                    m = false;
                }
            }
        }
        else if(m == false)
        {
            MapManu.SetActive(false);
        }
    }

    private void Place()
    {
        if (transform.position == map[1].transform.position)
        {
            place.GetComponent<Text>().text = "王城";
        }
        
    }

    //   private void TEST()
    //   float step = 6 * Time.deltaTime;
    //   {
    //       if (transform.position == m11 || py != m14.y)
    //       {
    //           transform.position = Vector3.MoveTowards(transform.position, m14, step);
    //       }
    //   }
}
