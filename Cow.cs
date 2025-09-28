using UnityEngine;

public class Cow : Animal
{
    public float Milk { get; private set; }

    public override void Init(string newName, FoodType fav = FoodType.Hay)
    {
        base.Init(newName, fav);
        Milk = 0;
    }

    public override void MakeSound()
    {
        AdjustHappiness(+2);
        Debug.Log($"{Name} Moo Moo! (Happiness:{Happiness})");
    }

    public override string Produce()
    {
        float produced = 0;
        if (Happiness > 70)
        {
            produced = Happiness / 10f;
            Milk += produced;
        }
        return $"{Name} produced {produced} milk. Total milk: {Milk}";
    }
}