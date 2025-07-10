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
        }

        class Status
        {
            public void Run()
            {

            }
        }

        class StartScene
        {
          
            public void Run()
            {
                WriteStartScene();
                ChangeScene();
            }
            public void WriteStartScene()
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

            public void ChangeScene()
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
