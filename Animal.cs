using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    //Encapsulation
    private string name;
    public string Name { get => name; private set => name = string.IsNullOrEmpty(value) ? "Animal" : value; }

    private int hunger;
    public int Hunger { get => hunger; private set => hunger = Mathf.Clamp(value, 0, 100); }

    private int happiness;
    public int Happiness { get => happiness; private set => happiness = Mathf.Clamp(value, 0, 100); }

    public FoodType PreferedFood { get; private set; }

    //Init
    public virtual void Init(string newName, FoodType fav)
    {
        Name = newName;
        Hunger = 50;
        Happiness = 50;
        PreferedFood = fav;
    }

    //Adjust Methods
    public void AdjustHunger(int adjust) => Hunger = Mathf.Clamp(Hunger + adjust, 0, 100);
    public void AdjustHappiness(int adjust) => Happiness = Mathf.Clamp(Happiness + adjust, 0, 100);

    //Feed Overloading
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
            Debug.Log($"{Name} enjoyed its favourite food! Happiness:{Happiness}");
        }
        else
        {
            AdjustHappiness(amount / 2);
            Debug.Log($"{Name} ate but didn't prefer this. Happiness:{Happiness}");
        }
    }

    //GetStatus
    public void GetStatus()
    {
        Debug.Log($"[{GetType().Name}] Name:{Name}, Hunger:{Hunger}, Happiness:{Happiness}, Fav:{PreferedFood}");
    }

    //Abstract Methods
    public abstract void MakeSound();
    public abstract string Produce();
}


