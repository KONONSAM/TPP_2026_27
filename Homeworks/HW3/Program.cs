using System.Security;

class Character
{
    string name;
    int hp;
    int power;
    static int count = 0;

    public Character(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        count +=1;
    }
    public void Attack(Character target)
    {
        target.hp -= this.power;
        Console.WriteLine($"{this.name} успешно атаковал {target.name}");
    }

    public void GetStatus()
    {
        Console.WriteLine($"{this.name}: {this.hp} HP");
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
        
}

class Enemy: Character
{
    public Enemy(string name, int hp, int power): base(name, hp, power)
    {
        
    }
}

class Program
{
    static void Main()
    {
        Player player = new Player("Игрок", 5, 1);
        Enemy enemy = new Enemy("Враг", 2, 1);

        player.Attack(enemy);
        enemy.Attack(player);
        player.GetStatus();
        enemy.GetStatus();
    }
}