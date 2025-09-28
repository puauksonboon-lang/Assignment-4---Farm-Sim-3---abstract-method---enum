using UnityEngine;

public enum FoodType
{
    SitrusBerry,   
    PomegBerry,    
    GrepaBerry,    
    RottenFood,    
    AnimalFood     
}


public abstract class Animal : MonoBehaviour
{
    // Fields
    private string name;
    private int hunger;
    private int happiness;

    // Properties
    public string Name { get => name; private set => name = string.IsNullOrEmpty(value) ? "Animal" : value; }
    public int Hunger { get => hunger; private set => hunger = Mathf.Clamp(value, 0, 100); }
    public int Happiness { get => happiness; private set => happiness = Mathf.Clamp(value, 0, 100); }
    public FoodType PreferedFood { get; private set; }

    // Init
    public virtual void Init(string newName, FoodType fav)
    {
        Name = newName;
        Hunger = 50;
        Happiness = 50;
        PreferedFood = fav;
    }

    // Adjust
    public void AdjustHunger(int adjust) => Hunger = Mathf.Clamp(Hunger + adjust, 0, 100);
    public void AdjustHappiness(int adjust) => Happiness = Mathf.Clamp(Happiness + adjust, 0, 100);

    // Feed (Overloading)
    public void Feed(int amount)
    {
        AdjustHunger(-amount);
        AdjustHappiness(amount / 2);
        Debug.Log($"{Name} was fed {amount}. Hunger:{Hunger}, Happiness:{Happiness}");
    }

    public void Feed(FoodType type, int amount)
    {
       

        if (type == FoodType.RottenFood)
        {
            AdjustHappiness(-20);
            Debug.Log($"{Name} ate Rotten Food! Happiness:{Happiness}");
            return;
        }

        if (type == FoodType.AnimalFood)
        {
            Feed(amount);
            return;
        }

        AdjustHunger(-amount);

        if (type == PreferedFood)
        {
            AdjustHappiness(+15);
            Debug.Log($"{Name} enjoyed favourite food ({type}). Happiness:{Happiness}");
        }
        else
        {
            AdjustHappiness(amount / 2);
            Debug.Log($"{Name} ate non-preferred food ({type}). Happiness:{Happiness}");
        }
    }

    // GetStatus
    public void GetStatus()
    {
        Debug.Log($"[{GetType().Name}] Name:{Name}, Hunger:{Hunger}, Happiness:{Happiness}, Fav:{PreferedFood}");
    }

    // Abstract Methods
    public abstract void MakeSound();
    public abstract string Produce();
}

