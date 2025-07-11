namespace TXT_RPG
{
    class InventoryScene
    {
        List<Item>? items;

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
                int num = InputHelper.GetIntInput();

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
            foreach (Item item in items)    // CS8602
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
                int num = InputHelper.GetIntInput();

                if (num == 0)
                {
                    Run();
                    return;
                }
                else if (num >= 1 && num <= items.Count())  // CS8604
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
}