namespace TXT_RPG
{
    class Item
    {
        public string? name;
        public string? stat;
        public int statValue;
        public string? description;
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
}


