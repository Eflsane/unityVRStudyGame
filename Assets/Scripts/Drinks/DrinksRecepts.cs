using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinksRecepts : MonoBehaviour
{
    public static DrinksRecepts instance;
    
    [SerializeField]
    private Dictionary<DrinkType, List<DrinkType>> _recepts;

    [SerializeField]
    private List<Sprite> _receptsImages;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);

        ReceiptsCreator();
    }

    private void ReceiptsCreator()
    {
        _recepts = new Dictionary<DrinkType, List<DrinkType>>();
        List<DrinkType> newRecept = new List<DrinkType>();

        newRecept.Add(DrinkType.Vodka);
        _recepts.Add(DrinkType.Vodka,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Rum);
        _recepts.Add(DrinkType.Rum,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Sambuca);
        newRecept.Add(DrinkType.Tequila);
        newRecept.Add(DrinkType.Absent);
        newRecept.Add(DrinkType.BlueCuraCao);
        newRecept.Add(DrinkType.IrishCream);
        _recepts.Add(DrinkType.Clouds,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Gin);
        newRecept.Add(DrinkType.Proseco);
        newRecept.Add(DrinkType.LavanderBitter);
        newRecept.Add(DrinkType.SugarSyrup);
        newRecept.Add(DrinkType.Lemon);
        newRecept.Add(DrinkType.Ice);
        _recepts.Add(DrinkType.CloudsInTrausers,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Vodka);
        newRecept.Add(DrinkType.Proseco);
        newRecept.Add(DrinkType.SugarSyrup);
        newRecept.Add(DrinkType.Laim);
        newRecept.Add(DrinkType.Strawberry);
        newRecept.Add(DrinkType.Ice);
        _recepts.Add(DrinkType.Haeven,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Mezgal);
        newRecept.Add(DrinkType.Picon);
        newRecept.Add(DrinkType.GingerSyrup);
        newRecept.Add(DrinkType.Laim);
        newRecept.Add(DrinkType.Orange);
        _recepts.Add(DrinkType.DarkSideOfTheMoon,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Vodka);
        newRecept.Add(DrinkType.Lemon);
        newRecept.Add(DrinkType.Rum);
        _recepts.Add(DrinkType.Astranaut,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Mint);
        newRecept.Add(DrinkType.Lemon);
        newRecept.Add(DrinkType.Tequila);
        _recepts.Add(DrinkType.MexicanAstranaut,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Rum);
        newRecept.Add(DrinkType.Laim);
        newRecept.Add(DrinkType.Ice);
        _recepts.Add(DrinkType.Space,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.RumGold);
        newRecept.Add(DrinkType.MapleSyrup);
        newRecept.Add(DrinkType.Laim);
        newRecept.Add(DrinkType.AppleJuice);
        newRecept.Add(DrinkType.CarrotJuice);
        _recepts.Add(DrinkType.AboveTheClouds,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Vodka);
        newRecept.Add(DrinkType.TripleSec);
        newRecept.Add(DrinkType.Cranberry);
        newRecept.Add(DrinkType.Laim);
        newRecept.Add(DrinkType.Lemon);
        _recepts.Add(DrinkType.Cosmopolitan,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Sambuca);
        newRecept.Add(DrinkType.Mint);
        newRecept.Add(DrinkType.Laim);
        _recepts.Add(DrinkType.Stratosphere,
            newRecept
            );

        newRecept = new List<DrinkType>();
        newRecept.Add(DrinkType.Vodka);
        newRecept.Add(DrinkType.BlueCuraCao);
        newRecept.Add(DrinkType.Sprite);
        newRecept.Add(DrinkType.Ananas);
        _recepts.Add(DrinkType.BlueLagoon,
            newRecept
            );
    }

    public bool CheckWithRecepts(DrinkType drinkTypeOrdered, List<DrinkType> givenDrink)
    {
        foreach(DrinkType item in _recepts[drinkTypeOrdered])
        {
            if (givenDrink.Find((x) => x == item) == DrinkType.Null)
                return false;
        }
        return true;
    }

    public Sprite GetDrinkImage(DrinkType drink)
    {
        return _receptsImages[(int)drink];
    }
}
