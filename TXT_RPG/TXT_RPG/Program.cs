namespace TXT_RPG
{
    internal class Program
    {
        static int GetIntInput()
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

        class Shop
        {
            public void Run()
            {

            }
        }

        class Inventory
        {
            public void Run()
            {

            }

            void WriteInventory() { }
        }

        class Status
        {
            public int level = 1;
            public string name = "Chad";
            public string job = "전사";
            public int atk = 10;
            public int def = 5;
            public int hp = 100;
            public int gold = 1500;

            public void Run()
            {
                Console.Clear();

                WriteStatus();
                ChangeScene();
            }

            void WriteStatus()
            {
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("Lv. 0{0}", level);
                Console.WriteLine("{0}({1})", name, job);
                Console.WriteLine("공격력: {0}", atk);
                Console.WriteLine("방어력: {0}", def);
                Console.WriteLine("체 력 : {0}", hp);
                Console.WriteLine("Gold: {0} G", gold);
                Console.WriteLine();
                Console.WriteLine("0.나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
            }

            void ChangeScene()
            {
                while (true)
                {
                    int num = GetIntInput();

                    switch (num)
                    {
                        case 0:
                            StartScene startScene = new StartScene();
                            startScene.Run();
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
        }

        class StartScene
        {
          
            public void Run()
            {
                Console.Clear();
                
                WriteStartScene();
                ChangeScene();
            }
            void WriteStartScene()
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1.상태 보기");
                Console.WriteLine("2.인벤토리");
                Console.WriteLine("3.상점");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
            }

            void ChangeScene()
            {
                while (true)
                {
                    int num = GetIntInput();

                    switch (num)
                    {
                        case 1:
                            Status status = new Status();
                            status.Run();
                            return;
                        case 2:
                            Inventory inventory = new Inventory();
                            inventory.Run();
                            return;
                        case 3:
                            Shop shop = new Shop();
                            shop.Run();
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            StartScene startScene = new StartScene();
            startScene.Run();
        }
    }
}
