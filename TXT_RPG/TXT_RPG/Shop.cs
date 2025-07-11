namespace TXT_RPG
{
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
                int num = InputHelper.GetIntInput();

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
}


