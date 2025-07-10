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
            public int gold;
        }

        static class ItemDB
        {
            public static List<Item> items = new List<Item>()
            {
                new Item() { name = "무쇠갑옷", stat = "방어력", statValue = 9, description = "무쇠로 만들어져 튼튼한 갑옷입니다.",
                    isEquipped = false, isHave = true, gold = 1800 },
                new Item() { name = "스파르타의 창", stat = "공격력", statValue = 7, description = "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                    isEquipped = false, isHave = true, gold = 2100 },
                new Item() { name = "낡은 검", stat = "공격력", statValue = 2, description = "쉽게 볼 수 있는 낡은 검 입니다.",
                    isEquipped = false, isHave = true, gold = 600 },
                new Item() { name = "수련자 갑옷", stat = "방어력", statValue = 5, description = "수련에 도움을 주는 갑옷입니다.",
                    isEquipped = false, isHave = false, gold = 1000 },
                new Item() { name = "청동 도끼", stat = "공격력", statValue = 5, description = "어디선가 사용됐던거 같은 도끼입니다.",
                    isEquipped = false, isHave = false, gold = 1500 },
                new Item() { name = "스파르타의 갑옷", stat = "방어력", statValue = 15, description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                    isEquipped = false, isHave = false, gold = 3500 }
            };
        }
        class Player
        {

            // 싱글톤의 개념과 작성에 아직 익숙하지 않아서 chatGPT의 도움을 받았습니다.
            // 처음에는 Main에서 처음 실행되는 VillageMenu에서 new Player를 만들어서 유지하는 방식을 사용하려고 했지만,
            // 오히려 저 방식이 더 구현할 때 구조가 복잡해 질 것 같아,
            // 이 부분은 chatGPT의 조언을 따라 싱글톤 패턴으로 변경하기로 했습니다.
            private static Player instance;
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
        class Shop
        {
            List<Item> shopItems = new List<Item>();

            public void Run()
            {
                Console.Clear();
                
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();

                ShowUserGold();
                ShowItemList();

                Console.WriteLine();
                Console.Write("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                Buy();
            }

            void ShowUserGold()
            {
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{Player.Instance.gold} G");
                Console.WriteLine();
            }

            void ShowItemList()
            {
                shopItems = new List<Item>(); // 상품 목록 초기화

                // 상품 정렬           
                shopItems.AddRange((from item in ItemDB.items      // 아이템 데이터 배이스에서
                                    where item.stat == "방어력"     // 방어구 상품부터
                                    orderby item.statValue          // 스텟 순으로
                                    select item).ToList());
                shopItems.AddRange((from item in ItemDB.items
                                    where item.stat == "공격력"
                                    orderby item.statValue
                                    select item).ToList());

                Console.WriteLine("[아이템 목록]");
                // 상품 진열
                int i = 0;
                string price;
                foreach (Item item in shopItems)
                {
                    i++;
                    price = item.isHave ? "구매완료" : $"{item.gold} G";
                    Console.WriteLine($"- {i} {item.name}\t| {item.stat} +{item.statValue}  | {item.description}\t | {price}");
                }

            }

            void Buy()
            {
                while (true)
                {
                    int num = GetIntInput();

                    if (num == 0)
                    {
                        VillageMenu villageMenu = new VillageMenu();
                        villageMenu.Run();
                        return;
                    }
                    else if (num >= 1 && num <= shopItems.Count())
                    {
                        Item selectedItem = shopItems[num - 1];

                        if (selectedItem.isHave == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                            Console.ReadLine(); // 확인 대기
                            Run();  // 화면 재구성
                            return;
                        }
                        else
                        {
                            if (Player.Instance.gold >= selectedItem.gold)
                            {
                                Console.WriteLine("구매를 완료했습니다.");
                                Player.Instance.gold -= selectedItem.gold;  // 재화 감소
                                selectedItem.isHave = true; // 안밴토리에 아이템 추가
                                Run();  // 화면 재구성
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Gold가 부족합니다.");
                                Console.ReadLine(); // 확인 대기
                                Run();  // 화면 재구성
                                return;
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                    }
                }
            }
        }
        class StatusScene
        {
            public int atkBonus;
            public int defBonus;

            public void Run()
            {
                StatusUpdate();

                Console.Clear();

                WriteStatus();
                ChangeScene();
            }

            void WriteStatus()
            {
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine($"Lv. 0{Player.Instance.level}");
                Console.WriteLine($"{Player.Instance.name}({Player.Instance.job})");
                Console.WriteLine($"공격력: {Player.Instance.atk + atkBonus} (+{atkBonus})");
                Console.WriteLine($"방어력: {Player.Instance.def + defBonus} (+{defBonus})");
                Console.WriteLine($"체 력 : {Player.Instance.hp}");
                Console.WriteLine($"Gold: {Player.Instance.gold} G");
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
                            VillageMenu villageMenu = new VillageMenu();
                            villageMenu.Run();
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }

            void StatusUpdate()
            {
                atkBonus = 0;
                defBonus = 0;

                // 장착 아이템 목록
                List<Item> equippeditems = (from item in ItemDB.items
                                            where item.isEquipped == true
                                            select item).ToList();

                foreach (Item item in equippeditems)
                {
                    string selectedStat = item.stat;
                    switch (selectedStat)
                    {
                        case "공격력":
                            atkBonus += item.statValue;
                            break;
                        case "방어력":
                            defBonus += item.statValue;
                            break;
                        default:
                            Console.WriteLine("장비에 오류가 발생했습니다.");
                            Console.WriteLine("인벤토리 화면으로 이동합니다.");
                            InventoryScene inventory = new InventoryScene();
                            inventory.Run();
                            return;
                    }
                }
            }
        }
        class InventoryScene
        {
            List<Item> items;

            public void Run()
            {
                // 아이템 DB 아이템 중 가진 아이템만 불러오기
                items = (from item in ItemDB.items
                         where item.isHave == true
                         select item).ToList();


                Console.Clear();

                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine();

                WriteCurrentInventory();

                Console.WriteLine();
                Console.WriteLine("1.장착 관리");
                Console.WriteLine("0.나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                ChangeScene();
            }

            void ChangeScene()
            {
                while (true)
                {
                    int num = GetIntInput();

                    switch (num)
                    {
                        case 1:
                            RunEquipmentManage();
                            return;
                        case 0:
                            VillageMenu villageMenu = new VillageMenu();
                            villageMenu.Run();
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }

            void WriteCurrentInventory()
            {
                
                // 보유 중인 아이템 목록 작성
                foreach (Item item in items)
                {
                    string equipMark = item.isEquipped ? "[E]" : "";
                    Console.WriteLine($"- {equipMark}{item.name}\t| {item.stat} +{item.statValue} | {item.description}");
                }
            }

            void RunEquipmentManage()
            {
                // 아이템 DB 아이템 중 가진 아이템만 불러오기
                items = (from item in ItemDB.items
                         where item.isHave == true
                         select item).ToList();

                Console.Clear();

                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");

                int i = 0;
                foreach (Item item in items)
                {
                    i++;
                    string equipMark = item.isEquipped ? "[E]" : "";
                    Console.WriteLine($"- {i} {equipMark}{item.name}\t| {item.stat} +{item.statValue} | {item.description}");
                }

                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                EquipmentManage();
            }

            void EquipmentManage()
            {
                while (true)
                {
                    int num = GetIntInput();

                    if (num == 0)
                    {
                        Run();
                        return;
                    }
                    else if (num >= 1 && num <= items.Count())
                    {
                        Item selectedItem = items[num - 1];
                        selectedItem.isEquipped = !selectedItem.isEquipped;
                        RunEquipmentManage();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                    }
                }
            }
        }
        class VillageMenu
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
                            StatusScene status = new StatusScene();
                            status.Run();
                            return;
                        case 2:
                            InventoryScene inventory = new InventoryScene();
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
            VillageMenu villageMenu = new VillageMenu();
            villageMenu.Run();
        }

    }

}


