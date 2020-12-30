using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerScript2 : MonoBehaviour
{
	public GameObject Byutto;
	public Transform byutto;
	public GameObject button;

	float BPD1;
	float BED1;

	float BPD2;
	float BED2;

	float BPD3;
	float BED3;

	float Player;
	float Enemy;

	float Enearest;
	public int scorecount;
	

	[SerializeField]
	private GameObject EnemyBall1;

	[SerializeField, Range(0F, 90F)]
	private float ThrowingAngle;

	public GameObject Ball2;
	public GameObject GameManager;

	GameObject player1;
	Rigidbody Prb1;

	GameObject player2;
	Rigidbody Prb2;

	GameObject player3;
	Rigidbody Prb3;

	GameObject enemy1;
	Rigidbody Erb1;

	GameObject enemy2;
	Rigidbody Erb2;

	GameObject enemy3;
	Rigidbody Erb3;


	bool shotbutton = true;

	bool Trueplayer;//float Playerに数値格納したかどうか
	bool Trueenemy;//float Enemyに数値格納したかどうか

	public int count2;
	public int enemycount2;

	Ball2Script script1;
	MoveGameManager moveGameManagerscript;

	[SerializeField]
	GameObject PowerMeterObject;

	public float forceMagnitude = 0f;

	[SerializeField, Range(0f, 90f)]
	float forceAngle = 45.0f;

	bool isFlying = false;
	bool isBoostPressed = false;
	bool isCheckingDistance = false;

	bool movePowerMeter = true;

	bool firstShot;
	bool secondShot;
	bool thirdShot;
	bool firstShotEnemy;
	bool secondShotEnemy;//secondShotEnemy=happyMiyuki
	bool thirdShotEnemy;

	bool happyMiyuki;

	bool DegreeDecision;
	bool PushButton;
	public GameObject DegreeImage;
	public GameObject DesideButton;

	public GameObject Sli;
	public GameObject BoostButton;

	Vector3 initPosition = Vector3.zero;
	Vector3 stopPosition = Vector3.zero;
	Rigidbody rb;

	Slider PowerMeterSlider;

	[SerializeField]
	float meterSpeed = 0.5f;

	[SerializeField]
	float delayTime = 0.08f;
	float waitTime = 0f;

	bool isMeterIncreasing = true;

	int ButtonCount2;
	public float speed;
	int fugo = 1;

	bool touch;

	public GameObject Stopsound;
	public GameObject Boostsound;
	void Start()
	{
		initPosition = gameObject.transform.position;
		PowerMeterSlider = PowerMeterObject.GetComponent<Slider>();
		script1 = Ball2.GetComponent<Ball2Script>();
		GameManager = GameObject.Find("GameManager");
		moveGameManagerscript = GameManager.GetComponent<MoveGameManager>();

		FirstTurn();
		DegreeDecision = true;
		
	}

	void Update()
	{
		Move();

        if (DegreeDecision == true)
        {
			DegreeImage.SetActive(true);
			DesideButton.SetActive(true);
			Sli.SetActive(false);
			BoostButton.SetActive(false);

        }
        else
        {
			DegreeImage.SetActive(true);
			DesideButton.SetActive(false);
			Sli.SetActive(true);
			BoostButton.SetActive(true);
		}
		//Quaternion quaternion = this.transform.rotation;
		// float y = this.transform.rotation.y;
		if (movePowerMeter == true)
		{
			MovePowerMeter();
		}

		if (firstShot == true)
		{
			FirstTurn();
		}
		if (firstShotEnemy == true)
		{
			if (Erb1.IsSleeping())
			{
				BPD1 = Vector3.Distance(byutto.position, player1.transform.position);
				BED1 = Vector3.Distance(byutto.position, enemy1.transform.position);
				ThirdTurn();
			}
		}
		if (secondShot == true)
		{
			if (Prb2.IsSleeping())
			{
				BPD2 = Vector3.Distance(byutto.position, player2.transform.position);
				if (BPD1 > BPD2 == true)
				{
					Player = BPD2;
					if (enemycount2 == 1)
					{
						if (BED1 > Player)
						{
							
							Trueenemy = true;//PEP→E
							FourthTurn();
						}
						else
						{
							
							Trueplayer = true;//PEP→P
							FourthTurn();
						}
					}
					if (enemycount2 == 2 && Erb2.IsSleeping())
					{
						if (Player > Enemy)
						{
							
							Trueplayer = true;//PEEP→P
							FifthTurn();
						}
						else
						{
							
							Trueenemy = true;//PEEP→E
							FifthTurn();
						}
					}
                    if (enemycount2 == 3)
                    {
						
						Trueplayer=true;
						SixthTurn();
                    }
				}
				else
				{
					Player = BPD1;
					if (enemycount2 == 1)
					{
						if (BED1 > Player)
						{
							
							Trueenemy = true;//PEP→E
							FourthTurn();
						}
						else
						{
							
							Trueplayer = true;//PEP→P
							FourthTurn();
						}
					}
					if (enemycount2 == 2 && Erb2.IsSleeping())
					{
						if (Player > Enemy)
						{
							
							Trueplayer = true;//PEEP→P
							FifthTurn();
						}
						else
						{
							
							Trueenemy = true;//PEEP→E
							FifthTurn();
						}
					}
					if (enemycount2 == 3)
					{
						
						Trueplayer = true;
						SixthTurn();
					}
				}

			}
		}
		
		if (happyMiyuki == true)//secondShotEnemy=happyMiyuki
		{
			if (Erb2.IsSleeping())
			{
				BED2 = Vector3.Distance(byutto.position, enemy2.transform.position);
				if (BED1 > BED2 == true)
				{
					Enemy = BED2;
					if (count2 == 2)
					{
						if (Player > Enemy == true)
						{
							
							Trueplayer = true;
							FifthTurn();//PEPE→P
						}
						else
						{
							
							Trueenemy = true;//PEPE→E
							FifthTurn();
						}
					}
					if (count2 == 3)
					{
						if (Player > Enemy)
						{
							
							SceneManager.LoadScene("LoseScene");//Player3球の最短がEnemyよりも遠いときは負け確定（PEPPE）
						}
						else
						{
							
							Trueenemy = true;
							SixthTurn();
							//Player3球のどれかがEnemyより近い場合は残りの球をEnemyが出す（PEPPEE）
						}
					}
					if (count2 == 1)
					{
						if (BPD1 > Enemy == true)
						{
							
							Trueplayer = true;//PEE→P
							FourthTurn();
						}
                        else 
						{
							
							Trueenemy = true;
							FourthTurn();//PEE→E
						}
					}
				}
				else
				{
					Enemy = BED1;
					if (count2 == 2)
					{
						if (Player > Enemy == true)
						{
							
							Trueplayer = true;
							FifthTurn();//PEPE→P
						}
						else
						{
							
							Trueenemy = true;//PEPE→E
							FifthTurn();
						}
					}
					if (count2 == 3)
					{
						if (Player > Enemy)
						{
							
							SceneManager.LoadScene("LoseScene");//Player3球の最短がEnemyよりも遠いときは負け確定（PEPPE）
						}
						else//Enemy>Player
						{
							
							Trueenemy = true;
							SixthTurn();//Player3球のどれかがEnemyより近い場合は残りの球をEnemyが出す（PEPPEE）
						}
					}
					if (count2 == 1)
					{
						if (BPD1 > Enemy == true)
						{
							
							Trueplayer = true;//PEE→P
							FourthTurn();
						}
						else
						{
							
							Trueenemy = true;
							FourthTurn();//PEE→E
						}
					}
				}
			}
		}

		if (thirdShot == true)
		{
			if (Prb3.IsSleeping())
			{
				BPD3 = Vector3.Distance(byutto.position, player3.transform.position);
				if (Player > BPD3 == true)
				{
					Player = BPD3;
					if (Player > BED1 == true)
					{
						
						SceneManager.LoadScene("LoseScene");//PEPPで負け確のとき
                    }
                    if(Player < BED1 == true && enemycount2==1)
                    {
						
						Trueenemy = true;
						Trueplayer = false;//PEPP→E
						FifthTurn();
                    }
					if (count2 == 3 && enemycount2 == 2 && thirdShot == true)//PEPEP→E
					{
						
						Trueenemy = true;
						SixthTurn();
					}
				}
				else//BPD3>Player
				{
					if (Player > BED1 == true)
					{
						
						SceneManager.LoadScene("LoseScene");//PEPPで負け確のとき
					}
					if (Player < BED1 == true && enemycount2 == 1)
					{
						
						Trueenemy = true;
						FifthTurn();
					}
					if (count2 == 3 && enemycount2 == 2)
					{
						
						Trueenemy = true;
						SixthTurn();
					}
				}
				if (count2 == 3 && enemycount2 == 3 && Erb3.IsSleeping())//双方投げ切り
				{
					if (Player > Enemy)
					{
						
						SceneManager.LoadScene("LoseScene");
					}
                    else
                    {
						ScoreCount();
						PlayerPrefs.SetInt("PS2", scorecount);
						SceneManager.LoadScene("WinScene2");
					}
				}
			}

		}

		if (thirdShotEnemy == true)
		{
			BED3 = Vector3.Distance(byutto.position, enemy3.transform.position);
			if (Erb3.IsSleeping())
			{
				
				if (count2 == 1 && enemycount2 == 3)
				{
					
					Trueplayer = true;//PEEE→P
					FifthTurn();
				}
				if (count2 == 2 && enemycount2 == 3)
				{
					
					Trueplayer = true;//PEEEP→P
					SixthTurn();
					if (count2 == 3 && Prb3.IsSleeping())
					{
						ScoreCount();
						PlayerPrefs.SetInt("PS2", scorecount);
						SceneManager.LoadScene("WinScene2");
					}
				}
				if (count2 == 3 && enemycount2 == 3)//双方投げ切り
				{
					if (Player > Enemy)
					{
						
						SceneManager.LoadScene("LoseScene");
					}
                    else
                    {
						ScoreCount();
						PlayerPrefs.SetInt("PS2", scorecount);
						SceneManager.LoadScene("WinScene2");
                    }
				}
			}
		}

	}
	void FirstTurn()
	{
		if (player1 != null && Prb1.IsSleeping())
		{
			BPD1 = Vector3.Distance(byutto.position, player1.transform.position);
			SecondTurn();
			firstShot = false;
		}

	}
	void SecondTurn()
	{
		ThrowingBall();
	}
	void ThirdTurn()
	{
		if (BPD1 > BED1 == true)
		{
			
			movePowerMeter = true;//PE→P
			DegreeDecision = true;
			shotbutton = true;
			button.SetActive(true);
			firstShotEnemy = false;
		}
		else
		{
			
			movePowerMeter = false;
			shotbutton = false;
			button.SetActive(false);

			ThrowingBall();
			firstShotEnemy = false;
		}
	}
	void FourthTurn()
	{
		if (Trueplayer == true)
		{
			
			if (count2 ==1 && enemycount2 == 2)
			{
				
				happyMiyuki = false;
			}
			movePowerMeter = true;
			DegreeDecision = true;
			button.SetActive(true);
			shotbutton = true;
			if(count2 == 2 && enemycount2 == 1)
            {
				
				secondShot = false;
            }
            
		}
		if (Trueenemy == true)
		{
			
			if (count2 == 2 && enemycount2 == 1)
			{
				
				secondShot = false;
			}
			movePowerMeter = false;
			button.SetActive(false);
			shotbutton = false;
			if (enemycount2 < 3) 
			{
				
				ThrowingBall(); 
			}
			
			if(count2 == 1 && enemycount2 == 3)
			{
				
				happyMiyuki = false;
			}
			Trueenemy = false;
		}
	}

		void FifthTurn()
		{
			if (Trueplayer == true)
			{
			
				if (count2 == 1 && enemycount2 == 3)
				{
				
				thirdShotEnemy = false;//PEPPE
				}
				if (count2 == 2 && enemycount2 == 2)
				{
				
					secondShot = false;//PEEP→P
					happyMiyuki = false;//PEPE→P
				}
				
			    movePowerMeter = true;
			DegreeDecision = true;
			button.SetActive(true);
				shotbutton = true;
			}

			if (Trueenemy == true)
			{
				
				if(count2 == 2 && enemycount2 == 2)
				{
				
					happyMiyuki = false;
					ThrowingBall();
				}

			    thirdShot = false;
			    movePowerMeter = false;
				shotbutton = false;
				button.SetActive(false);
			    if(enemycount2 < 2)
			    {
					
				    ThrowingBall();
					
			    }
				Trueenemy = false;
				
			}
		}
		void SixthTurn()
		{
			if (Trueplayer == true)
			{
				if (count2 == 2 && enemycount2 == 3)
				{
					
					secondShot = false;
					happyMiyuki = false;
					thirdShotEnemy = false;
				}
				
				movePowerMeter = true;
			DegreeDecision = true;
			button.SetActive(true);
				shotbutton = true;
			}
			if (Trueenemy == true)
			{
				if(count2 == 3 && enemycount2 == 2)
				{
				
				thirdShot = false;
				}
			    happyMiyuki = false;
			    movePowerMeter = false;
				shotbutton = false;
				button.SetActive(false);
				ThrowingBall();
			}
		}

		void MovePowerMeter()
		{
		// 飛行中フラグがfalseの時にメーターを上下させる
		
		if (isFlying)
			{
				return;
			}

			// 境界値の定義
			float boundaryValue = 0f;

			// forceMagnitudeにmeterSpeedの値を加えていってメーターを上下させる
			if (isMeterIncreasing)
			{
				PowerMeterSlider.value += meterSpeed;
				boundaryValue = PowerMeterSlider.maxValue;

			}
			else
			{
				PowerMeterSlider.value -= meterSpeed;
				boundaryValue = PowerMeterSlider.minValue;
			}

			// 境界値になったら少し止めた後にメーターを逆向きに動かす
			if (Mathf.Approximately(PowerMeterSlider.value, boundaryValue))
			{
				WaitAtBoundaryValue();
			}

			// スライダーの現在値をforceMagnitudeに格納
			forceMagnitude = PowerMeterSlider.value;
		}


		public void ShotButton()
		{
		DegreeImage.SetActive(false);
		count2 += 1;
			if (count2 == 1)
			{
				if (shotbutton == true)
				{
					Instantiate(Boostsound);
					movePowerMeter = false;

				   
					player1 = Instantiate(Ball2, this.transform.position+this.transform.forward, Quaternion.Euler(new Vector3(0f, 45, 0f))) as GameObject;
					Prb1 = player1.GetComponent<Rigidbody>();
					firstShot = true;
					button.SetActive(false);
				}
				shotbutton = false;
			}
			if (count2 == 2)
			{
			
			if (shotbutton == true)
				{
				Instantiate(Boostsound);
				movePowerMeter = false;

				
				player2 = Instantiate(Ball2, this.transform.position, Quaternion.Euler(new Vector3(0f,45,0f))) as GameObject;
					Prb2 = player2.GetComponent<Rigidbody>();
					secondShot = true;
					button.SetActive(false);
				}
				shotbutton = false;
			}
			if (count2 == 3)
			{
				if (shotbutton == true)
				{
				Instantiate(Boostsound);
				movePowerMeter = false;

				
				player3 = Instantiate(Ball2, this.transform.position, Quaternion.Euler(new Vector3(0f, 45, 0f))) as GameObject;
					Prb3 = player3.GetComponent<Rigidbody>();
					thirdShot = true;
					button.SetActive(false);
				}
				shotbutton = false;
			}
		}
		
		private void ThrowingBall()
		{
		
			
			if (enemycount2 == 0)
			{
			    enemycount2 += 1;
			    float y = Random.Range(3.0f, 15.0f);
				float z = Random.Range(3.0f, 15.0f);
				Vector3 force = new Vector3(0.0f, y, z);

				float x = Random.Range(-3.5f,3.5f);
				enemy1 = Instantiate(EnemyBall1, new Vector3(x,3.07f,-15.52f), Quaternion.identity) as GameObject;
				Erb1 = enemy1.GetComponent<Rigidbody>();
				Erb1.AddForce(force, ForceMode.Impulse);
				
				firstShotEnemy = true;
			    ButtonCount2 += 1;
			}
			if (enemycount2 == 1 && Erb1.IsSleeping())
			{
				enemycount2 += 1;
				float y = Random.Range(3.0f, 15.0f);
				float z = Random.Range(3.0f, 15.0f);
				Vector3 force = new Vector3(0.0f, y, z);

				float x = Random.Range(-3.5f, 3.5f);
				enemy2 = Instantiate(EnemyBall1, new Vector3(x,3.07f,-15.52f), Quaternion.identity) as GameObject;
				Erb2 = enemy2.GetComponent<Rigidbody>();
				Erb2.AddForce(force, ForceMode.Impulse);
				
				happyMiyuki = true;
			}
			if (enemycount2 == 2 && Erb2.IsSleeping())
			{
				enemycount2 += 1;
				float y = Random.Range(8.0f, 10.0f);
				float z = Random.Range(8.0f, 15.0f);
				Vector3 force = new Vector3(0.0f, y, z);

				float x = Random.Range(-3.5f, 3.5f);
				enemy3 = Instantiate(EnemyBall1, new Vector3(x, 3.07f, -15.52f), Quaternion.identity) as GameObject;
				Erb3 = enemy3.GetComponent<Rigidbody>();
				Erb3.AddForce(force, ForceMode.Impulse);
				
				thirdShotEnemy = true;
			}

		}
		void WaitAtBoundaryValue() {
			// 前のフレームが呼ばれて、処理が完了するまでにかかった時間を加算
			waitTime += Time.deltaTime;

			// waitTimeがdelayTimeを超えたら増加フラグの反転
			if (waitTime >= delayTime)
			{
				isMeterIncreasing = !isMeterIncreasing;
				waitTime = 0f;
			}
		}

		public void DesideBUtton()
    {
		ButtonCount2 += 1;
		DegreeDecision = false;
		PushButton = true;

		Instantiate(Stopsound);
	}
	void Move()
    {
        if (DegreeDecision == true)
        {
			speed += Time.deltaTime * 100 * fugo;
			this.transform.rotation = Quaternion.Euler(0, speed, 0);
		}
	

		if (touch == true)
		{
			fugo = -1;
			
		}
		else
		{
			fugo = 1;
		}

		if (this.transform.localEulerAngles.y > 40 && this.transform.localEulerAngles.y < 120)
		{
			touch = true;
		}
		if (this.transform.localEulerAngles.y < 320 && this.transform.localEulerAngles.y > 300)
		{
			touch = false;
		}
	}
	public void ResetButton()
    {
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene("StartScene");
    }
	void ScoreCount()
	{
		if (Enemy > BED3 == true)
		{
			Enearest = BED3;
			if (Enearest > BPD1 == true)
			{
				scorecount += 1;
			}
			if (Enearest > BPD2)
			{
				scorecount += 1;
			}
			if (Enearest > BPD3 == true)
			{
				scorecount += 1;
			}
		}
		else
		{
			Enearest = Enemy;
			if (Enearest > BPD1 == true)
			{
				scorecount += 1;
			}
			if (Enearest > BPD2)
			{
				scorecount += 1;
			}
			if (Enearest > BPD3 == true)
			{
				scorecount += 1;
			}
		}
	}
} 

