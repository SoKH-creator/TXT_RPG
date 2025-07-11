namespace TXT_RPG
{

    class Player
    {
        private static Player? instance = null;     // CS8618
        public static Player Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player();
                return instance;
            }
        }

        public int level = 1;
        public string name = "James";
        public string job = "전사";
        public int atk = 10;
        public int def = 5;
        public int hp = 100;
        public int gold = 1500;
    }

    class InputHelper
    {
        static public int GetIntInput()
        {
            while (true)
            {
                int input;
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
    }

    internal class Program
    {      
        static void Main(string[] args)
        {
            VillageMenu villageMenu = new VillageMenu();
            villageMenu.Run();
        }
    }
}


