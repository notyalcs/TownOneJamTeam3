using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public List<Constants.AlienTypes> units;
    public float trainHP;
    public float trainSpeed;
    public float trainArmour;
    public int upgradePoints;
    public float currentMoney;
    public List<Bonus> bonuses;

    private void Awake() {
        GameObject[] managers = GameObject.FindGameObjectsWithTag("GameManager");
        if (managers.Length == 0) {
            units.Add(Constants.AlienTypes.HAMSTER);
            trainHP = Constants.StartHP;
            trainSpeed = Constants.StartSpeed;
            trainArmour = Constants.StartArmour;
            upgradePoints = Constants.StartUpgrades;
            currentMoney = Constants.StartMoney;
            bonuses = new List<Bonus>();
            bonuses.Add(new Bonus(Constants.AlienTypes.TRAIN, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f));
            bonuses.Add(new Bonus(Constants.AlienTypes.HAMSTER, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f));
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addUnit(Constants.AlienTypes newUnit) {
        units.Add(newUnit);
        bonuses.Add(new Bonus(newUnit, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f));
    }

    public void updateHP(float newHP) {
        trainHP = newHP;
    }

    public void updateSpeed(float newSpeed) {
        trainSpeed = newSpeed;
    }

    public void updateArmour(float newArmour) {
        trainArmour = newArmour;
    }

    public void instantiatePlayer() {
        GameObject.Instantiate(player);
    }

    public class Bonus
    {
        public Constants.AlienTypes unitType;
        public float healthBonus;
        public float armourBonus;
        public float speedBonus;
        public float attackDamageBonus;
        public float attackSpeedBonus;
        public float attackRangeBonus;
        public float cooldownBonus;
        public float costBonus;

        public Bonus(Constants.AlienTypes unitType, float healthBonus, float armourBonus, float speedBonus, float attackDamageBonus, float attackSpeedBonus, float attackRangeBonus, float cooldownBonus, float costBonus) {
            this.unitType = unitType;
            this.healthBonus = healthBonus;
            this.armourBonus = armourBonus;
            this.speedBonus = speedBonus;
            this.attackDamageBonus = attackDamageBonus;
            this.attackSpeedBonus = attackSpeedBonus;
            this.attackRangeBonus = attackRangeBonus;
            this.cooldownBonus = cooldownBonus;
            this.costBonus = costBonus;
        }
    }
}
