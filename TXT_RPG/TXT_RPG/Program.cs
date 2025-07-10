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

        class Item
        {
            public string name;
            public string stat;
            public int statValue;
            public string description;
            public bool isEquipped;
            public bool isHave;
        }

        static class ItemDB
        {
            public static List<Item> items = new List<Item>()
            {
                new Item() { name = "무쇠갑옷", stat = "방어력", statValue = 5, description = "무쇠로 만들어져 튼튼한 갑옷입니다.", isEquipped = true, isHave = true },
                new Item() { name = "스파르타의 창", stat = "공격력", statValue = 7, description = "스파르타의 전사들이 사용했다는 전설의 창입니다.", isEquipped = true, isHave = true },
                new Item() { name = "낡은 검", stat = "공격력", statValue = 2, description = "쉽게 볼 수 있는 낡은 검 입니다.", isEquipped = false, isHave = true }
            };
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
                Console.Clear();

                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine();

                WriteCurrentInventory();

                Console.WriteLine("1.장착 관리");
                Console.WriteLine("0.나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                ChageScene();
            }

            void WriteCurrentInventory()
            {
                // 아이템 DB 아이템 중 가진 아이템만 불러오기
                List<Item> items = (from item in ItemDB.items
                                   where item.isHave == true
                                   select item).ToList();

                // 보유 중인 아이템 목록 작성
                foreach (Item item in items)
                {
                    string equipMark = item.isEquipped ? "[E]" : "";
                    Console.WriteLine($"- {equipMark}{item.name}\t| {item.stat} +{item.statValue} | {item.description}");
                }
            }

            void ChageScene()
            {
                while (true)
                {
                    int num = GetIntInput();

                    switch (num)
                    {
                        case 1:
                            ManageEquipment();
                            return;
                        case 2:
                            StartScene startScene = new StartScene();
                            startScene.Run();
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }

                void ManageEquipment()
                {

                }
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
}
