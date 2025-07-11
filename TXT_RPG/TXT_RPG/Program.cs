namespace TXT_RPG
{

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


