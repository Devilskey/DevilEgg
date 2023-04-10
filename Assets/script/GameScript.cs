using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject[] enemy;
    public float spawntimer = 5;
    public Text dif;

    public GameObject[] playertextures;
    public GameObject[] eggtextures;

    public AudioSource deadsound;
    public AudioSource levelsound;


    public float money;
    public Text moneyCount;

    // upgrade health egg
    int healthElvl;
    public Text healthEUpgrade;
    int healthEupgradeprize = 200;

    // Upgrade more health;
    int healthlvl;
    public Text healthUpgrade;
    int healthupgradeprize = 500;

    //Upgrade faster fire power;
    public player p;
    int firelvl;
    public Text fireUpgrade;
    int fireupgradeprize = 50;


    //damage from bullet;
    public Text upgradebullets;
    public float damage = 25;
    int dmglvl;
    int prizebulletUpgrade = 50;

    //regeneration
    public Text regen;
    int regenlvl;
    int regenupgradeprize = 1000;
    bool regenActive;
    float regenpower = 1;

    //egg regen
    public Text regenE;
    int regenElvl;
    int regenEupgradeprize = 1000;
    bool regenEActive;
    float regenEpower = 1;

    //wall upgrade
    public Text wall;
    int walllvl;
    int wallupgradeprize = 500;
    public Color[] wal;

    public float spawned;

    public int dead;
    int d;

    // egg health
    public egg e;

    public GameObject DeadUI;
    public GameObject player;
    public GameObject shop;



    void Start()
    {
        p = FindObjectOfType<player>();
        e = FindObjectOfType<egg>();
    }

    void Update()
    {


        if (dead >= 1)
        {
            if (d == 0)
            {
                levelsound.Stop();
                deadsound.Play();
                d = 1;
            }

            DeadUI.SetActive(true);
            player.SetActive(false);
            shop.SetActive(false);
        }


        ///////////////////////////////textures

        if(healthElvl == 1)
        {
            eggtextures[0].SetActive(false);
            eggtextures[1].SetActive(true);
        }
        if (healthElvl == 2)
        {
            eggtextures[1].SetActive(false);
            eggtextures[2].SetActive(true);
        }
        if (healthElvl == 3)
        {
            eggtextures[2].SetActive(false);
            eggtextures[3].SetActive(true);
        }
        if (healthElvl == 4)
        {
            eggtextures[3].SetActive(false);
            eggtextures[4].SetActive(true);
        }

        if (healthlvl == 1)
        {
            playertextures[0].SetActive(false);
            playertextures[1].SetActive(true);
        }
        if (healthlvl == 2)
        {
            playertextures[1].SetActive(false);
            playertextures[2].SetActive(true);
        }
        if (healthlvl == 3)
        {
            playertextures[2].SetActive(false);
            playertextures[3].SetActive(true);
        }
        if (healthlvl == 4)
        {
            playertextures[3].SetActive(false);
            playertextures[4].SetActive(true);
        }

        if (walllvl == 1)
        {
            p.walcolor = wal[0];
        }
        if (walllvl == 2)
        {
            p.walcolor = wal[1];
        }
        if (walllvl == 3)
        {
            p.walcolor = wal[2];
        }
        if (walllvl == 4)
        {
            p.walcolor = wal[3];
        }
        //////////////////////////////////////textures

        //////////////////////////////////////shop
        moneyCount.text = "$: " + money;


        if(regenActive == true)
        {
            if (p.health < p.h)
            {
                p.health += Time.deltaTime * regenpower;
            }
        }
        if (regenEActive == true)
        {
            if (e.health < e.h)
            {
                e.health += Time.deltaTime * regenEpower;
            }
        }

        if (walllvl < 4)
        {
            int w = walllvl + 1;
            wall.text = "wall lvl" + w + " $" + wallupgradeprize;
        }
        else
        {
            wall.text = "wall max lvl";
        }


        if (healthElvl < 4)
        {
            int h = healthElvl + 1;
            healthEUpgrade.text = "health egg lvl" + h + " $" + healthEupgradeprize;
        }
        else
        {
            healthEUpgrade.text = "health egg max lvl";
        }

        if (regenElvl < 2)
        {
            int rege = regenElvl + 1;
            regenE.text = "regeneration egg lvl" + rege + " $" + regenEupgradeprize;
        }
        else
        {
            regenE.text = "regeneration egg max lvl";
        }

        if (regenlvl < 2)
        {
            int rege = regenlvl + 1;
            regen.text = "regeneration lvl" + rege + " $" + regenupgradeprize;
        }
        else
        {
            regen.text = "regeneration max lvl";
        }

        if (healthlvl < 3)
        {
            int h = healthlvl + 1;
            healthUpgrade.text = "health lvl" + h + " $" + healthupgradeprize;
        }
        else
        {
            healthUpgrade.text = "health max lvl";
        }

        if (dmglvl < 5)
        {
            int d = dmglvl + 1;
            upgradebullets.text = "bullets lvl" + d + " $" + prizebulletUpgrade;
        }


        if (firelvl < 4)
        {
            int f = firelvl + 1;
            fireUpgrade.text = "fire rate lvl" + f + " $" + fireupgradeprize;
        }
        else
        {
            fireUpgrade.text = "fire rate max lvl";
        }

        if (dmglvl < 5)
        {
            int d = dmglvl + 1;
            upgradebullets.text = "bullets lvl" + d + " $" + prizebulletUpgrade;
        }
        else
        {
            upgradebullets.text = "bullets max Level";
        }
        ////////////////////////shop
        
        //////////////////////////////spawn enemys

        float r = Random.Range(0, spawnpoints.Length);
        spawntimer -= Time.deltaTime;
        if(spawntimer < 0)
        {
            if (spawned < 40) {
                dif.text = "difficulty: easy";
                Instantiate(enemy[0], spawnpoints[(int)r].transform.position, spawnpoints[(int)r].transform.rotation);
                spawned += 1;
                spawntimer = 3;
                return;
            }
            if (spawned > 39 && spawned < 100)
            {
                dif.text = "difficulty: normal";
                float r1 = Random.Range(0, 1.4f);
                Instantiate(enemy[(int)r1], spawnpoints[(int)r].transform.position, spawnpoints[(int)r].transform.rotation);
                spawned += 1;
                spawntimer = 2;
                return;
            }
            if (spawned > 99 && spawned < 300)
            {
                dif.text = "difficulty: hard";
                float r1 = Random.Range(0, 2.4f);
                Instantiate(enemy[(int)r1], spawnpoints[(int)r].transform.position, spawnpoints[(int)r].transform.rotation);
                spawned += 1;
                spawntimer = 1.2f;
                return;
            }
            if (spawned > 299)
            {
                dif.text = "difficulty: verry hard";
                float r1 = Random.Range(0, 3.4f);
                Instantiate(enemy[(int)r1], spawnpoints[(int)r].transform.position, spawnpoints[(int)r].transform.rotation);
                spawned += 1;
                spawntimer = 0.5f;
                return;
            }
        }
    }


    //////////////////////////////////////////////////////////////////shop
    public void regenerationUpgrade() {
        if(regenlvl == 0 && money >= 1000)
        {
            regenActive = true;
            regenupgradeprize = 10000;
            money -= 1000;
            regenlvl = 1;
            return;
        }
        if (regenlvl == 1 && money >= 10000)
        {
            regenpower = 2;
            money -= 10000;
            regenlvl = 2;
            return;
        }
    }

    public void regenerationEUpgrade()
    {
        if (regenElvl == 0 && money >= 1000)
        {
            regenEActive = true;
            regenEupgradeprize = 10000;
            money -= 1000;
            regenElvl = 1;
            return;
        }
        if (regenElvl == 1 && money >= 10000)
        {
            regenEpower = 2;
            money -= 10000;
            regenElvl = 2;
            return;
        }
    }




    public void healthUpgrades()
    {
        if (healthlvl == 0 && money >= 500)
        {
            p.health = 125;
            p.h = 125;
            healthlvl = 1;
            healthupgradeprize = 1000;
            money -= 500;
            return;

        }
        if (healthlvl == 1 && money >= 1000)
        {
            p.health = 150;
            p.h = 150;
            healthlvl = 2;
            healthupgradeprize = 2000;
            money -= 1000;
            return;
        }
        if (healthlvl == 2 && money >= 2000)
        {
            p.health = 200;
            p.h = 200;
            healthlvl = 3;
            money -= 2000;
            return;
        }
    }


    public void fireUpgrades()
    {
        if(firelvl == 0 && money >= 50)
        {
            p.sp = 0.3f;
            firelvl = 1;
            money -= 50;
            fireupgradeprize = 200;
            return;

        }
        if (firelvl == 1 && money >= 200)
        {
            p.sp = 0.3f;
            firelvl = 2;
            money -= 200;
            fireupgradeprize = 500;
            return;
        }
        if (firelvl == 2 && money >= 500)
        {
            p.sp = 0.2f;
            firelvl = 3;
            money -= 500;
            fireupgradeprize = 1000;
            return;
        }
        if (firelvl == 3 && money >= 1000)
        {
            p.sp = 0.1f;
            firelvl = 1;
            firelvl = 4;
            money -= 1000;
            return;
        }
    }


    public void damageUpgrade()
    {
        if(dmglvl == 0 && money >= 50)
        {
            money -= 50;
            damage = 30;
            prizebulletUpgrade = 100;
            dmglvl = 1;
            return;
        }
        if (dmglvl == 1 && money >= 100)
        {
            money -= 100;
            prizebulletUpgrade = 200;
            damage = 35;
            dmglvl = 2;
            return;
        }
        if (dmglvl == 2 && money >= 200)
        {
            money -= 200;
            damage = 40;
            prizebulletUpgrade = 500;
            dmglvl = 3;
            return;
        }
        if (dmglvl == 3 && money >= 500)
        {
            money -= 500;
            damage = 50;
            prizebulletUpgrade = 1000;
            dmglvl = 4;
            return;
        }
        if (dmglvl == 4 && money >= 1000)
        {
            money -= 1000;
            damage = 100;
            dmglvl = 5;
            return;
        }
    }
    public void eggUpgradeHealth()
    {
        if(healthElvl == 0 && money >= 200)
        {
            e.health = 110;
            e.h = 110;
            healthElvl = 1;
            money -= 200;
            healthEupgradeprize = 500;
            return;
        }
        if (healthElvl == 1 && money >= 500)
        {
            e.health = 125;
            e.h = 125;
            healthElvl = 2;
            money -= 500;
            healthEupgradeprize = 1000;
            return;
        }
        if (healthElvl == 2 && money >= 1000)
        {
            e.health = 150;
            e.h = 150;
            healthElvl = 3;
            money -= 1000;
            healthEupgradeprize = 10000;
            return;
        }
        if (healthElvl == 3 && money >= 10000)
        {
            e.health = 200;
            e.h = 200;
            healthElvl = 4;
            money -= 10000;
            healthEupgradeprize = 10000;
            return;
        }
    }
    public void UpgradeWall()
    {
        if(walllvl == 0 && money >= 500)
        {
            money -= 500;
            walllvl = 1;
            wallupgradeprize = 1000;
            p.walltime = 15;
            return;
        }

        if (walllvl == 1 && money >= 1000)
        {
            money -= 1000;
            walllvl = 2;
            wallupgradeprize = 5000;
            p.walltime = 20;
            return;
        }
        if (walllvl == 2 && money >= 5000)
        {
            money -= 5000;
            walllvl = 3;
            wallupgradeprize = 10000;
            p.walltime = 25;
            return;
        }
        if (walllvl == 3 && money >= 10000)
        {
            money -= 10000;
            walllvl = 4;
            p.walltime = 30;
            return; 
        }
    }
    ////////////////////////////////////shop
    ///
    public void playAgain()
    {
        SceneManager.LoadScene(1);
    }
}