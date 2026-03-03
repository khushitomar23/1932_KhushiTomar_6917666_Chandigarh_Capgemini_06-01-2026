namespace GameCharacterSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior w = new Warrior("Khushi");
            Mage m = new Mage("Jaideep");
            Archer a = new Archer("Diksha");

            Skill s1 = new Skill("Power Strike");
            Inventory inv = new Inventory();

            Console.WriteLine("---- Game Battle ----");
            w.Attack();
            m.Attack();
            a.Attack();

            w.LevelUp();
            s1.UseSkill();
            inv.ShowItems();

            w.ShowStatus();
        }
    }
}
