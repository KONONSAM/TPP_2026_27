using System.Security;
using System.Collections.Generic;

class Character
{
    string name;
    int hp;
    int power;
    static int count = 0;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public int Hp
    {
        get
        {
            return this.hp;
        }
        set
        {
            this.hp = value;
        }
    }

    public int Power
    {
        get
        {
            return this.power;
        }
        set
        {
            this.power = value;
        }
    }

    public Character(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        count +=1;
    }
    public virtual void Attack(Character target)
    {
        target.TakeDamage(power);
        Console.WriteLine($"{Name} успешно атаковал {target.Name}");
    }

    public void TakeDamage(int damage)
    {
        this.hp -= damage;
    }

    public bool IsAlive()
    {
        if(Hp > 0){
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        return $"{Name} (HP: {Hp})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Character other)
        {
            return this.name == other.name && this.hp == other.hp && this.power == other.power;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, hp, power);
    }

    public static int HowMany()
    {
        return count;
    }

    public static void IsValidStats(int hp, int power)
    {
        if(hp>0 && power > 0)
        {
            Console.WriteLine("У персонажа всё в порядке");
        }
        else
        {
            Console.WriteLine("У персонажа отрицательные характеристики, либо равны 0");
        }
    }
}


class Player: Character
{
    public Player(string name, int hp, int power): base(name, hp, power)
    {
        
    }

    public override void Attack(Character target)
    {
        target.TakeDamage(Power);
        Console.WriteLine($"{Name} с разворота в голову! атаковал {target.Name}");
    }
        
}

class Enemy: Character
{
    public Enemy(string name, int hp, int power): base(name, hp, power)
    {
        
    }

    public override void Attack(Character target)
    {
        target.TakeDamage(Power);
        Console.WriteLine($"{Name} ..исподтишка.. атаковал {target.Name}");
    }
}

class Program
{
    static void Main()
    {
        List<Character> characters = new List<Character>();
        
        Player player = new Player("Игрок", 5, 1);
        Enemy enemy = new Enemy("Враг", 2, 1);
        characters.Add(player);
        characters.Add(enemy);
        Console.WriteLine($"НА АРЕНЕ БУДУТ ДРАТЬСЯ {characters[0]} и {characters[1]}");
        Console.WriteLine($"{characters[0].Name}: {characters[0].Hp} HP и {characters[0].Power} мощи");
        Console.WriteLine($"{characters[1].Name}: {characters[1].Hp} HP и {characters[1].Power} мощи");
        Console.WriteLine("Бой начинается!");

        while (characters[0].IsAlive() && characters[1].IsAlive())
        {
            characters[0].Attack(characters[1]);
            Console.WriteLine(characters[1]);
            if (!characters[1].IsAlive())
            {
                Console.WriteLine($"{characters[1].Name} погиб!");
                break;
            }

            characters[1].Attack(characters[0]);
            Console.WriteLine(characters[0]);
            if (!characters[0].IsAlive())
            {
                Console.WriteLine($"{characters[0].Name} погиб!");
                break;
            }
        }
    }
}