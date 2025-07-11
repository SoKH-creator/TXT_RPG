namespace TXT_RPG
{
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
                int num = InputHelper.GetIntInput();

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
                string selectedStat = item.stat ?? "";    // CS8600
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
}


